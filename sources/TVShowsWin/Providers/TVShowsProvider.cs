// -----------------------------------------------------------------------
// <copyright file="TVShowsProvider.cs" company="TVShowsWin">
// GNU General Public License see http://www.gnu.org.
// </copyright>
// -----------------------------------------------------------------------

namespace TVShowsWin.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using TVShowsWin.Common.Cache.Generic;
    using TVShowsWin.Common.Extensions;
    using TVShowsWin.Providers.Model;

    /// <summary>
    /// TVShows Shows Provider
    /// </summary>
    public sealed class TVShowsProvider : ITVShowsProvider
    {
        /// <summary>
        /// The show list feed
        /// </summary>
        private static readonly string ShowListFeed = "http://tvshowsapp.com/showlist/showlist.xml";

        /// <summary>
        /// The Cache ID
        /// </summary>
        private static readonly Guid CacheId = Guid.Parse("57051126-7898-4741-8648-79D7561A327C");

        /// <summary>
        /// The shows field
        /// </summary>
        private Cache<TVShowsShow, int> shows;

        /// <summary>
        /// Initializes a new instance of the <see cref="TVShowsProvider" /> class.
        /// </summary>
        public TVShowsProvider()
        {
            this.shows = new Cache<TVShowsShow, int>(show => show.TVDId, CacheId);
        }

        /// <summary>
        /// Gets the shows.
        /// </summary>
        /// <param name="max">The max.</param>
        /// <param name="page">The page.</param>
        /// <returns>
        /// The shows.
        /// </returns>
        public async Task<IList<TVShowsShow>> GetShows(int max = int.MaxValue, int page = 0)
        {
            if ((DateTime.Now - this.shows.Timestamp).TotalMinutes > 60)
            {
                XDocument xmlDocument = await ShowListFeed.ToUri().GetXDocument();

                this.shows.Invalidate();

                foreach (var element in xmlDocument.Descendants("show"))
                {
                    TVShowsShow show = new TVShowsShow();
                    show.Name = element.Element("name").Value;
                    show.TVDId = int.Parse(element.Element("tvdbid").Value);
                    show.Added = DateTime.ParseExact(
                                    element.Element("added").Value,
                                    "ddd MMM d HH:mm:ss zzzzz yyyy",
                                    new CultureInfo("en-US"));

                    IEnumerable<XElement> mirrors = element.Descendants("mirror");

                    foreach (var mirror in mirrors)
                    {
                        show.Mirrors.Add(new Uri(mirror.Value));
                    }

                    this.shows.AddOrUpdate(show);
                }

                this.shows.Save();
            }

            return this.shows.Items.Skip(max * page).Take(max).ToList();
        }

        /// <summary>
        /// Gets the episodes of a show.
        /// </summary>
        /// <param name="mirror">The mirror of the show.</param>
        /// <returns>The episodes of the show</returns>
        public async Task<IList<TVShowsEpisode>> GetEpisodes(string mirror)
        {
            List<TVShowsEpisode> episodes = new List<TVShowsEpisode>();

            XDocument xmlDocument = await mirror.ToUri().GetXDocument();

            foreach (var element in xmlDocument.Descendants("item"))
            {
                TVShowsEpisode episode = new TVShowsEpisode();
                episode.Title = element.Element("title").Value;
                episode.TorrentLink = element.Element("link").Value;
                episode.MagnetLink = element.Element("guid").Value;
                episodes.Add(episode);
            }

            return episodes;
        }
    }
}

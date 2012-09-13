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
    using System.Xml.Linq;
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
        /// The shows field
        /// </summary>
        private IList<Show> shows = new List<Show>();

        /// <summary>
        /// The last update field
        /// </summary>
        private DateTime lastUpdate = DateTime.MinValue;

        /// <summary>
        /// Gets the shows.
        /// </summary>
        /// <returns>
        /// The shows.
        /// </returns>
        public IList<Show> GetShows()
        {
            if ((DateTime.Now - this.lastUpdate).TotalMinutes > 60)
            {
                XDocument xmlDocument = XDocument.Load(ShowListFeed);

                this.shows.Clear();

                foreach (var element in xmlDocument.Descendants("show"))
                {
                    Show show = new Show();
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

                    this.shows.Add(show);
                }

                this.lastUpdate = DateTime.Now;
            }

            return this.shows;
        }

        /// <summary>
        /// Gets the episodes of a show.
        /// </summary>
        /// <param name="mirror">The mirror of the show.</param>
        /// <returns>The episodes of the show</returns>
        public IList<Episode> GetEpisodes(string mirror)
        {
            List<Episode> episodes = new List<Episode>();

            XDocument xmlDocument = XDocument.Load(mirror);

            foreach (var element in xmlDocument.Descendants("item"))
            {
                Episode episode = new Episode();
                episode.Title = element.Element("title").Value;
                episode.TorrentLink = element.Element("link").Value;
                episode.MagnetLink = element.Element("guid").Value;
                episodes.Add(episode);
            }

            return episodes;
        }
    }
}

// -----------------------------------------------------------------------
// <copyright file="ShowsProvider.cs" company="TVShowsWin">
// GNU General Public License see http://www.gnu.org.
// </copyright>
// -----------------------------------------------------------------------

namespace TVShowsWin.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TVShowsWin.Common;
    using TVShowsWin.Common.Cache.Generic;
    using TVShowsWin.Providers.Model;

    /// <summary>
    /// Shows Provider
    /// </summary>
    public sealed class ShowsProvider
    {
        /// <summary>
        /// The Cache Id
        /// </summary>
        private static readonly Guid CacheId = Guid.Parse("A56AE455-1558-4EDC-A8D7-62C93A4FF4F3");

        /// <summary>
        /// The Shows Cache
        /// </summary>
        private Cache<Show, int> showsCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShowsProvider" /> class.
        /// </summary>
        public ShowsProvider()
        {
            this.showsCache = new Cache<Show, int>(show => show.TVShowsShow.TVDId, CacheId);
        }

        /// <summary>
        /// Gets the shows.
        /// </summary>
        /// <param name="max">The max.</param>
        /// <param name="page">The page.</param>
        /// <returns>
        /// The shows
        /// </returns>
        public async Task<IList<Show>> GetShows(int max, int page)
        {
            TVShowsProvider tvshowsProvider = new TVShowsProvider();
            TheTVDBProvider tvdbProvider = new TheTVDBProvider();

            List<Show> shows = new List<Show>();
            var tvshows = await tvshowsProvider.GetShows(max, page);

            foreach (var tvshow in tvshows)
            {
                Show show = null;

                if (this.showsCache.Contains(tvshow.TVDId))
                {
                    show = this.showsCache.Get(tvshow.TVDId);
                    if (show.TVDBShow != null)
                    {
                        Uri uri = new Uri(show.TVDBShow.Poster);
                        if (uri.Scheme.Contains("http"))
                        {
                            show.TVDBShow.Poster = await ImageCache.Current.GetImage(uri);
                        }
                    }
                }
                else
                {
                    show = new Show();
                    show.TVShowsShow = tvshow;
                    show.TVDBShow = await tvdbProvider.GetShow(tvshow.TVDId);

                    this.showsCache.AddOrUpdate(show);
                }

                shows.Add(show);
            }

            this.showsCache.Save();

            return shows;
        }
    }
}

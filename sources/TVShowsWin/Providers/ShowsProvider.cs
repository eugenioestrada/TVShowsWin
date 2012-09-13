// -----------------------------------------------------------------------
// <copyright file="ShowsProvider.cs" company="TVShowsWin">
// GNU General Public License see http://www.gnu.org.
// </copyright>
// -----------------------------------------------------------------------

namespace TVShowsWin.Providers
{
    using System.Collections.Generic;
    using System.Linq;
    using TVShowsWin.Providers.Model;

    /// <summary>
    /// Shows Provider
    /// </summary>
    public class ShowsProvider
    {
        /// <summary>
        /// Gets the shows.
        /// </summary>
        /// <returns>The shows</returns>
        public IList<Show> GetShows()
        {
            TVShowsProvider tvshowsProvider = new TVShowsProvider();
            TheTVDBProvider tvdbProvider = new TheTVDBProvider();

            List<Show> shows = new List<Show>();
            var tvshows = tvshowsProvider.GetShows().Take(10);

            foreach (var tvshow in tvshows)
            {
                Show show = new Show();
                show.TVShowsShow = tvshow;
                show.TVDBShow = tvdbProvider.GetShow(tvshow.TVDId);
                shows.Add(show);
            }

            return shows;
        }
    }
}

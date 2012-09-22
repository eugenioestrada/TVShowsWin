// -----------------------------------------------------------------------
// <copyright file="ITVShowsProvider.cs" company="TVShowsWin">
// GNU General Public License see http://www.gnu.org.
// </copyright>
// -----------------------------------------------------------------------

namespace TVShowsWin.Providers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TVShowsWin.Providers.Model;

    /// <summary>
    /// Interface for a Shows Provider
    /// </summary>
    public interface ITVShowsProvider
    {
        /// <summary>
        /// Gets the shows.
        /// </summary>
        /// <param name="max">The max.</param>
        /// <param name="page">The page.</param>
        /// <returns>
        /// The shows.
        /// </returns>
        Task<IList<TVShowsShow>> GetShows(int max, int page);

        /// <summary>
        /// Gets the episodes of a show.
        /// </summary>
        /// <param name="mirror">The mirror of the show.</param>
        /// <returns>The episodes of the show</returns>
        Task<IList<TVShowsEpisode>> GetEpisodes(string mirror);
    }
}

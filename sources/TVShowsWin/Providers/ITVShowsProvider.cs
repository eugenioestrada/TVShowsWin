﻿// -----------------------------------------------------------------------
// <copyright file="ITVShowsProvider.cs" company="TVShowsWin">
// GNU General Public License see http://www.gnu.org.
// </copyright>
// -----------------------------------------------------------------------

namespace TVShowsWin.Providers
{
    using System.Collections.Generic;
    using TVShowsWin.Providers.Model;

    /// <summary>
    /// Interface for a Shows Provider
    /// </summary>
    public interface ITVShowsProvider
    {
        /// <summary>
        /// Gets the shows.
        /// </summary>
        /// <returns>The shows.</returns>
        IList<Show> GetShows();
    }
}
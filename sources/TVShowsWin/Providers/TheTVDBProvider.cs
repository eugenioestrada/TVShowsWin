﻿// -----------------------------------------------------------------------
// <copyright file="TheTVDBProvider.cs" company="TVShowsWin">
// GNU General Public License see http://www.gnu.org.
// </copyright>
// -----------------------------------------------------------------------

namespace TVShowsWin.Providers
{
    /// <summary>
    /// The TVDB Provider
    /// </summary>
    public class TheTVDBProvider
    {
        /// <summary>
        /// The TVDB Api Key
        /// </summary>
        private static readonly string ApiKey = "2AEC8D238223C926";

        /// <summary>
        /// Template for the show feed
        /// </summary>
        private static readonly string ShowFeed = "http://www.thetvdb.com/api/{0}/series/{1}/all/en.xml";

        /// <summary>
        /// The banners cache template
        /// </summary>
        private static readonly string BannersCache = "http://thetvdb.com/banners/{0}";

        /// <summary>
        /// Gets the show feed.
        /// </summary>
        /// <param name="showId">The show id.</param>
        /// <returns>Thw show feed.</returns>
        private string GetShowFeed(int showId)
        {
            return string.Format(ShowFeed, ApiKey, showId);
        }

        /// <summary>
        /// Gets the banner URL.
        /// </summary>
        /// <param name="bannerName">Name of the banner.</param>
        /// <returns>The banner url</returns>
        private string GetBannerUrl(string bannerName)
        {
            return string.Format(BannersCache, bannerName);
        }
    }
}

// -----------------------------------------------------------------------
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
        public static readonly string ApiKey = "2AEC8D238223C926";

        /// <summary>
        /// Template for the show feed
        /// </summary>
        public static readonly string ShowFeed = "http://www.thetvdb.com/api/{0}/series/{1}/all/en.xml";

        /// <summary>
        /// Gets the show feed.
        /// </summary>
        /// <param name="showId">The show id.</param>
        /// <returns>Thw show feed.</returns>
        private string GetShowFeed(int showId)
        {
            return string.Format(ShowFeed, ApiKey, showId);
        }
    }
}

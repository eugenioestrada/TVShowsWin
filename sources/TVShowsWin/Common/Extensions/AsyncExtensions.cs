// -----------------------------------------------------------------------
// <copyright file="AsyncExtensions.cs" company="TVShowsWin">
// GNU General Public License see http://www.gnu.org.
// </copyright>
// -----------------------------------------------------------------------

namespace TVShowsWin.Common.Extensions
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    /// <summary>
    /// Async Helper
    /// </summary>
    public static class AsyncExtensions
    {
        /// <summary>
        /// Gets the X document.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns>The XDocument downloaded</returns>
        public static async Task<XDocument> GetXDocument(this Uri uri)
        {
            WebClient webClient = new WebClient();
            try
            {
                string content = await webClient.DownloadStringTaskAsync(uri);
                return XDocument.Parse(content);
            }
            catch (WebException)
            {
                return null;
            }
        }
    }
}

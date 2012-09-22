// -----------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="TVShowsWin">
// GNU General Public License see http://www.gnu.org.
// </copyright>
// -----------------------------------------------------------------------

namespace TVShowsWin.Common.Extensions
{
    using System;

    /// <summary>
    /// String Helper
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Convert a String into a Uri.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="uriKind">Kind of the Uri.</param>
        /// <returns>The Uri</returns>
        public static Uri ToUri(this string url, UriKind uriKind = UriKind.Absolute)
        {
            Uri uri;
            if (Uri.TryCreate(url, uriKind, out uri))
            {
                return uri;
            }

            return null;
        }
    }
}

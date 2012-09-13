// -----------------------------------------------------------------------
// <copyright file="TVDBShow.cs" company="TVShowsWin">
// GNU General Public License see http://www.gnu.org.
// </copyright>
// -----------------------------------------------------------------------

namespace TVShowsWin.Providers.Model
{
    /// <summary>
    /// The TVDB Show Model
    /// </summary>
    public sealed class TVDBShow
    {
        /// <summary>
        /// THe poster field
        /// </summary>
        private string poster;

        /// <summary>
        /// Gets or sets the poster.
        /// </summary>
        /// <value>
        /// The poster.
        /// </value>
        public string Poster
        {
            get
            {
                return this.poster;
            }

            set
            {
                this.poster = value;
            }
        }
    }
}

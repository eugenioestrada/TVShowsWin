// -----------------------------------------------------------------------
// <copyright file="Show.cs" company="TVShowsWin">
// GNU General Public License see http://www.gnu.org.
// </copyright>
// -----------------------------------------------------------------------

namespace TVShowsWin.Providers.Model
{
    /// <summary>
    /// The Show Model
    /// </summary>
    public sealed class Show
    {
        /// <summary>
        /// The TVDB Show field
        /// </summary>
        private TVDBShow tvdbshow;

        /// <summary>
        /// The TV Shows Show field
        /// </summary>
        private TVShowsShow tvshowsshow;

        /// <summary>
        /// Gets or sets the TVDB show.
        /// </summary>
        /// <value>
        /// The TVDB show.
        /// </value>
        public TVDBShow TVDBShow
        {
            get
            {
                return this.tvdbshow;
            }

            set
            {
                this.tvdbshow = value;
            }
        }

        /// <summary>
        /// Gets or sets the TV shows show.
        /// </summary>
        /// <value>
        /// The TV shows show.
        /// </value>
        public TVShowsShow TVShowsShow
        {
            get
            {
                return this.tvshowsshow;
            }

            set
            {
                this.tvshowsshow = value;
            }
        }
    }
}

// -----------------------------------------------------------------------
// <copyright file="Episode.cs" company="TVShowsWin">
// GNU General Public License see http://www.gnu.org.
// </copyright>
// -----------------------------------------------------------------------

namespace TVShowsWin.Providers.Model
{
    /// <summary>
    /// Model of a Episode
    /// </summary>
    public sealed class Episode
    {
        /// <summary>
        /// The title field.
        /// </summary>
        private string title;

        /// <summary>
        /// The torrent link.
        /// </summary>
        private string torrentLink;

        /// <summary>
        /// The magnet link.
        /// </summary>
        private string magnetLink;

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                this.title = value;
            }
        }

        /// <summary>
        /// Gets or sets the torrent link.
        /// </summary>
        /// <value>
        /// The torrent link.
        /// </value>
        public string TorrentLink
        {
            get
            {
                return this.torrentLink;
            }

            set
            {
                this.torrentLink = value;
            }
        }

        /// <summary>
        /// Gets or sets the magnet link.
        /// </summary>
        /// <value>
        /// The magnet link.
        /// </value>
        public string MagnetLink
        {
            get
            {
                return this.magnetLink;
            }

            set
            {
                this.magnetLink = value;
            }
        }
    }
}

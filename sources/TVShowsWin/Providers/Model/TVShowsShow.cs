// -----------------------------------------------------------------------
// <copyright file="TVShowsShow.cs" company="TVShowsWin">
// GNU General Public License see http://www.gnu.org.
// </copyright>
// -----------------------------------------------------------------------

namespace TVShowsWin.Providers.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Model of a Show
    /// </summary>
    public sealed class TVShowsShow
    {
        /// <summary>
        /// The name field
        /// </summary>
        private string name;

        /// <summary>
        /// The TVDId field
        /// </summary>
        private int tvdbid;

        /// <summary>
        /// The added field
        /// </summary>
        private DateTime added;

        /// <summary>
        /// The list of mirrors field
        /// </summary>
        private IList<Uri> mirrors = new List<Uri>();

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets the TVD id.
        /// </summary>
        /// <value>
        /// The TVD id.
        /// </value>
        public int TVDId
        {
            get
            {
                return this.tvdbid;
            }

            set
            {
                this.tvdbid = value;
            }
        }

        /// <summary>
        /// Gets or sets the added.
        /// </summary>
        /// <value>
        /// The added.
        /// </value>
        public DateTime Added
        {
            get
            {
                return this.added;
            }

            set
            {
                this.added = value;
            }
        }

        /// <summary>
        /// Gets or sets the mirrors.
        /// </summary>
        /// <value>
        /// The mirrors.
        /// </value>
        public IList<Uri> Mirrors
        {
            get
            {
                return this.mirrors;
            }

            set
            {
                this.mirrors = value;
            }
        }
    }
}

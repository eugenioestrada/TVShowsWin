// -----------------------------------------------------------------------
// <copyright file="DesignerHelper.cs" company="TVShowsWin">
// GNU General Public License see http://www.gnu.org.
// </copyright>
// -----------------------------------------------------------------------

namespace TVShowsWin.Common.Helpers
{
    using System.ComponentModel;
    using System.Windows;

    /// <summary>
    /// Designer Helper
    /// </summary>
    public class DesignerHelper
    {
        /// <summary>
        /// Is Design Mode
        /// </summary>
        private static bool? isInDesignMode;

        /// <summary>
        /// Gets a value indicating whether the control is in design mode (running in Blend
        /// or Visual Studio).
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is in design mode; otherwise, <c>false</c>.
        /// </value>
        public static bool IsInDesignMode
        {
            get
            {
                if (!isInDesignMode.HasValue)
                {
                    var prop = DesignerProperties.IsInDesignModeProperty;
                    isInDesignMode = (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
                }

                return isInDesignMode.Value;
            }
        }
    }
}

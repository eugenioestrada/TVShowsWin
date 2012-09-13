// -----------------------------------------------------------------------
// <copyright file="DispatcherHelper.cs" company="TVShowsWin">
// GNU General Public License see http://www.gnu.org.
// </copyright>
// -----------------------------------------------------------------------

namespace TVShowsWin.Common.Helpers
{
    using System;
    using System.Threading;
    using System.Windows;

    /// <summary>
    /// Help you using the UI Dispatcher
    /// </summary>
    public class DispatcherHelper
    {
        /// <summary>
        /// Invokes the in dispatcher.
        /// </summary>
        /// <param name="action">The action.</param>
        public void InvokeInDispatcher(Action action)
        {
            if (Application.Current.Dispatcher.Thread != Thread.CurrentThread)
            {
                Application.Current.Dispatcher.BeginInvoke(action);
            }
            else
            {
                action();
            }
        }
    }
}

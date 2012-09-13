// -----------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="TVShowsWin">
// GNU General Public License see http://www.gnu.org.
// </copyright>
// -----------------------------------------------------------------------

namespace TVShowsWin.TVShowsApp
{
    using System;
    using System.Collections.Generic;
    using System.Reactive;
    using System.Reactive.Linq;
    using System.Windows;
    using TVShowsWin.Providers;
    using TVShowsWin.Services;
    using TVShowsWin.Services.Messages;
    using TVShowsWin.Services.Messenger;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// The services
        /// </summary>
        private readonly IList<IService> services;

        /// <summary>
        /// Initializes a new instance of the <see cref="App" /> class.
        /// </summary>
        public App()
        {
            this.services = new List<IService>();
            this.Startup += this.App_Startup;
        }

        /// <summary>
        /// Handles the Startup event of the App control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="StartupEventArgs" /> instance containing the event data.</param>
        private void App_Startup(object sender, StartupEventArgs e)
        {
        }
    }
}

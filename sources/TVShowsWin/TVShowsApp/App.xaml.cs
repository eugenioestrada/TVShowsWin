﻿// -----------------------------------------------------------------------
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
        /// Subscription of the observer
        /// </summary>
        private IDisposable subscription;

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
            // this.services.Add();
            var messenger = new MessengerService();
            messenger.Start();
            this.subscription = messenger.Messages.Subscribe<NewShowMessage>(newShowMessage =>
            {
                MessageBox.Show("New Show");
            });
            messenger.Messages.OnNext(new NewShowMessage());

            // foreach (IService service in services)
            // {
            //     service.Start();

            // }
        }
    }
}

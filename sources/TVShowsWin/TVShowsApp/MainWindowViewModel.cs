// -----------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="TVShowsWin">
// GNU General Public License see http://www.gnu.org.
// </copyright>
// -----------------------------------------------------------------------

namespace TVShowsWin.TVShowsApp
{
    using System.Collections.ObjectModel;
    using System.Threading;
    using System.Threading.Tasks;
    using TVShowsWin.Common.Helpers;
    using TVShowsWin.Common.UI;
    using TVShowsWin.Providers;
    using TVShowsWin.Providers.Model;

    /// <summary>
    /// MainWindow ViewModel
    /// </summary>
    public sealed class MainWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// The Shows field
        /// </summary>
        private ObservableCollection<Show> shows;

        /// <summary>
        /// The Shows Provider
        /// </summary>
        private ShowsProvider showsProvider = new ShowsProvider();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel" /> class.
        /// </summary>
        public MainWindowViewModel()
        {
            Task.Factory.StartNew(() =>
            {
                var shows = this.showsProvider.GetShows();
                DispatcherHelper.InvokeInDispatcher(() =>
                {
                    this.Shows = new ObservableCollection<Show>(shows);
                });
            });
        }

        /// <summary>
        /// Gets or sets the shows.
        /// </summary>
        /// <value>
        /// The shows.
        /// </value>
        public ObservableCollection<Show> Shows
        {
            get
            {
                return this.shows;
            }

            set
            {
                this.OnPropertyChanging();
                this.shows = value;
                this.OnPropertyChanged();
            }
        }
    }
}

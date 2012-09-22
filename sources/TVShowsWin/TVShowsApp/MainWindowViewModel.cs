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
        /// Size of Page
        /// </summary>
        private const int PageSize = 10;

        /// <summary>
        /// The Shows field
        /// </summary>
        private ObservableCollection<Show> shows;

        /// <summary>
        /// The Shows Provider
        /// </summary>
        private ShowsProvider showsProvider = new ShowsProvider();

        /// <summary>
        /// The Current Page field
        /// </summary>
        private int currentPage = 0;

        /// <summary>
        /// Download of all shows completed field
        /// </summary>
        private bool downloadCompleted = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel" /> class.
        /// </summary>
        public MainWindowViewModel()
        {
            this.Shows = new ObservableCollection<Show>();
            this.GetNextPage();
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

        /// <summary>
        /// Gets the next page.
        /// </summary>
        private void GetNextPage()
        {
            var task = this.showsProvider.GetShows(PageSize, this.currentPage);
            task.ContinueWith(t =>
            {
                var shows = t.Result;
                if (shows.Count > 0)
                {
                    DispatcherHelper.InvokeInDispatcher(() =>
                    {
                        foreach (var show in shows)
                        {
                            this.Shows.Add(show);
                        }
                    });
                }
                else
                {
                    this.downloadCompleted = true;
                }

                if (!this.downloadCompleted)
                {
                    this.currentPage++;
                    this.GetNextPage();
                }
            });
        }
    }
}

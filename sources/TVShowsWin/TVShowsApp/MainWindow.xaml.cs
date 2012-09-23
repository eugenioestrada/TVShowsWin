// -----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="TVShowsWin">
// GNU General Public License see http://www.gnu.org.
// </copyright>
// -----------------------------------------------------------------------

namespace TVShowsWin.TVShowsApp
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles the 1 event of the Button_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Handles the 1 event of the VirtualizingStackPanel_MouseWheel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseWheelEventArgs" /> instance containing the event data.</param>
        private void VirtualizingStackPanel_MouseWheel_1(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            VirtualizingStackPanel virtualizingStackPanel = sender as VirtualizingStackPanel;
            virtualizingStackPanel.ScrollOwner.ScrollToHorizontalOffset(virtualizingStackPanel.ScrollOwner.HorizontalOffset - (e.Delta * 0.01));
        }
    }
}

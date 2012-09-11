// -----------------------------------------------------------------------
// <copyright file="IService.cs" company="TVShowsWin">
// GNU General Public License see http://www.gnu.org.
// </copyright>
// -----------------------------------------------------------------------

namespace TVShowsWin.Services
{
    /// <summary>
    /// Interface of a Service
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// Starts this service.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops this service.
        /// </summary>
        void Stop();
    }
}

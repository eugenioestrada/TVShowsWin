// -----------------------------------------------------------------------
// <copyright file="IMessengerService.cs" company="TVShowsWin">
// GNU General Public License see http://www.gnu.org.
// </copyright>
// -----------------------------------------------------------------------

namespace TVShowsWin.Services.Messenger
{
    using System;
    using System.Reactive.Subjects;
    using TVShowsWin.Services.Messages;

    /// <summary>
    /// Interface of the Messenger Service
    /// </summary>
    public interface IMessengerService
    {
        /// <summary>
        /// Gets the messages.
        /// </summary>
        /// <value>
        /// The messages.
        /// </value>
        ISubject<MessageBase> Messages { get; }
    }
}

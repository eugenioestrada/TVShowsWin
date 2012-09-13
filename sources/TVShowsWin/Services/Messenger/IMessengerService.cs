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
        /// Subscribes the specified message.
        /// </summary>
        /// <typeparam name="TMessage">The type of the message.</typeparam>
        /// <param name="callback">The callback.</param>
        /// <returns>The subscription</returns>
        IDisposable Subscribe<TMessage>(Action<TMessage> callback) where TMessage : MessageBase;

        /// <summary>
        /// Publishes the specified message.
        /// </summary>
        /// <typeparam name="TMessage">The type of the message.</typeparam>
        /// <param name="message">The message.</param>
        void Publish<TMessage>(TMessage message) where TMessage : MessageBase;
    }
}

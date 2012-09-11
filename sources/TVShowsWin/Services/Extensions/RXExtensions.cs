// -----------------------------------------------------------------------
// <copyright file="RXExtensions.cs" company="TVShowsWin">
// GNU General Public License see http://www.gnu.org.
// </copyright>
// -----------------------------------------------------------------------

namespace TVShowsWin
{
    using System;
    using System.Reactive.Subjects;
    using TVShowsWin.Services.Messages;

    /// <summary>
    /// Extension methods for Reactive Extensions
    /// </summary>
    public static class RXExtensions
    {
        /// <summary>
        /// Subscribes the specified subject.
        /// </summary>
        /// <typeparam name="TMessage">The type of the message.</typeparam>
        /// <param name="subject">The subject.</param>
        /// <param name="onNext">The on next.</param>
        /// <returns>The disposable subscription</returns>
        public static IDisposable Subscribe<TMessage>(this ISubject<MessageBase> subject, Action<TMessage> onNext) where TMessage : MessageBase
        {
            return subject.Subscribe(messageBase =>
            {
                TMessage message = messageBase as TMessage;
                if (message != null)
                {
                    onNext(message);
                }
            });
        }
    }
}

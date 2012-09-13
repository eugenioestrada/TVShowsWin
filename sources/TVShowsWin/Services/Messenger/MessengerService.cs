// -----------------------------------------------------------------------
// <copyright file="MessengerService.cs" company="TVShowsWin">
// GNU General Public License see http://www.gnu.org.
// </copyright>
// -----------------------------------------------------------------------

namespace TVShowsWin.Services.Messenger
{
    using System;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using TVShowsWin.Services.Messages;

    /// <summary>
    /// Implementation of the Messenger Service
    /// </summary>
    public sealed class MessengerService : IService, IMessengerService, IDisposable
    {
        /// <summary>
        /// The messages
        /// </summary>
        private readonly ISubject<MessageBase> messages;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessengerService" /> class.
        /// </summary>
        public MessengerService()
        {
            this.messages = new Subject<MessageBase>();
        }

        /// <summary>
        /// Subscribes the specified message.
        /// </summary>
        /// <typeparam name="TMessage">The type of the message.</typeparam>
        /// <param name="callback">The callback.</param>
        public void Subscribe<TMessage>(Action<TMessage> callback) where TMessage : MessageBase
        {
            this.messages.Subscribe(m =>
            {
                TMessage message = m as TMessage;
                if (message != null)
                {
                    callback(message);
                }
            });
        }

        /// <summary>
        /// Publishes the specified message.
        /// </summary>
        /// <typeparam name="TMessage">The type of the message.</typeparam>
        /// <param name="message">The message.</param>
        public void Publish<TMessage>(TMessage message) where TMessage : MessageBase
        {
            this.messages.OnNext(message);
        }

        /// <summary>
        /// Starts this service.
        /// </summary>
        public void Start()
        {
        }

        /// <summary>
        /// Stops this service.
        /// </summary>
        public void Stop()
        {
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}

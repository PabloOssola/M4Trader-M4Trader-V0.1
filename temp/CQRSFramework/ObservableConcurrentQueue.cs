using System;
using System.Collections.Concurrent;

namespace M4Trader.ordenes.server.CQRSFramework
{
    public delegate void ConcurrentQueueChangedEventHandler<T>(
       object sender,
       NotifyConcurrentQueueChangedEventArgs<T> args);

    public enum NotifyConcurrentQueueChangedAction
    {
        Enqueue,
        Dequeue,
        Peek,
        Empty
    }

    public class NotifyConcurrentQueueChangedEventArgs<T> : EventArgs
    {
        #region Constructors and Destructors

        
        public NotifyConcurrentQueueChangedEventArgs(NotifyConcurrentQueueChangedAction action, T changedItem)
        {
            this.Action = action;
            this.ChangedItem = changedItem;
        }

        
        public NotifyConcurrentQueueChangedEventArgs(NotifyConcurrentQueueChangedAction action)
        {
            this.Action = action;
        }

        #endregion

        #region Public Properties

        
        public NotifyConcurrentQueueChangedAction Action { get; private set; }

        
        public T ChangedItem { get; private set; }

        #endregion
    }

    public sealed class ObservableConcurrentQueue<T> : ConcurrentQueue<T>
    {
        #region Public Events

        
        public event ConcurrentQueueChangedEventHandler<T> ContentChanged;

        #endregion

        #region Public Methods and Operators

        
        public new void Enqueue(T item)
        {
            base.Enqueue(item);

            // Raise event added event
            this.OnContentChanged(
                new NotifyConcurrentQueueChangedEventArgs<T>(NotifyConcurrentQueueChangedAction.Enqueue, item));
        }

        
        public new bool TryDequeue(out T result)
        {
            if (!base.TryDequeue(out result))
            {
                return false;
            }

            // Raise item dequeued event
            this.OnContentChanged(
                new NotifyConcurrentQueueChangedEventArgs<T>(NotifyConcurrentQueueChangedAction.Dequeue, result));

            if (this.IsEmpty)
            {
                // Raise Queue empty event
                this.OnContentChanged(
                    new NotifyConcurrentQueueChangedEventArgs<T>(NotifyConcurrentQueueChangedAction.Empty));
            }

            return true;
        }

        
        public new bool TryPeek(out T result)
        {
            var retValue = base.TryPeek(out result);
            if (retValue)
            {
                // Raise item dequeued event
                this.OnContentChanged(
                    new NotifyConcurrentQueueChangedEventArgs<T>(NotifyConcurrentQueueChangedAction.Peek, result));
            }

            return retValue;
        }

        #endregion

        #region Methods

        
        private void OnContentChanged(NotifyConcurrentQueueChangedEventArgs<T> args)
        {
            var handler = this.ContentChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        #endregion
    }
}

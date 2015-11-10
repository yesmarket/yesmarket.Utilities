using System;
using System.ComponentModel;
using System.Messaging;

namespace yesmarket.Messaging.Msmq
{
    public class MessageQueueImpl : IMessageQueue
    {
        private bool _disposed;
        private MessageQueue _wrapped;

        public MessageQueueImpl()
        {
            _wrapped = new MessageQueue();
        }

        public MessageQueueImpl(string path)
        {
            _wrapped = new MessageQueue(path);
        }

        public MessageQueueImpl(string path, QueueAccessMode accessMode)
        {
            _wrapped = new MessageQueue(path, accessMode);
        }

        public MessageQueueImpl(string path, bool sharedModeDenyReceive)
        {
            _wrapped = new MessageQueue(path, sharedModeDenyReceive);
        }

        public MessageQueueImpl(string path, bool sharedModeDenyReceive, bool enableCache)
        {
            _wrapped = new MessageQueue(path, sharedModeDenyReceive, enableCache);
        }

        public MessageQueueImpl(string path, bool sharedModeDenyReceive, bool enableCache, QueueAccessMode accessMode)
        {
            _wrapped = new MessageQueue(path, sharedModeDenyReceive, enableCache, accessMode);
        }

        public QueueAccessMode AccessMode
        {
            get { return _wrapped.AccessMode; }
        }

        public bool Authenticate
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                return _wrapped.Authenticate;
            }
            set
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                _wrapped.Authenticate = value;
            }
        }

        public short BasePriority
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                return _wrapped.BasePriority;
            }
            set
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                _wrapped.BasePriority = value;
            }
        }

        public bool CanRead
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                return _wrapped.CanRead;
            }
        }

        public bool CanWrite
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                return _wrapped.CanWrite;
            }
        }

        public Guid Category
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                return _wrapped.Category;
            }
            set
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                _wrapped.Category = value;
            }
        }

        public DateTime CreateTime
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                return _wrapped.CreateTime;
            }
        }

        public DefaultPropertiesToSend DefaultPropertiesToSend
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                return _wrapped.DefaultPropertiesToSend;
            }
            set
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                _wrapped.DefaultPropertiesToSend = value;
            }
        }

        public bool DenySharedReceive
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                return _wrapped.DenySharedReceive;
            }
            set
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                _wrapped.DenySharedReceive = value;
            }
        }

        public EncryptionRequired EncryptionRequired
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                return _wrapped.EncryptionRequired;
            }
            set
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                _wrapped.EncryptionRequired = value;
            }
        }

        public string FormatName
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                return _wrapped.FormatName;
            }
        }

        public IMessageFormatter Formatter
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                return _wrapped.Formatter;
            }
            set
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                _wrapped.Formatter = value;
            }
        }

        public Guid Id
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                return _wrapped.Id;
            }
        }

        public string Label
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                return _wrapped.Label;
            }
            set
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                _wrapped.Label = value;
            }
        }

        public DateTime LastModifyTime
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                return _wrapped.LastModifyTime;
            }
        }

        public string MachineName
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                return _wrapped.MachineName;
            }
            set
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                _wrapped.MachineName = value;
            }
        }

        public long MaximumJournalSize
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                return _wrapped.MaximumJournalSize;
            }
            set
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                _wrapped.MaximumJournalSize = value;
            }
        }

        public long MaximumQueueSize
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                return _wrapped.MaximumQueueSize;
            }
            set
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                _wrapped.MaximumQueueSize = value;
            }
        }

        public MessagePropertyFilter MessageReadPropertyFilter
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                return _wrapped.MessageReadPropertyFilter;
            }
            set
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                _wrapped.MessageReadPropertyFilter = value;
            }
        }

        public string MulticastAddress
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                return _wrapped.MulticastAddress;
            }
            set
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                _wrapped.MulticastAddress = value;
            }
        }

        public string Path
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                return _wrapped.Path;
            }
            set
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                _wrapped.Path = value;
            }
        }

        public string QueueName
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                return _wrapped.QueueName;
            }
            set
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                _wrapped.QueueName = value;
            }
        }

        public IntPtr ReadHandle
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                return _wrapped.ReadHandle;
            }
        }

        public ISynchronizeInvoke SynchronizingObject
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                return _wrapped.SynchronizingObject;
            }
            set
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                _wrapped.SynchronizingObject = value;
            }
        }

        public bool Transactional
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                return _wrapped.Transactional;
            }
        }

        public bool UseJournalQueue
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                return _wrapped.UseJournalQueue;
            }
            set
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                _wrapped.UseJournalQueue = value;
            }
        }

        public IntPtr WriteHandle
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                return _wrapped.WriteHandle;
            }
        }

        public event PeekCompletedEventHandler PeekCompleted
        {
            add
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                _wrapped.PeekCompleted += value;
            }
            remove
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                _wrapped.PeekCompleted -= value;
            }
        }

        public event ReceiveCompletedEventHandler ReceiveCompleted
        {
            add
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                _wrapped.ReceiveCompleted += value;
            }
            remove
            {
                if (_disposed) throw new ObjectDisposedException(GetType().FullName);
                _wrapped.ReceiveCompleted -= value;
            }
        }

        public IAsyncResult BeginPeek()
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.BeginPeek();
        }

        public IAsyncResult BeginPeek(TimeSpan timeout)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.BeginPeek(timeout);
        }

        public IAsyncResult BeginPeek(TimeSpan timeout, object stateObject)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.BeginPeek(timeout, stateObject);
        }

        public IAsyncResult BeginPeek(TimeSpan timeout, object stateObject, AsyncCallback callback)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.BeginPeek(timeout, stateObject, callback);
        }

        public IAsyncResult BeginPeek(TimeSpan timeout, Cursor cursor, PeekAction action, object state,
            AsyncCallback callback)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.BeginPeek(timeout, cursor, action, state, callback);
        }

        public IAsyncResult BeginReceive()
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.BeginReceive();
        }

        public IAsyncResult BeginReceive(TimeSpan timeout)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.BeginReceive(timeout);
        }

        public IAsyncResult BeginReceive(TimeSpan timeout, object stateObject)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.BeginReceive(timeout, stateObject);
        }

        public IAsyncResult BeginReceive(TimeSpan timeout, object stateObject, AsyncCallback callback)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.BeginReceive(timeout, stateObject, callback);
        }

        public IAsyncResult BeginReceive(TimeSpan timeout, Cursor cursor, object state, AsyncCallback callback)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.BeginReceive(timeout, cursor, state, callback);
        }

        public void Close()
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            _wrapped.Close();
        }

        public Cursor CreateCursor()
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.CreateCursor();
        }

        public Message EndPeek(IAsyncResult asyncResult)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.EndPeek(asyncResult);
        }

        public Message EndReceive(IAsyncResult asyncResult)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.EndReceive(asyncResult);
        }

        public Message[] GetAllMessages()
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.GetAllMessages();
        }

        public MessageEnumerator GetMessageEnumerator2()
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.GetMessageEnumerator2();
        }

        public Message Peek()
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.Peek();
        }

        public Message Peek(TimeSpan timeout)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.Peek(timeout);
        }

        public Message Peek(TimeSpan timeout, Cursor cursor, PeekAction action)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.Peek(timeout, cursor, action);
        }

        public Message PeekById(string id)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.PeekById(id);
        }

        public Message PeekById(string id, TimeSpan timeout)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.PeekById(id, timeout);
        }

        public Message PeekByCorrelationId(string correlationId)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.PeekByCorrelationId(correlationId);
        }

        public Message PeekByCorrelationId(string correlationId, TimeSpan timeout)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.PeekByCorrelationId(correlationId, timeout);
        }

        public Message PeekByLookupId(long lookupId)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.PeekByLookupId(lookupId);
        }

        public Message PeekByLookupId(MessageLookupAction action, long lookupId)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.PeekByLookupId(action, lookupId);
        }

        public void Purge()
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            _wrapped.Purge();
        }

        public Message Receive()
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.Receive();
        }

        public Message Receive(MessageQueueTransaction transaction)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.Receive(transaction);
        }

        public Message Receive(MessageQueueTransactionType transactionType)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.Receive(transactionType);
        }

        public Message Receive(TimeSpan timeout)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.Receive(timeout);
        }

        public Message Receive(TimeSpan timeout, Cursor cursor)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.Receive(timeout, cursor);
        }

        public Message Receive(TimeSpan timeout, MessageQueueTransaction transaction)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.Receive(timeout, transaction);
        }

        public Message Receive(TimeSpan timeout, MessageQueueTransactionType transactionType)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.Receive(timeout, transactionType);
        }

        public Message Receive(TimeSpan timeout, Cursor cursor, MessageQueueTransaction transaction)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.Receive(timeout, cursor, transaction);
        }

        public Message Receive(TimeSpan timeout, Cursor cursor, MessageQueueTransactionType transactionType)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.Receive(timeout, cursor, transactionType);
        }

        public Message ReceiveById(string id)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.ReceiveById(id);
        }

        public Message ReceiveById(string id, MessageQueueTransaction transaction)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.ReceiveById(id, transaction);
        }

        public Message ReceiveById(string id, MessageQueueTransactionType transactionType)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.ReceiveById(id, transactionType);
        }

        public Message ReceiveById(string id, TimeSpan timeout)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.ReceiveById(id, timeout);
        }

        public Message ReceiveById(string id, TimeSpan timeout, MessageQueueTransaction transaction)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.ReceiveById(id, timeout, transaction);
        }

        public Message ReceiveById(string id, TimeSpan timeout, MessageQueueTransactionType transactionType)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.ReceiveById(id, timeout, transactionType);
        }

        public Message ReceiveByCorrelationId(string correlationId)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.ReceiveByCorrelationId(correlationId);
        }

        public Message ReceiveByCorrelationId(string correlationId, MessageQueueTransaction transaction)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.ReceiveByCorrelationId(correlationId, transaction);
        }

        public Message ReceiveByCorrelationId(string correlationId, MessageQueueTransactionType transactionType)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.ReceiveByCorrelationId(correlationId, transactionType);
        }

        public Message ReceiveByCorrelationId(string correlationId, TimeSpan timeout)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.ReceiveByCorrelationId(correlationId, timeout);
        }

        public Message ReceiveByCorrelationId(string correlationId, TimeSpan timeout,
            MessageQueueTransaction transaction)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.ReceiveByCorrelationId(correlationId, timeout, transaction);
        }

        public Message ReceiveByCorrelationId(string correlationId, TimeSpan timeout,
            MessageQueueTransactionType transactionType)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.ReceiveByCorrelationId(correlationId, timeout, transactionType);
        }

        public Message ReceiveByLookupId(long lookupId)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.ReceiveByLookupId(lookupId);
        }

        public Message ReceiveByLookupId(MessageLookupAction action, long lookupId,
            MessageQueueTransactionType transactionType)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.ReceiveByLookupId(action, lookupId, transactionType);
        }

        public Message ReceiveByLookupId(MessageLookupAction action, long lookupId, MessageQueueTransaction transaction)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            return _wrapped.ReceiveByLookupId(action, lookupId, transaction);
        }

        public void Refresh()
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            _wrapped.Refresh();
        }

        public void Send(object obj)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            _wrapped.Send(obj);
        }

        public void Send(object obj, MessageQueueTransaction transaction)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            _wrapped.Send(obj, transaction);
        }

        public void Send(object obj, MessageQueueTransactionType transactionType)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            _wrapped.Send(obj, transactionType);
        }

        public void Send(object obj, string label)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            _wrapped.Send(obj, label);
        }

        public void Send(object obj, string label, MessageQueueTransaction transaction)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            _wrapped.Send(obj, label, transaction);
        }

        public void Send(object obj, string label, MessageQueueTransactionType transactionType)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            _wrapped.Send(obj, label, transactionType);
        }

        public void ResetPermissions()
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            _wrapped.ResetPermissions();
        }

        public void SetPermissions(string user, MessageQueueAccessRights rights)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            _wrapped.SetPermissions(user, rights);
        }

        public void SetPermissions(string user, MessageQueueAccessRights rights, AccessControlEntryType entryType)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            _wrapped.SetPermissions(user, rights, entryType);
        }

        public void SetPermissions(MessageQueueAccessControlEntry ace)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            _wrapped.SetPermissions(ace);
        }

        public void SetPermissions(AccessControlList dacl)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
            _wrapped.SetPermissions(dacl);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed || !disposing) return;
            if (_wrapped != null)
            {
                _wrapped.Dispose();
                _wrapped = null;
            }
            _disposed = true;
        }
    }
}
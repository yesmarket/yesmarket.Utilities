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
                CheckDisposed();
                return _wrapped.Authenticate;
            }
            set
            {
                CheckDisposed();
                _wrapped.Authenticate = value;
            }
        }

        public short BasePriority
        {
            get
            {
                CheckDisposed();
                return _wrapped.BasePriority;
            }
            set
            {
                CheckDisposed();
                _wrapped.BasePriority = value;
            }
        }

        public bool CanRead
        {
            get
            {
                CheckDisposed();
                return _wrapped.CanRead;
            }
        }

        public bool CanWrite
        {
            get
            {
                CheckDisposed();
                return _wrapped.CanWrite;
            }
        }

        public Guid Category
        {
            get
            {
                CheckDisposed();
                return _wrapped.Category;
            }
            set
            {
                CheckDisposed();
                _wrapped.Category = value;
            }
        }

        public DateTime CreateTime
        {
            get
            {
                CheckDisposed();
                return _wrapped.CreateTime;
            }
        }

        public DefaultPropertiesToSend DefaultPropertiesToSend
        {
            get
            {
                CheckDisposed();
                return _wrapped.DefaultPropertiesToSend;
            }
            set
            {
                CheckDisposed();
                _wrapped.DefaultPropertiesToSend = value;
            }
        }

        public bool DenySharedReceive
        {
            get
            {
                CheckDisposed();
                return _wrapped.DenySharedReceive;
            }
            set
            {
                CheckDisposed();
                _wrapped.DenySharedReceive = value;
            }
        }

        public EncryptionRequired EncryptionRequired
        {
            get
            {
                CheckDisposed();
                return _wrapped.EncryptionRequired;
            }
            set
            {
                CheckDisposed();
                _wrapped.EncryptionRequired = value;
            }
        }

        public string FormatName
        {
            get
            {
                CheckDisposed();
                return _wrapped.FormatName;
            }
        }

        public IMessageFormatter Formatter
        {
            get
            {
                CheckDisposed();
                return _wrapped.Formatter;
            }
            set
            {
                CheckDisposed();
                _wrapped.Formatter = value;
            }
        }

        public Guid Id
        {
            get
            {
                CheckDisposed();
                return _wrapped.Id;
            }
        }

        public string Label
        {
            get
            {
                CheckDisposed();
                return _wrapped.Label;
            }
            set
            {
                CheckDisposed();
                _wrapped.Label = value;
            }
        }

        public DateTime LastModifyTime
        {
            get
            {
                CheckDisposed();
                return _wrapped.LastModifyTime;
            }
        }

        public string MachineName
        {
            get
            {
                CheckDisposed();
                return _wrapped.MachineName;
            }
            set
            {
                CheckDisposed();
                _wrapped.MachineName = value;
            }
        }

        public long MaximumJournalSize
        {
            get
            {
                CheckDisposed();
                return _wrapped.MaximumJournalSize;
            }
            set
            {
                CheckDisposed();
                _wrapped.MaximumJournalSize = value;
            }
        }

        public long MaximumQueueSize
        {
            get
            {
                CheckDisposed();
                return _wrapped.MaximumQueueSize;
            }
            set
            {
                CheckDisposed();
                _wrapped.MaximumQueueSize = value;
            }
        }

        public MessagePropertyFilter MessageReadPropertyFilter
        {
            get
            {
                CheckDisposed();
                return _wrapped.MessageReadPropertyFilter;
            }
            set
            {
                CheckDisposed();
                _wrapped.MessageReadPropertyFilter = value;
            }
        }

        public string MulticastAddress
        {
            get
            {
                CheckDisposed();
                return _wrapped.MulticastAddress;
            }
            set
            {
                CheckDisposed();
                _wrapped.MulticastAddress = value;
            }
        }

        public string Path
        {
            get
            {
                CheckDisposed();
                return _wrapped.Path;
            }
            set
            {
                CheckDisposed();
                _wrapped.Path = value;
            }
        }

        public string QueueName
        {
            get
            {
                CheckDisposed();
                return _wrapped.QueueName;
            }
            set
            {
                CheckDisposed();
                _wrapped.QueueName = value;
            }
        }

        public IntPtr ReadHandle
        {
            get
            {
                CheckDisposed();
                return _wrapped.ReadHandle;
            }
        }

        public ISynchronizeInvoke SynchronizingObject
        {
            get
            {
                CheckDisposed();
                return _wrapped.SynchronizingObject;
            }
            set
            {
                CheckDisposed();
                _wrapped.SynchronizingObject = value;
            }
        }

        public bool Transactional
        {
            get
            {
                CheckDisposed();
                return _wrapped.Transactional;
            }
        }

        public bool UseJournalQueue
        {
            get
            {
                CheckDisposed();
                return _wrapped.UseJournalQueue;
            }
            set
            {
                CheckDisposed();
                _wrapped.UseJournalQueue = value;
            }
        }

        public IntPtr WriteHandle
        {
            get
            {
                CheckDisposed();
                return _wrapped.WriteHandle;
            }
        }

        public event PeekCompletedEventHandler PeekCompleted
        {
            add
            {
                CheckDisposed();
                _wrapped.PeekCompleted += value;
            }
            remove
            {
                CheckDisposed();
                _wrapped.PeekCompleted -= value;
            }
        }

        public event ReceiveCompletedEventHandler ReceiveCompleted
        {
            add
            {
                CheckDisposed();
                _wrapped.ReceiveCompleted += value;
            }
            remove
            {
                CheckDisposed();
                _wrapped.ReceiveCompleted -= value;
            }
        }

        public IAsyncResult BeginPeek()
        {
            CheckDisposed();
            return _wrapped.BeginPeek();
        }

        public IAsyncResult BeginPeek(TimeSpan timeout)
        {
            CheckDisposed();
            return _wrapped.BeginPeek(timeout);
        }

        public IAsyncResult BeginPeek(TimeSpan timeout, object stateObject)
        {
            CheckDisposed();
            return _wrapped.BeginPeek(timeout, stateObject);
        }

        public IAsyncResult BeginPeek(TimeSpan timeout, object stateObject, AsyncCallback callback)
        {
            CheckDisposed();
            return _wrapped.BeginPeek(timeout, stateObject, callback);
        }

        public IAsyncResult BeginPeek(TimeSpan timeout, Cursor cursor, PeekAction action, object state,
            AsyncCallback callback)
        {
            CheckDisposed();
            return _wrapped.BeginPeek(timeout, cursor, action, state, callback);
        }

        public IAsyncResult BeginReceive()
        {
            CheckDisposed();
            return _wrapped.BeginReceive();
        }

        public IAsyncResult BeginReceive(TimeSpan timeout)
        {
            CheckDisposed();
            return _wrapped.BeginReceive(timeout);
        }

        public IAsyncResult BeginReceive(TimeSpan timeout, object stateObject)
        {
            CheckDisposed();
            return _wrapped.BeginReceive(timeout, stateObject);
        }

        public IAsyncResult BeginReceive(TimeSpan timeout, object stateObject, AsyncCallback callback)
        {
            CheckDisposed();
            return _wrapped.BeginReceive(timeout, stateObject, callback);
        }

        public IAsyncResult BeginReceive(TimeSpan timeout, Cursor cursor, object state, AsyncCallback callback)
        {
            CheckDisposed();
            return _wrapped.BeginReceive(timeout, cursor, state, callback);
        }

        public void Close()
        {
            CheckDisposed();
            _wrapped.Close();
        }

        public Cursor CreateCursor()
        {
            CheckDisposed();
            return _wrapped.CreateCursor();
        }

        public Message EndPeek(IAsyncResult asyncResult)
        {
            CheckDisposed();
            return _wrapped.EndPeek(asyncResult);
        }

        public Message EndReceive(IAsyncResult asyncResult)
        {
            CheckDisposed();
            return _wrapped.EndReceive(asyncResult);
        }

        public Message[] GetAllMessages()
        {
            CheckDisposed();
            return _wrapped.GetAllMessages();
        }

        public MessageEnumerator GetMessageEnumerator2()
        {
            CheckDisposed();
            return _wrapped.GetMessageEnumerator2();
        }

        public Message Peek()
        {
            CheckDisposed();
            return _wrapped.Peek();
        }

        public Message Peek(TimeSpan timeout)
        {
            CheckDisposed();
            return _wrapped.Peek(timeout);
        }

        public Message Peek(TimeSpan timeout, Cursor cursor, PeekAction action)
        {
            CheckDisposed();
            return _wrapped.Peek(timeout, cursor, action);
        }

        public Message PeekById(string id)
        {
            CheckDisposed();
            return _wrapped.PeekById(id);
        }

        public Message PeekById(string id, TimeSpan timeout)
        {
            CheckDisposed();
            return _wrapped.PeekById(id, timeout);
        }

        public Message PeekByCorrelationId(string correlationId)
        {
            CheckDisposed();
            return _wrapped.PeekByCorrelationId(correlationId);
        }

        public Message PeekByCorrelationId(string correlationId, TimeSpan timeout)
        {
            CheckDisposed();
            return _wrapped.PeekByCorrelationId(correlationId, timeout);
        }

        public Message PeekByLookupId(long lookupId)
        {
            CheckDisposed();
            return _wrapped.PeekByLookupId(lookupId);
        }

        public Message PeekByLookupId(MessageLookupAction action, long lookupId)
        {
            CheckDisposed();
            return _wrapped.PeekByLookupId(action, lookupId);
        }

        public void Purge()
        {
            CheckDisposed();
            _wrapped.Purge();
        }

        public Message Receive()
        {
            CheckDisposed();
            return _wrapped.Receive();
        }

        public Message Receive(MessageQueueTransaction transaction)
        {
            CheckDisposed();
            return _wrapped.Receive(transaction);
        }

        public Message Receive(MessageQueueTransactionType transactionType)
        {
            CheckDisposed();
            return _wrapped.Receive(transactionType);
        }

        public Message Receive(TimeSpan timeout)
        {
            CheckDisposed();
            return _wrapped.Receive(timeout);
        }

        public Message Receive(TimeSpan timeout, Cursor cursor)
        {
            CheckDisposed();
            return _wrapped.Receive(timeout, cursor);
        }

        public Message Receive(TimeSpan timeout, MessageQueueTransaction transaction)
        {
            CheckDisposed();
            return _wrapped.Receive(timeout, transaction);
        }

        public Message Receive(TimeSpan timeout, MessageQueueTransactionType transactionType)
        {
            CheckDisposed();
            return _wrapped.Receive(timeout, transactionType);
        }

        public Message Receive(TimeSpan timeout, Cursor cursor, MessageQueueTransaction transaction)
        {
            CheckDisposed();
            return _wrapped.Receive(timeout, cursor, transaction);
        }

        public Message Receive(TimeSpan timeout, Cursor cursor, MessageQueueTransactionType transactionType)
        {
            CheckDisposed();
            return _wrapped.Receive(timeout, cursor, transactionType);
        }

        public Message ReceiveById(string id)
        {
            CheckDisposed();
            return _wrapped.ReceiveById(id);
        }

        public Message ReceiveById(string id, MessageQueueTransaction transaction)
        {
            CheckDisposed();
            return _wrapped.ReceiveById(id, transaction);
        }

        public Message ReceiveById(string id, MessageQueueTransactionType transactionType)
        {
            CheckDisposed();
            return _wrapped.ReceiveById(id, transactionType);
        }

        public Message ReceiveById(string id, TimeSpan timeout)
        {
            CheckDisposed();
            return _wrapped.ReceiveById(id, timeout);
        }

        public Message ReceiveById(string id, TimeSpan timeout, MessageQueueTransaction transaction)
        {
            CheckDisposed();
            return _wrapped.ReceiveById(id, timeout, transaction);
        }

        public Message ReceiveById(string id, TimeSpan timeout, MessageQueueTransactionType transactionType)
        {
            CheckDisposed();
            return _wrapped.ReceiveById(id, timeout, transactionType);
        }

        public Message ReceiveByCorrelationId(string correlationId)
        {
            CheckDisposed();
            return _wrapped.ReceiveByCorrelationId(correlationId);
        }

        public Message ReceiveByCorrelationId(string correlationId, MessageQueueTransaction transaction)
        {
            CheckDisposed();
            return _wrapped.ReceiveByCorrelationId(correlationId, transaction);
        }

        public Message ReceiveByCorrelationId(string correlationId, MessageQueueTransactionType transactionType)
        {
            CheckDisposed();
            return _wrapped.ReceiveByCorrelationId(correlationId, transactionType);
        }

        public Message ReceiveByCorrelationId(string correlationId, TimeSpan timeout)
        {
            CheckDisposed();
            return _wrapped.ReceiveByCorrelationId(correlationId, timeout);
        }

        public Message ReceiveByCorrelationId(string correlationId, TimeSpan timeout,
            MessageQueueTransaction transaction)
        {
            CheckDisposed();
            return _wrapped.ReceiveByCorrelationId(correlationId, timeout, transaction);
        }

        public Message ReceiveByCorrelationId(string correlationId, TimeSpan timeout,
            MessageQueueTransactionType transactionType)
        {
            CheckDisposed();
            return _wrapped.ReceiveByCorrelationId(correlationId, timeout, transactionType);
        }

        public Message ReceiveByLookupId(long lookupId)
        {
            CheckDisposed();
            return _wrapped.ReceiveByLookupId(lookupId);
        }

        public Message ReceiveByLookupId(MessageLookupAction action, long lookupId,
            MessageQueueTransactionType transactionType)
        {
            CheckDisposed();
            return _wrapped.ReceiveByLookupId(action, lookupId, transactionType);
        }

        public Message ReceiveByLookupId(MessageLookupAction action, long lookupId, MessageQueueTransaction transaction)
        {
            CheckDisposed();
            return _wrapped.ReceiveByLookupId(action, lookupId, transaction);
        }

        public void Refresh()
        {
            CheckDisposed();
            _wrapped.Refresh();
        }

        public void Send(object obj)
        {
            CheckDisposed();
            _wrapped.Send(obj);
        }

        public void Send(object obj, MessageQueueTransaction transaction)
        {
            CheckDisposed();
            _wrapped.Send(obj, transaction);
        }

        public void Send(object obj, MessageQueueTransactionType transactionType)
        {
            CheckDisposed();
            _wrapped.Send(obj, transactionType);
        }

        public void Send(object obj, string label)
        {
            CheckDisposed();
            _wrapped.Send(obj, label);
        }

        public void Send(object obj, string label, MessageQueueTransaction transaction)
        {
            CheckDisposed();
            _wrapped.Send(obj, label, transaction);
        }

        public void Send(object obj, string label, MessageQueueTransactionType transactionType)
        {
            CheckDisposed();
            _wrapped.Send(obj, label, transactionType);
        }

        public void ResetPermissions()
        {
            CheckDisposed();
            _wrapped.ResetPermissions();
        }

        public void SetPermissions(string user, MessageQueueAccessRights rights)
        {
            CheckDisposed();
            _wrapped.SetPermissions(user, rights);
        }

        public void SetPermissions(string user, MessageQueueAccessRights rights, AccessControlEntryType entryType)
        {
            CheckDisposed();
            _wrapped.SetPermissions(user, rights, entryType);
        }

        public void SetPermissions(MessageQueueAccessControlEntry ace)
        {
            CheckDisposed();
            _wrapped.SetPermissions(ace);
        }

        public void SetPermissions(AccessControlList dacl)
        {
            CheckDisposed();
            _wrapped.SetPermissions(dacl);
        }

        private void CheckDisposed()
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
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
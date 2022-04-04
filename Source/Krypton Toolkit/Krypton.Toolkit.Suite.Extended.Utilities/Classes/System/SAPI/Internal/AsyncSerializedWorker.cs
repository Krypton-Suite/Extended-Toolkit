#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Internal
{
    internal class AsyncSerializedWorker : IAsyncDispatch
    {
        private AsyncOperation _asyncOperation;

        private SendOrPostCallback _workerPostCallback;

        private Queue _queue;

        private bool _hasPendingPost;

        private bool _isAsyncMode;

        private WaitCallback _workerCallback;

        private WaitCallback _defaultCallback;

        private bool _isEnabled;

        internal bool Enabled
        {
            get
            {
                lock (_queue.SyncRoot)
                {
                    return _isEnabled;
                }
            }
            set
            {
                lock (_queue.SyncRoot)
                {
                    _isEnabled = value;
                }
            }
        }

        internal WaitCallback DefaultCallback
        {
            get
            {
                lock (_queue.SyncRoot)
                {
                    return _defaultCallback;
                }
            }
        }

        internal bool AsyncMode
        {
            get
            {
                lock (_queue.SyncRoot)
                {
                    return _isAsyncMode;
                }
            }
            set
            {
                bool flag = false;
                lock (_queue.SyncRoot)
                {
                    if (_isAsyncMode != value)
                    {
                        _isAsyncMode = value;
                        if (_queue.Count > 0)
                        {
                            flag = true;
                        }
                    }
                }
                if (flag)
                {
                    OnWorkItemPending();
                }
            }
        }

        internal event WaitCallback WorkItemPending;

        internal AsyncSerializedWorker(WaitCallback defaultCallback, AsyncOperation asyncOperation)
        {
            _asyncOperation = asyncOperation;
            _workerPostCallback = WorkerProc;
            Initialize(defaultCallback);
        }

        private void Initialize(WaitCallback defaultCallback)
        {
            _queue = new Queue();
            _hasPendingPost = false;
            _workerCallback = WorkerProc;
            _defaultCallback = defaultCallback;
            _isAsyncMode = true;
            _isEnabled = true;
        }

        public void Post(object evt)
        {
            AddItem(new AsyncWorkItem(DefaultCallback, evt));
        }

        public void Post(object[] evt)
        {
            lock (_queue.SyncRoot)
            {
                if (Enabled)
                {
                    for (int i = 0; i < evt.Length; i++)
                    {
                        AddItem(new AsyncWorkItem(DefaultCallback, evt[i]));
                    }
                }
            }
        }

        public void PostOperation(Delegate callback, params object[] parameters)
        {
            AddItem(new AsyncWorkItem(callback, parameters));
        }

        internal void Purge()
        {
            lock (_queue.SyncRoot)
            {
                _queue.Clear();
            }
        }

        internal AsyncWorkItem NextWorkItem()
        {
            lock (_queue.SyncRoot)
            {
                if (_queue.Count == 0)
                {
                    return null;
                }
                AsyncWorkItem result = (AsyncWorkItem)_queue.Dequeue();
                if (_queue.Count == 0)
                {
                    _hasPendingPost = false;
                }
                return result;
            }
        }

        internal void ConsumeQueue()
        {
            AsyncWorkItem asyncWorkItem;
            while ((asyncWorkItem = NextWorkItem()) != null)
            {
                asyncWorkItem.Invoke();
            }
        }

        private void AddItem(AsyncWorkItem item)
        {
            bool flag = true;
            lock (_queue.SyncRoot)
            {
                if (Enabled)
                {
                    _queue.Enqueue(item);
                    if (!_hasPendingPost || !_isAsyncMode)
                    {
                        flag = false;
                        _hasPendingPost = true;
                    }
                }
            }
            if (!flag)
            {
                OnWorkItemPending();
            }
        }

        private void WorkerProc(object ignored)
        {
            while (true)
            {
                AsyncWorkItem asyncWorkItem;
                lock (_queue.SyncRoot)
                {
                    if (_queue.Count <= 0 || !_isAsyncMode)
                    {
                        if (_queue.Count == 0)
                        {
                            _hasPendingPost = false;
                        }
                        return;
                    }
                    asyncWorkItem = (AsyncWorkItem)_queue.Dequeue();
                }
                asyncWorkItem.Invoke();
            }
        }

        private void OnWorkItemPending()
        {
            if (!_hasPendingPost)
            {
                return;
            }
            if (AsyncMode)
            {
                if (_asyncOperation == null)
                {
                    ThreadPool.QueueUserWorkItem(_workerCallback, null);
                }
                else
                {
                    _asyncOperation.Post(_workerPostCallback, null);
                }
            }
            else if (this.WorkItemPending != null)
            {
                this.WorkItemPending(null);
            }
        }
    }
}

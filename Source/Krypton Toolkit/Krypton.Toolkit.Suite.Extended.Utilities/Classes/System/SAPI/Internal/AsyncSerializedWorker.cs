#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
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

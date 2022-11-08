#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
    internal class OperationLock : IDisposable
    {
        private ManualResetEvent _event = new ManualResetEvent(true);

        private uint _operationCount;

        private object _thisObjectLock = new object();

        public void Dispose()
        {
            _event.Close();
            GC.SuppressFinalize(this);
        }

        internal void StartOperation()
        {
            lock (_thisObjectLock)
            {
                if (_operationCount == 0)
                {
                    _event.Reset();
                }
                _operationCount++;
            }
        }

        internal void FinishOperation()
        {
            lock (_thisObjectLock)
            {
                _operationCount--;
                if (_operationCount == 0)
                {
                    _event.Set();
                }
            }
        }

        internal void WaitForOperationsToFinish()
        {
            _event.WaitOne();
        }
    }
}

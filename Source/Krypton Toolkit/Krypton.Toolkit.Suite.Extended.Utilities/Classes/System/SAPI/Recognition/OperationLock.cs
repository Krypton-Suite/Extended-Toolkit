#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition;

internal class OperationLock : IDisposable
{
    private ManualResetEvent _event = new(true);

    private uint _operationCount;

    private object _thisObjectLock = new();

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
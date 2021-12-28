#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Internal
{
    internal class AsyncWorkItem
    {
        private Delegate _dynamicCallback;

        private object[] _postData;

        internal AsyncWorkItem(Delegate dynamicCallback, params object[] postData)
        {
            _dynamicCallback = dynamicCallback;
            _postData = postData;
        }

        internal void Invoke()
        {
            if ((object)_dynamicCallback != null)
            {
                _dynamicCallback.DynamicInvoke(_postData);
            }
        }
    }
}
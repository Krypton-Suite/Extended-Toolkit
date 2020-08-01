using System;

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
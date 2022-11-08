#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    internal class SpNotifySink : ISpNotifySink
    {
        private WeakReference _eventNotifyReference;

        public SpNotifySink(EventNotify eventNotify)
        {
            _eventNotifyReference = new WeakReference(eventNotify);
        }

        void ISpNotifySink.Notify()
        {
            EventNotify eventNotify = (EventNotify)_eventNotifyReference.Target;
            if (eventNotify != null)
            {
                ThreadPool.QueueUserWorkItem(eventNotify.SendNotification);
            }
        }
    }
}
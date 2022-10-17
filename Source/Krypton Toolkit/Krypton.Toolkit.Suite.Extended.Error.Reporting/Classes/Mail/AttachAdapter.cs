﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    /// <summary>
    /// Provide a plug between incompatible classes that nevertheless need the same "attach" treatment
    /// </summary>
    internal class AttachAdapter : IAttach
    {
        readonly SimpleMapi _mapi;
        readonly MailMessage _mailMessage;

        public AttachAdapter(MailMessage mailMessage)
        {
            _mailMessage = mailMessage;
        }

        public AttachAdapter(SimpleMapi mapi)
        {
            _mapi = mapi;
        }

        public void Attach(string filename)
        {
            if (_mapi != null)
            {
                _mapi.Attach(filename);
            }

            if (_mailMessage != null)
            {
                _mailMessage.Attachments.Add(new Attachment(filename));
            }
        }
    }
}
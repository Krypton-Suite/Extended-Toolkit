#region License and Copyright
/*
 
Copyright (c) Guifreaks - Jacob Mesu
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:
    * Redistributions of source code must retain the above copyright
      notice, this list of conditions and the following disclaimer.
    * Redistributions in binary form must reproduce the above copyright
      notice, this list of conditions and the following disclaimer in the
      documentation and/or other materials provided with the distribution.
    * Neither the name of the Guifreaks nor the
      names of its contributors may be used to endorse or promote products
      derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL <COPYRIGHT HOLDER> BE LIABLE FOR ANY
DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

*/
#endregion

using System;

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    public delegate void NaviBandEventHandler(object sender, NaviBandEventArgs e);

    /// <summary>
    /// Contains additional event info
    /// </summary>
    public class NaviBandEventArgs : EventArgs
    {
        #region Fields

        private NaviBand newActiveBand;
        private bool cancel = false;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the NaviBandEventArgs class
        /// </summary>
        /// <param name="newActiveButton">The new active band</param>
        public NaviBandEventArgs(NaviBand newActiveBand)
           : base()
        {
            this.newActiveBand = newActiveBand;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the new active band
        /// </summary>
        public NaviBand NewActiveBand
        {
            get { return newActiveBand; }
            set { newActiveBand = value; }
        }

        /// <summary>
        /// Gets or sets whether the event is canceled
        /// </summary>
        public bool Canceled
        {
            get { return cancel; }
            set { cancel = value; }
        }

        #endregion
    }

}
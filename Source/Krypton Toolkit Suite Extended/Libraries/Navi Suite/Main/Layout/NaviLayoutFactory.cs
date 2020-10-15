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


namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    /// <summary>
    /// Responsible for reinitializing the LayoutEngine
    /// </summary>
    public class NaviLayoutFactory
    {
        // Fields
        private NaviBar ownerBar;

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the NaviLayoutFactory class 
        /// </summary>
        /// <param name="owner">The owner control</param>
        public NaviLayoutFactory(NaviBar owner)
        {
            ownerBar = owner;
        }

        /// <summary>
        /// Reinitializes the layout
        /// </summary>
        public void ReinitializeLayout()
        {
            if (ownerBar.NaviLayoutEngine != null)
                ownerBar.NaviLayoutEngine.Cleanup();

            if (ownerBar.LayoutStyle == NaviLayoutStyle.StyleFromOwner)
                ownerBar.LayoutStyle = NaviLayoutStyle.Office2007Blue;

            switch (ownerBar.LayoutStyle)
            {
                case NaviLayoutStyle.Office2003Blue:
                case NaviLayoutStyle.Office2003Green:
                case NaviLayoutStyle.Office2003Silver:
                case NaviLayoutStyle.Office2007Blue:
                case NaviLayoutStyle.Office2007Silver:
                case NaviLayoutStyle.Office2007Black:
                case NaviLayoutStyle.Office2010Blue:
                case NaviLayoutStyle.Office2010Silver:
                case NaviLayoutStyle.Office2010Black:
                    ownerBar.NaviLayoutEngine = new NaviLayoutEngineOffice(ownerBar);
                    break;
                default:
                    break;
            }

            ownerBar.NaviLayoutEngine.Initialize();
        }

        #endregion
    }
}
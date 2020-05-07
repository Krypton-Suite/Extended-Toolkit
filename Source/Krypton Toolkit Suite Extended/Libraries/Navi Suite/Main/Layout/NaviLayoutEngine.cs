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

using System.Drawing;
using System.Windows.Forms.Layout;

namespace Krypton.Toolkit.Extended.Navi.Suite
{
    /// <summary>
    /// Contains layout logic defining the view and the functionality of the NavigationBar
    /// </summary>
    public class NaviLayoutEngine : LayoutEngine, IObserver
    {
        // Fields
        private NaviBar ownerBar;

        #region Constructor 

        /// <summary>
        /// Intializes a new instance of the NaviLayoutEngine class
        /// </summary>
        /// <param name="owner">The Bar owner</param>
        public NaviLayoutEngine(NaviBar owner)
        {
            ownerBar = owner;
        }

        #endregion

        #region Properties 

        /// <summary>
        /// The NaviBar to which this layout logic applies
        /// </summary>
        protected NaviBar OwnerBar
        {
            get { return ownerBar; }
        }

        #endregion

        #region Public Virtual Methods

        /// <summary>
        /// Request the engine to clean up resource being used, like local controls
        /// </summary>
        public virtual void Cleanup()
        {
        }

        /// <summary>
        /// Requests the engine to initialize itself
        /// </summary>
        public virtual void Initialize()
        {
        }

        /// <summary>
        /// Initializes the Bands for the first time. This typically occurs when a new band has been added 
        /// or removed
        /// </summary>
        public virtual void InitializeBands()
        {
        }

        /// <summary>
        /// Requests the engine to start the drawing process for the navigation bar
        /// </summary>
        /// <param name="g"></param>
        public virtual void Draw(Graphics g)
        {
        }

        /// <summary>
        /// Requests the engine to start the drawing process for the background of the navigation bar
        /// </summary>
        /// <param name="g"></param>
        public virtual void DrawBackground(Graphics g)
        {
        }

        #endregion

        #region IObserver Members

        /// <summary>
        /// Overriden. Handles the Notification the observable object sent
        /// </summary>
        /// <param name="obj">The observable object</param>
        /// <param name="id">An identification which caused this notification</param>
        /// <param name="arguments">Additional info</param>
        public virtual void Notify(IObservable obj, string id, object arguments)
        {
        }

        #endregion
    }
}
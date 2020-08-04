using System;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class DismissEventArgs : EventArgs
    {
        #region Variables
        private bool _fadeWhenClosing;

        private object[] _optionalArguments;
        #endregion

        #region Properties
        /// <summary>Gets or sets a value indicating whether to [fade selected form when closing].</summary>
        /// <value>
        ///   <c>true</c> if [fade selected form when closing]; otherwise, <c>false</c>.</value>
        public bool FadeWhenClosing { get => _fadeWhenClosing; set => _fadeWhenClosing = value; }

        /// <summary>Gets or sets the optional arguments.</summary>
        /// <value>The optional arguments to run.</value>
        public object[] OptionalArguments { get => _optionalArguments; set => _optionalArguments = value; }
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="DismissEventArgs" /> class.</summary>
        /// <param name="fadeWhenClosing">if set to <c>true</c> [fade selected form when closing].</param>
        public DismissEventArgs(bool fadeWhenClosing) => FadeWhenClosing = fadeWhenClosing;

        /// <summary>Initializes a new instance of the <see cref="DismissEventArgs" /> class.</summary>
        /// <param name="optionalArguments">The optional arguments to run.</param>
        public DismissEventArgs(object[] optionalArguments) => OptionalArguments = optionalArguments;

        /// <summary>Initializes a new instance of the <see cref="DismissEventArgs" /> class.</summary>
        /// <param name="fadeWhenClosing">if set to true [fade selected form when closing].</param>
        /// <param name="optionalArguments">The optional arguments to run.</param>
        public DismissEventArgs(bool fadeWhenClosing, object[] optionalArguments)
        {
            FadeWhenClosing = fadeWhenClosing;

            OptionalArguments = optionalArguments;
        }
        #endregion

        #region Methods
        /*
        public void ProcessOptionalArguments()
        {
            if (OptionalArguments != null)
            {
                Process.Start(OptionalArguments);
            }
        }
        */
        #endregion
    }
}
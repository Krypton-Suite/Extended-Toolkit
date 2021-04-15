#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Diagnostics;

namespace Krypton.Toolkit.Suite.Extended.Notifications
{
    public class LaunchActionEventArgs : EventArgs
    {
        #region Variable
        private string _processName;
        #endregion

        #region Properties
        /// <summary>Gets or sets the type of the action.</summary>
        /// <value>The type of the action.</value>
        public ActionType ActionType { get; set; }

        /// <summary>
        /// Gets or sets the name of the process.
        /// </summary>
        /// <value>
        /// The name of the process.
        /// </value>
        public string ProcessName { get => _processName; set => _processName = value; }
        #endregion

        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="LaunchActionEventArgs" /> class.</summary>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="processName">Name of the process.</param>
        public LaunchActionEventArgs(ActionType actionType, string processName)
        {
            ActionType = actionType;

            ProcessName = processName;
        }

        /// <summary>Initializes a new instance of the <see cref="LaunchActionEventArgs" /> class.</summary>
        /// <param name="processName">Name of the process.</param>
        public LaunchActionEventArgs(string processName)
        {
            ActionType = ActionType.DEFAULT;

            ProcessName = processName;
        }
        #endregion

        #region Methods
        /// <summary>Runs the action.</summary>
        public void RunAction()
        {
            if (ActionType != ActionType.DEFAULT)
            {
                switch (ActionType)
                {
                    case ActionType.LAUCHPROCESS:
                        Process.Start(ProcessName);
                        break;
                    case ActionType.OPEN:
                        Process.Start("explorer.exe", ProcessName);
                        break;
                }
            }
            else
            {
                Process.Start(ProcessName);
            }
        }
        #endregion
    }
}
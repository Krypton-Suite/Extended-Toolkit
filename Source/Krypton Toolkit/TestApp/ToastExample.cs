using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Toast;

namespace TestApp
{
    public partial class ToastExample : KryptonForm
    {
        #region Instance Fields

        private ActionType _actionType = ActionType.Default;

        private ActionButtonLocation _actionButtonLocation = ActionButtonLocation.Left;

        private DefaultNotificationButton _defaultNotificationButton = DefaultNotificationButton.None;

        private IconType _iconType = IconType.None;

        private RightToLeftSupport _rightToLeftSupport = RightToLeftSupport.LeftToRight;

        private ToastNotificationSystemSounds _systemSounds = ToastNotificationSystemSounds.None;

        private ToastNotificationContentAreaType _contentAreaType = ToastNotificationContentAreaType.Label;

        #endregion

        public ToastExample()
        {
            InitializeComponent();
        }
    }
}

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

        #region Setters & Getters

        /// <summary>Sets the ActionType to value.</summary>
        /// <param name="value">The value of the ActionType.</param>
        public void SetActionType(ActionType value) => _actionType = value;

        /// <summary>Gets the ActionType value.</summary>
        /// <returns>The value of the ActionType.</returns>
        public ActionType GetActionType() => _actionType;

        /// <summary>Sets the ActionButtonLocation to value.</summary>
        /// <param name="value">The value of the ActionButtonLocation.</param>
        public void SetActionButtonLocation(ActionButtonLocation value) => _actionButtonLocation = value;

        /// <summary>Gets the ActionButtonLocation value.</summary>
        /// <returns>The value of the ActionButtonLocation.</returns>
        public ActionButtonLocation GetActionButtonLocation() => _actionButtonLocation;

        /// <summary>Sets the DefaultNotificationButton to value.</summary>
        /// <param name="value">The value of the DefaultNotificationButton.</param>
        public void SetDefaultNotificationButton(DefaultNotificationButton value) => _defaultNotificationButton = value;

        /// <summary>Gets the DefaultNotificationButton value.</summary>
        /// <returns>The value of the DefaultNotificationButton.</returns>
        public DefaultNotificationButton GetDefaultNotificationButton() => _defaultNotificationButton;

        /// <summary>Sets the IconType to value.</summary>
        /// <param name="value">The value of the IconType.</param>
        public void SetIconType(IconType value) => _iconType = value;

        /// <summary>Gets the IconType value.</summary>
        /// <returns>The value of the IconType.</returns>
        public IconType GetIconType() => _iconType;

        /// <summary>Sets the RightToLeftSupport to value.</summary>
        /// <param name="value">The value of the RightToLeftSupport.</param>
        public void SetRightToLeftSupport(RightToLeftSupport value) => _rightToLeftSupport = value;

        /// <summary>Gets the RightToLeftSupport value.</summary>
        /// <returns>The value of the RightToLeftSupport.</returns>
        public RightToLeftSupport GetRightToLeftSupport() => _rightToLeftSupport;

        /// <summary>Sets the ToastNotificationSystemSounds to value.</summary>
        /// <param name="value">The value of the ToastNotificationSystemSounds.</param>
        public void SetToastNotificationSystemSounds(ToastNotificationSystemSounds value) => _systemSounds = value;

        /// <summary>Gets the ToastNotificationSystemSounds value.</summary>
        /// <returns>The value of the ToastNotificationSystemSounds.</returns>
        public ToastNotificationSystemSounds GetToastNotificationSystemSounds() => _systemSounds;

        #endregion
    }
}

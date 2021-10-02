#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.ComponentModel.Design;

namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    internal class KryptonMessageBoxConfiguratorActionList : DesignerActionList
    {
        #region Instance Fields
        private readonly KryptonMessageBoxManager _messageBoxConfigurator;

        private readonly IComponentChangeService _service;
        #endregion

        #region Identity
        public KryptonMessageBoxConfiguratorActionList(KryptonMessageBoxConfiguratorDesigner owner) : base(owner.Component)
        {
            _messageBoxConfigurator = owner.Component as KryptonMessageBoxManager;

            _service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
        }
        #endregion

        #region Public
        public ExtendedMessageBoxButtons MessageBoxButtons
        {
            get => _messageBoxConfigurator.MessageBoxButtons;

            set
            {
                if (_messageBoxConfigurator.MessageBoxButtons != value)
                {
                    _service.OnComponentChanged(_messageBoxConfigurator, null, _messageBoxConfigurator.MessageBoxButtons, value);

                    _messageBoxConfigurator.MessageBoxButtons = value;
                }
            }
        }

        public MessageBoxDefaultButton MessageBoxDefaultButton
        {
            get => _messageBoxConfigurator.MessageBoxDefaultButton;

            set
            {
                if (_messageBoxConfigurator.MessageBoxDefaultButton != value)
                {
                    _service.OnComponentChanged(_messageBoxConfigurator, null, _messageBoxConfigurator.MessageBoxDefaultButton, value);

                    _messageBoxConfigurator.MessageBoxDefaultButton = value;
                }
            }
        }

        public string MessageBoxCaption
        {
            get => _messageBoxConfigurator.MessageBoxCaption;

            set
            {
                if (_messageBoxConfigurator.MessageBoxCaption != value)
                {
                    _service.OnComponentChanged(_messageBoxConfigurator, null, _messageBoxConfigurator.MessageBoxCaption, value);

                    _messageBoxConfigurator.MessageBoxCaption = value;
                }
            }
        }

        public string MessageBoxText
        {
            get => _messageBoxConfigurator.MessageBoxContentText;

            set
            {
                if (_messageBoxConfigurator.MessageBoxContentText != value)
                {
                    _service.OnComponentChanged(_messageBoxConfigurator, null, _messageBoxConfigurator.MessageBoxContentText, value);

                    _messageBoxConfigurator.MessageBoxContentText = value;
                }
            }
        }
        #endregion

        #region Public Override
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection actions = new();

            if (_messageBoxConfigurator != null)
            {
                actions.Add(new DesignerActionHeaderItem("Appearance"));

                actions.Add(new DesignerActionPropertyItem("MessageBoxButtons", "MessageBoxButtons", "Appearance", "The buttons for the messagebox."));
            }

            return actions;
        }
        #endregion
    }
}
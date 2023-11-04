#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

using System.ComponentModel.Design;

namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    internal class KryptonMessageBoxConfiguratorActionList : DesignerActionList
    {
        #region Instance Fields
        //private readonly KryptonMessageBoxManagerOld _messageBoxConfigurator;

        private readonly IComponentChangeService _service;
        #endregion

        #region Identity
        public KryptonMessageBoxConfiguratorActionList(KryptonMessageBoxConfiguratorDesigner owner) : base(owner.Component)
        {
            //_messageBoxConfigurator = owner.Component as KryptonMessageBoxManagerOld;

            _service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
        }
        #endregion

        #region Public
        //public ExtendedMessageBoxButtons MessageBoxButtons
        //{
        //    get => _messageBoxConfigurator.MessageBoxButtons;

        //    set
        //    {
        //        if (_messageBoxConfigurator.MessageBoxButtons != value)
        //        {
        //            _service.OnComponentChanged(_messageBoxConfigurator, null, _messageBoxConfigurator.MessageBoxButtons, value);

        //            _messageBoxConfigurator.MessageBoxButtons = value;
        //        }
        //    }
        //}

        //public KryptonMessageBoxDefaultButton KryptonMessageBoxDefaultButton
        //{
        //    get => _messageBoxConfigurator.KryptonMessageBoxDefaultButton;

        //    set
        //    {
        //        if (_messageBoxConfigurator.KryptonMessageBoxDefaultButton != value)
        //        {
        //            _service.OnComponentChanged(_messageBoxConfigurator, null, _messageBoxConfigurator.KryptonMessageBoxDefaultButton, value);

        //            _messageBoxConfigurator.KryptonMessageBoxDefaultButton = value;
        //        }
        //    }
        //}

        //public string MessageBoxCaption
        //{
        //    get => _messageBoxConfigurator.MessageBoxCaption;

        //    set
        //    {
        //        if (_messageBoxConfigurator.MessageBoxCaption != value)
        //        {
        //            _service.OnComponentChanged(_messageBoxConfigurator, null, _messageBoxConfigurator.MessageBoxCaption, value);

        //            _messageBoxConfigurator.MessageBoxCaption = value;
        //        }
        //    }
        //}

        //public string MessageBoxText
        //{
        //    get => _messageBoxConfigurator.MessageBoxContentText;

        //    set
        //    {
        //        if (_messageBoxConfigurator.MessageBoxContentText != value)
        //        {
        //            _service.OnComponentChanged(_messageBoxConfigurator, null, _messageBoxConfigurator.MessageBoxContentText, value);

        //            _messageBoxConfigurator.MessageBoxContentText = value;
        //        }
        //    }
        //}
        #endregion

        #region Public Override
        //public override DesignerActionItemCollection GetSortedActionItems()
        //{
        //    DesignerActionItemCollection actions = new();

        //    if (_messageBoxConfigurator != null)
        //    {
        //        actions.Add(new DesignerActionHeaderItem("Appearance"));

        //        actions.Add(new DesignerActionPropertyItem("MessageBoxButtons", "MessageBoxButtons", "Appearance", "The buttons for the messagebox."));
        //    }

        //    return actions;
        //}
        #endregion
    }
}
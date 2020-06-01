using System;
using System.ComponentModel;

namespace Krypton.Toolkit.Suite.Extended.Task.Dialogs
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public sealed class TaskDialogFooter : TaskDialogControl
    {
        private string _text;

        private TaskDialogIcon _icon;

        private IntPtr _iconHandle;

        private bool _boundFooterIconIsFromHandle;

        /// <summary>
        /// 
        /// </summary>
        public TaskDialogFooter()
            : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public TaskDialogFooter(string text)
            : this()
        {
            _text = text;
        }

        /// <summary>
        /// Gets or sets the text to be displayed in the dialog's footer area.
        /// </summary>
        /// <remarks>
        /// This property can be set while the dialog is shown.
        /// </remarks>
        public string Text
        {
            get => _text;

            set
            {
                DenyIfBoundAndNotCreated();
                DenyIfWaitingForInitialization();

                // Update the text if we are bound.
                BoundPage?.BoundTaskDialog.UpdateTextElement(
                        TaskDialogTextElement.TDE_FOOTER,
                        value);

                _text = value;
            }
        }

        /// <summary>
        /// Gets or sets the footer icon, if <see cref="IconHandle"/> is
        /// <see cref="IntPtr.Zero"/>.
        /// </summary>
        /// <remarks>
        /// This property can be set while the dialog is shown.
        /// </remarks>
        [DefaultValue(TaskDialogIcon.None)]
        public TaskDialogIcon Icon
        {
            get => _icon;

            set
            {
                // See comments in property "TaskDialogPage.Icon".
                if (value < ushort.MinValue || (int)value > ushort.MaxValue)
                    throw new ArgumentOutOfRangeException(nameof(value));

                DenyIfBoundAndNotCreated();
                DenyIfWaitingForInitialization();

                if (BoundPage != null &&
                        _boundFooterIconIsFromHandle)
                    throw new InvalidOperationException();

                BoundPage?.BoundTaskDialog.UpdateIconElement(
                        TaskDialogIconElement.TDIE_ICON_FOOTER,
                        (IntPtr)value);

                _icon = value;
            }
        }

        /// <summary>
        /// Gets or sets the handle to the footer icon. When this member is not
        /// <see cref="IntPtr.Zero"/>, the <see cref="Icon"/> property will
        /// be ignored.
        /// </summary>
        /// <remarks>
        /// This property can be set while the dialog is shown.
        /// </remarks>
        [Browsable(false)]
        public IntPtr IconHandle
        {
            get => _iconHandle;

            set
            {
                DenyIfBoundAndNotCreated();
                DenyIfWaitingForInitialization();

                if (BoundPage != null &&
                        !_boundFooterIconIsFromHandle)
                    throw new InvalidOperationException();

                BoundPage?.BoundTaskDialog.UpdateIconElement(
                        TaskDialogIconElement.TDIE_ICON_FOOTER,
                        value);

                _iconHandle = value;
            }
        }

        internal override bool IsCreatable
        {
            get => base.IsCreatable && !TaskDialogPage.IsNativeStringNullOrEmpty(_text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _text ?? base.ToString();
        }

        internal TaskDialogFlags Bind(TaskDialogPage page, out IntPtr footerIconValue)
        {
            TaskDialogFlags result = base.Bind(page);

            footerIconValue = _boundFooterIconIsFromHandle ?
                    _iconHandle :
                    (IntPtr)_icon;

            return result;
        }

        private protected override TaskDialogFlags BindCore()
        {
            TaskDialogFlags flags = base.BindCore();

            _boundFooterIconIsFromHandle = _iconHandle != IntPtr.Zero;

            if (_boundFooterIconIsFromHandle)
                flags |= TaskDialogFlags.TDF_USE_HICON_FOOTER;

            return flags;
        }

        private protected override void UnbindCore()
        {
            _boundFooterIconIsFromHandle = false;

            base.UnbindCore();
        }
    }
}
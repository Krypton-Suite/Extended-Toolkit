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

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    public class KryptonDateTimePickerToolStripItem : ToolStripControlHostFixed
    {
        #region Public

        [RefreshProperties(RefreshProperties.All), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KryptonDateTimePicker DateTimePickerControl => Control as KryptonDateTimePicker;

        #endregion

        #region Exposed Properties

        public bool AlwaysActive
        {
            get => ((KryptonDateTimePicker)Control).AlwaysActive;

            set => ((KryptonDateTimePicker)Control).AlwaysActive = value;
        }

        public bool AllowButtonSpecToolTips
        {
            get => ((KryptonDateTimePicker)Control).AllowButtonSpecToolTips;

            set => ((KryptonDateTimePicker)Control).AllowButtonSpecToolTips = value;
        }

        public bool AllowButtonSpecToolTipPrioity
        {
            get => ((KryptonDateTimePicker)Control).AllowButtonSpecToolTipPriority;

            set => ((KryptonDateTimePicker)Control).AllowButtonSpecToolTipPriority = value;
        }

        public bool AutoShift
        {
            get => ((KryptonDateTimePicker)Control).AutoShift;

            set => ((KryptonDateTimePicker)Control).AutoShift = value;
        }

        public bool Checked
        {
            get => ((KryptonDateTimePicker)Control).Checked;

            set => ((KryptonDateTimePicker)Control).Checked = value;
        }

        public bool ShowUpDown
        {
            get => ((KryptonDateTimePicker)Control).ShowUpDown;

            set => ((KryptonDateTimePicker)Control).ShowUpDown = value;
        }

        public bool ShowCheckBox
        {
            get => ((KryptonDateTimePicker)Control).ShowCheckBox;

            set => ((KryptonDateTimePicker)Control).ShowCheckBox = value;
        }

        public bool UseMnemonic
        {
            get => ((KryptonDateTimePicker)Control).UseMnemonic;

            set => ((KryptonDateTimePicker)Control).UseMnemonic = value;
        }

        public bool CalendarShowTodayCircle
        {
            get => ((KryptonDateTimePicker)Control).CalendarShowTodayCircle;

            set => ((KryptonDateTimePicker)Control).CalendarShowTodayCircle = value;
        }

        public bool CalendarShowWeekNumbers
        {
            get => ((KryptonDateTimePicker)Control).CalendarShowWeekNumbers;

            set => ((KryptonDateTimePicker)Control).CalendarShowWeekNumbers = value;
        }

        public bool CalendarCloseOnTodayClick
        {
            get => ((KryptonDateTimePicker)Control).CalendarCloseOnTodayClick;

            set => ((KryptonDateTimePicker)Control).CalendarCloseOnTodayClick = value;
        }

        public bool CalendarShowToday
        {
            get => ((KryptonDateTimePicker)Control).CalendarShowToday;

            set => ((KryptonDateTimePicker)Control).CalendarShowToday = value;
        }

        public bool RightToLeftLayout
        {
            get => ((KryptonDateTimePicker)Control).RightToLeftLayout;

            set => ((KryptonDateTimePicker)Control).RightToLeftLayout = value;
        }

        public bool IsActive => ((KryptonDateTimePicker)Control).IsActive;

        public bool IsMouseOver => ((KryptonDateTimePicker)Control).IsMouseOver;

        public bool IsDropped => ((KryptonDateTimePicker)Control).IsDropped;

        public bool ShowAdornments
        {
            set => ((KryptonDateTimePicker)Control).ShowAdornments = value;
        }

        public bool ShowBorder
        {
            set => ((KryptonDateTimePicker)Control).ShowBorder = value;
        }

        public CheckBoxImages Images => ((KryptonDateTimePicker)Control).Images;

        public DateTime? CalendarTodayDate
        {
            get => ((KryptonDateTimePicker)Control).CalendarTodayDate;

            set => ((KryptonDateTimePicker)Control).CalendarTodayDate = (DateTime)value!;
        }

        public DateTime[]? CalendarAnnuallyBoldedDates
        {
            get => ((KryptonDateTimePicker)Control).CalendarAnnuallyBoldedDates;

            set => ((KryptonDateTimePicker)Control).CalendarAnnuallyBoldedDates = value;
        }

        public DateTime[]? CalendarMonthlyBoldedDates
        {
            get => ((KryptonDateTimePicker)Control).CalendarMonthlyBoldedDates;

            set => ((KryptonDateTimePicker)Control).CalendarMonthlyBoldedDates = value;
        }

        public DateTime[]? CalendarBoldedDates
        {
            get => ((KryptonDateTimePicker)Control).CalendarBoldedDates;

            set => ((KryptonDateTimePicker)Control).CalendarBoldedDates = value;
        }

        public DateTime Value
        {
            get => ((KryptonDateTimePicker)Control).Value;

            set => ((KryptonDateTimePicker)Control).Value = value;
        }

        public DateTime MaxDate
        {
            get => ((KryptonDateTimePicker)Control).MaxDate;

            set => ((KryptonDateTimePicker)Control).MaxDate = value;
        }

        public DateTime MinDate
        {
            get => ((KryptonDateTimePicker)Control).MinDate;

            set => ((KryptonDateTimePicker)Control).MinDate = value;
        }

        public DateTimePickerFormat Format
        {
            get => ((KryptonDateTimePicker)Control).Format;

            set => ((KryptonDateTimePicker)Control).Format = value;
        }

        public Day CalendarFirstDayOfWeek
        {
            get => ((KryptonDateTimePicker)Control).CalendarFirstDayOfWeek;

            set => ((KryptonDateTimePicker)Control).CalendarFirstDayOfWeek = value;
        }

        public KryptonDateTimePicker.DateTimePickerButtonSpecCollection ButtonSpecs =>
            ((KryptonDateTimePicker)Control).ButtonSpecs;

        public LeftRightAlignment DropDownAlign
        {
            get => ((KryptonDateTimePicker)Control).DropDownAlign;

            set => ((KryptonDateTimePicker)Control).DropDownAlign = value;
        }

        public InputControlStyle InputControlStyle
        {
            get => ((KryptonDateTimePicker)Control).InputControlStyle;

            set => ((KryptonDateTimePicker)Control).InputControlStyle = value;
        }

        public object? ValueNullable
        {
            get => ((KryptonDateTimePicker)Control).ValueNullable;

            set => ((KryptonDateTimePicker)Control).ValueNullable = value;
        }

        public string CalendarTodayText
        {
            get => ((KryptonDateTimePicker)Control).CalendarTodayText;

            set => ((KryptonDateTimePicker)Control).CalendarTodayText = value;
        }

        public string? CustomFormat
        {
            get => ((KryptonDateTimePicker)Control).CustomFormat;

            set => ((KryptonDateTimePicker)Control).CustomFormat = value;
        }

        public string CustomNullText
        {
            get => ((KryptonDateTimePicker)Control).CustomNullText;

            set => ((KryptonDateTimePicker)Control).CustomNullText = value;
        }

        public string CalendarTodayFormat
        {
            get => ((KryptonDateTimePicker)Control).CalendarTodayFormat;

            set => ((KryptonDateTimePicker)Control).CalendarTodayFormat = value;
        }

        public string ActiveFragment
        {
            get => ((KryptonDateTimePicker)Control).ActiveFragment;

            set => ((KryptonDateTimePicker)Control).ActiveFragment = value;
        }

        public HeaderStyle CalendarHeaderStyle
        {
            get => ((KryptonDateTimePicker)Control).CalendarHeaderStyle;

            set => ((KryptonDateTimePicker)Control).CalendarHeaderStyle = value;
        }

        public ButtonStyle CalendarDayStyle
        {
            get => ((KryptonDateTimePicker)Control).CalendarDayStyle;

            set => ((KryptonDateTimePicker)Control).CalendarDayStyle = value;
        }

        public ButtonStyle CalendarDayOfWeekStyle
        {
            get => ((KryptonDateTimePicker)Control).CalendarDayOfWeekStyle;

            set => ((KryptonDateTimePicker)Control).CalendarDayOfWeekStyle = value;
        }

        public ButtonStyle UpDownButtonStyle
        {
            get => ((KryptonDateTimePicker)Control).UpDownButtonStyle;

            set => ((KryptonDateTimePicker)Control).UpDownButtonStyle = value;
        }

        public ButtonStyle DropButtonStyle
        {
            get => ((KryptonDateTimePicker)Control).DropButtonStyle;

            set => ((KryptonDateTimePicker)Control).DropButtonStyle = value;
        }

        public ToolTipManager ToolTipManager => ((KryptonDateTimePicker)Control).ToolTipManager;

        #endregion

        #region Exposed Events

        public event EventHandler? ValueChanged;

        protected void OnValueChanged(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }

        #endregion

        #region Identity

        public KryptonDateTimePickerToolStripItem() : base(new KryptonDateTimePicker()) => AutoSize = false;

        #endregion

        #region Overrides

        public override Size GetPreferredSize(Size constrainingSize) => DateTimePickerControl.GetPreferredSize(constrainingSize);

        protected override void OnSubscribeControlEvents(Control? control)
        {
            base.OnSubscribeControlEvents(control);

            ((control as KryptonDateTimePicker)!).ValueChanged += OnValueChanged;
        }

        protected override void OnUnsubscribeControlEvents(Control control)
        {
            base.OnUnsubscribeControlEvents(control);

            ((KryptonDateTimePicker)control).ValueChanged -= OnValueChanged;
        }

        #endregion
    }
}
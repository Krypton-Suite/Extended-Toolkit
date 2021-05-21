using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

using Microsoft.VisualBasic;

namespace Krypton.Toolkit.Suite.Extended.Calendar.Library
{
    public enum DateMode
    {
        OneDay = 0,
        FiveDay = 1,
        SevenDay = 2,
        Month = 3
    }


    [System.Drawing.ToolboxBitmap(typeof(MonthCalendar)), ToolboxItem(false)]
    public partial class Calendar : DataGridView
    {
        #region Design Code
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        #endregion
        #endregion

        private bool _english = false;
        public bool English
        {
            get
            {
                return _english;
            }
            set
            {
                if (value)
                {
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US", false);
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", false);
                }
                else
                {
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.InstalledUICulture;
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(CultureInfo.InstalledUICulture.ToString(), false);

                }
                _english = value;
            }
        }

        private bool _showWeekNumbers = true;
        /// <summary>
        /// Shows the week numbers
        /// </summary>
        public bool ShowWeekNumbers
        {
            get
            {
                return _showWeekNumbers;
            }
            set
            {
                _showWeekNumbers = value;

                switch (DateMode)
                {
                    case DateMode.SevenDay:
                    case DateMode.Month:
                        RowHeadersVisible = value;
                        break;
                    default:
                        break;
                }

            }
        }

        private bool _showTimes = true;
        /// <summary>
        /// Shows a Row with the time
        /// </summary>
        public bool ShowDayTimes
        {
            get
            {
                return _showTimes;
            }
            set
            {
                _showTimes = value;

                switch (DateMode)
                {
                    case DateMode.FiveDay:
                    case DateMode.OneDay:
                        RowHeadersVisible = value;
                        break;
                    default:
                        break;
                }

            }
        }

        private List<string> m_clickedItemsList = null;
        private string m_clickedItemsCSV = "";

        private DateMode m_dateMode = DateMode.OneDay;
        private DateTime m_startTime = DateTime.Now;
        private List<CalendarItem> m_items = null;
        internal Dictionary<CalendarItem, int> OverlapCount = new Dictionary<CalendarItem, int>();
        internal Dictionary<CalendarItem, int> OrderCount = new Dictionary<CalendarItem, int>();

        private DataTable m_dt = new DataTable();
        //private string FieldStartTime;
        //private string FieldEndTime;
        //private string FieldDescription;
        //private string FieldTenatative;
        //private string FieldKey;

        private bool m_enableAppointmentAddContextMenu = false;
        private ToolStripMenuItem menuItemNewAppointment;

        public delegate void ClickedEventHandler(string newList);
        public event ClickedEventHandler ListChanged;

        public static ColourTable ct = new ColourTable();



        public Calendar()
        {
            InitializeComponent();

            //(1) To remove flicker we use double buffering for drawing
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            m_items = new List<CalendarItem>();
            this.ReadOnly = true;
            this.AllowUserToAddRows = false;
            this.AllowUserToOrderColumns = false;
            this.AllowUserToResizeRows = false;
            this.AllowUserToResizeColumns = false;
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            InitialiseDisplay();

            this.SizeChanged += new EventHandler(Calendar_SizeChanged);
            this.ListChanged += new ClickedEventHandler(Calendar_ListChanged);

            //context Menu
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            menuItemNewAppointment = new ToolStripMenuItem("New Appointment");
            contextMenuStrip.Items.Add(menuItemNewAppointment);
            menuItemNewAppointment.Click += new EventHandler(item_Click);
            this.ContextMenuStrip = contextMenuStrip;

        }

        private void item_Click(object sender, EventArgs e)
        {
            try
            {

                Calendar cal = this;
                if (m_enableAppointmentAddContextMenu)
                {
                    AddAppointment AppAdd = new AddAppointment(ref cal);
                    AppAdd.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

        private void Calendar_ListChanged(string newList)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        private void Calendar_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                switch (DateMode)
                {
                    case DateMode.SevenDay:
                        int height = (int)((this.Height - this.Columns[0].HeaderCell.Size.Height - 2) / 3);
                        for (int i = 0; i < 3; i++)
                            this.Rows[i].Height = height;
                        break;
                    case DateMode.Month:
                        height = (int)((this.Height - this.Columns[0].HeaderCell.Size.Height - 2) / 5);
                        for (int i = 0; i < 5; i++)
                            this.Rows[i].Height = height;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // Calling the base class OnPaint
            base.OnPaint(pe);
        }

        public List<string> ClickedItemsList
        {
            get
            {
                return m_clickedItemsList;
            }

        }

        public string ClickedItemsCSV
        {
            get
            {
                return m_clickedItemsCSV;
            }

        }

        public DataTable BoundData
        {
            get
            {
                return m_dt;
            }
            set
            {
                // SetData(m_dt);
                InitialiseDisplay();
                m_dt = value;
            }
        }

        public bool EnableAppointmentAddContextMenu
        {
            get
            {
                return m_enableAppointmentAddContextMenu;
            }
            set
            {
                m_enableAppointmentAddContextMenu = value;
                InitialiseDisplay();
            }
        }

        public DateMode DateMode
        {
            get
            {
                return m_dateMode;
            }
            set
            {
                m_dateMode = value;
                InitialiseDisplay();
            }
        }

        public DateTime StartTime
        {
            get
            {
                DateTime d = new DateTime(m_startTime.Year, m_startTime.Month, m_startTime.Day);
                if (this.DateMode == DateMode.OneDay || d.DayOfWeek == DayOfWeek.Monday)
                    return d;
                else
                {
                    // Get the previous Monday
                    while (d.DayOfWeek != DayOfWeek.Monday)
                        d = d.Subtract(new System.TimeSpan(1, 0, 0, 0));
                    return d;
                }
            }
            set
            {
                if (!m_startTime.Equals(value))
                {
                    m_startTime = value;
                    InitialiseDisplay();
                }
            }
        }

        public DateTime EndTime
        {
            get
            {
                if (this.DateMode == DateMode.OneDay)
                    return this.StartTime.AddDays(1);
                else if (this.DateMode == DateMode.FiveDay)
                    return this.StartTime.AddDays(5);
                else if (this.DateMode == DateMode.SevenDay)
                    return this.StartTime.AddDays(7);
                else
                    return this.StartTime.AddDays(35);
            }
        }

        public List<CalendarItem> CalendarItems
        {
            get
            {
                return m_items;
            }
            set
            {
                m_items = value;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (keyData == Keys.Escape)
                {
                    this.ClearSelection();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
                return false;
            }
        }

        public void InitialiseDisplay()
        {
            try
            {
                if (this.ColumnCount > 0)
                    this.Columns.Clear();

                //setHeader
                this.EnableHeadersVisualStyles = false;

                this.ColumnHeadersDefaultCellStyle.BackColor = ct.BackColor;
                this.ColumnHeadersDefaultCellStyle.ForeColor = ct.HeaderText;
                this.ColumnHeadersDefaultCellStyle.Font = ct.FontStd;
                this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                this.GridColor = ct.SeparatorDark;
                this.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                this.BackgroundColor = ct.BackColor;

                switch (DateMode)
                {
                    case DateMode.OneDay:
                        this.RowHeadersVisible = true;
                        this.ColumnHeadersVisible = true;
                        DayColumn dc = new DayColumn(this.StartTime);
                        this.Columns.Add(dc);
                        this.RowCount = 48;
                        for (int i = 0; i < this.RowCount; i++)
                            this.Rows[i].HeaderCell = new HalfHourRowHeaderCell();
                        this.RowHeadersWidth = 50;
                        this.ColumnHeadersHeight = 20;
                        this.FirstDisplayedScrollingRowIndex = 16;
                        this.MultiSelect = true;
                        break;
                    case DateMode.FiveDay:
                        this.RowHeadersVisible = true;
                        this.ColumnHeadersVisible = true;
                        for (int i = 0; i < 5; i++)
                        {
                            DayColumn d = new DayColumn(this.StartTime.AddDays(i));
                            this.Columns.Add(d);
                        }
                        this.RowCount = 48;
                        this.FirstDisplayedScrollingRowIndex = 16;
                        for (int i = 0; i < this.RowCount; i++)
                            this.Rows[i].HeaderCell = new HalfHourRowHeaderCell();
                        this.RowHeadersWidth = 50;
                        this.ColumnHeadersHeight = 50;
                        this.MultiSelect = true;
                        break;
                    case DateMode.SevenDay:
                        HalfWeekColumn hc1 = new HalfWeekColumn(this.StartTime);
                        HalfWeekColumn hc2 = new HalfWeekColumn(this.StartTime.AddDays(3));
                        this.Columns.AddRange(hc1, hc2);
                        this.RowCount = 3;
                        DateTime ch = StartTime;
                        for (int i = 0; i < this.RowCount; i++)
                        {
                            CultureInfo ci = CultureInfo.CurrentCulture;
                            int w = ci.Calendar.GetWeekOfYear(ch, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
                            this.Rows[i].HeaderCell = new WeekRowHeaderCell(w);

                        }
                        this.RowHeadersVisible = ShowWeekNumbers;
                        this.ColumnHeadersVisible = false;
                        this.ColumnHeadersHeight = 50;
                        this.MultiSelect = true;
                        int height = (int)((this.Height - this.Columns[0].HeaderCell.Size.Height - 2) / 3);
                        for (int i = 0; i < 3; i++)
                            this.Rows[i].Height = height;
                        break;
                    case DateMode.Month:
                        this.RowHeadersVisible = ShowWeekNumbers;
                        this.ColumnHeadersVisible = true;
                        this.RowTemplate = new WeekRow();
                        for (int i = 0; i < 6; i++)
                        {
                            WeekDayColumn c = new WeekDayColumn();
                            c.DisplayIndex = i;
                            this.Columns.Add(c);
                        }
                        this.MultiSelect = true;
                        this.RowCount = 5;
                        DateTime ch2 = StartTime;
                        for (int i = 0; i < this.RowCount; i++)
                        {
                            CultureInfo ci = CultureInfo.CurrentCulture;
                            int w = ci.Calendar.GetWeekOfYear(ch2, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
                            this.Rows[i].HeaderCell = new DayRowHeaderCell(w);
                            ch2 = ch2.AddDays(7);
                        }
                        this.ColumnHeadersHeight = 20;
                        height = (int)((this.Height - this.Columns[0].HeaderCell.Size.Height - 2) / 5);

                        for (int i = 0; i < 5; i++)
                            this.Rows[i].Height = height;

                        break;

                    default:
                        break;
                }
                this.ClearSelection();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }


        public void SetData(DataTable dt, string StartTimeFieldName, string EndTimeFieldName, string DescriptionFieldName, string TenatativeFieldName, string KeyFieldName, string ColorFieldName)
        {
            DataView dv = new DataView(dt);
            int i = 0;

            this.CalendarItems.Clear();

            for (i = 0; i < dv.Count; i++)
            {
                DateTime startTime = DateTime.Parse(dv[i][StartTimeFieldName].ToString());
                DateTime endTime = DateTime.Parse(dv[i][EndTimeFieldName].ToString());

                bool Tentative = false;
                if (TenatativeFieldName != null) bool.TryParse(dv[i][TenatativeFieldName].ToString(), out Tentative);

                string Key = "";
                if (KeyFieldName != null) Key = dv[i][KeyFieldName].ToString();

                string ItemColor = "White";
                if (ColorFieldName != null) ItemColor = dv[i][ColorFieldName].ToString();

                this.CalendarItems.Add(new CalendarItem(startTime, endTime, dv[i][DescriptionFieldName].ToString(), (bool)Tentative, Key, ItemColor));
            }

        }

        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            DataRow dr1;

            //StartTime, EndTime, Description, Key, Tentative, Color
            dt.Columns.Add(new DataColumn("StartTime", System.Type.GetType("System.DateTime")));
            dt.Columns.Add(new DataColumn("EndTime", System.Type.GetType("System.DateTime")));
            dt.Columns.Add(new DataColumn("Description", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("Key", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("Tentative", System.Type.GetType("System.Boolean")));
            dt.Columns.Add(new DataColumn("Color", System.Type.GetType("System.String")));

            for (int i = 0; i < this.CalendarItems.Count; i++)
            {
                dr1 = dt.NewRow();
                dr1[0] = CalendarItems[i].StartTime;
                dr1[1] = CalendarItems[i].EndTime;
                dr1[2] = CalendarItems[i].Description;
                dr1[3] = CalendarItems[i].Key;
                dr1[4] = CalendarItems[i].IsTentative;
                dr1[5] = CalendarItems[i].Colour;
                dt.Rows.Add(dr1);
            }
            return dt;
        }

        private DataGridViewCell clickedCell;

        private void MouseClickManagement(MouseEventArgs e)
        {
            //reinit values
            List<string> ClickedValues = new List<string>();
            m_clickedItemsList = new List<string>();

            string ClickedValuesString = "";
            m_clickedItemsCSV = "";

            //get the Cell
            DataGridView.HitTestInfo hit = this.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.Cell)
            {
                clickedCell =
                    this.Rows[hit.RowIndex].Cells[hit.ColumnIndex];
            }


            //hour cell?
            try
            {
                HalfHourCell hhc = (HalfHourCell)clickedCell;
                for (int i = 0; i < hhc.CalendarItems.Count; i++)
                {
                    ClickedValues.Add(hhc.CalendarItems[i].Key);
                    ClickedValuesString += hhc.CalendarItems[i].Key + ",";
                }

            }
            catch { }


            //day cell?
            try
            {
                DayCell hhc = (DayCell)clickedCell;
                for (int i = 0; i < hhc.CalendarItems.Count; i++)
                {
                    ClickedValues.Add(hhc.CalendarItems[i].Key);
                    ClickedValuesString += hhc.CalendarItems[i].Key + ",";
                }
            }
            catch { }

            if (ClickedValues.Count > 0)
            {
                m_clickedItemsList = ClickedValues;
                //less the last ,
                m_clickedItemsCSV = Strings.Left(ClickedValuesString, Strings.Len(ClickedValuesString) - 1);

                //raise event Change List
                this.ListChanged(m_clickedItemsCSV);
            }
            else
            {
                this.ListChanged("");
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            MouseClickManagement(e);
            base.OnMouseDoubleClick(e);

        }

        private DataGridView.HitTestInfo _hitLast;

        protected override void OnMouseClick(MouseEventArgs e)
        {
            //MouseClickManagement(e);
            if (e.Button == MouseButtons.Right)
            {
                //get the Cell
                DataGridView.HitTestInfo hit = this.HitTest(e.X, e.Y);
                if (hit.Type == DataGridViewHitTestType.Cell)
                {
                    //pass values
                    _hitLast = hit;

                    //get the cell
                    clickedCell = this.Rows[hit.RowIndex].Cells[hit.ColumnIndex];

                    //debug
                    //MessageBox.Show(clickedCell.Value.ToString());
                }
            }
            base.OnMouseClick(e);

        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (m_enableAppointmentAddContextMenu)
                {
                    menuItemNewAppointment.Visible = true;
                }
                else
                {
                    menuItemNewAppointment.Visible = false;
                }
            }

            //MouseClickManagement(e);
            base.OnMouseDown(e);

        }
        public CalendarTimeSpan SelectedDates
        {
            get
            {
                CalendarTimeSpan ts = new CalendarTimeSpan();
                List<DateTime> dtms = new List<DateTime>();
                if (SelectedCells.Count > 0)
                {
                    foreach (DataGridViewCell item in SelectedCells)
                    {
                        if (item is HalfHourCell)
                        {
                            HalfHourCell hc = item as HalfHourCell;
                            dtms.Add(hc.EndTime);
                            dtms.Add(hc.StartTime);
                        }
                        else if (item is DayCell)
                        {
                            DayCell dc = item as DayCell;
                            dtms.Add(dc.StartTime);
                        }

                    }
                    dtms.Sort();
                    if (dtms.Count > 0)
                    {
                        ts.Start = dtms[0];
                        ts.End = dtms[dtms.Count - 1];
                        return ts;
                    }
                }
                return null;
            }

        }

    }
}
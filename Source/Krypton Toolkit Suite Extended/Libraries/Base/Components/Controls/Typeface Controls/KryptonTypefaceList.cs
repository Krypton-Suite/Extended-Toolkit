using Krypton.Toolkit.Extended.Common;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class KryptonTypefaceList : UserControl
    {
        #region Designer Code
        private Toolkit.KryptonTextBox ktxtTypeface;

        private void InitializeComponent()
        {
            this.ktxtTypeface = new Toolkit.KryptonTextBox();
            this.lbTypefaceList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ktxtTypeface
            // 
            this.ktxtTypeface.Dock = System.Windows.Forms.DockStyle.Top;
            this.ktxtTypeface.Hint = "Search...";
            this.ktxtTypeface.Location = new System.Drawing.Point(0, 0);
            this.ktxtTypeface.Name = "ktxtTypeface";
            this.ktxtTypeface.Size = new System.Drawing.Size(339, 29);
            this.ktxtTypeface.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxtTypeface.StateCommon.Content.TextH = Toolkit.PaletteRelativeAlign.Inherit;
            this.ktxtTypeface.TabIndex = 0;
            this.ktxtTypeface.TextChanged += new System.EventHandler(this.ktxtTypeface_TextChanged);
            this.ktxtTypeface.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ktxtTypeface_MouseClick);
            // 
            // lbTypefaceList
            // 
            this.lbTypefaceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTypefaceList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTypefaceList.FormattingEnabled = true;
            this.lbTypefaceList.ItemHeight = 21;
            this.lbTypefaceList.Location = new System.Drawing.Point(0, 29);
            this.lbTypefaceList.Name = "lbTypefaceList";
            this.lbTypefaceList.Size = new System.Drawing.Size(339, 458);
            this.lbTypefaceList.TabIndex = 1;
            this.lbTypefaceList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbTypefaceList_DrawItem);
            this.lbTypefaceList.SelectedIndexChanged += new System.EventHandler(this.lbTypefaceList_SelectedIndexChanged);
            this.lbTypefaceList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbTypefaceList_KeyDown);
            // 
            // KryptonTypefaceList
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lbTypefaceList);
            this.Controls.Add(this.ktxtTypeface);
            this.Name = "KryptonTypefaceList";
            this.Size = new System.Drawing.Size(339, 487);
            this.Load += new System.EventHandler(this.KryptonTypefaceList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Variables
        private Font _typeface;

        public RecentlyUsedList<Font> _recentlyUsed = new RecentlyUsedList<Font>(5);

        private int _lastSelectedIndex = -1;
        private ListBox lbTypefaceList;
        #endregion

        #region Events
        public event EventHandler SelectedFontFamilyChanged;
        #endregion

        #region Properties
        public Font Typeface { get => _typeface; set { _typeface = value; Invalidate(); } }

        private int AllFontsSectionIndex => _recentlyUsed.Count + 1;

        private int AllFontsStartIndex => _recentlyUsed.Count + 2;

        public FontFamily SelectedFontFamily
        {
            get
            {
                if (lbTypefaceList.SelectedItem != null)
                {
                    return ((Font)lbTypefaceList.SelectedItem).FontFamily;
                }
                else
                {
                    return null;
                }
            }

            set
            {
                if (value == null) lbTypefaceList.ClearSelected();
                else
                {
                    lbTypefaceList.SelectedIndex = IndexOf(value);
                }

            }
        }
        #endregion

        #region Constants
        private const int RECENTLY_USED_SECTION_INDEX = 0;
        #endregion

        #region Constructor
        public KryptonTypefaceList()
        {
            InitializeComponent();

            lbTypefaceList.Items.Add("Section"); //section entry for Recently Used

            lbTypefaceList.Items.Add("Section"); //section entry for All Fonts

            foreach (FontFamily f in FontFamily.Families)
            {
                try
                {
                    if (f.Name != null || f.Name != "") lbTypefaceList.Items.Add(new Font(f, Typeface.Size));
                }
                catch { }

            }
        }
        #endregion

        private void KryptonTypefaceList_Load(object sender, EventArgs e)
        {
            SetupControl();
        }

        #region Methods
        private void SetupControl()
        {
            SetTypeface(new Font("Segoe UI", 12f, FontStyle.Regular));

            ActiveControl = lbTypefaceList;
        }

        public int IndexOf(FontFamily ff)
        {
            for (int i = 1; i < lbTypefaceList.Items.Count; i++)
            {
                if (lbTypefaceList.Items[i] == "Section") continue;
                Font f = (Font)lbTypefaceList.Items[i];
                if (f.FontFamily.Name == ff.Name)
                {
                    return i;
                }
            }

            return -1;
        }

        public void AddSelectedFontToRecent()
        {
            if (lbTypefaceList.SelectedIndex < 1) return;

            lbTypefaceList.SuspendLayout();

            int tmpCount = _recentlyUsed.Count;

            _recentlyUsed.Add((Font)lbTypefaceList.SelectedItem);

            for (int i = 1; i <= tmpCount; i++)
            {
                lbTypefaceList.Items.RemoveAt(1);
            }

            for (int i = 0; i < _recentlyUsed.Count; i++)
            {
                lbTypefaceList.Items.Insert(i + 1, _recentlyUsed[i]);
            }

            lbTypefaceList.SelectedIndex = 1;

            lbTypefaceList.ResumeLayout();

        }

        public void AddFontToRecent(FontFamily ff)
        {
            lbTypefaceList.SuspendLayout();

            for (int i = 1; i <= _recentlyUsed.Count; i++)
            {
                lbTypefaceList.Items.RemoveAt(1);
            }

            _recentlyUsed.Add((Font)lbTypefaceList.Items[IndexOf(ff)]);

            for (int i = 0; i < _recentlyUsed.Count; i++)
            {
                lbTypefaceList.Items.Insert(i + 1, _recentlyUsed[i]);
            }

            //klbTypefaceList.SelectedIndex = 1;

            lbTypefaceList.ResumeLayout();

        }
        #endregion

        #region Setters and Getters
        /// <summary>
        /// Sets the Typeface.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetTypeface(Font value) => Typeface = value;

        /// <summary>
        /// Gets the Typeface.
        /// </summary>
        /// <returns>The value of Typeface.</returns>
        public Font GetTypeface() => Typeface;
        #endregion

        private void lbTypefaceList_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == 0)
            {
                e.Graphics.FillRectangle(Brushes.AliceBlue, e.Bounds);
                Font font = new Font(DefaultFont, FontStyle.Bold | FontStyle.Italic);
                e.Graphics.DrawString("Recently Used", font, Brushes.Black, e.Bounds.X + 10, e.Bounds.Y + 3, StringFormat.GenericDefault);
            }
            else if (e.Index == AllFontsStartIndex - 1)
            {
                e.Graphics.FillRectangle(Brushes.AliceBlue, e.Bounds);
                Font font = new Font(DefaultFont, FontStyle.Bold | FontStyle.Italic);
                e.Graphics.DrawString("All Fonts", font, Brushes.Black, e.Bounds.X + 10, e.Bounds.Y + 3, StringFormat.GenericDefault);
            }
            else
            {
                // Draw the background of the ListBox control for each item.
                e.DrawBackground();

                Font font = (Font)lbTypefaceList.Items[e.Index];
                e.Graphics.DrawString(font.Name, font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);

                // If the ListBox has focus, draw a focus rectangle around the selected item.
                e.DrawFocusRectangle();
            }
        }

        private void lbTypefaceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbTypefaceList.SelectedIndex == RECENTLY_USED_SECTION_INDEX || lbTypefaceList.SelectedIndex == AllFontsSectionIndex)
            {
                lbTypefaceList.SelectedIndex = _lastSelectedIndex;
            }
            else if (lbTypefaceList.SelectedItem != null)
            {
                if (!ktxtTypeface.Focused)
                {
                    Font f = (Font)lbTypefaceList.SelectedItem;
                    ktxtTypeface.Text = f.Name;
                }

                SelectedFontFamilyChanged(lbTypefaceList, new EventArgs());
                _lastSelectedIndex = lbTypefaceList.SelectedIndex;
            }
        }

        private void ktxtTypeface_TextChanged(object sender, EventArgs e)
        {
            if (!ktxtTypeface.Focused) return;

            for (int i = AllFontsStartIndex; i < lbTypefaceList.Items.Count; i++)
            {
                string str = ((Font)lbTypefaceList.Items[i]).Name;
                if (str.StartsWith(ktxtTypeface.Text, true, null))
                {
                    lbTypefaceList.SelectedIndex = i;

                    const uint WM_VSCROLL = 0x0115;
                    const uint SB_THUMBPOSITION = 4;

                    uint b = ((uint)(lbTypefaceList.SelectedIndex) << 16) | (SB_THUMBPOSITION & 0xffff);
                    SendMessage(lbTypefaceList.Handle, WM_VSCROLL, b, 0);

                    return;
                }
            }
        }

        private void ktxtTypeface_MouseClick(object sender, MouseEventArgs e)
        {
            ktxtTypeface.SelectAll();
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lParam);

        private void lbTypefaceList_KeyDown(object sender, KeyEventArgs e)
        {
            // if you type alphanumeric characters while focus is on ListBox, it shifts the focus to TextBox.
            if (Char.IsLetterOrDigit((char)e.KeyValue))
            {
                ktxtTypeface.Focus();

                ktxtTypeface.Text = ((char)e.KeyValue).ToString();

                ktxtTypeface.SelectionStart = 1;
            }


            // allows to move between sections using arrow keys
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                    if (lbTypefaceList.SelectedIndex == AllFontsSectionIndex + 1)
                    {
                        lbTypefaceList.SelectedIndex = lbTypefaceList.SelectedIndex - 2;

                        e.SuppressKeyPress = true;
                    }
                    break;
                case Keys.Down:
                case Keys.Right:
                    if (lbTypefaceList.SelectedIndex == AllFontsSectionIndex - 1)
                    {
                        lbTypefaceList.SelectedIndex = lbTypefaceList.SelectedIndex + 2;

                        e.SuppressKeyPress = true;
                    }
                    break;

            }
        }
    }
}
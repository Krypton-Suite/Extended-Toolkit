using Krypton.Toolkit.Extended.Common;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Base
{
    public class KryptonTypefaceListBoxControl : UserControl
    {
        #region Design Code
        private Panel panel1;
        private KryptonTextBox ktxtSearch;
        private Panel panel2;
        private KryptonListBox klbTypefaces;

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.ktxtSearch = new Krypton.Toolkit.KryptonTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.klbTypefaces = new Krypton.Toolkit.KryptonListBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.ktxtSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 23);
            this.panel1.TabIndex = 0;
            // 
            // ktxtSearch
            // 
            this.ktxtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ktxtSearch.Hint = "Search...";
            this.ktxtSearch.Location = new System.Drawing.Point(0, 0);
            this.ktxtSearch.Name = "ktxtSearch";
            this.ktxtSearch.Size = new System.Drawing.Size(196, 23);
            this.ktxtSearch.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.klbTypefaces);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(196, 221);
            this.panel2.TabIndex = 1;
            // 
            // klbTypefaces
            // 
            this.klbTypefaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klbTypefaces.Location = new System.Drawing.Point(0, 0);
            this.klbTypefaces.Name = "klbTypefaces";
            this.klbTypefaces.Size = new System.Drawing.Size(196, 221);
            this.klbTypefaces.TabIndex = 0;
            // 
            // KryptonTypefaceListBoxControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "KryptonTypefaceListBoxControl";
            this.Size = new System.Drawing.Size(196, 244);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private float _typefaceSize;

        public RecentlyUsedList<Font> _recentlyUsed = new RecentlyUsedList<Font>(5);

        private int _lastSelectedIndex = -1;
        #endregion

        #region Constant
        private const int RECENTLY_USED_SELECTION_INDEX = 0;
        #endregion

        #region Property
        [DefaultValue(8.25)]
        public float TypefaceSize { get => _typefaceSize; set { _typefaceSize = value; Invalidate(); } }

        private int AllTypefaceSelectionIndex { get => _recentlyUsed.Count + 1; }

        private int AllTypefaceStartIndex { get => _recentlyUsed.Count + 2; }

        public FontFamily SelectedTypeface
        {
            get
            {
                if (klbTypefaces.SelectedItem != null)
                {
                    return ((Font)klbTypefaces.SelectedItem).FontFamily;
                }
                else
                {
                    return null;
                }
            }

            set
            {
                if (value == null)
                {
                    klbTypefaces.ClearSelected();
                }
                else
                {
                    klbTypefaces.SelectedIndex = IndexOf(value);
                }
            }
        }
        #endregion

        #region Event
        public delegate void TypefaceChangedEventHandler(object sender, TypefaceChangedEventArgs e);

        public event TypefaceChangedEventHandler OnTypefaceChanged;

        protected virtual void TypefaceChanged(object sender, TypefaceChangedEventArgs e) => OnTypefaceChanged?.Invoke(sender, e);
        #endregion

        #region Constructor
        public KryptonTypefaceListBoxControl(float size = 8f)
        {
            InitializeComponent();

            klbTypefaces.Items.Add("Section");

            klbTypefaces.Items.Add("Section");

            foreach (FontFamily typeface in FontFamily.Families)
            {
                try
                {
                    AddTypeface(size, typeface);
                }
                catch 
                {
                }
            }
        }
        #endregion

        #region Methods
        private void AddTypeface(float size, FontFamily typeface)
        {
            if (typeface.Name != null || typeface.Name != "") klbTypefaces.Items.Add(new Font(typeface, size));
        }

        public int IndexOf(FontFamily typeface)
        {
            for (int i = 1; i < klbTypefaces.Items.Count; i++)
            {
                if (klbTypefaces.Items[i] == "section") continue;

                Font t = (Font)klbTypefaces.Items[i];

                if (t.FontFamily.Name == typeface.Name) return i;
            }

            return -1;
        }
        #endregion
    }
}
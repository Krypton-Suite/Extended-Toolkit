
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using FontAwesome.Sharp;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.VirtualTreeColumnView;

namespace VirtualTreeColumnViewApp
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
            imageList1.AddIcon(IconChar.AddressBook, Color.Aqua, 24);
            imageList1.AddIcon(IconChar.Eraser, Color.Red, 24);
            imageList1.AddIcon(IconChar.Home, Color.Green, 24);
            kryptonVirtualTreeColumnView1.DrawCell = DrawCell;
            kryptonVirtualTreeColumnView1.OnGetRowNodeCellText = OnGetRowNodeCellText;
        }

        private string OnGetRowNodeCellText(VirtualTreeRowNode row, int column)
        {
            if (column == 1
                || (row.Tag is not RowDataPoco data)
                    )
                return string.Empty;
            return data.Row;
        }

        private bool DrawCell(VirtualTreeRowNode row, int column, Graphics g, RectangleF rect)
        {
            if (column != 1)
                return false;
            if (row.Tag is not RowDataPoco data)
                return false;
            g.DrawImage(imageList1.Images[data.ImageOffset], rect);
            return true;
        }

        private void RbOffice2010Blue_CheckedChanged(object sender, System.EventArgs e) => 
            kryptonPalette.BasePaletteMode = PaletteMode.Office2010Blue;

        private void RbOffice2007Blue_CheckedChanged(object sender, System.EventArgs e) =>
            kryptonPalette.BasePaletteMode = PaletteMode.Office2007Blue;

        private void RbOffice2007Black_CheckedChanged(object sender, System.EventArgs e) =>
            kryptonPalette.BasePaletteMode = PaletteMode.Office2007BlackDarkMode;

        private void RbOffice2003_CheckedChanged(object sender, System.EventArgs e) =>
            kryptonPalette.BasePaletteMode = PaletteMode.ProfessionalOffice2003;

        private void RbSparkle_CheckedChanged(object sender, System.EventArgs e) =>
            kryptonPalette.BasePaletteMode = PaletteMode.SparkleBlue;

        private void RbOffice365Blue_CheckedChanged(object sender, System.EventArgs e) =>
            kryptonPalette.BasePaletteMode = PaletteMode.Office365BlueDarkMode;

        private void BtnAddMillion_Click(object sender, System.EventArgs e)
        {
            var curser = Cursor;
            try
            {
                Cursor = Cursors.WaitCursor;
                var sw = Stopwatch.StartNew();
                kryptonVirtualTreeColumnView1.BeginUpdate();
                for (int parent = 0; parent < 1000; parent++)
                {
                    var parentRow = kryptonVirtualTreeColumnView1.Add(null, NodeAttachPlacement.AddChildLast,
                        new RowDataPoco { Row = $@"parent [{parent}]", ImageOffset = parent % 3 });
                    for (int child = 0; child < 1000; child++)
                    {
                        kryptonVirtualTreeColumnView1.Add(parentRow, NodeAttachPlacement.AddChildLast,
                            new RowDataPoco { Row = $@"Child [{parent}:{child}]", ImageOffset = child % 3 });                    
                    }
                }
                kryptonVirtualTreeColumnView1.EndUpdate();

                sw.Stop();
                lblTimeTaken.Text = $@"{sw.Elapsed}";
            }
            finally
            {
                Cursor = curser;
            }
        }

        private void BtnExpandAll_Click(object sender, System.EventArgs e)
        {
            var curser = Cursor;
            try
            {
                Cursor = Cursors.WaitCursor;
                var sw = Stopwatch.StartNew();
                kryptonVirtualTreeColumnView1.ExpandAll();

                sw.Stop();
                lblTimeTaken.Text = $@"{sw.Elapsed}";
            }
            finally
            {
                Cursor = curser;
            }

        }

        private void BtnCollapseAll_Click(object sender, System.EventArgs e)
        {
            var curser = Cursor;
            try
            {
                Cursor = Cursors.WaitCursor;
                var sw = Stopwatch.StartNew();
                kryptonVirtualTreeColumnView1.CollapseAll();

                sw.Stop();
                lblTimeTaken.Text = $@"{sw.Elapsed}";
            }
            finally
            {
                Cursor = curser;
            }
        }
    }
}

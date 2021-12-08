#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Drawing.Printing;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    ///<summary>
    /// A print helper class for a bitmap buffer. Landscape or portrate, but
    /// does NOT support any angles in between. It does not check for maximum printable
    /// pages, which I think might cause spoolsv.exe to fail if overflows.
    /// </summary>
    public class CPrinter
    {
        private Bitmap bmpBuffer;
        public Bitmap BmpBuffer
        {
            get { return bmpBuffer; }
            set { bmpBuffer = value; }
        }

        private int nPageCount;
        public int PageCount
        {
            get { return nPageCount; }
            set { nPageCount = value; }
        }

        private int nPagesPrinted;
        public int PagesPrinted
        {
            get { return nPagesPrinted; }
            set { nPagesPrinted = value; }
        }

        private PrintDocument document;
        public PrintDocument Document
        {
            get { return document; }
            set { /*document = value;*/ }
        }

        private bool bFitToPaper;
        public bool FitToPaper
        {
            get { return bFitToPaper; }
            set { bFitToPaper = value; }
        }

        public CPrinter()
        {
            //printSettings = new PrinterSettings();
            bmpBuffer = null;

            document = new PrintDocument();
            document.PrintPage += new PrintPageEventHandler(this.OnPrintPage);
        }

        public bool ShowOptions()
        {
            bool ret = false;

            DialogResult res;
            PrintDialog pdlg;

            pdlg = new PrintDialog();
            pdlg.Document = document;
            pdlg.UseEXDialog = true;

            res = pdlg.ShowDialog();
            if (res == DialogResult.OK || res == DialogResult.Yes)
            {
                ret = true;
            }
            pdlg.Dispose();
            pdlg = null;

            return ret;
        }

        public bool Print()
        {
            if (BmpBuffer == null) return false;

            PageCount = 0;

            document.Print();

            return true;
        }

        private void OnPrintPage(object sender, PrintPageEventArgs e)
        {
            if (FitToPaper)
            {
                e.Graphics.DrawImage(
                    BmpBuffer,
                    e.PageBounds,
                    new Rectangle(
                    0,
                    0,
                    BmpBuffer.Width,
                    BmpBuffer.Height),
                    GraphicsUnit.Pixel);
            }
            else
            {
                e.Graphics.DrawImageUnscaled(
                    BmpBuffer,
                    e.PageBounds.Left,
                    e.PageBounds.Top);
            }

            e.HasMorePages = false;
            /*
            // Prepare for next pageas
            PagesPrinted++;
            if (PagesPrinted >= PageCount)
            {
                e.HasMorePages = false;
                BmpBuffer.Dispose();
                BmpBuffer = null;
            }
            else e.HasMorePages = true;
             */
        }
    }
}
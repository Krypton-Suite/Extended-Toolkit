namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    public class PrintDialogSettings
    {
        public PrintDialogSettings()
        {
            ShowPrintPreviewDialog = true;
            Title = "";
            Footer = "";
            Header = "";
        }

        public bool ShowPageSetupDialog { get; set; }
        public bool ShowPrintDialog { get; set; }
        public bool ShowPrintPreviewDialog { get; set; }

        /// <summary>
        /// Title of page. If you want to print Title on the page, insert code &amp;w in Footer or Header.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Footer of page.
        /// Here you can use special codes: &amp;w (Window title), &amp;D, &amp;d (Date), &amp;t(), &amp;4 (Time), &amp;p (Current page number), &amp;P (Total number of pages),  &amp;&amp; (A single ampersand), &amp;b (Right justify text, Center text. If &amp;b occurs once, then anything after the &amp;b is right justified. If &amp;b occurs twice, then anything between the two &amp;b is centered, and anything after the second &amp;b is right justified).
        /// More detailed see <see cref="http://msdn.microsoft.com/en-us/library/aa969429(v=vs.85).aspx">here</see>
        /// </summary>
        public string Footer { get; set; }

        /// <summary>
        /// Header of page
        /// Here you can use special codes: &amp;w (Window title), &amp;D, &amp;d (Date), &amp;t(), &amp;4 (Time), &amp;p (Current page number), &amp;P (Total number of pages),  &amp;&amp; (A single ampersand), &amp;b (Right justify text, Center text. If &amp;b occurs once, then anything after the &amp;b is right justified. If &amp;b occurs twice, then anything between the two &amp;b is centered, and anything after the second &amp;b is right justified).
        /// More detailed see <see cref="http://msdn.microsoft.com/en-us/library/aa969429(v=vs.85).aspx">here</see>
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Prints line numbers
        /// </summary>
        public bool IncludeLineNumbers { get; set; }
    }
}
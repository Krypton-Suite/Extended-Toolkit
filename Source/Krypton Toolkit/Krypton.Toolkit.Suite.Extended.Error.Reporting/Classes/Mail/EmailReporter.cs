namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    /// <summary>
    /// an email requires an intro (subject) and a body
    /// and both require generation via templates, so here we combine the intro and body together
    /// </summary>
    internal class EmailReporter
    {
        private readonly ExceptionReportInfo _info;

        public EmailReporter(ExceptionReportInfo info)
        {
            _info = info;
        }

        public string Create()
        {
            var template = new TemplateRenderer(new EmailIntroModel
            {
                ScreenshotTaken = _info.TakeScreenshot
            });
            var emailIntro = template.RenderPreset();
            var report = new ReportGenerator(_info).Generate();

            return emailIntro + report;
        }
    }
}
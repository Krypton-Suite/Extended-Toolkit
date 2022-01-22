using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Error.Reporting;

namespace ErrorReporting
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void klblDefault_LinkClicked(object sender, EventArgs e)
        {
            ThrowAndShowExceptionReporter();
        }

        private void klbSendEMail_LinkClicked(object sender, EventArgs e)
        {
            try
            {
                SomeMethodThatThrows();
            }
            catch (Exception exception)
            {
                var er = new ExceptionReporter();

                //	ConfigureSmtpEmail(er.Config);
                ConfigureWebService(er.Config);     //toggle which type to configure
                er.Send(exception);
            }
        }

        private void klblSilentReport_LinkClicked(object sender, EventArgs e)
        {
            try
            {
                SomeMethodThatThrows();
            }
            catch (Exception exception)
            {
                // testing attaching files
                var file1 = Path.GetTempFileName() + "-file1.txt";
                var file2 = Path.GetTempFileName() + "-file2.txt";

                File.WriteAllText(file1, "test text file 1");
                File.WriteAllText(file2, "test text file 2");

                var exceptionReporter = CreateEmailReadyReporter();

                exceptionReporter.Config.FilesToAttach = new[] { file1, file2 };
                exceptionReporter.Config.TakeScreenshot = true;

                exceptionReporter.Show(exception);
            }
        }

		ExceptionReporter CreateEmailReadyReporter()
		{
			var exceptionReporter = new ExceptionReporter();
			ConfigureWebService(exceptionReporter.Config);
			//	ConfigureSmtpEmail(exceptionReporter.Config);		// comment any of these in/out to test
			//	ConfigureSimpleMAPI(exceptionReporter.Config);

			return exceptionReporter;
		}

		void ConfigureSimpleMAPI(ExceptionReportInfo config)
		{
			config.EmailReportAddress = "demo@exceptionreporter.com";
			config.SendMethod = ReportSendMethod.SimpleMAPI;
		}

		void ConfigureWebService(ExceptionReportInfo config)
		{
			config.SendMethod = ReportSendMethod.WebService;
			config.WebServiceUrl = "http://localhost:24513/api/er";
		}

		void ConfigureSmtpEmail(ExceptionReportInfo config)
		{
			//--- Test SMTP - recommend using MailSlurper https://github.com/mailslurper
			config.SendMethod = ReportSendMethod.SMTP;      // obsolete deprecated property used here, will be removed in later version
			config.SmtpServer = "127.0.0.1";
			config.SmtpPort = 2500;
			config.SmtpUsername = "";
			config.SmtpPassword = "";
			config.SmtpFromAddress = "test@test.com";
			config.EmailReportAddress = "support@support.com";
			config.SmtpUseSsl = false;     // NB you'll need to have "Allow less secure apps: ON" if using Gmail for this
										   //---
		}

		static void ThrowAndShowExceptionReporter(bool detailView = false)
		{
			try
			{
				SomeMethodThatThrows();
			}
			catch (Exception exception)
			{
				var er = new ExceptionReporter
				{
					Config =
					{
						SendMethod = ReportSendMethod.SimpleMAPI,
						EmailReportAddress = "support@acme.com",
						CompanyName = "Acme", // this goes alongside email button text
						TitleText = "Acme Error Report",
						// er.Config.ShowFullDetail = false;
						ShowLessDetailButton = true,
						ReportTemplateFormat = TemplateFormat.Text,
						EmailReportSubject = "サブジェクト" }
				};

				// er.Config.ShowEmailButton = false;		// just for testing that removing email button works
				er.Config.ReportTemplateFormat = TemplateFormat.Text;

				er.Show(exception);
			}
		}

		static void SomeMethodThatThrows()
		{
			CallAnotherMethod();
		}

		static void CallAnotherMethod()
		{
			AndAnotherOne();
		}

		static void AndAnotherOne()
		{
			var exception = new IOException(
				"Unable to establish a connection with the Fizz photo service",
				new Exception(
					"This is an Inner Exception message - with a message that is not too small"));
			throw exception;
		}

		/// <summary>
		/// This is a demonstration of using a custom dialog/view - which implements IExceptionReportView
		/// And how the IViewReportMaker interface is used to set the custom view as the one to be instantiated
		/// </summary>
		void UseCustomReportView()
		{
			try
			{
				SomeMethodThatThrows();
			}
			catch (Exception exception)
			{
				var er = new ExceptionReporter
				{
					ViewMaker = new CustomViewMaker()
				};
				ConfigureWebService(er.Config);
				er.Show(exception);
			}
		}
	}
}
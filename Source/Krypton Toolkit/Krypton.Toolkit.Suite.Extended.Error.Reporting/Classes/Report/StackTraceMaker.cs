namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    internal class StackTraceMaker : IStackTraceMaker
    {
        private readonly IList<Exception> _exceptions;

        public StackTraceMaker(params Exception[] exceptions)
        {
            _exceptions = exceptions;
        }

        public string FullStackTrace()
        {
            var sb = new StringBuilder();

            foreach (var exception in _exceptions)
            {
                sb.AppendLine(this.StackTrace(exception));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Create a line-delimited string of the exception hierarchy 
        /// //TODO see Label='EH' in View, which is partly duplicated
        /// </summary>
        private string StackTrace(Exception exception)
        {
            var currentException = exception;
            var stringBuilder = new StringBuilder();
            var count = 0;

            while (currentException != null)
            {
                if (count++ == 0)
                    stringBuilder.AppendLine("Top-level Exception");
                else
                    stringBuilder.AppendLine("Inner Exception " + (count - 1));

                stringBuilder
                    .AppendLine("Type:    " + currentException.GetType())
                    .AppendLine("Message: " + currentException.Message)
                    .AppendLine("Source:  " + currentException.Source);

                if (currentException.StackTrace != null)
                {
                    stringBuilder.AppendLine("Stack Trace: " + currentException.StackTrace.Trim());
                }

                currentException = currentException.InnerException;
            }

            var exceptionString = stringBuilder.ToString();
            return exceptionString.TrimEnd();
        }
    }
}
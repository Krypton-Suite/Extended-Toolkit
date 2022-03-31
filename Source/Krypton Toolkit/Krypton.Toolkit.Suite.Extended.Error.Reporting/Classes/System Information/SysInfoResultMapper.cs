namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    ///<summary>
    /// Map SysInfoResults to human-readable format
    ///</summary>
    internal class SysInfoResultMapper : ISysInfoResultMapper
    {
        private readonly IEnumerable<SysInfoResult> _sysInfoResults;

        protected SysInfoResultMapper()
        { }

        public SysInfoResultMapper(IEnumerable<SysInfoResult> sysInfoResults)
        {
            _sysInfoResults = sysInfoResults;
        }

        /// <summary>
        /// create a string representation of a list of SysInfoResults, customised specifically (eg 2-level deep)
        /// </summary>
        public string SysInfoString()
        {
            var sb = new StringBuilder();

            foreach (var result in _sysInfoResults)
            {
                sb.AppendLine(result.Name);

                foreach (var nodeValueParent in result.Nodes)
                {
                    sb.AppendLine("-" + nodeValueParent);

                    foreach (var nodeValue in result.ChildResults.SelectMany(childResult => childResult.Nodes))
                    {
                        sb.AppendLine("--" + nodeValue);        // the max no. of levels is 2, ie '--' is as deep as we go
                    }
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
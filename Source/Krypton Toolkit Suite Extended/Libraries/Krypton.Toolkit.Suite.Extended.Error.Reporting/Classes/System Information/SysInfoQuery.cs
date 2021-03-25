namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    /// <summary>
    /// describes a query to SysInfo (more precisely, the Windows 'WMI' ManagementObjectSearcher)
    /// </summary>
    internal class SysInfoQuery
    {
        private readonly bool _useNameAsDisplayField;

        public SysInfoQuery(string name, string query, bool useNameAsDisplayField)
        {
            _useNameAsDisplayField = useNameAsDisplayField;
            Name = name;
            QueryText = query;
        }

        public string QueryText { get; }

        public string DisplayField
        {
            get { return _useNameAsDisplayField ? "Name" : "Caption"; }
        }

        public string Name { get; }
    }
}
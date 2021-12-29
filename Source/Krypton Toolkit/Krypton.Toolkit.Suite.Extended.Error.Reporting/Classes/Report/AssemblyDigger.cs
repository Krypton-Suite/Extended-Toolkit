namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    /// <summary>
    /// Used to find referenced assemblies
    /// </summary>
    internal class AssemblyDigger : IAssemblyDigger
    {
        private static Assembly _assembly;
        private static IEnumerable<AssemblyRef> _assemblyRefs;

        ///<summary>Initialise with root/main assembly</summary>
        public AssemblyDigger(Assembly assembly)
        {
            var isSame = _assembly != null && _assembly.FullName == assembly.FullName;

            // a little dance to be able to memoize without becoming a singleton (ioc would make this easier too) 
            // this ensures that, even with new objects created, if passed the same assembly twice, the result is memoized
            // this could be overkill because we may never need to pass a different assembly... but it's done (and tested)
            _assembly = isSame ? _assembly : assembly;
            _assemblyRefs = isSame ? _assemblyRefs : null;      // reset the refs variable to reset memoize
        }

        /// <summary>
        /// Returns all referenced assemblies in a customized array used in <see cref="ReportModel"/>
        /// Memoized
        /// </summary>
        public IEnumerable<AssemblyRef> GetAssemblyRefs()
        {
            return _assemblyRefs ?? (_assemblyRefs =
                from a in _assembly.GetReferencedAssemblies()
                    .Concat(new List<AssemblyName>
                    {
                        _assembly.GetName() // ensure we add the root assembly
                    })
                orderby a.Name.ToLower()
                select new AssemblyRef
                {
                    Name = a.Name,
                    Version = a.Version.ToString()
                });
        }
    }
}
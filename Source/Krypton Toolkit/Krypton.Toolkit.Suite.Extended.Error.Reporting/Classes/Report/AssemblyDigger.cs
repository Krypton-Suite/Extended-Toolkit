#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

// ReSharper disable ConvertToNullCoalescingCompoundAssignment
#pragma warning disable CS8602
namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    /// <summary>
    /// Used to find referenced assemblies
    /// </summary>
    internal class AssemblyDigger : IAssemblyDigger
    {
        private static Assembly? _assembly;
        private static IEnumerable<AssemblyRef>? _assemblyRefs;

        ///<summary>Initialise with root/main assembly</summary>
        public AssemblyDigger(Assembly? assembly)
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
        public IEnumerable<AssemblyRef> GetAssemblyRefs() =>
            _assemblyRefs ?? (_assemblyRefs =
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
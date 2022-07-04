#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

#pragma warning disable 1591
namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
	/// <summary>
    /// SysInfoResult holds results from a (ultimately WMI) query into system information
    /// </summary>
    public class SysInfoResult
    {
        public SysInfoResult(string name)
        {
            Name = name;
        }

        public void AddNode(string node)
        {
            Nodes.Add(node);
        }

        public void AddChildren(IEnumerable<SysInfoResult> children)
        {
            ChildResults.AddRange(children);
        }

        public List<string> Nodes { get; } = new List<string>();

        private void Clear()
        {
            Nodes.Clear();
        }

        private void AddRange(IEnumerable<string> nodes)
        {
            Nodes.AddRange(nodes);
        }

        public string Name { get; }

        public List<SysInfoResult> ChildResults { get; } = new List<SysInfoResult>();

        public SysInfoResult Filter(string[] filterStrings)
        {
            var filteredNodes = (
                from node in ChildResults[0].Nodes
                from filter in filterStrings
                where node.Contains(filter + " = ")
                select node).ToList();

            ChildResults[0].Clear();
            ChildResults[0].AddRange(filteredNodes);
            return this;
        }
    }
}
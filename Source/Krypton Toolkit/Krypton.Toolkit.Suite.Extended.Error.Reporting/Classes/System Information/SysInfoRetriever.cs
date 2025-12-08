#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Error.Reporting;

/// <summary>
/// Retrieves system information using WMI
/// </summary>
internal class SysInfoRetriever
{
    private ManagementObjectSearcher _sysInfoSearcher;
    private SysInfoResult _sysInfoResult;
    private SysInfoQuery _sysInfoQuery;

    /// <summary>
    /// Retrieve system information, using the given SysInfoQuery to determine what information to retrieve
    /// </summary>
    /// <param name="sysInfoQuery">the query to determine what information to retrieve</param>
    /// <returns>a SysInfoResult ie containing the results of the query</returns>
    public SysInfoResult Retrieve(SysInfoQuery sysInfoQuery)
    {
        _sysInfoQuery = sysInfoQuery;
        _sysInfoSearcher = new ManagementObjectSearcher($"SELECT * FROM {_sysInfoQuery.QueryText}");
        _sysInfoResult = new SysInfoResult(_sysInfoQuery.Name);

        foreach (var o in _sysInfoSearcher.Get())
        {
            var managementObject = (ManagementObject)o;
            _sysInfoResult.AddNode(managementObject.GetPropertyValue(_sysInfoQuery.DisplayField).ToString().Trim());
            _sysInfoResult.AddChildren(GetChildren(managementObject));
        }
        return _sysInfoResult;
    }

    private IEnumerable<SysInfoResult?> GetChildren(ManagementBaseObject managementObject)
    {
        SysInfoResult? childResult = null;
        ICollection<SysInfoResult?> childList = new List<SysInfoResult?>();

        foreach (var propertyData in managementObject.Properties)
        {
            if (childResult == null)
            {
                childResult = new SysInfoResult($"{_sysInfoQuery.Name}_Child");
                childList.Add(childResult);
            }

            var nodeValue = $"{propertyData.Name} = {Convert.ToString(propertyData.Value)}";
            childResult.Nodes.Add(nodeValue);
        }

        return childList;
    }
}
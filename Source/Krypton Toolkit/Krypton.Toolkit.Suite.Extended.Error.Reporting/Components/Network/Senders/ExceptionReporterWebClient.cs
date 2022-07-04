#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Error.Reporting;

/// <summary>
/// override of WebClient - this is the only way to set a timeout
/// </summary>
internal class ExceptionReporterWebClient : WebClient
{
    private readonly int _timeout;

    public ExceptionReporterWebClient(int timeout)
    {
        _timeout = timeout;
    }

    protected override WebRequest GetWebRequest(Uri address)
    {
        var wr = base.GetWebRequest(address);
        wr.Timeout = _timeout * 1000;
        return wr;
    }
}
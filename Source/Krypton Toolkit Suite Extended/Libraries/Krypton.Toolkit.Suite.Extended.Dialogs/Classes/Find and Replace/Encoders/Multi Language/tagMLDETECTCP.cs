#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public enum MLDETECTCP
    {
        // Default setting will be used. 
        MLDETECTCP_NONE = 0,

        // Input stream consists of 7-bit data. 
        MLDETECTCP_7BIT = 1,

        // Input stream consists of 8-bit data. 
        MLDETECTCP_8BIT = 2,

        // Input stream consists of double-byte data. 
        MLDETECTCP_DBCS = 4,

        // Input stream is an HTML page. 
        MLDETECTCP_HTML = 8,

        //Not currently supported. 
        MLDETECTCP_NUMBER = 16
    }
}
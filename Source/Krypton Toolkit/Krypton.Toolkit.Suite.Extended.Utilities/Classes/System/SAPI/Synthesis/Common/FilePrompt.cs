#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    /// <filterpriority>2</filterpriority>
    [DebuggerDisplay("{_text}")]
    public class FilePrompt : Prompt
    {
        public FilePrompt(string path, SynthesisMediaType media)
            : this(new Uri(path, UriKind.Relative), media)
        {
        }

        public FilePrompt(Uri promptFile, SynthesisMediaType media)
            : base(promptFile, media)
        {
        }
    }
}

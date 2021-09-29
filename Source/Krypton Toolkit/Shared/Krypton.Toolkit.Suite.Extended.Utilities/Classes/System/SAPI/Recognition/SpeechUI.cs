#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
    public class SpeechUI
    {
        internal SpeechUI()
        {
        }

        public static bool SendTextFeedback(RecognitionResult result, string feedback, bool isSuccessfulAction)
        {
            Helpers.ThrowIfNull(result, "result");
            Helpers.ThrowIfEmptyOrNull(feedback, "feedback");
            return result.SetTextFeedback(feedback, isSuccessfulAction);
        }
    }
}

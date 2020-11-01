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

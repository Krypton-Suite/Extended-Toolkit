using Krypton.Toolkit.Suite.Extended.Core;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.IO
{
    public class TextUtilities
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="TextUtilities" /> class.</summary>
        public TextUtilities()
        {

        }
        #endregion

        #region Methods
        /// <summary>Searches for a selected word.
        /// Adapted from: https://www.youtube.com/watch?v=a7LUa4vjuRE
        /// </summary>
        /// <param name="wordToFind">The word to find.</param>
        /// <param name="target">The target <see cref="KryptonRichTextBox" />.</param>
        /// <param name="highlightColour">The text highlight colour.</param>
        /// <param name="pattern">The pattern to find.</param>
        public static void SearchForWord(string wordToFind, KryptonRichTextBox target, Color highlightColour, RichTextBoxFinds pattern = RichTextBoxFinds.MatchCase)
        {
            try
            {
                int start = 0, end = target.Text.LastIndexOf(wordToFind);

                target.SelectAll();

                target.SelectionBackColor = Color.White;

                while (start < end)
                {
                    target.Find(wordToFind, start, target.TextLength, pattern);

                    target.SelectionBackColor = highlightColour;

                    start = target.Text.IndexOf(wordToFind, start) + 1;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.CaptureException(e);
            }
        }

        /// <summary>
        /// Counts the occurrences of a selected word.
        /// Adapted from: https://stackoverflow.com/questions/41132147/how-to-count-specific-words-on-richtextbox/56585526
        /// </summary>
        /// <param name="textToSearch">The text to search.</param>
        /// <param name="word">The word to search for.</param>
        /// <returns>The number of the specified word.</returns>
        public static int CountOccurrencesOfWord(string textToSearch, string word)
        {
            int counter = 0, i = textToSearch.IndexOf(word);

            while (i != -1)
            {
                counter++;

                i = textToSearch.IndexOf(word, i + 1);
            }

            return counter;
        }
        #endregion
    }
}
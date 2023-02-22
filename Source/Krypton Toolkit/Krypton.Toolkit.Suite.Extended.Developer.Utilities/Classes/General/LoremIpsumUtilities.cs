using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ReSharper disable PossibleNullReferenceException

namespace Krypton.Toolkit.Suite.Extended.Developer.Utilities
{
    internal static class Extensions
    {
        internal static string Remove(this string value, string pattern) => value.Replace(pattern, "");

        internal static string[] Split(this string value, string separator) => value.Split(new[] { separator }, StringSplitOptions.None);

        internal static string UppercaseFirst(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            return char.ToUpper(value[0]) + value.Substring(1);
        }
    }

    public static class LoremIpsumGenerator
    {
        public static bool Chance(int successes, int attempts)
        {
            var number = Number(1, attempts);

            return number <= successes;
        }

        public static T Random<T>(T[] items)
        {
            var index = RandomHelper.Instance.Next(items.Length);

            return items[index];
        }

        public static TEnum Enum<TEnum>() where TEnum : struct, IConvertible
        {
            if (typeof(TEnum).IsEnum)
            {
                var v = System.Enum.GetValues(typeof(TEnum));
                return (TEnum)v.GetValue(RandomHelper.Instance.Next(v.Length));
            }
            else
            {
                throw new ArgumentException("Generic type must be an enum.");
            }
        }

        /* http://stackoverflow.com/a/6651661/234132 */
        public static long Number(long min, long max)
        {
            byte[] buf = new byte[8];
            RandomHelper.Instance.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return (Math.Abs(longRand % ((max + 1) - min)) + min);
        }

        #region DateTime

        public static DateTime DateTime(int startYear = 1950, int startMonth = 1, int startDay = 1) => DateTime(new System.DateTime(startYear, startMonth, startDay), System.DateTime.Now);

        public static DateTime DateTime(DateTime min) => DateTime(min, System.DateTime.Now);

        /* http://stackoverflow.com/a/1483677/234132 */
        public static DateTime DateTime(DateTime min, DateTime max)
        {
            TimeSpan timeSpan = max - min;
            TimeSpan newSpan = new TimeSpan(0, RandomHelper.Instance.Next(0, (int)timeSpan.TotalMinutes), 0);

            return min + newSpan;
        }

        #endregion

        #region Text

        public static string Email() => $@"{Words(1, false)}@{Words(1, false)}.com";

        public static string Words(int wordCount, bool uppercaseFirstLetter = true, bool includePunctuation = false) => Words(wordCount, wordCount, uppercaseFirstLetter, includePunctuation);

        public static string Words(int wordCountMin, int wordCountMax, bool uppercaseFirstLetter = true, bool includePunctuation = false)
        {
            var source = string.Join(" ", Source.WordList(includePunctuation).Take(RandomHelper.Instance.Next(wordCountMin, wordCountMax)));

            if (uppercaseFirstLetter)
            {
                source = source.UppercaseFirst();
            }

            return source;
        }

        public static string Sentence(int wordCount)
        => Sentence(wordCount, wordCount);

        public static string Sentence(int wordCountMin, int wordCountMax)
        => $"{Words(wordCountMin, wordCountMax, true, true)}.".Replace(",.", ".").Remove("..");

        public static string Paragraph(int wordCount, int sentenceCount)
        => Paragraph(wordCount, wordCount, sentenceCount, sentenceCount);

        public static string Paragraph(int wordCountMin, int wordCountMax, int sentenceCount)
        => Paragraph(wordCountMin, wordCountMax, sentenceCount, sentenceCount);

        public static string Paragraph(int wordCountMin, int wordCountMax, int sentenceCountMin, int sentenceCountMax)
        {
            var source = string.Join(" ", Enumerable.Range(0, RandomHelper.Instance.Next(sentenceCountMin, sentenceCountMax)).Select(x => Sentence(wordCountMin, wordCountMax)));

            //remove traililng space
            return source.Remove(source.Length - 1);
        }

        public static IEnumerable<string> Paragraphs(int wordCount, int sentenceCount, int paragraphCount) => Paragraphs(wordCount, wordCount, sentenceCount, sentenceCount, paragraphCount, paragraphCount);

        public static IEnumerable<string> Paragraphs(int wordCountMin, int wordCountMax, int sentenceCount, int paragraphCount)
        => Paragraphs(wordCountMin, wordCountMax, sentenceCount, sentenceCount, paragraphCount, paragraphCount);

        public static IEnumerable<string> Paragraphs(int wordCountMin, int wordCountMax, int sentenceCountMin, int sentenceCountMax, int paragraphCount)
        => Paragraphs(wordCountMin, wordCountMax, sentenceCountMin, sentenceCountMax, paragraphCount, paragraphCount);

        public static IEnumerable<string> Paragraphs(int wordCountMin, int wordCountMax, int sentenceCountMin, int sentenceCountMax, int paragraphCountMin, int paragraphCountMax)
        => Enumerable.Range(0, RandomHelper.Instance.Next(paragraphCountMin, paragraphCountMax)).Select(p => Paragraph(wordCountMin, wordCountMax, sentenceCountMin, sentenceCountMax)).ToArray();

        #endregion

        #region Color

        /* http://stackoverflow.com/a/1054087/234132 */
        public static string HexNumber(int digits)
        {
            byte[] buffer = new byte[digits / 2];
            RandomHelper.Instance.NextBytes(buffer);
            string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());

            if (digits % 2 == 0)
            {
                return result;
            }

            return result + RandomHelper.Instance.Next(16).ToString("X");
        }

        #endregion
    }

    /*
    * http://stackoverflow.com/a/1785821/234132
    */
    internal static class RandomHelper
    {
        private static int _seedCounter = new Random().Next();

        [ThreadStatic]
        private static Random _rng;

        internal static Random Instance
        {
            get
            {
                if (_rng == null)
                {
                    int seed = Interlocked.Increment(ref _seedCounter);
                    _rng = new Random(seed);
                }
                return _rng;
            }
        }
    }

    public static class Source
    {
        public static string Text { get; private set; } = @"lorem ipsum amet, pellentesque mattis accumsan maximus etiam mollis ligula non iaculis ornare mauris efficitur ex eu rhoncus aliquam in hac habitasse platea dictumst maecenas ultrices, purus at venenatis auctor, sem nulla urna, molestie nisi mi a ut euismod nibh id libero lacinia, sit amet lacinia lectus viverra donec scelerisque dictum enim, dignissim dolor cursus morbi rhoncus, elementum magna sed, sed velit consectetur adipiscing elit curabitur nulla, eleifend vel, tempor metus phasellus vel pulvinar, lobortis quis, nullam felis orci congue vitae augue nisi, tincidunt id, posuere fermentum facilisis ultricies mi, nisl fusce neque, vulputate integer tortor tempus praesent proin quis nunc massa congue, quam auctor eros placerat eros, leo nec, sapien egestas duis feugiat, vestibulum porttitor, odio sollicitudin arcu, et aenean sagittis ante urna fringilla, risus et, vivamus semper nibh, eget finibus est laoreet justo commodo sagittis, vitae, nunc, diam ac, tellus posuere, condimentum enim tellus, faucibus suscipit ac nec turpis interdum malesuada fames primis quisque pretium ex, feugiat porttitor massa, vehicula dapibus blandit, hendrerit elit, aliquet nam orci, fringilla blandit ullamcorper mauris, ultrices consequat tempor, convallis gravida sodales volutpat finibus, neque pulvinar varius, porta laoreet, eu, ligula, porta, placerat, lacus pharetra erat bibendum leo, tristique cras rutrum at, dui tortor, in, varius arcu interdum, vestibulum, magna, ante, imperdiet erat, luctus odio, non, dui, volutpat, bibendum, quam, euismod, mattis, class aptent taciti sociosqu ad litora torquent per conubia nostra, inceptos himenaeos suspendisse lorem, a, sem, eleifend, commodo, dolor, cursus, luctus, lectus,";

        internal static IEnumerable<string> Rearrange(string words)
        {
            return words.Split(" ").OrderBy(x => RandomHelper.Instance.Next());
        }

        internal static IEnumerable<string> WordList(bool includePuncation)
        {
            return includePuncation ? Rearrange(Text) : Rearrange(Text.Remove(","));
        }

        public static void Update(string text)
        {
            Text = text;
        }
    }
}
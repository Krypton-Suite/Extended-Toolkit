#region License

/*
 * MIT License
 *
 * Copyright (c) 2012 - 2023 RBSoft
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
 */

#endregion

namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    internal static class Utils
    {
        public static string BuildArguments(Collection<string?> argumentList)
        {
            var arguments = new StringBuilder();
            if (argumentList is not { Count: > 0 })
            {
                return string.Empty;
            }

            foreach (string? argument in argumentList) PasteArguments.AppendArgument(ref arguments, argument);
            return arguments.ToString();
        }
    }

    internal static class PasteArguments
    {
        private const char QUOTE = '\"';
        private const char BACKSLASH = '\\';

        internal static void AppendArgument(ref StringBuilder stringBuilder, string? argument)
        {
            if (stringBuilder.Length != 0)
            {
                stringBuilder.Append(' ');
            }

            // Parsing rules for non-argv[0] arguments:
            //   - Backslash is a normal character except followed by a quote.
            //   - 2N backslashes followed by a quote ==> N literal backslashes followed by unescaped quote
            //   - 2N+1 backslashes followed by a quote ==> N literal backslashes followed by a literal quote
            //   - Parsing stops at first whitespace outside of quoted region.
            //   - (post 2008 rule): A closing quote followed by another quote ==> literal quote, and parsing remains in quoting mode.
            if (argument.Length != 0 && ContainsNoWhitespaceOrQuotes(argument))
            {
                // Simple case - no quoting or changes needed.
                stringBuilder.Append(argument);
            }
            else
            {
                stringBuilder.Append(QUOTE);
                var idx = 0;
                while (idx < argument.Length)
                {
                    char c = argument[idx++];
                    switch (c)
                    {
                        case BACKSLASH:
                            {
                                var numBackSlash = 1;
                                while (idx < argument.Length && argument[idx] == BACKSLASH)
                                {
                                    idx++;
                                    numBackSlash++;
                                }

                                if (idx == argument.Length)
                                {
                                    // We'll emit an end quote after this so must double the number of backslashes.
                                    stringBuilder.Append(BACKSLASH, numBackSlash * 2);
                                }
                                else if (argument[idx] == QUOTE)
                                {
                                    // Backslashes will be followed by a quote. Must double the number of backslashes.
                                    stringBuilder.Append(BACKSLASH, numBackSlash * 2 + 1);
                                    stringBuilder.Append(QUOTE);
                                    idx++;
                                }
                                else
                                {
                                    // Backslash will not be followed by a quote, so emit as normal characters.
                                    stringBuilder.Append(BACKSLASH, numBackSlash);
                                }

                                continue;
                            }
                        case QUOTE:
                            // Escape the quote so it appears as a literal. This also guarantees that we won't end up generating a closing quote followed
                            // by another quote (which parses differently pre-2008 vs. post-2008.)
                            stringBuilder.Append(BACKSLASH);
                            stringBuilder.Append(QUOTE);
                            continue;
                        default:
                            stringBuilder.Append(c);
                            break;
                    }
                }

                stringBuilder.Append(QUOTE);
            }
        }

        private static bool ContainsNoWhitespaceOrQuotes(string? s)
        {
            return s.All(c => !char.IsWhiteSpace(c) && c != QUOTE);
        }
    }
}
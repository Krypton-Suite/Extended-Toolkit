#region License
/*
 * MIT License
 *
 * Copyright (c) 2017 ENTech Solutions
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

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    /// <summary>
    /// From http://kigg.codeplex.com/SourceControl/changeset/view/18277#346723
    /// </summary>
    [Serializable]
    public class Verify
    {
        internal Verify()
        {
        }

        [Serializable]
        public class Argument
        {
            internal Argument()
            {
            }

            [DebuggerStepThrough]
            public static void IsNotEmpty(Guid argument, string argumentName)
            {
                if (argument == Guid.Empty)
                    throw new ArgumentException(argumentName + " cannot be empty guid.", argumentName);
            }

            [DebuggerStepThrough]
            public static void IsNotEmpty(string argument, string argumentName)
            {
                if (string.IsNullOrEmpty((argument ?? string.Empty).Trim()))
                    throw new ArgumentException(argumentName + " cannot be empty.", argumentName);
            }

            [DebuggerStepThrough]
            public static void IsWithinLength(string argument, int length, string argumentName)
            {
                if (argument.Trim().Length > length)
                    throw new ArgumentException(argumentName + " cannot be more than " + length + " characters", argumentName);
            }


            [DebuggerStepThrough]
            public static void IsNull(object argument, string argumentName)
            {
                if (argument != null)
                    throw new ArgumentException(argumentName + " must be null", argumentName);
            }


            [DebuggerStepThrough]
            public static void IsNotNull(object argument, string argumentName)
            {
                if (argument == null)
                    throw new ArgumentNullException(argumentName);
            }

            [DebuggerStepThrough]
            public static void IsPositiveOrZero(int argument, string argumentName)
            {
                if (argument < 0)
                    throw new ArgumentOutOfRangeException(argumentName);
            }


            [DebuggerStepThrough]
            public static void IsPositive(int argument, string argumentName)
            {
                if (argument <= 0)
                    throw new ArgumentOutOfRangeException(argumentName);
            }


            [DebuggerStepThrough]
            public static void IsPositiveOrZero(long argument, string argumentName)
            {
                if (argument < 0)
                    throw new ArgumentOutOfRangeException(argumentName);
            }

            [DebuggerStepThrough]
            public static void IsPositive(long argument, string argumentName)
            {
                if (argument <= 0)
                    throw new ArgumentOutOfRangeException(argumentName);
            }

            [DebuggerStepThrough]
            public static void IsPositiveOrZero(float argument, string argumentName)
            {
                if (argument < 0)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            [DebuggerStepThrough]
            public static void IsPositive(float argument, string argumentName)
            {
                if (argument <= 0)
                    throw new ArgumentOutOfRangeException(argumentName);
            }

            [DebuggerStepThrough]
            public static void IsPositiveOrZero(decimal argument, string argumentName)
            {
                if (argument < 0)
                    throw new ArgumentOutOfRangeException(argumentName);
            }

            [DebuggerStepThrough]
            public static void IsPositive(decimal argument, string argumentName)
            {
                if (argument <= 0)
                    throw new ArgumentOutOfRangeException(argumentName);
            }
            /*
			[DebuggerStepThrough]
			public static void IsValidDate(DateTime argument, string argumentName)
			{
				if (!argument.IsValid())
					throw new ArgumentOutOfRangeException(argumentName);
			}

			[DebuggerStepThrough]
			public static void IsInFuture(DateTime argument, string argumentName)
			{
				if (argument < SystemTime.Now())
					throw new ArgumentOutOfRangeException(argumentName);
			}

			[DebuggerStepThrough]
			public static void IsInPast(DateTime argument, string argumentName)
			{
				if (argument > SystemTime.Now())
					throw new ArgumentOutOfRangeException(argumentName);
			}
			*/

            [DebuggerStepThrough]
            public static void IsPositiveOrZero(TimeSpan argument, string argumentName)
            {
                if (argument < TimeSpan.Zero)
                    throw new ArgumentOutOfRangeException(argumentName);
            }

            [DebuggerStepThrough]
            public static void IsPositive(TimeSpan argument, string argumentName)
            {
                if (argument <= TimeSpan.Zero)
                    throw new ArgumentOutOfRangeException(argumentName);
            }

            [DebuggerStepThrough]
            public static void IsNotEmpty<T>(IList<T> argument, string argumentName)
            {
                IsNotNull(argument, argumentName);

                if (argument.Count == 0)
                    throw new ArgumentException("List cannot be empty.", argumentName);
            }


            [DebuggerStepThrough]
            public static void IsInRange(int argument, int min, int max, string argumentName)
            {
                if ((argument < min) || (argument > max))
                    throw new ArgumentOutOfRangeException(argumentName, argumentName + "must be between " + min + "-" + max + ".");
            }

            public static void AreEqual<T>(T expected, T actual, string argumentName)
            {
                if (!EqualityComparer<T>.Default.Equals(expected, actual))
                    throw new ArgumentOutOfRangeException(argumentName, argumentName + " must be " + expected + ", but was " + actual + ".");
            }

            public static void IsTrue(bool actual, string argumentName)
            {
                AreEqual(true, actual, argumentName);
            }

            public static void IsFalse(bool actual, string argumentName)
            {
                AreEqual(false, actual, argumentName);
            }

            public static void AreNotEqual<T>(T expected, T actual, string argumentName)
            {
                if (EqualityComparer<T>.Default.Equals(expected, actual))
                    throw new ArgumentOutOfRangeException(argumentName, argumentName + " must not be equal to " + expected + ".");
            }

            /*
		   [DebuggerStepThrough]
		   public static void IsNotInvalidEmail(string argument, string argumentName)
		   {
			   IsNotEmpty(argument, argumentName);

			   if (!argument.IsEmail())
			   {
				   throw new ArgumentException("\"{0}\" is not a valid email address.".FormatWith(argumentName), argumentName);
			   }
		   }


		   [DebuggerStepThrough]
		   public static void IsNotInvalidWebUrl(string argument, string argumentName)
		   {
			   IsNotEmpty(argument, argumentName);

			   if (!argument.IsWebUrl())
			   {
				   throw new ArgumentException("\"{0}\" is not a valid web url.".FormatWith(argumentName), argumentName);
			   }
		   }
			*/

            [DebuggerStepThrough]
            public static void IsValidID(int? id, string argumentName)
            {
                IsNotNull(id, argumentName);
                IsPositive(id.Value, argumentName);
            }

        }
    }

}
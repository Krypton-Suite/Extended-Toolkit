#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    internal static class SapiConstants
    {
        internal const string SPPROP_RESPONSE_SPEED = "ResponseSpeed";

        internal const string SPPROP_COMPLEX_RESPONSE_SPEED = "ComplexResponseSpeed";

        internal const string SPPROP_CFG_CONFIDENCE_REJECTION_THRESHOLD = "CFGConfidenceRejectionThreshold";

        internal const uint SPDF_ALL = 255u;

        internal static SRID SapiErrorCode2SRID(SAPIErrorCodes code)
        {
            if (code >= SAPIErrorCodes.SPERR_FIRST && code <= SAPIErrorCodes.SPERR_LAST)
            {
                return (SRID)(258 + (code - -2147201023));
            }
            switch (code)
            {
                case SAPIErrorCodes.SP_NO_RULE_ACTIVE:
                    return SRID.SapiErrorNoRuleActive;
                case SAPIErrorCodes.SP_NO_RULES_TO_ACTIVATE:
                    return SRID.SapiErrorNoRulesToActivate;
                case SAPIErrorCodes.SP_NO_PARSE_FOUND:
                    return SRID.NoParseFound;
                case SAPIErrorCodes.S_FALSE:
                    return SRID.UnexpectedError;
                default:
                    return (SRID)(-1);
            }
        }
    }
}
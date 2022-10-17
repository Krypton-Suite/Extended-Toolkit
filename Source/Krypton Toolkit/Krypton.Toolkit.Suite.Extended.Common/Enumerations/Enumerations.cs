﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Common
{
    public enum SupportedHashAlgorithims
    {
        MESSAGEDIGEST5 = 0,
        SECUREHASHALGORITHIM1 = 1,
        SECUREHASHALGORITHIM256 = 2,
        SECUREHASHALGORITHIM384 = 3,
        SECUREHASHALGORITHIM512 = 4,
        RACEINTEGRITYPRIMITIVESEVALUATIONMESSAGEDIGEST = 5
    }

    /// <summary>
    /// The icon type.
    /// </summary>
    public enum IconType
    {
        /// <summary>
        /// The warning
        /// </summary>
        WARNING = 101,
        /// <summary>
        /// The help
        /// </summary>
        HELP = 102,
        /// <summary>
        /// The error
        /// </summary>
        ERROR = 103,
        /// <summary>
        /// The information
        /// </summary>
        INFO = 104,
        /// <summary>
        /// The shield
        /// </summary>
        SHIELD = 106
    }

    public enum DevelopmentState
    {
        PREALPHA,
        ALPHA,
        BETA,
        RTM,
        CURRENT,
        EOL
    }

    /// <summary>
    ///     Contains a list of all known animation functions
    /// </summary>
    public enum KnownAnimationFunctions
    {
        /// <summary>
        ///     No known animation function
        /// </summary>
        None,

        /// <summary>
        ///     The cubic ease-in animation function.
        /// </summary>
        CubicEaseIn,

        /// <summary>
        ///     The cubic ease-in and ease-out animation function.
        /// </summary>
        CubicEaseInOut,

        /// <summary>
        ///     The cubic ease-out animation function.
        /// </summary>
        CubicEaseOut,

        /// <summary>
        ///     The linear animation function.
        /// </summary>
        Linear,

        /// <summary>
        ///     The circular ease-in and ease-out animation function.
        /// </summary>
        CircularEaseInOut,

        /// <summary>
        ///     The circular ease-in animation function.
        /// </summary>
        CircularEaseIn,

        /// <summary>
        ///     The circular ease-out animation function.
        /// </summary>
        CircularEaseOut,

        /// <summary>
        ///     The quadratic ease-in animation function.
        /// </summary>
        QuadraticEaseIn,

        /// <summary>
        ///     The quadratic ease-out animation function.
        /// </summary>
        QuadraticEaseOut,

        /// <summary>
        ///     The quadratic ease-in and ease-out animation function.
        /// </summary>
        QuadraticEaseInOut,

        /// <summary>
        ///     The quartic ease-in animation function.
        /// </summary>
        QuarticEaseIn,

        /// <summary>
        ///     The quartic ease-out animation function.
        /// </summary>
        QuarticEaseOut,

        /// <summary>
        ///     The quartic ease-in and ease-out animation function.
        /// </summary>
        QuarticEaseInOut,

        /// <summary>
        ///     The quintic ease-in and ease-out animation function.
        /// </summary>
        QuinticEaseInOut,

        /// <summary>
        ///     The quintic ease-in animation function.
        /// </summary>
        QuinticEaseIn,

        /// <summary>
        ///     The quintic ease-out animation function.
        /// </summary>
        QuinticEaseOut,

        /// <summary>
        ///     The sinusoidal ease-in animation function.
        /// </summary>
        SinusoidalEaseIn,

        /// <summary>
        ///     The sinusoidal ease-out animation function.
        /// </summary>
        SinusoidalEaseOut,

        /// <summary>
        ///     The sinusoidal ease-in and ease-out animation function.
        /// </summary>
        SinusoidalEaseInOut,

        /// <summary>
        ///     The exponential ease-in animation function.
        /// </summary>
        ExponentialEaseIn,

        /// <summary>
        ///     The exponential ease-out animation function.
        /// </summary>
        ExponentialEaseOut,

        /// <summary>
        ///     The exponential ease-in and ease-out animation function.
        /// </summary>
        ExponentialEaseInOut
    }

    /// <summary>
    ///     The known one dimensional properties of WinForm controls
    /// </summary>
    public enum KnownProperties
    {
        /// <summary>
        ///     The property named 'Value' of the object
        /// </summary>
        Value,

        /// <summary>
        ///     The property named 'Text' of the object
        /// </summary>
        Text,

        /// <summary>
        ///     The property named 'Caption' of the object
        /// </summary>
        Caption,

        /// <summary>
        ///     The property named 'BackColour' of the object
        /// </summary>
        BackColour,

        /// <summary>
        ///     The property named 'ForeColour' of the object
        /// </summary>
        ForeColour,

        /// <summary>
        ///     The property named 'Opacity' of the object
        /// </summary>
        Opacity
    }

    /// <summary>
    ///     The known two dimensional properties of WinForm controls
    /// </summary>
    public enum KnownFormProperties
    {
        /// <summary>
        ///     The property named 'Size' of the object
        /// </summary>
        Size,

        /// <summary>
        ///     The property named 'Location' of the object
        /// </summary>
        Location
    }

    /// <summary>
    ///     The known three dimensional properties of WinForm controls
    /// </summary>
    public enum KnownColourProperties
    {
        /// <summary>
        ///     The property named 'BackColour' of the object
        /// </summary>
        BackColour,

        /// <summary>
        ///     The property named 'ForeColour' of the object
        /// </summary>
        ForeColour
    }

    /// <summary>
    ///     The possible statuses for an animator instance
    /// </summary>
    public enum AnimatorStatus
    {
        /// <summary>
        ///     Animation is stopped
        /// </summary>
        Stopped,

        /// <summary>
        ///     Animation is now playing
        /// </summary>
        Playing,

        /// <summary>
        ///     Animation is now on hold for path delay, consider this value as playing
        /// </summary>
        OnHold,

        /// <summary>
        ///     Animation is paused
        /// </summary>
        Paused
    }

    /// <summary>
    ///     FPS limiter known values
    /// </summary>
    public enum FPSLimiterKnownValues
    {
        /// <summary>
        ///     Limits maximum frames per second to 10fps
        /// </summary>
        LimitTen = 10,

        /// <summary>
        ///     Limits maximum frames per second to 20fps
        /// </summary>
        LimitTwenty = 20,

        /// <summary>
        ///     Limits maximum frames per second to 30fps
        /// </summary>
        LimitThirty = 30,

        /// <summary>
        ///     Limits maximum frames per second to 60fps
        /// </summary>
        LimitSixty = 60,

        /// <summary>
        ///     Limits maximum frames per second to 100fps
        /// </summary>
        LimitOneHundred = 100,

        /// <summary>
        ///     Limits maximum frames per second to 200fps
        /// </summary>
        LimitTwoHundred = 200,

        /// <summary>
        ///     Adds no limit to the number of frames per second
        /// </summary>
        NoFPSLimit = -1
    }
}
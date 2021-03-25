﻿using System;

namespace Krypton.Toolkit.Suite.Extended.Common
{
    /// <summary>
    ///     The functions gallery for animation
    /// </summary>
    public static class AnimationFunctions
    {
        /// <summary>
        ///     The base delegate for defining new animation functions.
        /// </summary>
        /// <param name="time">
        ///     The time of the animation.
        /// </param>
        /// <param name="beginningValue">
        ///     The starting value.
        /// </param>
        /// <param name="changeInValue">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="duration">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public delegate float Function(float time, float beginningValue, float changeInValue, float duration);

        /// <summary>
        ///     Returns a function delegate based on the the passed known animation function
        /// </summary>
        /// <param name="knownFunction">The animation function</param>
        /// <returns>Animation fucntion delegate</returns>
        public static Function FromKnown(KnownAnimationFunctions knownFunction)
        {
            switch (knownFunction)
            {
                case KnownAnimationFunctions.CubicEaseIn:
                    return CubicEaseIn;
                case KnownAnimationFunctions.CubicEaseInOut:
                    return CubicEaseInOut;
                case KnownAnimationFunctions.CubicEaseOut:
                    return CubicEaseOut;
                case KnownAnimationFunctions.Linear:
                    return Linear;
                case KnownAnimationFunctions.CircularEaseInOut:
                    return CircularEaseInOut;
                case KnownAnimationFunctions.CircularEaseIn:
                    return CircularEaseIn;
                case KnownAnimationFunctions.CircularEaseOut:
                    return CircularEaseOut;
                case KnownAnimationFunctions.QuadraticEaseIn:
                    return QuadraticEaseIn;
                case KnownAnimationFunctions.QuadraticEaseOut:
                    return QuadraticEaseOut;
                case KnownAnimationFunctions.QuadraticEaseInOut:
                    return QuadraticEaseInOut;
                case KnownAnimationFunctions.QuarticEaseIn:
                    return QuarticEaseIn;
                case KnownAnimationFunctions.QuarticEaseOut:
                    return QuarticEaseOut;
                case KnownAnimationFunctions.QuarticEaseInOut:
                    return QuarticEaseInOut;
                case KnownAnimationFunctions.QuinticEaseInOut:
                    return QuinticEaseInOut;
                case KnownAnimationFunctions.QuinticEaseIn:
                    return QuinticEaseIn;
                case KnownAnimationFunctions.QuinticEaseOut:
                    return QuinticEaseOut;
                case KnownAnimationFunctions.SinusoidalEaseIn:
                    return SinusoidalEaseIn;
                case KnownAnimationFunctions.SinusoidalEaseOut:
                    return SinusoidalEaseOut;
                case KnownAnimationFunctions.SinusoidalEaseInOut:
                    return SinusoidalEaseInOut;
                case KnownAnimationFunctions.ExponentialEaseIn:
                    return ExponentialEaseIn;
                case KnownAnimationFunctions.ExponentialEaseOut:
                    return ExponentialEaseOut;
                case KnownAnimationFunctions.ExponentialEaseInOut:
                    return ExponentialEaseInOut;
                default:
                    throw new ArgumentOutOfRangeException(nameof(knownFunction), knownFunction,
                        "The passed animation function is unknown.");
            }
        }


        /// <summary>
        ///     The cubic ease-in animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float CubicEaseIn(float t, float b, float c, float d)
        {
            t /= d;
            return c * t * t * t + b;
        }

        /// <summary>
        ///     The cubic ease-in and ease-out animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float CubicEaseInOut(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1)
                return c / 2 * t * t * t + b;

            t -= 2;
            return c / 2 * (t * t * t + 2) + b;
        }

        /// <summary>
        ///     The cubic ease-out animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float CubicEaseOut(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return c * (t * t * t + 1) + b;
        }

        /// <summary>
        ///     The linear animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float Linear(float t, float b, float c, float d)
        {
            return c * t / d + b;
        }

        /// <summary>
        ///     The circular ease-in and ease-out animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float CircularEaseInOut(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1)
                return (float)(-c / 2 * (Math.Sqrt(1 - t * t) - 1) + b);
            t -= 2;
            return (float)(c / 2 * (Math.Sqrt(1 - t * t) + 1) + b);
        }


        /// <summary>
        ///     The circular ease-in animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float CircularEaseIn(float t, float b, float c, float d)
        {
            t /= d;
            return (float)(-c * (Math.Sqrt(1 - t * t) - 1) + b);
        }


        /// <summary>
        ///     The circular ease-out animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float CircularEaseOut(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return (float)(c * Math.Sqrt(1 - t * t) + b);
        }


        /// <summary>
        ///     The quadratic ease-in animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float QuadraticEaseIn(float t, float b, float c, float d)
        {
            t /= d;
            return c * t * t + b;
        }


        /// <summary>
        ///     The quadratic ease-out animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float QuadraticEaseOut(float t, float b, float c, float d)
        {
            t /= d;
            return -c * t * (t - 2) + b;
        }


        /// <summary>
        ///     The quadratic ease-in and ease-out animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float QuadraticEaseInOut(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1) return c / 2 * t * t + b;
            t--;
            return -c / 2 * (t * (t - 2) - 1) + b;
        }

        /// <summary>
        ///     The quartic ease-in animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float QuarticEaseIn(float t, float b, float c, float d)
        {
            t /= d;
            return c * t * t * t * t + b;
        }

        /// <summary>
        ///     The quartic ease-out animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float QuarticEaseOut(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return -c * (t * t * t * t - 1) + b;
        }

        /// <summary>
        ///     The quartic ease-in and ease-out animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float QuarticEaseInOut(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1) return c / 2 * t * t * t * t + b;
            t -= 2;
            return -c / 2 * (t * t * t * t - 2) + b;
        }

        /// <summary>
        ///     The quintic ease-in and ease-out animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float QuinticEaseInOut(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1) return c / 2 * t * t * t * t * t + b;
            t -= 2;
            return c / 2 * (t * t * t * t * t + 2) + b;
        }

        /// <summary>
        ///     The quintic ease-in animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float QuinticEaseIn(float t, float b, float c, float d)
        {
            t /= d;
            return c * t * t * t * t * t + b;
        }

        /// <summary>
        ///     The quintic ease-out animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float QuinticEaseOut(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return c * (t * t * t * t * t + 1) + b;
        }

        /// <summary>
        ///     The sinusoidal ease-in animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float SinusoidalEaseIn(float t, float b, float c, float d)
        {
            return (float)(-c * Math.Cos(t / d * (Math.PI / 2)) + c + b);
        }

        /// <summary>
        ///     The sinusoidal ease-out animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float SinusoidalEaseOut(float t, float b, float c, float d)
        {
            return (float)(c * Math.Sin(t / d * (Math.PI / 2)) + b);
        }

        /// <summary>
        ///     The sinusoidal ease-in and ease-out animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float SinusoidalEaseInOut(float t, float b, float c, float d)
        {
            return (float)(-c / 2 * (Math.Cos(Math.PI * t / d) - 1) + b);
        }

        /// <summary>
        ///     The exponential ease-in animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float ExponentialEaseIn(float t, float b, float c, float d)
        {
            return (float)(c * Math.Pow(2, 10 * (t / d - 1)) + b);
        }

        /// <summary>
        ///     The exponential ease-out animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float ExponentialEaseOut(float t, float b, float c, float d)
        {
            return (float)(c * (-Math.Pow(2, -10 * t / d) + 1) + b);
        }


        /// <summary>
        ///     The exponential ease-in and ease-out animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float ExponentialEaseInOut(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1)
                return (float)(c / 2 * Math.Pow(2, 10 * (t - 1)) + b);
            t--;
            return (float)(c / 2 * (-Math.Pow(2, -10 * t) + 2) + b);
        }
    }
}
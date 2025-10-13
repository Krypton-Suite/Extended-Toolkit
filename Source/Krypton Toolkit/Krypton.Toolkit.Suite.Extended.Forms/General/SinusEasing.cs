#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2024 - 2024 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Forms;

public class SinusEasing : Easing
{
    #region Public

    /// <summary>
    /// Gets or sets the amplitude of the sinus wave.
    /// </summary>
    public double Amplitude { get; set; }

    /// <summary>
    /// Gets or sets the frequency of the sinus wave.
    /// </summary>
    public double Frequency { get; set; }

    #endregion

    #region Identity

    /// <summary>
    /// Creates an object of the sinus easing.
    /// </summary>
    /// <param name="amplitude">The amplitude of the sinus wave.</param>
    /// <param name="frequency">The frequency of the sinus wave.</param>
    public SinusEasing(double amplitude = 0.2, double frequency = 2.0)
    {
        Amplitude = amplitude;
        Frequency = frequency;
    }

    #endregion

    #region Implementation

    /// <inheritdoc />
    public override double CalculateStep(int frame, int frames, double start, double end)
        => start + frame * (end - start) / frames +
           Math.Sin(frame * Frequency * 2 * Math.PI / frames) * (end - start) * Amplitude;

    #endregion
}
#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.DataGridView;

/// <summary>
/// Three scale color class parameters
/// </summary>
/// <seealso cref="IFormatParams" />
public class ThreeColoursParams : IFormatParams
{
    /// <summary>
    /// The minimum color
    /// </summary>
    public Color MinimumColour;
    /// <summary>
    /// The medium color
    /// </summary>
    public Color MediumColour;
    /// <summary>
    /// The maximum color
    /// </summary>
    public Color MaximumColour;
    /// <summary>
    /// The color associated to the value
    /// </summary>
    public Color ValueColour;

    /// <summary>
    /// Initializes a new instance of the <see cref="ThreeColoursParams"/> class.
    /// </summary>
    /// <param name="minColour">The minimum color.</param>
    /// <param name="mediumColour">Color of the medium.</param>
    /// <param name="maxColour">The maximum color.</param>
    public ThreeColoursParams(Color minColour, Color mediumColour, Color maxColour)
    {
        MinimumColour = minColour;
        MediumColour = mediumColour;
        MaximumColour = maxColour;
    }

    /// <summary>
    /// Crée un objet qui est une copie de l'instance actuelle.
    /// </summary>
    /// <returns>
    /// Nouvel objet qui est une copie de cette instance.
    /// </returns>
    public object Clone()
    {
        return MemberwiseClone();
    }

    /// <summary>
    /// Persists the parameters.
    /// </summary>
    /// <param name="writer">The XML writer.</param>
    void IFormatParams.Persist(XmlWriter writer)
    {
        writer.WriteElementString("MinimumColour", MinimumColour.ToArgb().ToString());
        writer.WriteElementString("MediumColour", MediumColour.ToArgb().ToString());
        writer.WriteElementString("MaximumColour", MaximumColour.ToArgb().ToString());
    }
}
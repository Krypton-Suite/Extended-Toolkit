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

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class ColourMapFactory
    {
        private readonly Dictionary<string, Func<IColourMap>> ColourMaps =
            new Dictionary<string, Func<IColourMap>>()
            {
                { "Algae", () => new Algae()},
                { "Amp", () => new Amp()},
                { "Balance", () => new Balance()},
                { "Blues", () => new Blues()},
                { "Curl", () => new Curl()},
                { "Deep", () => new Deep()},
                { "Delta", () => new Delta()},
                { "Dense", () => new Dense()},
                { "Diff", () => new Diff()},
                { "Grayscale", () => new Grayscale()},
                { "GrayscaleR", () => new GrayscaleR()},
                { "Greens", () => new Greens()},
                { "Haline", () => new Haline()},
                { "Ice", () => new Ice()},
                { "Inferno", () => new Inferno()},
                { "Jet", () => new Jet()},
                { "Magma", () => new Magma()},
                { "Matter", () => new Matter()},
                { "Oxy", () => new Oxy()},
                { "Phase", () => new Phase()},
                { "Plasma", () => new Plasma()},
                { "Rain", () => new Rain()},
                { "Solar", () => new Solar()},
                { "Speed", () => new Speed()},
                { "Tarn", () => new Tarn()},
                { "Tempo", () => new Tempo()},
                { "Thermal", () => new Thermal()},
                { "Topo", () => new Topo()},
                { "Turbid", () => new Turbid()},
                { "Turbo", () => new Turbo()},
                { "Viridis", () => new Viridis()},
            };

        public IColourMap GetDefaultColourMap() => new Grayscale();

        public ColourMap CreateOrDefault(string Name)
        {
            if (ColourMaps.TryGetValue(Name, out Func<IColourMap> cmap))
            {
                return new ColourMap(cmap());
            }
            else
            {
                return new ColourMap(GetDefaultColourMap());
            }
        }

        public ColourMap CreateOrThrow(string Name)
        {
            if (ColourMaps.TryGetValue(Name, out Func<IColourMap> cmap))
            {
                return new ColourMap(cmap());
            }
            else
            {
                throw new ArgumentOutOfRangeException($"No colormap with name '{Name}'");
            }
        }

        public IEnumerable<string> GetAvailableNames() => ColourMaps.Keys;

        public IEnumerable<ColourMap> GetAvailableColourMaps() =>
            ColourMaps.Values.Select(f => new ColourMap(f()));
    }
}
#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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
                return new ColourMap(cmap());
            else
                return new ColourMap(GetDefaultColourMap());
        }

        public ColourMap CreateOrThrow(string Name)
        {
            if (ColourMaps.TryGetValue(Name, out Func<IColourMap> cmap))
                return new ColourMap(cmap());
            else
                throw new ArgumentOutOfRangeException($"No colormap with name '{Name}'");
        }

        public IEnumerable<string> GetAvailableNames() => ColourMaps.Keys;

        public IEnumerable<ColourMap> GetAvailableColourMaps() =>
            ColourMaps.Values.Select(f => new ColourMap(f()));
    }
}
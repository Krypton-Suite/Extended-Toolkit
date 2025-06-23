namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public class RandomDataGenerator
{
    /// <summary>
    /// Global random number generator, to ensure each generator will returns different data.
    /// Using ThreadLocal, because Random is not thread safe.
    /// </summary>
    private static readonly ThreadLocal<Random> _globalRandomThread = new(() => new Random(GetCryptoRandomInt()));

    /// <summary>
    /// To select right random number generator
    /// </summary>
    private readonly Random _rand;

    /// <summary>
    /// Create a random number generator.
    /// The seed is random by deafult, but could be fixed to the defined value
    /// </summary>
    public RandomDataGenerator(int? seed = null)
    {
        _rand = seed.HasValue
            ? new Random(seed.Value)
            : _globalRandomThread.Value!;
    }

    public static RandomDataGenerator Generate { get; private set; } = new(0);

    private static int GetCryptoRandomInt()
    {
        var rng = RandomNumberGenerator.Create();
        var data = new byte[sizeof(int)];
        rng.GetBytes(data);
        return BitConverter.ToInt32(data, 0) & (int.MaxValue - 1);
    }

    #region Methods that return single numbers

    /// <summary>
    /// Return a uniformly random number between 0 (inclusive) and 1 (exclusive)
    /// </summary>
    public double RandomNumber()
    {
        return _rand.NextDouble();
    }

    /// <summary>
    /// Return a uniformly random number between 0 (inclusive) and <paramref name="max"/> (exclusive)
    /// </summary>
    public double RandomNumber(double max)
    {
        return _rand.NextDouble() * max;
    }

    /// <summary>
    /// Return a uniformly random number between <paramref name="min"/> (inclusive) and <paramref name="max"/> (exclusive)
    /// </summary>
    public double RandomNumber(double min, double max)
    {
        return _rand.NextDouble() * (max - min) + min;
    }

    /// <summary>
    /// Return a random number guaranteed not to be zero
    /// </summary>
    public double RandomNonZeroNumber(double max = 1)
    {
        var randomValue = RandomNumber(max);
        return randomValue != 0
            ? randomValue
            : RandomNonZeroNumber();
    }

    /// <summary>
    /// Return a random integer up to the maximum integer size
    /// </summary>
    public int RandomInteger()
    {
        return _rand.Next();
    }

    /// <summary>
    /// Return a random byte (0-255)
    /// </summary>
    public byte RandomByte()
    {
        return (byte)_rand.Next(256);
    }

    /// <summary>
    /// Return a random integer between zero (inclusive) and <paramref name="max"/> (exclusive)
    /// </summary>
    public int RandomInteger(int max)
    {
        return _rand.Next(max);
    }

    /// <summary>
    /// Return a random integer between <paramref name="min"/> (inclusive) and <paramref name="max"/> (exclusive)
    /// </summary>
    public int RandomInteger(int min, int max)
    {
        return _rand.Next(min, max);
    }

    /// <summary>
    /// Return a number normally distributed around the given <paramref name="mean"/> 
    /// according to the <paramref name="stdDev"/> standard deviation.
    /// </summary>
    public double RandomNormalNumber(double mean = 0, double stdDev = 1)
    {
        var u1 = RandomNonZeroNumber();
        var u2 = RandomNumber();
        var randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
        return mean + stdDev * randStdNormal;
    }

    #endregion

    /// <summary>
    /// Uniformly distributed random numbers between 0 and 1
    /// (multiplied by <paramref name="mult"/> then added to <paramref name="offset"/>).
    /// </summary>
    public double[] RandomSample(int count, double mult = 1, double offset = 0)
    {
        var values = new double[count];
        for (var i = 0; i < count; i++)
        {
            values[i] = _rand.NextDouble() * mult + offset;
        }

        return values;
    }

    /// <summary>
    /// Return a collection of numbers normally distributed around the given <paramref name="mean"/> 
    /// according to the <paramref name="stdDev"/> standard deviation.
    /// </summary>
    public double[] RandomNormalSample(int count, double mean = 0, double stdDev = 1)
    {
        var values = new double[count];
        for (var i = 0; i <= count; i++)
        {
            values[i] = RandomNormalNumber(mean, stdDev);
        }
        return values;
    }

    /// <summary>
    /// Sine wave with random frequency, amplitude, and phase
    /// </summary>
    public double[] RandomSin(int count)
    {
        var mult = Math.Pow(2, 1 + _rand.NextDouble() * 10);
        var offset = mult * (_rand.NextDouble() - .5);
        var oscillations = 1 + _rand.NextDouble() * 5;
        var phase = _rand.NextDouble() * Math.PI * 2;
        return ScottPlot.Generate.Sin(count, mult, offset, oscillations, phase);
    }

    /// <summary>
    /// A sequence of numbers that starts at <paramref name="offset"/> 
    /// and "walks" randomly from one point to the next, scaled by <paramref name="mult"/>
    /// with an approximate slope of <paramref name="slope"/>.
    /// </summary>
    public double[] RandomWalk(int count, double mult = 1, double offset = 0, double slope = 0)
    {
        var data = new double[count];
        data[0] = offset;
        for (var i = 1; i < data.Length; i++)
        {
            // RandomSample number between -1 and 1;
            var randomStep = _rand.NextDouble() * 2 - 1;
            // Using linear equation y_2 = m * x + y_1 where x = 1,
            // then adding a scaled random step simplifies to:
            data[i] = slope + data[i - 1] + randomStep * mult;
        }
        return data;
    }

    /// <summary>
    /// Return a collection OHLCs representing random price action
    /// </summary>
    public List<Ohlc> RandomOhlCs(int count)
    {
        var dates = ScottPlot.Generate.DateTime.Weekdays(count);
        var span = TimeSpan.FromDays(1);

        double mult = 1;

        List<Ohlc> ohlcs = [];
        var open = RandomNumber(150, 250);
        for (var i = 0; i < count; i++)
        {
            var close = open + RandomNumber(-mult, mult);
            var high = Math.Max(open, close) + RandomNumber(0, mult);
            var low = Math.Min(open, close) - RandomNumber(0, mult);
            Ohlc ohlc = new(open, high, low, close, dates[i], span);
            ohlcs.Add(ohlc);
            open = close + RandomNumber(-mult / 2, mult / 2);
        }

        return ohlcs;
    }
}
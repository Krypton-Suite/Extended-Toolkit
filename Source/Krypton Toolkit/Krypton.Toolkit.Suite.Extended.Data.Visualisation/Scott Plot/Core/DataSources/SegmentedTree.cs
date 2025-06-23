namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public class SegmentedTree<T> where T : struct, IComparable
{
    private T[] _sourceArray;

    private T[]? _treeMin;
    private T[]? _treeMax;
    private int _n = 0; // size of each Tree
    public bool TreesReady = false;

    // precompiled lambda expressions for fast math on generic
    private static Func<T, T, T> _minExp;
    private static Func<T, T, T> _maxExp;
    private static Func<T, T, bool> _equalExp;
    private static Func<T> _maxValue;
    private static Func<T> _minValue;
    private static Func<T, T, bool> _lessThanExp;
    private static Func<T, T, bool> _greaterThanExp;

    public T[] SourceArray
    {
        get => _sourceArray;
        set
        {
            _sourceArray = value ?? throw new Exception("Source Array cannot be null");
            UpdateTrees();
        }
    }

    public SegmentedTree()
    {
        try // runtime check
        {
            var v = new T();
            NumericConversion.GenericToDouble(ref v);
        }
        catch
        {
            throw new ArgumentOutOfRangeException("Unsupported data type, provide convertable to double data types");
        }
        InitExp();
    }

    public async Task SetSourceAsync(T[] data)
    {
        _sourceArray = data ?? throw new ArgumentNullException("Data cannot be null");
        await Task.Run(() => UpdateTrees());
    }

    private void InitExp()
    {
        var paramA = Expression.Parameter(typeof(T), "a");
        var paramB = Expression.Parameter(typeof(T), "b");
        // add the parameters together
        var bodyMin = Expression.Condition(Expression.LessThanOrEqual(paramA, paramB), paramA, paramB);
        var bodyMax = Expression.Condition(Expression.GreaterThanOrEqual(paramA, paramB), paramA, paramB);
        var bodyEqual = Expression.Equal(paramA, paramB);
        var bodyMaxValue = Expression.MakeMemberAccess(null, typeof(T).GetField("MaxValue"));
        var bodyMinValue = Expression.MakeMemberAccess(null, typeof(T).GetField("MinValue"));
        var bodyLessThan = Expression.LessThan(paramA, paramB);
        var bodyGreaterThan = Expression.GreaterThan(paramA, paramB);
        // compile it
        _minExp = Expression.Lambda<Func<T, T, T>>(bodyMin, paramA, paramB).Compile();
        _maxExp = Expression.Lambda<Func<T, T, T>>(bodyMax, paramA, paramB).Compile();
        _equalExp = Expression.Lambda<Func<T, T, bool>>(bodyEqual, paramA, paramB).Compile();
        _maxValue = Expression.Lambda<Func<T>>(bodyMaxValue).Compile();
        _minValue = Expression.Lambda<Func<T>>(bodyMinValue).Compile();
        _lessThanExp = Expression.Lambda<Func<T, T, bool>>(bodyLessThan, paramA, paramB).Compile();
        _greaterThanExp = Expression.Lambda<Func<T, T, bool>>(bodyGreaterThan, paramA, paramB).Compile();
    }

    public void UpdateElement(int index, T newValue)
    {
        _sourceArray[index] = newValue;
        // Update Tree, can be optimized            
        if (index == _sourceArray.Length - 1) // last elem haven't pair
        {
            _treeMin![_n / 2 + index / 2] = _sourceArray[index];
            _treeMax![_n / 2 + index / 2] = _sourceArray[index];
        }
        else if (index % 2 == 0) // even elem have right pair
        {
            _treeMin![_n / 2 + index / 2] = _minExp(_sourceArray[index], _sourceArray[index + 1]);
            _treeMax![_n / 2 + index / 2] = _maxExp(_sourceArray[index], _sourceArray[index + 1]);
        }
        else // odd elem have left pair
        {
            _treeMin![_n / 2 + index / 2] = _minExp(_sourceArray[index], _sourceArray[index - 1]);
            _treeMax![_n / 2 + index / 2] = _maxExp(_sourceArray[index], _sourceArray[index - 1]);
        }

        T candidate;
        for (var i = (_n / 2 + index / 2) / 2; i > 0; i /= 2)
        {
            candidate = _minExp(_treeMin[i * 2], _treeMin[i * 2 + 1]);
            if (_equalExp(_treeMin[i], candidate)) // if node same then new value don't need to recalc all upper
            {
                break;
            }

            _treeMin[i] = candidate;
        }
        for (var i = (_n / 2 + index / 2) / 2; i > 0; i /= 2)
        {
            candidate = _maxExp(_treeMax[i * 2], _treeMax[i * 2 + 1]);
            if (_equalExp(_treeMax[i], candidate)) // if node same then new value don't need to recalc all upper
            {
                break;
            }

            _treeMax[i] = candidate;
        }
    }

    public void UpdateRange(int from, int to, T[] newData, int fromData = 0) // RangeUpdate
    {
        //update source signal
        for (var i = from; i < to; i++)
        {
            _sourceArray[i] = newData[i - from + fromData];
        }

        for (var i = _n / 2 + from / 2; i < _n / 2 + to / 2; i++)
        {
            _treeMin![i] = _minExp(_sourceArray[i * 2 - _n], _sourceArray[i * 2 + 1 - _n]);
            _treeMax![i] = _maxExp(_sourceArray[i * 2 - _n], _sourceArray[i * 2 + 1 - _n]);
        }
        if (to == _sourceArray.Length) // last elem haven't pair
        {
            _treeMin![_n / 2 + to / 2] = _sourceArray[to - 1];
            _treeMax![_n / 2 + to / 2] = _sourceArray[to - 1];
        }
        else if (to % 2 == 1) //last elem even(to-1) and not last
        {
            _treeMin![_n / 2 + to / 2] = _minExp(_sourceArray[to - 1], _sourceArray[to]);
            _treeMax![_n / 2 + to / 2] = _maxExp(_sourceArray[to - 1], _sourceArray[to]);
        }

        from = (_n / 2 + from / 2) / 2;
        to = (_n / 2 + to / 2) / 2;

        T candidate;
        while (from != 0) // up to root elem, that is [1], [0] - is free elem
        {
            if (from != to)
            {
                for (var i = from; i <= to; i++) // Recalc all level nodes in range 
                {
                    _treeMin![i] = _minExp(_treeMin[i * 2], _treeMin[i * 2 + 1]);
                    _treeMax![i] = _maxExp(_treeMax[i * 2], _treeMax[i * 2 + 1]);
                }
            }
            else
            {
                // left == right, so no need more from to loop
                for (var i = from; i > 0; i /= 2) // up to root node
                {
                    candidate = _minExp(_treeMin![i * 2], _treeMin[i * 2 + 1]);
                    if (_equalExp(_treeMin[i], candidate)) // if node same then new value don't need to recalc all upper
                    {
                        break;
                    }

                    _treeMin[i] = candidate;
                }

                for (var i = from; i > 0; i /= 2) // up to root node
                {
                    candidate = _maxExp(_treeMax![i * 2], _treeMax[i * 2 + 1]);
                    if (_equalExp(_treeMax[i], candidate)) // if node same then new value don't need to recalc all upper
                    {
                        break;
                    }

                    _treeMax[i] = candidate;
                }
                // all work done exit while loop
                break;
            }
            // level up
            from = from / 2;
            to = to / 2;
        }
    }

    public void UpdateData(int from, T[] newData)
    {
        UpdateRange(from, newData.Length, newData);
    }

    public void UpdateData(T[] newData)
    {
        UpdateRange(0, newData.Length, newData);
    }

    public void UpdateTreesInBackground()
    {
        Task.Run(() => { UpdateTrees(); });
    }

    public void UpdateTrees()
    {
        // O(n) to build trees
        TreesReady = false;
        try
        {
            if (_sourceArray.Length == 0)
            {
                throw new ArgumentOutOfRangeException($"Array cant't be empty");
            }

            // Size up to pow2
            if (_sourceArray.Length > 0x40_00_00_00) // pow 2 must be more then int.MaxValue
            {
                throw new ArgumentOutOfRangeException($"Array higher than {0x40_00_00_00} not supported by SignalConst");
            }

            var pow2 = 1;
            while (pow2 < 0x40_00_00_00 && pow2 < _sourceArray.Length)
                pow2 <<= 1;
            _n = pow2;
            _treeMin = new T[_n];
            _treeMax = new T[_n];
            var maxValue = _maxValue();
            var minValue = _minValue();

            // fill bottom layer of tree
            for (var i = 0; i < _sourceArray.Length / 2; i++) // with source array pairs min/max
            {
                _treeMin[_n / 2 + i] = _minExp(_sourceArray[i * 2], _sourceArray[i * 2 + 1]);
                _treeMax[_n / 2 + i] = _maxExp(_sourceArray[i * 2], _sourceArray[i * 2 + 1]);
            }
            if (_sourceArray.Length % 2 == 1) // if array size odd, last element haven't pair to compare
            {
                _treeMin[_n / 2 + _sourceArray.Length / 2] = _sourceArray[_sourceArray.Length - 1];
                _treeMax[_n / 2 + _sourceArray.Length / 2] = _sourceArray[_sourceArray.Length - 1];
            }
            for (var i = _n / 2 + (_sourceArray.Length + 1) / 2; i < _n; i++) // min/max for pairs of nonexistent elements
            {
                _treeMin[i] = minValue;
                _treeMax[i] = maxValue;
            }
            // fill other layers
            for (var i = _n / 2 - 1; i > 0; i--)
            {
                _treeMin[i] = _minExp(_treeMin[2 * i], _treeMin[2 * i + 1]);
                _treeMax[i] = _maxExp(_treeMax[2 * i], _treeMax[2 * i + 1]);
            }
            TreesReady = true;
        }
        catch (OutOfMemoryException oem)
        {
            _treeMin = null;
            _treeMax = null;
            TreesReady = false;
            DebugUtilities.WriteLine(oem);
        }
    }

    //  O(log(n)) for each range min/max query
    public void MinMaxRangeQuery(int l, int r, out double lowestValue, out double highestValue)
    {
        T lowestValueT;
        T highestValueT;
        // if the tree calculation isn't finished or if it crashed
        if (!TreesReady)
        {
            // use the original (slower) min/max calculated method
            lowestValueT = _sourceArray[l];
            highestValueT = _sourceArray[l];
            for (var i = l; i < r; i++)
            {
                if (_lessThanExp(_sourceArray[i], lowestValueT))
                {
                    lowestValueT = _sourceArray[i];
                }

                if (_greaterThanExp(_sourceArray[i], highestValueT))
                {
                    highestValueT = _sourceArray[i];
                }
            }
            lowestValue = NumericConversion.GenericToDouble(ref lowestValueT);
            highestValue = NumericConversion.GenericToDouble(ref highestValueT);
            return;
        }

        lowestValueT = _maxValue();
        highestValueT = _minValue();
        if (l == r)
        {
            lowestValue = highestValue = NumericConversion.GenericToDouble(ref _sourceArray[l]);
            return;
        }
        // first iteration on source array that virtualy bottom of tree
        if ((l & 1) == 1) // l is right child
        {
            lowestValueT = _minExp(lowestValueT, _sourceArray[l]);
            highestValueT = _maxExp(highestValueT, _sourceArray[l]);
        }
        if ((r & 1) != 1) // r is left child
        {
            lowestValueT = _minExp(lowestValueT, _sourceArray[r]);
            highestValueT = _maxExp(highestValueT, _sourceArray[r]);
        }
        // go up from array to bottom of Tree
        l = (l + _n + 1) / 2;
        r = (r + _n - 1) / 2;
        // next iterations on tree
        while (l <= r)
        {
            if ((l & 1) == 1) // l is right child
            {
                lowestValueT = _minExp(lowestValueT, _treeMin![l]);
                highestValueT = _maxExp(highestValueT, _treeMax![l]);
            }
            if ((r & 1) != 1) // r is left child
            {
                lowestValueT = _minExp(lowestValueT, _treeMin![r]);
                highestValueT = _maxExp(highestValueT, _treeMax![r]);
            }
            // go up one level
            l = (l + 1) / 2;
            r = (r - 1) / 2;
        }
        lowestValue = NumericConversion.GenericToDouble(ref lowestValueT);
        highestValue = NumericConversion.GenericToDouble(ref highestValueT);
    }
}
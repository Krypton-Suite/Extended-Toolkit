#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.GanttChart;

/// <summary>
/// Represents a single schedulable task on a <see cref="KryptonGanttChart"/>.
/// </summary>
public sealed class GanttTask : INotifyPropertyChanged
{
    private string _name = string.Empty;
    private DateTime _start = DateTime.Today;
    private DateTime _end = DateTime.Today;
    private int _percentComplete;
    private Color? _barColor;

    /// <summary>Stable identifier used with <see cref="GanttDependency"/>.</summary>
    public string Id { get; set; } = Guid.NewGuid().ToString("N");

    /// <summary>Display text in the task name column.</summary>
    [DefaultValue("")]
    public string Name
    {
        get => _name;
        set { if (_name == value) return; _name = value ?? string.Empty; OnPropertyChanged(nameof(Name)); }
    }

    /// <summary>Start date (date portion is used for chart placement).</summary>
    public DateTime Start
    {
        get => _start;
        set { if (_start == value) return; _start = value; OnPropertyChanged(nameof(Start)); }
    }

    /// <summary>Finish date (date portion is used; treated as inclusive).</summary>
    public DateTime End
    {
        get => _end;
        set { if (_end == value) return; _end = value; OnPropertyChanged(nameof(End)); }
    }

    /// <summary>Completion percentage from 0 to 100.</summary>
    [DefaultValue(0)]
    public int PercentComplete
    {
        get => _percentComplete;
        set
        {
            var v = value < 0 ? 0 : (value > 100 ? 100 : value);
            if (_percentComplete == v) return;
            _percentComplete = v;
            OnPropertyChanged(nameof(PercentComplete));
        }
    }

    /// <summary>Optional override for the bar colour; when null the chart assigns a colour.</summary>
    public Color? BarColor
    {
        get => _barColor;
        set { if (_barColor == value) return; _barColor = value; OnPropertyChanged(nameof(BarColor)); }
    }

    /// <inheritdoc />
    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

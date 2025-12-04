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

#region Original MIT License

/*
 * Source code for _PasswordTextBox Control_ is Copyright © 2016
 * [Nils Jonsson][mail] and [contributors][contributors].
 *  
 * Permission is hereby granted, free of charge, to any person obtaining a copy of
 * this software and associated documentation files (the “Software”), to deal in the
 * Software without restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the
 * Software, and to permit persons to whom the Software is furnished to do so,
 * subject to the following conditions:
 *  
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *  
 * THE SOFTWARE IS PROVIDED “AS IS,” WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
 * FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
 * COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN
 * AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
 * WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 *  
 * [mail]:         mailto:passwordtextbox@nilsjonsson.com                           "send email to Nils Jonsson"
 * [contributors]: https://github.com/njonsson/PasswordTextBox-Control/contributors "PasswordTextBox Control contributors at GitHub"   
 */

#endregion

namespace Krypton.Toolkit.Suite.Extended.Controls;

/// <summary>
/// An abstraction of <see cref="System.Timers.Timer"/>.
/// </summary>
/// <remarks>Exists in order to make test assertions on usage of
/// <see cref="System.Timers.Timer"/>.</remarks>
public class TimerExtended : ITimer
{
    /// <summary>
    /// Converts the specified <paramref name="timer"/> object to a
    /// <see cref="System.Timers.Timer"/>.
    /// </summary>
    /// <param name="timer">A <see cref="TimerExtended"/>.</param>
    /// <returns>The <see cref="System.Timers.Timer"/> of which
    /// <paramref name="timer"/> is an abstraction.</returns>
    public static explicit operator System.Timers.Timer(TimerExtended timer)
    {
        return timer.native;
    }

    private readonly System.Timers.Timer native;

    /// <summary>
    /// Instantiates a new <see cref="TimerExtended"/> with the specified
    /// properties.
    /// </summary>
    /// <param name="autoReset">The desired value of
    /// <see cref="AutoReset"/>.</param>
    /// <param name="interval">The desired value of
    /// <see cref="Interval"/>.</param>
    /// <param name="synchronizingObject">The desired value of
    /// <see cref="SynchronizingObject"/>; optional.</param>
    public TimerExtended(bool autoReset,
        double interval,
        ISynchronizeInvoke synchronizingObject)
    {
        native = new System.Timers.Timer
        {
            AutoReset = autoReset,
            Interval = interval,
            SynchronizingObject = synchronizingObject
        };
    }

    /// <summary>
    /// Finalizes a <see cref="TimerExtended"/>.
    /// </summary>
    ~TimerExtended()
    {
        Dispose(false);
        System.Diagnostics.Debug.Fail($"{GetType().FullName} was not disposed!");
    }

    /// <summary>
    /// Occurs when <see cref="Interval"/> elapses.
    /// </summary>
    public event ElapsedEventHandler Elapsed
    {
        add { native.Elapsed += value; }

        remove { native.Elapsed -= value; }
    }

    /// <summary>
    /// Indicates whether the <see cref="TimerExtended"/> should raise the
    /// <see cref="Elapsed"/> event each time <see cref="Interval"/> elapses
    /// or only after the first time it elapses.
    /// </summary>
    public bool AutoReset => native.AutoReset;

    /// <summary>
    /// Gets or sets the interval, in milliseconds, at which to raise the
    /// <see cref="Elapsed"/> event.
    /// </summary>
    public double Interval
    {
        get { return native.Interval; }

        set { native.Interval = value; }
    }

    /// <summary>
    /// Gets the object used to marshal events raised by the
    /// <see cref="TimerExtended"/>.
    /// </summary>
    public ISynchronizeInvoke SynchronizingObject => native.SynchronizingObject;

    /// <summary>
    /// Disposes resources acquired by the <see cref="TimerExtended"/>.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Disposes unmanaged resources acquired by the <see cref="TimerExtended"/>,
    /// optionally disposing managed resources, as well.
    /// </summary>
    /// <param name="disposing">If <c>true</c>, managed resources are
    /// disposed along with unmanaged resources.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            native.Dispose();
        }
    }

    /// <summary>
    /// Starts counting down <see cref="Interval"/> to raise
    /// <see cref="Elapsed"/>.
    /// </summary>
    public void Start()
    {
        native.Start();
    }

    /// <summary>
    /// Stops counting down <see cref="Interval"/> to raise
    /// <see cref="Elapsed"/>.
    /// </summary>
    public void Stop()
    {
        native.Stop();
    }
}
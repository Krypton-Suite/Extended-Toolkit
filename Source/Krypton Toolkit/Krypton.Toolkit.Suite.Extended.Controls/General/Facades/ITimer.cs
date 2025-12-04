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
public interface ITimer : IDisposable
{
    /// <summary>
    /// Occurs when <see cref="Interval"/> elapses.
    /// </summary>
    event ElapsedEventHandler Elapsed;

    /// <summary>
    /// Gets or sets the interval, in milliseconds, at which to raise the
    /// <see cref="Elapsed"/> event.
    /// </summary>
    double Interval { get; set; }

    /// <summary>
    /// Starts counting down <see cref="Interval"/> to raise
    /// <see cref="Elapsed"/>.
    /// </summary>
    void Start();

    /// <summary>
    /// Stops counting down <see cref="Interval"/> to raise
    /// <see cref="Elapsed"/>.
    /// </summary>
    void Stop();
}
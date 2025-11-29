#region License

/*
 * Copyright(c) 2022 Deadpikle
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

#endregion

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.Core;

/// <summary>
/// Abstract class to handle update intervals and know which is the currently installed version
/// of the software.
/// </summary>
public abstract class Configuration
{
    /// <summary>
    /// The application name
    /// </summary>
    public string ApplicationName { get; protected set; }
    /// <summary>
    /// The previous version of the software that the user ran, e.g. "1.5.2"
    /// </summary>
    public string PreviousVersionOfSoftwareRan { get; protected set; }
    /// <summary>
    /// The currently-installed version, e.g. "1.4.3"
    /// </summary>
    public string InstalledVersion { get; protected set; }
    /// <summary>
    /// Flag to indicate if we should check for updates
    /// </summary>
    public bool CheckForUpdate { get; protected set; }
    /// <summary>
    /// True if this is the first time the application has been run based on save config data; false otherwise
    /// </summary>
    public bool IsFirstRun { get; protected set; }
    /// <summary>
    /// <seealso cref="DateTime"/> of the last update check
    /// </summary>
    public DateTime LastCheckTime { get; protected set; }
    /// <summary>
    /// The version number of the update that was skipped last.
    /// If the user skipped an update, then the version to ignore is stored here (e.g. "1.4.3")
    /// </summary>
    public string LastVersionSkipped { get; protected set; }
    /// <summary>
    /// Whether or not the application has run at least one time
    /// </summary>
    public bool DidRunOnce { get; protected set; }
    /// <summary>
    /// Last profile update
    /// </summary>
    public DateTime LastConfigUpdate { get; protected set; }
    /// <summary>
    /// Object that accesses version, title, etc. info for the currently running application
    /// (or some other application)
    /// </summary>
    public IAssemblyAccessor AssemblyAccessor { get; protected set; }

    /// <summary>
    /// Constructor for Configuration -- should load all pertinent values by the end of the constructor!
    /// If any exception is thrown during construction of this object (e.g. from the assembly accessors),
    /// then <see cref="CheckForUpdate"/> is set to false.
    /// </summary>
    /// <param name="assemblyAccessor">Object that accesses version, title, etc. info for the application
    /// you would like to check for updates for</param>
    public Configuration(IAssemblyAccessor assemblyAccessor)
    {
        // set default values
        InitWithDefaultValues();

        try
        {
            // set some value from the binary
            AssemblyAccessor = assemblyAccessor;
            ApplicationName = assemblyAccessor.AssemblyProduct;
            InstalledVersion = assemblyAccessor.AssemblyVersion;
        }
        catch
        {
            CheckForUpdate = false;
        }

    }

    /// <summary>
    /// Set the last configuration update time to <see cref="DateTime.Now"/>.
    /// </summary>
    public virtual void TouchProfileTime()
    {
        LastConfigUpdate = DateTime.Now;
    }

    /// <summary>
    /// Set the last time we checked for updates to <see cref="DateTime.Now"/>.
    /// Should be used after an update check has been made.
    /// </summary>
    public virtual void TouchCheckTime()
    {
        LastCheckTime = DateTime.Now;
    }

    /// <summary>
    /// Set the given version as the version that should be skipped (ignored)
    /// when looking at available updates
    /// </summary>
    /// <param name="version">the version to skip. e.g. "1.2.3"</param>
    public virtual void SetVersionToSkip(string version)
    {
        LastVersionSkipped = version;
    }

    /// <summary>
    /// Reloads the configuration object from disk/memory/etc.
    /// </summary>
    public abstract void Reload();

    /// <summary>
    /// Set the configuration values to their default values (should check for update,
    /// last check time was in the past, no version skipped, and have never run the
    /// software).
    /// </summary>
    protected void InitWithDefaultValues()
    {
        CheckForUpdate = true;
        LastCheckTime = new DateTime(0);
        LastVersionSkipped = string.Empty;
        DidRunOnce = false;
    }
}
// *****************************************************************************
// BSD 3-Clause License (https://github.com/Krypton-Suite/Extended-Toolkit/blob/master/LICENSE)
//
//  © Component Factory Pty Ltd, 2006 - 2024, (Version 6.8.0.0)
//  © Simon Coghlan (aka Smurf-IV), 2017 - 2026, (Version 6.8.0.0)
//  © Peter Wagner (aka Wagnerp), 2017 - 2026, (Version 6.8.0.0)
//
//  All modifications are distributed under the MIT license, unless otherwise stated.
//  https://github.com/Krypton-Suite/Extended-Toolkit/blob/master/LICENSE
// *****************************************************************************

namespace Krypton.Toolkit.Suite.Extended.Ultimate.Lite;

/// <summary>
/// Provides information about the Krypton Toolkit Suite Extended Ultimate Lite package.
/// This is an all-in-one package that includes all Extended Toolkit assemblies and dependencies,
/// targeting modern frameworks only (excludes .NET Framework 4.7.2).
/// </summary>
public static class UltimateLitePackageInfo
{
    /// <summary>
    /// Gets the package name.
    /// </summary>
    public static string PackageName => "Krypton.Toolkit.Suite.Extended.Ultimate.Lite";

    /// <summary>
    /// Gets the package description.
    /// </summary>
    public static string Description => 
        "The Ultimate Lite all-in-one package for Krypton Toolkit Suite Extended. " +
        "This package includes ALL Extended Toolkit assemblies and dependencies bundled together for maximum convenience. " +
        "This is the LITE version with reduced framework targets for smaller package size.";

    /// <summary>
    /// Gets the supported frameworks.
    /// </summary>
    public static string[] SupportedFrameworks => new[]
    {
        "net48",
        "net481",
        "net8.0-windows",
        "net9.0-windows",
        "net10.0-windows"
    };

    /// <summary>
    /// Gets the difference from the full Ultimate package.
    /// </summary>
    public static string DifferenceFromUltimate => 
        "Ultimate.Lite excludes .NET Framework 4.7.2 support, resulting in a smaller package size while maintaining full functionality for modern frameworks.";

    /// <summary>
    /// Gets the assembly version.
    /// </summary>
    public static string AssemblyVersion => typeof(UltimateLitePackageInfo).Assembly.GetName().Version?.ToString() ?? "Unknown";

    /// <summary>
    /// Gets information about what's included in this package.
    /// </summary>
    public static string[] IncludedComponents => new[]
    {
        "Core & Foundation Components",
        "All Utilities and Tools",
        "Drawing & Effects Libraries",
        "Settings & Configuration",
        "All UI Controls and Components",
        "Data Visualization Controls",
        "Dialogs & Notifications",
        "Navigation & Layout Components",
        "Themes & Appearance Tools",
        "Forms & Windows",
        "File Operations",
        "Networking & Update Components",
        "Error Reporting & Debugging Tools",
        "Additional Components (PDF, Scintilla, etc.)"
    };

    /// <summary>
    /// Checks if a specific framework is supported.
    /// </summary>
    /// <param name="framework">The framework moniker to check (e.g., "net48", "net8.0-windows")</param>
    /// <returns>True if the framework is supported, false otherwise.</returns>
    public static bool IsFrameworkSupported(string framework)
    {
        return System.Array.Exists(SupportedFrameworks, f => f.Equals(framework, System.StringComparison.OrdinalIgnoreCase));
    }
}
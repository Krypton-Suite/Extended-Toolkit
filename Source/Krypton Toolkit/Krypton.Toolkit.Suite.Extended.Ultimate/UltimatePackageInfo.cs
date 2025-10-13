// *****************************************************************************
// BSD 3-Clause License (https://github.com/Krypton-Suite/Extended-Toolkit/blob/master/LICENSE)
//
//  © Component Factory Pty Ltd, 2006 - 2024, (Version 6.8.0.0)
//  © Simon Coghlan (aka Smurf-IV), 2017 - 2024, (Version 6.8.0.0)
//  © Peter Wagner (aka Wagnerp), 2017 - 2024, (Version 6.8.0.0)
//
//  All modifications are distributed under the MIT license, unless otherwise stated.
//  https://github.com/Krypton-Suite/Extended-Toolkit/blob/master/LICENSE
// *****************************************************************************

namespace Krypton.Toolkit.Suite.Extended.Ultimate;

/// <summary>
/// Provides information about the Krypton Toolkit Suite Extended Ultimate package.
/// This is an all-in-one package that includes all Extended Toolkit assemblies and dependencies.
/// </summary>
public static class UltimatePackageInfo
{
    /// <summary>
    /// Gets the package name.
    /// </summary>
    public static string PackageName => "Krypton.Toolkit.Suite.Extended.Ultimate";

    /// <summary>
    /// Gets the package description.
    /// </summary>
    public static string Description => 
        "The Ultimate all-in-one package for Krypton Toolkit Suite Extended. " +
        "This package includes ALL Extended Toolkit assemblies and dependencies bundled together for maximum convenience.";

    /// <summary>
    /// Gets the supported frameworks.
    /// </summary>
    public static string[] SupportedFrameworks => new[]
    {
        "net472",
        "net48",
        "net481",
        "net8.0-windows",
        "net9.0-windows",
        "net10.0-windows"
    };

    /// <summary>
    /// Gets the assembly version.
    /// </summary>
    public static string AssemblyVersion => typeof(UltimatePackageInfo).Assembly.GetName().Version?.ToString() ?? "Unknown";

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
}
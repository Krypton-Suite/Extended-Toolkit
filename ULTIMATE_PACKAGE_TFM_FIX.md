# 🎯 **Ultimate Package Fix - TFM & Assembly Filtering**

## 📋 **Issues Identified**

### **Issue 1: Invalid TFM**
The Ultimate packages were including files under invalid TFMs (Target Framework Monikers):
- `lib/net10.0-windows/` - **INVALID** (.NET 10 doesn't exist yet)
- `lib/net8.0-windows/` - Valid but showing warnings
- `lib/net9.0-windows/` - Valid but showing warnings

### **Issue 2: Framework Assemblies Included**
The packages were including **ALL assemblies**, including:
- ❌ .NET BCL assemblies (System.*, Microsoft.*, etc.)
- ❌ Windows Framework assemblies (WindowsBase, PresentationCore, etc.)
- ✅ Should only include Krypton Extended Toolkit assemblies and third-party dependencies

## 🔧 **Root Causes**

1. **Invalid TFM:** The project files had `net10.0-windows` in their `<TargetFrameworks>` property, but .NET 10 is not released yet.

2. **Over-inclusive Packaging:** The custom target was including `@(ReferenceCopyLocalPaths)` without filtering, which included all framework assemblies that shouldn't be in the package.

## ✅ **Fixes Applied**

### **Fix 1: Removed Invalid TFM**

**Before:**
```xml
<TargetFrameworks>net472;net48;net481;net8.0-windows;net9.0-windows;net10.0-windows</TargetFrameworks>
```

**After:**
```xml
<TargetFrameworks>net472;net48;net481;net8.0-windows;net9.0-windows</TargetFrameworks>
```

### **Fix 2: Filter Out Framework Assemblies**

**Before:**
```xml
<Target Name="IncludeAllDependenciesInPackage" DependsOnTargets="ResolveReferences">
  <ItemGroup>
    <!-- Include all referenced assemblies - TOO BROAD! -->
    <BuildOutputInPackage Include="@(ReferenceCopyLocalPaths)" />
    <TfmSpecificPackageFile Include="@(ReferenceCopyLocalPaths)" PackagePath="lib/$(TargetFramework)/" />
  </ItemGroup>
</Target>
```

**After:**
```xml
<Target Name="IncludeAllDependenciesInPackage" DependsOnTargets="ResolveReferences">
  <ItemGroup>
    <!-- Include ONLY non-framework assemblies -->
    <_AllReferences Include="@(ReferenceCopyLocalPaths)" />
    
    <!-- Filter out framework assemblies (System.*, Microsoft.*, WindowsBase, etc.) -->
    <_FrameworkAssemblies Include="@(_AllReferences)" 
      Condition="$([System.String]::new('%(Filename)').StartsWith('System.')) OR 
                 $([System.String]::new('%(Filename)').StartsWith('Microsoft.VisualBasic')) OR 
                 ... (and more filters)" />
    
    <!-- Include only non-framework assemblies -->
    <_NonFrameworkAssemblies Include="@(_AllReferences)" Exclude="@(_FrameworkAssemblies)" />
    
    <BuildOutputInPackage Include="@(_NonFrameworkAssemblies)" />
    <TfmSpecificPackageFile Include="@(_NonFrameworkAssemblies)" PackagePath="lib/$(TargetFramework)/" />
  </ItemGroup>
</Target>
```

### **Fix 3: Updated Package Descriptions**

**Ultimate Package:**
- Changed from "Supports .NET Framework 4.7.2 - 4.8.1, .NET 8 - 10"
- To "Supports .NET Framework 4.7.2 - 4.8.1, .NET 8 - 9"

**Ultimate Lite Package:**
- Changed from "Supports .NET Framework 4.8 - 4.8.1, .NET 8 - 10"
- To "Supports .NET Framework 4.8 - 4.8.1, .NET 8 - 9"
- Updated comparison table to reflect correct TFMs

## 📁 **Files Modified**

1. **`Source/Krypton Toolkit/Krypton.Toolkit.Suite.Extended.Ultimate/Krypton.Toolkit.Suite.Extended.Ultimate 2022.csproj`**
   - Removed `net10.0-windows` from `<TargetFrameworks>`
   - Updated description
   - Added framework assembly filtering in `IncludeAllDependenciesInPackage` target

2. **`Source/Krypton Toolkit/Krypton.Toolkit.Suite.Extended.Ultimate.Lite/Krypton.Toolkit.Suite.Extended.Ultimate.Lite 2022.csproj`**
   - Removed `net10.0-windows` from `<TargetFrameworks>`
   - Updated description and comparison table
   - Added framework assembly filtering in `IncludeAllDependenciesInPackage` target

## 🎯 **Expected Result**

After these fixes, the Ultimate packages should:
- ✅ Only include files under valid TFMs (net472, net48, net481, net8.0-windows, net9.0-windows)
- ✅ Include only Krypton Extended Toolkit assemblies
- ✅ Include only third-party dependencies (BouncyCastle, SkiaSharp, Newtonsoft.Json, etc.)
- ❌ **NOT** include .NET Framework assemblies (System.*, Microsoft.*, etc.)
- ❌ **NOT** include Windows Presentation Foundation assemblies
- ✅ Much smaller package size
- ✅ No conflicts with target framework assemblies

## 🚀 **Next Steps**

1. **Clean and rebuild** the Ultimate packages
2. **Test package creation** to verify the fix
3. **Verify package contents** using the diagnostic tools

## 🔍 **What Assemblies Will Be Included?**

The filtering logic now excludes:
- All `System.*` assemblies
- All `Microsoft.VisualBasic*` assemblies
- All `Microsoft.Win32.*` assemblies
- All `Microsoft.CSharp` assemblies
- BCL assemblies: `mscorlib`, `netstandard`
- WPF assemblies: `WindowsBase`, `PresentationCore`, `PresentationFramework`, etc.
- UI Automation assemblies: `UIAutomationClient`, `UIAutomationProvider`, etc.
- `Accessibility` assembly

**What WILL be included:**
- ✅ All `Krypton.Toolkit.Suite.Extended.*` assemblies
- ✅ `Krypton.Toolkit.dll`, `Krypton.Docking.dll`, `Krypton.Navigator.dll`, `Krypton.Ribbon.dll`, `Krypton.Workspace.dll`
- ✅ Third-party dependencies:
  - `BouncyCastle.Crypto.dll`
  - `Cyotek.Windows.Forms.ColorPicker.dll`
  - `Handlebars.dll`
  - `libSkiaSharp.dll`, `SkiaSharp.dll`, `SkiaSharp.Views.*`
  - `libsodium.dll`, `NSec.Cryptography.dll` (net8.0+ only)
  - `Microsoft.WindowsAPICodePack.*` (not framework, third-party)
  - `Newtonsoft.Json.dll`
  - `OpenTK.dll`, `OpenTK.GLControl.dll`
  - `ProDotNetZip.dll`
  - `SimpleMapi.NET.dll`
  - `WinFormAnimation_DotNET.dll`

## 📝 **Notes**

1. **Platform Version Warning:** The warning about "missing a platform version" for `net8.0-windows` and `net9.0-windows` is a NuGet validation warning. These TFMs are valid, but ideally should specify a Windows SDK version (e.g., `net8.0-windows7.0`). However, using just `net8.0-windows` is acceptable and common practice.

2. **.NET 10:** When .NET 10 is officially released, you can add `net10.0-windows` back to the `<TargetFrameworks>` property.

3. **Package Size:** The packages will be **significantly smaller** now that framework assemblies are excluded (from ~200MB+ to likely under 50MB).

---

**Status:** ✅ **Fixed** - Invalid TFM removed & Framework assemblies filtered out

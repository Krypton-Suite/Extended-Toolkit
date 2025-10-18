# 🎯 Centralized Target Framework Monikers (TFMs) Configuration

## 📋 Overview

The Extended Toolkit now uses a **centralized TFM configuration system** defined in `Directory.Build.props`. This ensures **all projects** target consistent framework versions and makes it easy to update framework support globally.

## 🌟 Available TFM Configurations

### **1. ExtendedToolkitTFMs** (Full Support)
```xml
<TargetFrameworks>$(ExtendedToolkitTFMs)</TargetFrameworks>
```
**Includes:** `net472;net48;net481;net8.0-windows7.0;net9.0-windows7.0`

**Use for:**
- ✅ All standard Extended Toolkit projects
- ✅ Maximum compatibility
- ✅ Legacy and modern framework support

**Example Projects:**
- `Krypton.Toolkit.Suite.Extended.Ultimate`
- Most Extended Toolkit libraries

---

### **2. ExtendedToolkitLiteTFMs** (Lite Support)
```xml
<TargetFrameworks>$(ExtendedToolkitLiteTFMs)</TargetFrameworks>
```
**Includes:** `net48;net481;net8.0-windows7.0;net9.0-windows7.0`

**Use for:**
- ✅ Lite packages (smaller size)
- ✅ Modern .NET Framework 4.8+ only
- ✅ Excludes legacy .NET Framework 4.7.2

**Example Projects:**
- `Krypton.Toolkit.Suite.Extended.Ultimate.Lite`

---

### **3. ExtendedToolkitModernTFMs** (Modern Only)
```xml
<TargetFrameworks>$(ExtendedToolkitModernTFMs)</TargetFrameworks>
```
**Includes:** `net8.0-windows7.0;net9.0-windows7.0`

**Use for:**
- ✅ Modern .NET only projects
- ✅ Cutting-edge features
- ✅ Smallest package size

**Example Use Cases:**
- New projects targeting modern .NET only
- Utilities that don't need .NET Framework support

---

### **4. ExtendedToolkitLegacyTFMs** (Legacy Only)
```xml
<TargetFrameworks>$(ExtendedToolkitLegacyTFMs)</TargetFrameworks>
```
**Includes:** `net472;net48;net481`

**Use for:**
- ✅ Legacy-only projects
- ✅ .NET Framework-specific utilities
- ✅ Compatibility layers

**Example Use Cases:**
- .NET Framework-specific utilities
- Legacy migration projects

---

## 🔧 Implementation

### **Directory.Build.props Configuration**

```xml
<PropertyGroup>
    <!-- Full framework support (all projects by default) -->
    <ExtendedToolkitTFMs>net472;net48;net481;net8.0-windows7.0;net9.0-windows7.0</ExtendedToolkitTFMs>
    
    <!-- Lite framework support (excludes net472 for smaller packages) -->
    <ExtendedToolkitLiteTFMs>net48;net481;net8.0-windows7.0;net9.0-windows7.0</ExtendedToolkitLiteTFMs>
    
    <!-- Modern frameworks only (net8+) -->
    <ExtendedToolkitModernTFMs>net8.0-windows7.0;net9.0-windows7.0</ExtendedToolkitModernTFMs>
    
    <!-- Legacy frameworks only (net4x) -->
    <ExtendedToolkitLegacyTFMs>net472;net48;net481</ExtendedToolkitLegacyTFMs>
</PropertyGroup>
```

### **Project File Usage**

**Before (Manual Configuration):**
```xml
<PropertyGroup>
    <TargetFrameworks>net472;net48;net481;net8.0-windows7.0;net9.0-windows7.0</TargetFrameworks>
</PropertyGroup>
```

**After (Centralized Configuration):**
```xml
<PropertyGroup>
    <!-- Use centralized TFM configuration from Directory.Build.props -->
    <TargetFrameworks>$(ExtendedToolkitTFMs)</TargetFrameworks>
</PropertyGroup>
```

---

## 🎯 Benefits

### **For Developers**
- 🚀 **Single Source of Truth**: All TFMs defined in one place
- ✅ **Easy Updates**: Change TFMs globally by editing `Directory.Build.props`
- 🎯 **Consistency**: All projects use the same framework versions
- 🔧 **Flexibility**: Choose appropriate TFM set per project

### **For Maintenance**
- 📊 **Version Management**: Update .NET versions globally
- 🔄 **Easy Migration**: Add/remove frameworks in one place
- 🎯 **Predictable**: All projects follow the same pattern

### **For CI/CD**
- 🤖 **Automated**: Consistent framework targeting
- 📦 **Reliable**: Predictable build outputs
- 🚀 **Scalable**: Easy to add new frameworks

---

## 📈 Usage Examples

### **Standard Extended Toolkit Project**
```xml
<Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
        <TargetFrameworks>$(ExtendedToolkitTFMs)</TargetFrameworks>
        <OutputType>library</OutputType>
        <!-- ... other properties ... -->
    </PropertyGroup>
</Project>
```

### **Lite Package Project**
```xml
<Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
        <TargetFrameworks>$(ExtendedToolkitLiteTFMs)</TargetFrameworks>
        <OutputType>library</OutputType>
        <!-- ... other properties ... -->
    </PropertyGroup>
</Project>
```

### **Modern-Only Project**
```xml
<Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
        <TargetFrameworks>$(ExtendedToolkitModernTFMs)</TargetFrameworks>
        <OutputType>library</OutputType>
        <!-- ... other properties ... -->
    </PropertyGroup>
</Project>
```

### **Custom Override (if needed)**
```xml
<Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
        <!-- Override with custom TFMs if project has specific requirements -->
        <TargetFrameworks>net481;net8.0-windows7.0</TargetFrameworks>
        <OutputType>library</OutputType>
        <!-- ... other properties ... -->
    </PropertyGroup>
</Project>
```

---

## 🔄 Updating Framework Versions

### **Adding .NET 10 Support (Future)**

**Single change in `Directory.Build.props`:**
```xml
<PropertyGroup>
    <ExtendedToolkitTFMs>net472;net48;net481;net8.0-windows7.0;net9.0-windows7.0;net10.0-windows7.0</ExtendedToolkitTFMs>
    <ExtendedToolkitLiteTFMs>net48;net481;net8.0-windows7.0;net9.0-windows7.0;net10.0-windows7.0</ExtendedToolkitLiteTFMs>
    <ExtendedToolkitModernTFMs>net8.0-windows7.0;net9.0-windows7.0;net10.0-windows7.0</ExtendedToolkitModernTFMs>
</PropertyGroup>
```

**Result:** All projects automatically target .NET 10! 🎉

### **Dropping .NET Framework 4.7.2 Support (Future)**

**Single change in `Directory.Build.props`:**
```xml
<PropertyGroup>
    <ExtendedToolkitTFMs>net48;net481;net8.0-windows7.0;net9.0-windows7.0</ExtendedToolkitTFMs>
    <!-- ExtendedToolkitLiteTFMs remains unchanged -->
</PropertyGroup>
```

**Result:** All projects drop .NET Framework 4.7.2! 🎉

---

## 📊 Current Framework Support

| TFM Configuration | net472 | net48 | net481 | net8.0-windows7.0 | net9.0-windows7.0 |
|-------------------|--------|-------|--------|-------------------|-------------------|
| **ExtendedToolkitTFMs** | ✅ | ✅ | ✅ | ✅ | ✅ |
| **ExtendedToolkitLiteTFMs** | ❌ | ✅ | ✅ | ✅ | ✅ |
| **ExtendedToolkitModernTFMs** | ❌ | ❌ | ❌ | ✅ | ✅ |
| **ExtendedToolkitLegacyTFMs** | ✅ | ✅ | ✅ | ❌ | ❌ |

---

## 🎉 Result

**Centralized TFM configuration provides:**
- ✅ **Single Source of Truth**: All TFMs defined in `Directory.Build.props`
- ✅ **Easy Maintenance**: Update framework versions globally
- ✅ **Consistency**: All projects use standard configurations
- ✅ **Flexibility**: Multiple TFM sets for different use cases
- ✅ **Scalability**: Easy to add/remove frameworks

**This creates a unified, maintainable framework targeting strategy for the entire Extended Toolkit!** 🌟

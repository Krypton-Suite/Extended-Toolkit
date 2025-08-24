# KryptonDropZone Demo Applications

This folder contains demo applications that showcase the `KryptonDropZone` control and all its features.

## 📁 Demo Files

### 1. `KryptonDropZoneSimpleDemo.cs` - Simple Demo
A clean, focused demo that shows the core functionality:
- **Drop zone** with custom styling
- **File list** with icons and tooltips
- **Progress bar** showing file processing
- **Clear button** for file management
- **File extension filtering**
- **Click-to-browse** functionality

### 2. `KryptonDropZoneDemo.cs` - Full Featured Demo
A comprehensive demo with all controls and features:
- **Interactive controls** for toggling features on/off
- **File extension management** with real-time updates
- **Save/Load** file lists to/from disk
- **Status updates** and logging
- **All customization options**

## 🚀 How to Run the Demos

### Option 1: Simple Demo (Recommended for first-time users)
```csharp
// Run the simple demo
Application.Run(new KryptonDropZoneSimpleDemo());
```

### Option 2: Full Featured Demo
```csharp
// Run the comprehensive demo
Application.Run(new KryptonDropZoneDemo());
```

## ✨ Features Demonstrated

### 🎨 **Visual Design**
- **Minimalist drop zone** with dashed borders
- **Hover effects** with color transitions
- **Subtle shadows** and visual feedback
- **Clean, professional appearance**

### 📁 **File Management**
- **Drag & drop** files and folders
- **Click to browse** file dialog
- **File list view** with icons and tooltips
- **File reordering** within the list
- **Clear all files** functionality

### 📊 **Progress & Size Tracking**
- **Progress bar** showing file processing
- **Total file size** calculation
- **Real-time updates** during processing
- **File count** and size information

### ⚙️ **Customization**
- **File extension filtering** (allow specific types)
- **Show/hide** file list, progress bar, clear button
- **Custom colors** for borders and hover states
- **Custom text** for drop zone instructions

### 💾 **Persistence**
- **Save file lists** to disk
- **Load file lists** from disk
- **Export/import** file collections

## 🔧 Basic Usage Example

```csharp
// Create a basic drop zone
var dropZone = new KryptonDropZone();

// Customize appearance
dropZone.DropZoneText = "Drop your files here";
dropZone.BorderColor = Color.LightGray;
dropZone.HoverBorderColor = Color.DodgerBlue;

// Set allowed file types
dropZone.AllowedExtensions = new List<string> { ".txt", ".pdf", ".jpg" };

// Handle file drops
dropZone.ValidFilesDropped += (sender, files) => {
    Console.WriteLine($"Dropped {files.Count} files");
    Console.WriteLine($"Total size: {dropZone.TotalFileSizeFormatted}");
};

// Control visibility
dropZone.ShowFileListView = true;      // Show file list
dropZone.ShowSizeProgressBar = true;   // Show progress bar
dropZone.ShowClearButton = true;       // Show clear button
```

## 🎯 What You'll Learn

1. **How to create** a professional-looking drop zone
2. **How to handle** file drops and browsing
3. **How to customize** the appearance and behavior
4. **How to manage** file lists and extensions
5. **How to integrate** with your applications
6. **Best practices** for file upload interfaces

## 🎨 Design Features

The demos showcase the **minimalist design** similar to modern file upload interfaces:
- **Centered drop zone** with proper spacing
- **Dashed borders** that respond to hover
- **Clean typography** and visual hierarchy
- **Responsive feedback** during interactions
- **Professional appearance** suitable for business applications

## 🚀 Next Steps

After running the demos:
1. **Experiment** with different settings
2. **Try** different file types and sizes
3. **Customize** colors and text
4. **Integrate** into your own applications
5. **Extend** with additional features as needed

The `KryptonDropZone` control provides a solid foundation for building professional file upload interfaces with a modern, clean design.

# KryptonMessageBoxExtended - Expandable Footer Feature

## Overview

The `KryptonMessageBoxExtended` now supports an **expandable footer** feature, similar to Windows TaskDialog. This allows developers to display additional information (such as error details, stack traces, or help text) in a collapsible footer area that users can expand or collapse as needed.

## Table of Contents

<!-- Start Document Outline -->

* [Overview](#overview)
* [Features](#features)
* [API Reference](#api-reference)
  * [Show Method Overloads](#show-method-overloads)
  * [Properties](#properties)
* [Usage Examples](#usage-examples)
  * [Basic Usage](#basic-usage)
  * [Error with Stack Trace](#error-with-stack-trace)
  * [Warning with Additional Context](#warning-with-additional-context)
  * [Information with Technical Details](#information-with-technical-details)
  * [Question with Help Text](#question-with-help-text)
  * [Validation Errors](#validation-errors)
* [Implementation Details](#implementation-details)
  * [Footer Panel Structure](#footer-panel-structure)
  * [Toggle Mechanism](#toggle-mechanism)
  * [Sizing Behavior](#sizing-behavior)
* [Best Practices](#best-practices)
* [Compatibility](#compatibility)
* [See Also](#see-also)

<!-- End Document Outline -->

## Features

### Key Features

- **Expandable/Collapsible Footer** - Footer can be shown or hidden by the user via a toggle link
- **Configurable Initial State** - Footer can start expanded or collapsed based on developer preference
- **Multiple Content Types** - Footer supports Text (KryptonWrapLabel), CheckBox (KryptonCheckBox), or RichTextBox (KryptonRichTextBox)
- **Configurable RichTextBox Height** - When using RichTextBox, developers can specify a custom height
- **Automatic Sizing** - Form automatically adjusts its size when footer is expanded or collapsed
- **Optional Feature** - Footer is completely optional; if not specified, message box behaves as before
- **Seamless Integration** - Works with all existing message box features (icons, buttons, timeout, etc.)
- **User-Friendly** - Toggle link text automatically changes between "Show details" and "Hide details"

### Visual Design

- Footer appears below the button panel
- Border edge separates footer from main content
- Toggle link appears at the top of the footer area
- Footer text uses the same font as the main message (configurable via `MessageBoxTypeface`)
- Footer panel uses alternate panel style for visual distinction

## API Reference

### Show Method Overloads

The expandable footer feature is available through new `Show` method overloads that include `footerText` and `footerExpanded` parameters.

#### Basic Footer Overload

```csharp
public static DialogResult Show(
    string text, 
    string caption,
    ExtendedMessageBoxButtons buttons, 
    ExtendedKryptonMessageBoxIcon icon, 
    string? footerText = null, 
    bool footerExpanded = false,
    ExtendedKryptonMessageBoxFooterContentType footerContentType = ExtendedKryptonMessageBoxFooterContentType.Text,
    int? footerRichTextBoxHeight = null,
    bool? showCtrlCopy = null, 
    Font? messageBoxTypeface = null
)
```

**Parameters:**
- `text` - The main message text to display
- `caption` - The title bar caption
- `buttons` - Button configuration (OK, YesNo, YesNoCancel, etc.)
- `icon` - Icon to display (Error, Warning, Information, Question, None)
- `footerText` - **NEW**: Text content to display in the footer. If `null` or empty, footer will not be shown (unless `footerContentType` is `CheckBox`)
- `footerExpanded` - **NEW**: If `true`, footer starts expanded; if `false`, starts collapsed (default: `false`)
- `footerContentType` - **NEW**: Type of content to display in footer: `Text` (default), `CheckBox`, or `RichTextBox`
- `footerRichTextBoxHeight` - **NEW**: Height in pixels for RichTextBox when `footerContentType` is `RichTextBox`. If `null`, uses default height
- `showCtrlCopy` - Show "Ctrl+C to copy" hint in title bar
- `messageBoxTypeface` - Custom font for message and footer text

**Returns:** `DialogResult` indicating which button was clicked

#### Owner-Specified Overload

```csharp
public static DialogResult Show(
    IWin32Window owner,
    string text, 
    string caption,
    ExtendedMessageBoxButtons buttons, 
    ExtendedKryptonMessageBoxIcon icon, 
    string? footerText = null, 
    bool footerExpanded = false,
    ExtendedKryptonMessageBoxFooterContentType footerContentType = ExtendedKryptonMessageBoxFooterContentType.Text,
    int? footerRichTextBoxHeight = null,
    bool? showCtrlCopy = null, 
    Font? messageBoxTypeface = null
)
```

**Additional Parameters:**
- `owner` - Owner window for the modal dialog

### Properties

The following properties are available on `KryptonMessageBoxExtended` instances (though typically accessed through static methods):

#### FooterText

```csharp
public string FooterText { get; set; }
```

Gets or sets the footer text content to display in the expandable footer area.

- **Type:** `string`
- **Default:** `null` (footer not shown)
- **Remarks:** If `null` or empty, the footer will not be displayed

#### FooterExpanded

```csharp
public bool FooterExpanded { get; set; }
```

Gets or sets a value indicating whether the footer is initially expanded.

- **Type:** `bool`
- **Default:** `false`
- **Remarks:** 
  - `true` - Footer starts expanded and visible
  - `false` - Footer starts collapsed (only toggle link visible)

#### IsFooterExpanded

```csharp
public bool IsFooterExpanded { get; }
```

Gets a value indicating whether the footer is currently visible and expanded.

- **Type:** `bool` (read-only)
- **Remarks:** Returns `true` if footer is visible and expanded, `false` otherwise

## Usage Examples

### Basic Usage

#### Simple Error with Collapsed Footer

```csharp
using Krypton.Toolkit.Suite.Extended.Messagebox;
using System.Windows.Forms;

// Error message with collapsed footer containing stack trace (Text content type - default)
string mainMessage = "An error occurred while processing your request.";
string footerText = @"Stack Trace:
   at Examples.MyClass.ProcessData()
   at Examples.MyClass.Main(String[] args)
   
Exception: System.InvalidOperationException
Message: The operation cannot be completed.";

DialogResult result = KryptonMessageBoxExtended.Show(
    this,
    mainMessage,
    "Error",
    ExtendedMessageBoxButtons.OK,
    ExtendedKryptonMessageBoxIcon.Error,
    footerText,
    footerExpanded: false,  // Footer starts collapsed
    footerContentType: ExtendedKryptonMessageBoxFooterContentType.Text  // Default, can be omitted
);
```

#### Warning with Expanded Footer

```csharp
// Warning with important information that should be visible immediately
string mainMessage = "This operation will modify system settings.";
string footerText = @"Additional Information:
• This change affects all users on this system
• A system restart may be required
• Previous settings will be backed up automatically";

DialogResult result = KryptonMessageBoxExtended.Show(
    this,
    mainMessage,
    "Warning",
    ExtendedMessageBoxButtons.YesNo,
    ExtendedKryptonMessageBoxIcon.Warning,
    footerText,
    footerExpanded: true  // Footer starts expanded
);
```

### Error with Stack Trace (Text Footer)

Display comprehensive error information in a collapsed footer to avoid overwhelming users:

```csharp
try
{
    // Your code here
}
catch (Exception ex)
{
    string mainMessage = "An unexpected error occurred.";
    string footerText = $@"Exception Details:
Type: {ex.GetType().FullName}
Message: {ex.Message}
Source: {ex.Source}

Stack Trace:
{ex.StackTrace}

{(ex.InnerException != null ? $"\nInner Exception:\n{ex.InnerException}" : "")}";

    KryptonMessageBoxExtended.Show(
        this,
        mainMessage,
        "Error",
        ExtendedMessageBoxButtons.OK,
        ExtendedKryptonMessageBoxIcon.Error,
        footerText,
        footerExpanded: false,
        footerContentType: ExtendedKryptonMessageBoxFooterContentType.Text  // Default
    );
}
```

### Error with RichTextBox Footer

For formatted error details, use RichTextBox with custom height:

```csharp
catch (Exception ex)
{
    string mainMessage = "An unexpected error occurred.";
    string footerText = $@"Exception: {ex.GetType().FullName}
Message: {ex.Message}
Source: {ex.Source}

Stack Trace:
{ex.StackTrace}";

    KryptonMessageBoxExtended.Show(
        this,
        mainMessage,
        "Error",
        ExtendedMessageBoxButtons.OK,
        ExtendedKryptonMessageBoxIcon.Error,
        footerText,
        footerExpanded: false,
        footerContentType: ExtendedKryptonMessageBoxFooterContentType.RichTextBox,
        footerRichTextBoxHeight: 200  // Custom height in pixels
    );
}
```

### Question with CheckBox Footer

Use a checkbox in the footer for user preferences:

```csharp
KryptonMessageBoxExtended.Show(
    this,
    "Do you want to save your changes before closing?",
    "Save Changes?",
    ExtendedMessageBoxButtons.YesNoCancel,
    ExtendedKryptonMessageBoxIcon.Question,
    footerText: "Remember my choice",
    footerContentType: ExtendedKryptonMessageBoxFooterContentType.CheckBox,
    footerExpanded: true  // Checkbox visible by default
);
```

### Warning with Additional Context

Provide additional context for warnings without cluttering the main message:

```csharp
string mainMessage = "This operation will modify system settings.";
string footerText = @"Additional Information:
• This change affects all users on this system
• A system restart may be required
• Previous settings will be backed up automatically
• You can restore previous settings from the Settings menu

For more information, visit: https://example.com/help";

DialogResult result = KryptonMessageBoxExtended.Show(
    this,
    mainMessage,
    "Warning",
    ExtendedMessageBoxButtons.YesNo,
    ExtendedKryptonMessageBoxIcon.Warning,
    footerText,
    footerExpanded: true
);
```

### Information with Technical Details

Show technical details that may be useful for advanced users or troubleshooting:

```csharp
string mainMessage = "Your file has been successfully processed.";
string footerText = $@"Processing Details:
File: {filePath}
Size: {fileSize:N0} bytes
Processing Time: {processingTime.TotalSeconds:F2} seconds
Pages Processed: {pageCount}
Format: {fileFormat}
Checksum: {checksum}
Timestamp: {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC";

KryptonMessageBoxExtended.Show(
    this,
    mainMessage,
    "Information",
    ExtendedMessageBoxButtons.OK,
    ExtendedKryptonMessageBoxIcon.Information,
    footerText,
    footerExpanded: false
);
```

### Question with Help Text

Provide guidance for user decisions:

```csharp
string mainMessage = "Do you want to save your changes before closing?";
string footerText = @"Help:
• Click 'Yes' to save your changes and close the document
• Click 'No' to close without saving (changes will be lost)
• Click 'Cancel' to return to the document and continue editing

Keyboard Shortcuts:
• Ctrl+S: Save
• Ctrl+W: Close
• Esc: Cancel";

DialogResult result = KryptonMessageBoxExtended.Show(
    this,
    mainMessage,
    "Save Changes?",
    ExtendedMessageBoxButtons.YesNoCancel,
    ExtendedKryptonMessageBoxIcon.Question,
    footerText,
    footerExpanded: false
);
```

### Validation Errors

Display multiple validation errors in an organized format:

```csharp
var validationErrors = new List<string>
{
    "Email Address: Invalid format. Expected format: user@example.com",
    "Phone Number: Required field cannot be empty",
    "Date of Birth: Date cannot be in the future",
    "Password: Must be at least 8 characters and contain uppercase, lowercase, and numbers",
    "Confirm Password: Passwords do not match"
};

string mainMessage = "Please correct the following validation errors:";
string footerText = "Validation Errors:\n" + 
    string.Join("\n", validationErrors.Select((err, idx) => $"{idx + 1}. {err}")) +
    "\n\nPlease review each field and correct the errors before proceeding.";

KryptonMessageBoxExtended.Show(
    this,
    mainMessage,
    "Validation Failed",
    ExtendedMessageBoxButtons.OK,
    ExtendedKryptonMessageBoxIcon.Warning,
    footerText,
    footerExpanded: true  // Expanded to show all errors immediately
);
```

## Implementation Details

### Footer Panel Structure

The footer consists of the following components:

1. **Footer Panel** (`KryptonPanel`)
   - Uses `PaletteBackStyle.PanelAlternate` for visual distinction
   - Docked to top of form (below button panel)
   - Height adjusts dynamically based on expanded state

2. **Border Edge** (`KryptonBorderEdge`)
   - Separates footer from main content
   - Uses `PaletteBorderStyle.HeaderPrimary`
   - Docked to top of footer panel

3. **Toggle Button** (`KryptonButton`)
   - "Show details" when collapsed
   - "Hide details" when expanded
   - Clickable button to toggle footer state
   - Uses default Krypton button styling

4. **Footer Content** (one of the following, based on `footerContentType`):
   - **Text** (`KryptonWrapLabel`) - Displays text content with word wrapping
   - **CheckBox** (`KryptonCheckBox`) - Displays a checkbox with configurable text label
   - **RichTextBox** (`KryptonRichTextBox`) - Displays formatted text with configurable height (read-only)
   - All content types use the same font as main message (configurable via `MessageBoxTypeface`)
   - Content is visible only when footer is expanded

### Toggle Mechanism

When the user clicks the toggle button:

1. Footer expanded state is toggled
2. Footer content visibility is updated (Text, CheckBox, or RichTextBox)
3. Toggle button text changes ("Show details" ↔ "Hide details")
4. Footer panel height is recalculated based on content type:
   - **Text**: Height calculated from text measurement
   - **CheckBox**: Height based on checkbox control height
   - **RichTextBox**: Height uses specified `footerRichTextBoxHeight` or default
5. Form size is recalculated to accommodate new footer height

### Sizing Behavior

The form automatically adjusts its size when the footer is expanded or collapsed:

- **Collapsed State**: Footer height is minimal (~30 pixels) - just enough for the toggle button
- **Expanded State**: Footer height is calculated based on content type:
  - **Text**: Height calculated from text measurement, wrapping, and available width
  - **CheckBox**: Height based on checkbox control height
  - **RichTextBox**: Height uses specified `footerRichTextBoxHeight` parameter or default (100 pixels)
  - All types include padding for toggle button and borders
  - Minimum height of 50 pixels applies

The `UpdateSizing()` method accounts for:
- Message panel height
- Button panel height
- Footer panel height (varies based on state)
- Maximum width across all panels

## Best Practices

### When to Use the Footer

✅ **Good Use Cases:**
- **Error Details**: Stack traces, exception information, technical error codes
- **Additional Context**: Extra information that doesn't fit in the main message
- **Help Text**: Guidance for user decisions, keyboard shortcuts
- **Validation Errors**: Multiple field validation errors
- **System Information**: Diagnostic information, file details, processing statistics
- **Troubleshooting**: Steps to resolve issues, contact information

❌ **Avoid Using Footer For:**
- Critical information that users must see immediately (use main message instead)
- Very short text that fits easily in the main message
- Information that changes the meaning of the main message

### Footer Content Guidelines

1. **Keep it Relevant**: Footer should provide additional context, not replace the main message
2. **Choose Appropriate Content Type**:
   - Use **Text** for simple text content, stack traces, error details
   - Use **CheckBox** for user preferences and optional settings
   - Use **RichTextBox** for formatted text, code snippets, or longer content requiring scrolling
3. **Structure Clearly**: Use bullet points, numbered lists, or clear sections for readability
4. **Appropriate Length**: Very long footer text may require scrolling; consider breaking into sections or using RichTextBox
5. **RichTextBox Height**: Set a reasonable height (typically 100-200 pixels) based on expected content length
6. **Technical vs. User-Friendly**: Consider your audience - technical details are fine for developer tools, but keep user-facing messages simple

### Initial State Recommendations

- **Start Collapsed** (`footerExpanded: false`):
  - Stack traces and error details (Text or RichTextBox)
  - Technical information (Text or RichTextBox)
  - Optional help text (Text)
  - Information that most users won't need
  - CheckBox for optional preferences (CheckBox)

- **Start Expanded** (`footerExpanded: true`):
  - Important warnings that users should read (Text or RichTextBox)
  - Validation errors that need immediate attention (Text or RichTextBox)
  - Critical additional context
  - CheckBox that users should see immediately (CheckBox)

### Integration with Other Features

The footer feature works seamlessly with all existing `KryptonMessageBoxExtended` features:

- ✅ **Icons**: All icon types (Error, Warning, Information, Question, None)
- ✅ **Button Configurations**: All button types (OK, YesNo, YesNoCancel, etc.)
- ✅ **Custom Fonts**: Footer content uses the same `MessageBoxTypeface` as the main message
- ✅ **Timeout**: Footer works with timeout functionality
- ✅ **Do Not Show Again**: Footer works with the "Do not show again" checkbox (separate from footer CheckBox)
- ✅ **Custom Button Text**: Footer works with custom button text
- ✅ **Content Types**: All three footer content types (Text, CheckBox, RichTextBox) work with all features
- ✅ **RTL Support**: Footer supports right-to-left layouts

## Compatibility

### Framework Support

The expandable footer feature is available in all supported framework versions:
- .NET Framework 4.7.2 and later
- .NET 8.0 and later
- .NET 9.0 and later
- .NET 10.0 and later
- .NET 11.0 and later

### Backward Compatibility

- **Fully Backward Compatible**: Existing code continues to work without modification
- **Optional Feature**: If `footerText` is `null` or empty, the footer is not shown and the message box behaves exactly as before
- **No Breaking Changes**: All existing `Show` method overloads remain unchanged

### Namespace

```csharp
using Krypton.Toolkit.Suite.Extended.Settings;
```

The `KryptonMessageBoxExtended` class is located in the `Krypton.Toolkit.Suite.Extended.Settings` namespace.

## See Also

- [KryptonMessageBoxExtended API Documentation](../../Source/Krypton%20Toolkit/Krypton.Toolkit.Suite.Extended.Settings/Classes/Other/KryptonMessageBoxExtended.cs)
- [MessageBox Footer Example](../../Source/Krypton%20Toolkit/Examples/MessageBoxFooterExample.cs)
- [Issue #511 - Feature Request](https://github.com/Krypton-Suite/Extended-Toolkit/issues/511)
- [Changelog](Changelog.md)

---

**Last Updated:** January 2026  
**Feature Version:** 1.0  
**Namespace:** `Krypton.Toolkit.Suite.Extended.Settings`

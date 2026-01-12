# KryptonProgressBarExtended

## Table of Contents

1. [Overview](#overview)
2. [Features](#features)
3. [API Reference](#api-reference)
   - [Properties](#properties)
   - [Methods](#methods)
   - [Events](#events)
4. [Three-Color State Feature](#three-color-state-feature)
5. [Usage Examples](#usage-examples)
6. [Best Practices](#best-practices)
7. [Technical Details](#technical-details)

---

## Overview

`KryptonProgressBarExtended` is a specialized Windows Forms progress bar control that extends the standard `ProgressBar` with enhanced visual features and functionality. It displays the progress value as text on a faded background and supports dynamic color changes based on progress thresholds.

### Key Capabilities

- **Text Display**: Automatically displays the current progress value as a percentage
- **Fade Effect**: Configurable white overlay to fade background colors for better text readability
- **Three-Color State**: Dynamic color changes based on progress thresholds (Red/Orange/Green)
- **Customizable Appearance**: Full control over fonts, colors, and visual effects
- **Designer Support**: Full Visual Studio designer integration with expandable properties

### Namespace

```csharp
using Krypton.Toolkit.Suite.Extended.Controls;
```

### Base Class

```csharp
System.Windows.Forms.ProgressBar
```

---

## Features

### 1. **Text Overlay**
The control automatically displays the current progress value as text (e.g., "45%") overlaid on the progress bar. The text is rendered using the control's `Font` and `ForeColor` properties.

### 2. **Fade Effect**
A configurable white overlay brush fades the background colors, improving text readability. The fade intensity can be adjusted from 0 (darkest) to 255 (lightest).

### 3. **Three-Color State System**
When enabled, the progress bar automatically changes color based on the current progress value:
- **Low State** (below threshold): Red (default)
- **Medium State** (between thresholds): Orange (default)
- **High State** (above threshold): Green (default)

### 4. **Customizable Thresholds**
Both low and high thresholds are fully customizable (0-100%), allowing developers to define their own color transition points.

### 5. **Property Grid Integration**
The three-color state properties are organized in an expandable object, making it easy to configure all related settings in the Visual Studio designer.

---

## API Reference

### Properties

#### `Fade` (int)

Gets or sets the opacity of the white overlay brush that fades the background colors.

**Category**: `Appearance`  
**Default Value**: `150`  
**Range**: `0` to `255` (inclusive)

**Remarks**:
- Lower values make the background darker
- Higher values make the background lighter
- Used to improve text readability over the progress bar

**Example**:
```csharp
// Make background darker for better contrast
progressBar.Fade = 100;

// Make background lighter
progressBar.Fade = 200;
```

**Exceptions**:
- `ArgumentOutOfRangeException`: Thrown when value is less than 0 or greater than 255

---

#### `Font` (Font)

Gets or sets the font used to display the progress text.

**Category**: `Appearance`  
**Browsable**: `true`  
**Designer Serialization**: `Hidden`

**Remarks**:
- This is an ambient property (inherits from parent if not set)
- The `Font` class is immutable; assign a new `Font` object to change properties
- To change text color, use the `ForeColor` property

**Example**:
```csharp
// Use a bold, larger font
progressBar.Font = new Font("Arial", 12, FontStyle.Bold);
```

---

#### `ForeColor` (Color)

Gets or sets the color of the progress text.

**Category**: `Appearance`  
**Default Value**: `SystemColors.ControlText`

**Remarks**:
- Controls the color of the percentage text displayed on the progress bar
- Use this property to match text color with your application's theme

**Example**:
```csharp
// Use white text for dark backgrounds
progressBar.ForeColor = Color.White;

// Use black text for light backgrounds
progressBar.ForeColor = Color.Black;
```

---

#### `Text` (string) - Read-Only

Gets the text representation of the current progress value.

**Browsable**: `false`  
**Bindable**: `false`

**Returns**: A string in the format `"{Value}%"` (e.g., "45%")

**Remarks**:
- This property is read-only and automatically generated
- The format uses the current culture for number formatting
- The text is displayed using the `Font` and `ForeColor` properties

**Example**:
```csharp
// Display the current text
string currentText = progressBar.Text; // e.g., "45%"
```

---

#### `ThreeColorState` (ThreeColorStateProperties)

Gets or sets the three-color state properties, including colors, thresholds, and enable/disable flag.

**Category**: `Appearance`  
**Designer Serialization**: `Content`  
**Type**: `ThreeColorStateProperties` (expandable object)

**Remarks**:
- This property is expandable in the property grid
- Contains all three-color state configuration in one object
- Use `ThreeColorState.UseThreeColorState` to enable/disable the feature
- All color and threshold properties are accessible through this object

**Example**:
```csharp
// Enable three-color state
progressBar.ThreeColorState.UseThreeColorState = true;

// Customize colors
progressBar.ThreeColorState.LowColor = Color.Red;
progressBar.ThreeColorState.MediumColor = Color.Yellow;
progressBar.ThreeColorState.HighColor = Color.Green;

// Set thresholds
progressBar.ThreeColorState.LowThreshold = 30;  // 30%
progressBar.ThreeColorState.HighThreshold = 70; // 70%
```

---

### Methods

#### `Dispose(bool disposing)`

Releases the unmanaged resources used by the control and optionally releases managed resources.

**Parameters**:
- `disposing` (bool): `true` to release both managed and unmanaged resources; `false` to release only unmanaged resources

**Remarks**:
- Called automatically by the framework
- Cleans up the fade brush and other resources
- Override in derived classes to dispose additional resources

---

#### `ToString()`

Returns a string representation of the control.

**Returns**: A string containing the control type, minimum, maximum, and current value

**Example Output**:
```
Krypton.Toolkit.Suite.Extended.Controls.KryptonProgressBarExtended, Minimum: 0, Maximum: 100, Value: 45
```

---

### Events

The control inherits all standard `ProgressBar` events. No additional events are defined.

**Inherited Events**:
- `Click`
- `DoubleClick`
- `Paint`
- `Resize`
- And all other standard `Control` events

---

## Three-Color State Feature

### Overview

The three-color state feature allows the progress bar to dynamically change its color based on the current progress value. This is useful for indicating status (e.g., warning, in-progress, success) or drawing attention to specific progress ranges.

### ThreeColorStateProperties Class

All three-color state configuration is managed through the `ThreeColorStateProperties` class, which is exposed as an expandable property in the property grid.

#### Properties

##### `UseThreeColorState` (bool)

Enables or disables the three-color state feature.

**Category**: `Behavior`  
**Default Value**: `false`

**Example**:
```csharp
progressBar.ThreeColorState.UseThreeColorState = true;
```

---

##### `LowColor` (Color)

Gets or sets the color used when progress is below the low threshold.

**Category**: `Appearance`  
**Default Value**: `Color.Red`

**Example**:
```csharp
progressBar.ThreeColorState.LowColor = Color.DarkRed;
```

---

##### `MediumColor` (Color)

Gets or sets the color used when progress is between the low and high thresholds.

**Category**: `Appearance`  
**Default Value**: `Color.Orange`

**Example**:
```csharp
progressBar.ThreeColorState.MediumColor = Color.Yellow;
```

---

##### `HighColor` (Color)

Gets or sets the color used when progress is above the high threshold.

**Category**: `Appearance`  
**Default Value**: `Color.Green`

**Example**:
```csharp
progressBar.ThreeColorState.HighColor = Color.LimeGreen;
```

---

##### `LowThreshold` (int)

Gets or sets the threshold percentage below which the low color is used.

**Category**: `Behavior`  
**Default Value**: `45`  
**Range**: `0` to `100` (must be less than `HighThreshold`)

**Remarks**:
- When progress value is less than this threshold, `LowColor` is used
- Must be less than `HighThreshold`

**Example**:
```csharp
progressBar.ThreeColorState.LowThreshold = 30; // 30%
```

**Exceptions**:
- `ArgumentOutOfRangeException`: Thrown when value is outside 0-100 range or >= `HighThreshold`

---

##### `HighThreshold` (int)

Gets or sets the threshold percentage above which the high color is used.

**Category**: `Behavior`  
**Default Value**: `75`  
**Range**: `0` to `100` (must be greater than `LowThreshold`)

**Remarks**:
- When progress value is >= this threshold, `HighColor` is used
- When progress is between `LowThreshold` and `HighThreshold`, `MediumColor` is used
- Must be greater than `LowThreshold`

**Example**:
```csharp
progressBar.ThreeColorState.HighThreshold = 80; // 80%
```

**Exceptions**:
- `ArgumentOutOfRangeException`: Thrown when value is outside 0-100 range or <= `LowThreshold`

---

### Color Selection Logic

The control uses the following logic to determine which color to use:

1. Calculate percentage: `((Value - Minimum) / (Maximum - Minimum)) * 100`
2. Compare percentage to thresholds:
   - If `percentage < LowThreshold` → Use `LowColor`
   - If `percentage >= HighThreshold` → Use `HighColor`
   - Otherwise → Use `MediumColor`

### Automatic Updates

The progress bar color is automatically updated when:
- The `Value` property changes (during paint cycle)
- The control handle is created
- Any `ThreeColorState` property changes
- The `UseThreeColorState` property is toggled

---

## Usage Examples

### Basic Usage

```csharp
using Krypton.Toolkit.Suite.Extended.Controls;

// Create and configure a basic progress bar
var progressBar = new KryptonProgressBarExtended
{
    Minimum = 0,
    Maximum = 100,
    Value = 0,
    Fade = 150,
    ForeColor = Color.Black
};

// Add to form
this.Controls.Add(progressBar);
progressBar.Location = new Point(10, 10);
progressBar.Size = new Size(300, 30);

// Update progress
progressBar.Value = 50; // Displays "50%"
```

---

### Enabling Three-Color State

```csharp
// Enable three-color state with default settings
progressBar.ThreeColorState.UseThreeColorState = true;

// The progress bar will now change color:
// - Red when value < 45%
// - Orange when value is 45-74%
// - Green when value >= 75%
```

---

### Custom Three-Color Configuration

```csharp
// Configure custom colors and thresholds
progressBar.ThreeColorState.UseThreeColorState = true;
progressBar.ThreeColorState.LowColor = Color.DarkRed;
progressBar.ThreeColorState.MediumColor = Color.Gold;
progressBar.ThreeColorState.HighColor = Color.LimeGreen;
progressBar.ThreeColorState.LowThreshold = 25;  // 25%
progressBar.ThreeColorState.HighThreshold = 75; // 75%

// Now:
// - DarkRed when value < 25%
// - Gold when value is 25-74%
// - LimeGreen when value >= 75%
```

---

### Simulating Progress with Color Changes

```csharp
// Simulate a file download with color-coded progress
private async Task SimulateDownload(KryptonProgressBarExtended progressBar)
{
    progressBar.Minimum = 0;
    progressBar.Maximum = 100;
    progressBar.Value = 0;
    
    // Enable three-color state
    progressBar.ThreeColorState.UseThreeColorState = true;
    
    // Simulate progress
    for (int i = 0; i <= 100; i++)
    {
        progressBar.Value = i;
        await Task.Delay(50); // Simulate download delay
        
        // Color automatically changes:
        // - Red (0-44%): Download starting
        // - Orange (45-74%): Download in progress
        // - Green (75-100%): Download nearly complete
    }
}
```

---

### Designer Configuration

In Visual Studio designer:

1. **Add Control**: Drag `KryptonProgressBarExtended` from toolbox to form
2. **Configure Basic Properties**:
   - Set `Minimum`, `Maximum`, `Value`
   - Adjust `Fade` for text readability
   - Set `ForeColor` for text color
3. **Enable Three-Color State**:
   - Expand `ThreeColorState` property in property grid
   - Set `UseThreeColorState` to `true`
   - Customize `LowColor`, `MediumColor`, `HighColor`
   - Adjust `LowThreshold` and `HighThreshold` as needed

---

### Advanced: Dynamic Threshold Adjustment

```csharp
// Adjust thresholds based on application state
private void UpdateProgressThresholds(KryptonProgressBarExtended progressBar, 
    int criticalThreshold, int warningThreshold)
{
    progressBar.ThreeColorState.LowThreshold = criticalThreshold;
    progressBar.ThreeColorState.HighThreshold = warningThreshold;
    
    // Colors will update automatically
}
```

---

### Integration with BackgroundWorker

```csharp
private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
{
    if (progressBar.InvokeRequired)
    {
        progressBar.Invoke(new Action(() => 
        {
            progressBar.Value = e.ProgressPercentage;
            // Color automatically updates based on percentage
        }));
    }
    else
    {
        progressBar.Value = e.ProgressPercentage;
    }
}
```

---

## Best Practices

### 1. **Fade Value Selection**

Choose fade values based on your background:
- **Dark backgrounds**: Use higher fade values (200-255) for lighter overlay
- **Light backgrounds**: Use lower fade values (100-150) for darker overlay
- **Test readability**: Ensure text is readable with your chosen fade value

```csharp
// Good: Adjust fade for readability
progressBar.Fade = 180; // Good for dark themes
progressBar.ForeColor = Color.White; // White text on dark background
```

---

### 2. **Threshold Configuration**

Set meaningful thresholds based on your use case:
- **File operations**: Low = 25%, High = 75%
- **Data processing**: Low = 30%, High = 70%
- **User feedback**: Low = 40%, High = 80%

```csharp
// Good: Meaningful thresholds
progressBar.ThreeColorState.LowThreshold = 30;  // Warning zone
progressBar.ThreeColorState.HighThreshold = 80; // Success zone
```

---

### 3. **Color Selection**

Choose colors that:
- Provide clear visual distinction
- Match your application's theme
- Are accessible (consider colorblind users)

```csharp
// Good: High contrast colors
progressBar.ThreeColorState.LowColor = Color.FromArgb(220, 53, 69);   // Red
progressBar.ThreeColorState.MediumColor = Color.FromArgb(255, 193, 7); // Amber
progressBar.ThreeColorState.HighColor = Color.FromArgb(40, 167, 69);  // Green
```

---

### 4. **Performance Considerations**

- The color update happens during the paint cycle, so it's efficient
- Avoid changing `ThreeColorState` properties in tight loops
- Use `Invalidate()` sparingly; the control handles updates automatically

```csharp
// Good: Set properties once, let control handle updates
progressBar.ThreeColorState.UseThreeColorState = true;
progressBar.ThreeColorState.LowThreshold = 45;
progressBar.ThreeColorState.HighThreshold = 75;
// No need to call Invalidate() - it's automatic
```

---

### 5. **Thread Safety**

Always use `Invoke` when updating from background threads:

```csharp
// Good: Thread-safe update
if (progressBar.InvokeRequired)
{
    progressBar.Invoke(new Action(() => 
    {
        progressBar.Value = newValue;
    }));
}
else
{
    progressBar.Value = newValue;
}
```

---

### 6. **Error Handling**

Handle threshold validation errors:

```csharp
try
{
    progressBar.ThreeColorState.LowThreshold = 50;
    progressBar.ThreeColorState.HighThreshold = 40; // Will throw exception
}
catch (ArgumentOutOfRangeException ex)
{
    // Handle invalid threshold configuration
    MessageBox.Show($"Invalid threshold: {ex.Message}");
}
```

---

## Technical Details

### Implementation Details

#### Color Change Mechanism

The control uses Windows API `PBM_SETBARCOLOR` message to change the progress bar color:

```csharp
// Convert Color to COLORREF (0x00BBGGRR format)
int colorRef = colorToUse.B | (colorToUse.G << 8) | (colorToUse.R << 16);

// Send message to change color
UnsafeNativeMethods.SendMessage(Handle, NativeMethods.PBM_SETBARCOLOR, 
    IntPtr.Zero, new IntPtr(colorRef));
```

#### Paint Cycle

The control overrides the paint cycle to:
1. Update progress bar color (if three-color state enabled)
2. Apply fade overlay
3. Draw progress text

The color update happens in `PaintPrivate()`, ensuring it's synchronized with the paint cycle.

#### Property Change Notification

The `ThreeColorStateProperties` class implements a `PropertyChanged` event that the control subscribes to. When any property changes, the control automatically:
- Updates the progress bar color
- Invalidates the control for repaint

### Dependencies

- **Base Control**: `System.Windows.Forms.ProgressBar`
- **Native Methods**: Uses P/Invoke for color changes
- **ThreeColorStateProperties**: Custom class for three-color state configuration

### Limitations

1. **Visual Styles**: The color change may not work with all Windows visual styles
2. **Handle Requirement**: Color changes require the control handle to be created
3. **Obsolete Warning**: The control is marked as obsolete in favor of native `KryptonProgressBar`

### Known Issues

None currently documented.

---

## Related Classes

### `ThreeColorStateProperties`

A helper class that encapsulates all three-color state configuration. This class:
- Uses `ExpandableObjectConverter` for property grid integration
- Provides validation for threshold values
- Implements `PropertyChanged` notification

**Location**: `Krypton.Toolkit.Suite.Extended.Controls.ThreeColorStateProperties`

---

## Migration Notes

### From Standard ProgressBar

If migrating from `System.Windows.Forms.ProgressBar`:

1. **Replace Control**: Change `ProgressBar` to `KryptonProgressBarExtended`
2. **Add Namespace**: `using Krypton.Toolkit.Suite.Extended.Controls;`
3. **Configure Fade**: Set `Fade` property for text readability
4. **Optional**: Enable three-color state if needed

### To Native KryptonProgressBar

The control is marked as obsolete. Consider migrating to the native `KryptonProgressBar` when available, which may provide similar or enhanced functionality.

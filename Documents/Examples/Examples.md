<!-- Start Document Outline -->

* [Extended Toolkit Examples](#extended-toolkit-examples)
	* [DataGridView](#datagridview)
	* [Krypton Form FadeController](#krypton-form-fadecontroller)
	* [Circular Progress Bar](#circular-progress-bar)
	* [Command Links](#command-links)
	* [Extended Krypton Messagebox](#extended-krypton-messagebox)
	* [Krypton Colour Mixer](#krypton-colour-mixer)
	* [Krypton Colour Wheel](#krypton-colour-wheel)
	* [Krypton Knob Control](#krypton-knob-control)
	* [Krypton Palette Colour Shader](#krypton-palette-colour-shader)
	* [Krypton Property Grid](#krypton-property-grid)
	* [Krypton Scrollbars](#krypton-scrollbars)
	* [Krypton Theme Selector](#krypton-theme-selector)
	* [Krypton Toast Notification](#krypton-toast-notification)
		* [Version 1](#version-1)
	* [Krypton Toggle Switch](#krypton-toggle-switch)
	* [TreeGridView](#treegridview)
	* [Krypton View Bar](#krypton-view-bar)

<!-- End Document Outline -->
# Extended Toolkit Examples
<!-- Following Are the new docs -->


## `DataGridView`
[An Extension to the standard Krypton DataGridView with new Columns and Master-Detail](https://github.com/Krypton-Suite/Extended-Toolkit/tree/version-next/Source/Krypton%20Toolkit/Main/Krypton.Toolkit.Suite.Extended.DataGridView)


## Krypton Form `FadeController`
[Allows child controls to be faded in etc.](https://github.com/Krypton-Suite/Extended-Toolkit/tree/version-next/Source/Krypton%20Toolkit/Shared/Krypton.Toolkit.Suite.Extended.Effects)

## Circular Progress Bar
![](https://github.com/Krypton-Suite/Extended-Toolkit/blob/master/Assets/Examples/CircularProgressBar.png)

## Command Links

![](https://github.com/Krypton-Suite/Extended-Toolkit/blob/master/Assets/Examples/CommandLinks.png)


## Extended Krypton Messagebox

![](https://github.com/Krypton-Suite/Extended-Toolkit/blob/master/Assets/Examples/ExtendedKryptonMessageBox1.png)

![](https://github.com/Krypton-Suite/Extended-Toolkit/blob/master/Assets/Examples/ExtendedKryptonMessageBox2.png)

### Expandable Footer Feature

The `KryptonMessageBoxExtended` now supports an **expandable footer** feature, similar to Windows TaskDialog. This allows displaying additional information (error details, stack traces, help text) in a collapsible footer area.

**Key Features:**
- Collapsible footer with "Show details" / "Hide details" toggle
- Multiple content types: Text (default), CheckBox, or RichTextBox
- Configurable RichTextBox height for formatted content
- Configurable initial state (expanded or collapsed)
- Automatic form sizing
- Works with all message box features (icons, buttons, timeout, etc.)

**Example Usage:**

```csharp
using Krypton.Toolkit.Suite.Extended.Messagebox;

// Text footer (default)
KryptonMessageBoxExtended.Show(
    this,
    "An error occurred while processing your request.",
    "Error",
    ExtendedMessageBoxButtons.OK,
    ExtendedKryptonMessageBoxIcon.Error,
    footerText: "Stack Trace:\n   at Examples.MyClass.ProcessData()\n   ...",
    footerExpanded: false  // Footer starts collapsed
);

// CheckBox footer
KryptonMessageBoxExtended.Show(
    this,
    "Do you want to save your changes?",
    "Save Changes?",
    ExtendedMessageBoxButtons.YesNo,
    ExtendedKryptonMessageBoxIcon.Question,
    footerText: "Remember my choice",
    footerContentType: ExtendedKryptonMessageBoxFooterContentType.CheckBox
);

// RichTextBox footer with custom height
KryptonMessageBoxExtended.Show(
    this,
    "An error occurred.",
    "Error",
    ExtendedMessageBoxButtons.OK,
    ExtendedKryptonMessageBoxIcon.Error,
    footerText: "Detailed error information...",
    footerContentType: ExtendedKryptonMessageBoxFooterContentType.RichTextBox,
    footerRichTextBoxHeight: 150
);
```

**Comprehensive Documentation:**
- [KryptonMessageBoxExtended Footer Documentation](../Help/ExtendedKryptonMessageBox-Footer.md)
- [MessageBox Footer Example Source Code](https://github.com/Krypton-Suite/Extended-Toolkit/tree/version-next/Source/Krypton%20Toolkit/Examples/MessageBoxFooterExample.cs)

## Krypton Colour Mixer

![](https://github.com/Krypton-Suite/Extended-Toolkit/blob/master/Assets/Examples/KryptonColourMixer.png)

## Krypton Colour Wheel

![](https://github.com/Krypton-Suite/Extended-Toolkit/blob/master/Assets/Examples/KryptonColourWheel.png)

## Krypton Knob Control

![](https://github.com/Krypton-Suite/Extended-Toolkit/blob/master/Assets/Examples/KryptonKnobControl.png)

## Krypton Palette Colour Shader

![](https://github.com/Krypton-Suite/Extended-Toolkit/blob/master/Assets/Examples/KryptonPaletteColourShader.png)

## Krypton Property Grid

![](https://github.com/Krypton-Suite/Extended-Toolkit/blob/master/Assets/Examples/KryptonPropertyGrid.png)

## Krypton Scrollbars

![](https://github.com/Krypton-Suite/Extended-Toolkit/blob/master/Assets/Examples/KryptonScrollBars.png)

## Krypton Theme Selector

![](https://github.com/Krypton-Suite/Extended-Toolkit/blob/master/Assets/Examples/KryptonThemeSelector.png)

## Krypton Toast Notification

### Version 1

![](https://github.com/Krypton-Suite/Extended-Toolkit/blob/master/Assets/Examples/KryptonToastNotificationV1.png)

## Krypton Toggle Switch

![](https://github.com/Krypton-Suite/Extended-Toolkit/blob/master/Assets/Examples/KryptonToggleSwitch.png)

## `TreeGridView`
[A Tree and List View combined into a GridView](https://github.com/Krypton-Suite/Extended-Toolkit/tree/version-next/Source/Krypton%20Toolkit/Main/Krypton.Toolkit.Suite.Extended.TreeGridView)

## Krypton View Bar

![](https://github.com/Krypton-Suite/Extended-Toolkit/blob/master/Assets/Examples/KryptonViewBar.png)

## `VirtualTreeColumnView`
[A Tree and List View combined into a GridView](https://github.com/Krypton-Suite/Extended-Toolkit/tree/version-next/Source/Krypton%20Toolkit/Main/Krypton.Toolkit.Suite.Extended.VirtualTreeColumnView)


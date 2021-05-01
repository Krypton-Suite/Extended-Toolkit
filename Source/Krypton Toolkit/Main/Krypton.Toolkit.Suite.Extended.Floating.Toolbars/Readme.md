<!-- Start Document Outline -->

* [Floating Toolbars](#FloatingToolbars)
	* [Things of note in the picture](#things-of-note-in-the-picture)
	* [Usage](#usage)
* [ToDo](#todo)

<!-- End Document Outline -->

# `FloatingToolbars`
![](FloatableToolStrips.gif)

## Things of note in the picture
- Un-dock or re-dock a menu or a tool strip from a window
- Controlled via a `MenuStripPanelExtened` or a `ToolStripPanelExtened` control

## Usage
- Drag and drop a `MenuStripPanelExtened` or a `ToolStripPanelExtened` control on a `KryptonForm`
- Drag and drop a `FloatableMenuStrip` onto a `MenuStripPanelExtened`, or a `FloatableToolStrip` onto a `ToolStripPanelExtened` control
- Use the grip to 'tear' off the control
- Double click the control window to re-dock to the main window

# ToDo
- Rename both the `MenuStripPanelExtened` and the `ToolStripPanelExtened` controls to something more appropriate
- Fix the `FloatableToolStrip` re-docking mechanism 
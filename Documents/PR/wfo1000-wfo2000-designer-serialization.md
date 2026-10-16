# Designer serialization warnings

## Summary

Extended controls now tell the Windows Forms designer which public properties to save. Appearance and behavior settings continue to be written into designer code. Runtime-only values, and tool-strip passthroughs that duplicate a hosted control, are no longer serialized.

## Related issues

None.

## Type of change

Bug fix.

## Changes

- WFO1000: public control and component properties set `DesignerSerializationVisibility` to `Visible`, `Content`, or `Hidden`.
- Runtime state (timers, streams, synchronization objects, assemblies, drive lists, timestamps, secured text, dialog results, and owner back-references) is `Hidden`.
- Tool strip hosts that already serialize the inner control as `Content` mark the matching passthrough properties `Hidden`.
- WFO2000: blur kernels, SRGS null/void/garbage rule refs, and Ultimate package catalogs keep a single cached instance. Designer verbs on `NaviBarDesigner` are cached. Properties that must return a fresh snapshot or an editable copy (animation paths, colour palettes, ScottPlot prototypes, mirrored axis ranges, recognition alternates, and default zoom levels) keep that behavior and suppress WFO2000 at the declaration.

## Affected packages & target frameworks

BottomSheet, Circular ProgressBar, Common, Controls, Core, Data Visualisation, Dialogs, Drawing Utilities, File Copier, Forms, IO, Memory Box, Messagebox, Navi Suite, Notifications, Settings, Specialised Dialogs, Tool Strip Items, Ultimate, Ultimate Lite, Utilities, and Wizard. All target frameworks inherited from `ActiveExtendedToolkitTFMs`.

## Validation

- TestForm demo: not required; no new interactive surface.
- Manual steps: drop an affected control on a form and confirm appearance properties still round-trip through the designer. Runtime-only properties should not appear in `InitializeComponent`.
- Build command used: `dotnet build` of the affected projects, `net11.0-windows`, Debug.
- Unit tests (if any): none for these modules.

## Screenshots / GIFs

None. No visual change.

## Changelog

* Resolved WinForms designer serialization warnings on Extended controls.
	- Appearance and behavior properties now state explicitly that the designer should save them
	- Runtime-only values (timers, streams, synchronization objects, drive lists, and live animation snapshots) are left out of designer code
	- Tool strip items that already save their hosted control no longer save those same values a second time

## Breaking changes & migration

Designer files that previously assigned runtime-only properties will keep compiling. The next save from the designer omits those assignments. Tool strip passthrough assignments already in `InitializeComponent` still run; new saves persist the hosted control instead.

## Developer documentation

None. No new public surface.

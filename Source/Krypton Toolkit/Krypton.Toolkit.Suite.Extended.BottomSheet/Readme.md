# Krypton Bottom Sheet

Material-inspired bottom sheets for WinForms using the Krypton Toolkit.

## Features

- Service-style API via `KryptonBottomSheetManager`
- Modal and non-modal display modes
- Non-blocking `OpenAsync` with `Task` completion on dismiss
- Typed and untyped content data contracts
- Configurable backdrop scrims (`Dim`, `EnhancedDim`, `SoftGradient`, `Blur`)
- Slide animations with easing, separate open/close durations, and backdrop fade
- Drag handle with distance and velocity dismiss
- Optional snap heights in pixels or viewport percentages
- Auto-height and fixed-height modes
- Focus trap, focus restore, and selector-based autofocus
- Owner disable/enable during modal sheets
- Conflict handling: throw, animated replace, or queue
- Chrome controls: `KryptonBottomSheetHeader`, `KryptonBottomSheetList`
- DPI-aware metrics and wide-screen max width centering
- Owner tracking for move/resize
- Global defaults via `KryptonBottomSheetDefaultOptions`
- Designer support with toolbox bitmap and smart tags

## Quick start

```csharp
KryptonBottomSheetManager.Open<FileBottomSheetContent>(
    owner: this,
    config: new KryptonBottomSheetConfig
    {
        AccessibleName = "File actions",
        Data = new FileSheetData("cat-picture.jpeg"),
        HeightMode = BottomSheetHeightMode.Auto,
    },
    configure: sheetRef =>
    {
        sheetRef.AfterDismissed += (_, args) =>
        {
            if (args.Result is string action)
            {
                // handle action
            }
        };
    });
```

Use the `configure` callback for modal sheets so `AfterDismissed` is wired before the modal loop begins.

## Header and list chrome

```csharp
var header = new KryptonBottomSheetHeader { Title = "Share" };
var list = new KryptonBottomSheetList();
list.SetItems(new[]
{
    new BottomSheetListItem { Text = "Copy link", Result = "copy" },
    new BottomSheetListItem { Text = "Email", Result = "email" },
});

var content = new UserControl();
content.Controls.Add(list);
content.Controls.Add(header);

KryptonBottomSheetManager.Open(this, content, configure: sheetRef =>
{
    header.BindDismiss(sheetRef);
    list.BindDismiss(sheetRef);
});
```

## Typed data

```csharp
public sealed class FileSheetContent : UserControl, IKryptonBottomSheetContent<FileSheetData>
{
    public void OnBottomSheetOpened(KryptonBottomSheetRef sheetRef, FileSheetData data)
    {
        // use typed data
    }
}

KryptonBottomSheetManager.Open<FileSheetContent, FileSheetData>(
    this,
    new FileSheetData("cat-picture.jpeg"));
```

## Global defaults

```csharp
KryptonBottomSheetDefaultOptions.Default = new KryptonBottomSheetConfig
{
    BackdropStyle = BottomSheetBackdropStyle.SoftGradient,
    TrapFocus = true,
    MaxSheetWidth = 640,
    ConflictMode = BottomSheetConflictMode.Replace,
};
```

## Conflict modes

```csharp
// Replace the open sheet with an animated close
config.ConflictMode = BottomSheetConflictMode.Replace;

// Queue and open after the current sheet dismisses
config.ConflictMode = BottomSheetConflictMode.Queue;
```

## Non-modal

```csharp
KryptonBottomSheetManager.OpenNonModal(this, content, config, sheetRef =>
{
    sheetRef.AfterDismissed += (_, _) => { };
});
```

## Async

```csharp
object? result = await KryptonBottomSheetManager.OpenAsync(this, content);
```

`OpenAsync` shows the sheet without blocking the caller and disables the owner until dismiss.

## See also

- [Angular Material bottom sheet](https://material.angular.dev/components/bottom-sheet/overview)
- `KryptonCard` for related Material-inspired surface styling

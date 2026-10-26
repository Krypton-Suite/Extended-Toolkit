#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace TestForm;

public partial class BottomSheetExample : KryptonForm
{
    public BottomSheetExample()
    {
        InitializeComponent();
    }

    private void kbtnOpenBottomSheet_Click(object sender, EventArgs e)
    {
        KryptonBottomSheetManager.Open<FileBottomSheetContent, FileSheetData>(
            owner: this,
            data: new FileSheetData("cat-picture.jpeg"),
            config: new KryptonBottomSheetConfig
            {
                AccessibleName = "File actions",
                AccessibleDescription = "Choose an action for the received file.",
                HeightMode = BottomSheetHeightMode.Auto,
                BackdropStyle = BottomSheetBackdropStyle.SoftGradient,
                MaxSheetWidth = 560,
                ShowHandle = true,
                EnableDragToDismiss = true,
                SnapHeights = new[] { 180, 260 },
                TrapFocus = true,
            },
            configure: sheetRef =>
            {
                sheetRef.AfterOpened += (_, _) => kbtnOpenBottomSheet.Enabled = false;
                sheetRef.AfterDismissed += (_, args) =>
                {
                    kbtnOpenBottomSheet.Enabled = true;

                    if (args.Result is string action)
                    {
                        KryptonMessageBox.Show($"Action selected: {action}", "Bottom Sheet");
                    }
                };
            });
    }

    private void kbtnOpenNonModal_Click(object sender, EventArgs e)
    {
        KryptonBottomSheetManager.OpenNonModal(
            this,
            new FileBottomSheetContent(),
            new KryptonBottomSheetConfig
            {
                AccessibleName = "Non-modal sheet",
                Data = new FileSheetData("preview.txt"),
                DisplayMode = BottomSheetDisplayMode.NonModal,
                SheetHeight = 200,
            },
            sheetRef => sheetRef.AfterDismissed += (_, _) => { });
    }

    private void kbtnOpenActionList_Click(object sender, EventArgs e)
    {
        var header = new KryptonBottomSheetHeader { Title = "Share file" };
        var list = new KryptonBottomSheetList();
        list.SetItems(new[]
        {
            new BottomSheetListItem { Text = "Copy link", Result = "copy" },
            new BottomSheetListItem { Text = "Send email", Subtitle = "Opens your mail client", Result = "email" },
            new BottomSheetListItem { Text = "Delete", Result = "delete", Enabled = false },
        });

        var content = new UserControl { Dock = DockStyle.Fill };
        content.Controls.Add(list);
        content.Controls.Add(header);

        KryptonBottomSheetManager.Open(
            this,
            content,
            new KryptonBottomSheetConfig
            {
                AccessibleName = "Share actions",
                HeightMode = BottomSheetHeightMode.Auto,
                BackdropStyle = BottomSheetBackdropStyle.Blur,
                SnapHeightPercentages = new[] { 0.35d, 0.5d },
                ConflictMode = BottomSheetConflictMode.Replace,
            },
            sheetRef =>
            {
                header.BindDismiss(sheetRef);
                list.BindDismiss(sheetRef);
                sheetRef.AfterDismissed += (_, args) =>
                {
                    if (args.Result is string action)
                    {
                        KryptonMessageBox.Show($"Action selected: {action}", "Bottom Sheet");
                    }
                };
            });
    }
}

internal sealed class FileSheetData
{
    public FileSheetData(string fileName) => FileName = fileName;

    public string FileName { get; }
}

internal sealed class FileBottomSheetContent : UserControl, IKryptonBottomSheetContent<FileSheetData>
{
    private readonly KryptonWrapLabel _messageLabel = new();
    private readonly KryptonButton _openButton = new();
    private KryptonBottomSheetRef? _sheetRef;

    public FileBottomSheetContent()
    {
        Dock = DockStyle.Fill;
        Padding = new Padding(0, 4, 0, 0);

        _messageLabel.Dock = DockStyle.Top;
        _messageLabel.AutoSize = false;
        _messageLabel.Size = new Size(300, 48);
        _messageLabel.Text = "You have received a file.";

        _openButton.Text = "Open file";
        _openButton.AutoSize = true;
        _openButton.Margin = new Padding(0, 12, 0, 0);
        _openButton.Click += (_, _) => _sheetRef?.Dismiss("open");

        Controls.Add(_openButton);
        Controls.Add(_messageLabel);
    }

    public void OnBottomSheetOpened(KryptonBottomSheetRef sheetRef, FileSheetData data)
    {
        _sheetRef = sheetRef;
        _messageLabel.Text = $"You have received a file called \"{data.FileName}\".";
    }
}

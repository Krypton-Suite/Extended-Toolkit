#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Examples;

partial class BottomSheetExample
{
    private System.ComponentModel.IContainer components = null!;
    private KryptonPanel _panel = null!;
    private KryptonWrapLabel _descriptionLabel = null!;
    private KryptonButton kbtnOpenBottomSheet = null!;
    private KryptonButton kbtnOpenNonModal = null!;
    private KryptonButton kbtnOpenActionList = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            components?.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        _panel = new KryptonPanel();
        _descriptionLabel = new KryptonWrapLabel();
        kbtnOpenBottomSheet = new KryptonButton();
        kbtnOpenNonModal = new KryptonButton();
        kbtnOpenActionList = new KryptonButton();
        ((System.ComponentModel.ISupportInitialize)_panel).BeginInit();
        _panel.SuspendLayout();
        SuspendLayout();
        //
        // _descriptionLabel
        //
        _descriptionLabel.Dock = DockStyle.Top;
        _descriptionLabel.AutoSize = false;
        _descriptionLabel.Size = new Size(520, 72);
        _descriptionLabel.Text = "Demonstrates modal and non-modal Material-inspired bottom sheets with backdrop fade, snap heights, auto height, typed data, and configure callbacks.";
        //
        // kbtnOpenBottomSheet
        //
        kbtnOpenBottomSheet.AutoSize = true;
        kbtnOpenBottomSheet.Location = new Point(16, 96);
        kbtnOpenBottomSheet.Name = "kbtnOpenBottomSheet";
        kbtnOpenBottomSheet.Size = new Size(120, 25);
        kbtnOpenBottomSheet.TabIndex = 0;
        kbtnOpenBottomSheet.Values.Text = "Open bottom sheet";
        kbtnOpenBottomSheet.Click += kbtnOpenBottomSheet_Click;
        //
        // kbtnOpenNonModal
        //
        kbtnOpenNonModal.AutoSize = true;
        kbtnOpenNonModal.Location = new Point(152, 96);
        kbtnOpenNonModal.Name = "kbtnOpenNonModal";
        kbtnOpenNonModal.Size = new Size(130, 25);
        kbtnOpenNonModal.TabIndex = 1;
        kbtnOpenNonModal.Values.Text = "Open non-modal";
        kbtnOpenNonModal.Click += kbtnOpenNonModal_Click;
        //
        // kbtnOpenActionList
        //
        kbtnOpenActionList.AutoSize = true;
        kbtnOpenActionList.Location = new Point(300, 96);
        kbtnOpenActionList.Name = "kbtnOpenActionList";
        kbtnOpenActionList.Size = new Size(130, 25);
        kbtnOpenActionList.TabIndex = 2;
        kbtnOpenActionList.Values.Text = "Open action list";
        kbtnOpenActionList.Click += kbtnOpenActionList_Click;
        //
        // _panel
        //
        _panel.Controls.Add(kbtnOpenActionList);
        _panel.Controls.Add(kbtnOpenNonModal);
        _panel.Controls.Add(kbtnOpenBottomSheet);
        _panel.Controls.Add(_descriptionLabel);
        _panel.Dock = DockStyle.Fill;
        _panel.Location = new Point(0, 0);
        _panel.Name = "_panel";
        _panel.Padding = new Padding(16);
        _panel.Size = new Size(584, 361);
        _panel.TabIndex = 0;
        //
        // BottomSheetExample
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(584, 361);
        Controls.Add(_panel);
        Name = "BottomSheetExample";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Bottom Sheet Example";
        ((System.ComponentModel.ISupportInitialize)_panel).EndInit();
        _panel.ResumeLayout(false);
        _panel.PerformLayout();
        ResumeLayout(false);
    }
}

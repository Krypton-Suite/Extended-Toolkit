#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2026 - 2026 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

/// <summary>
/// Resolves focus targets and tab order inside bottom sheet content.
/// </summary>
internal static class BottomSheetFocusResolver
{
    public static Control? ResolveInitialFocus(Control root, KryptonBottomSheetConfig config, KryptonBottomSheet sheet)
    {
        if (!string.IsNullOrWhiteSpace(config.AutoFocusSelector))
        {
            Control? selected = FindBySelector(root, config.AutoFocusSelector!);
            if (selected != null)
            {
                return selected;
            }
        }

        switch (config.AutoFocus)
        {
            case BottomSheetAutoFocusMode.FirstHeader:
                return FindFirstHeader(root) ?? FindFirstTabbable(root);
            case BottomSheetAutoFocusMode.Sheet:
                return sheet;
            case BottomSheetAutoFocusMode.FirstTabbable:
                return FindFirstTabbable(root);
            case BottomSheetAutoFocusMode.None:
            default:
                return null;
        }
    }

    public static Control? FindFirstTabbable(Control root)
    {
        Control? current = null;
        while (true)
        {
            current = root.GetNextControl(current, forward: true);
            if (current == null)
            {
                return null;
            }

            if (current.CanSelect && current.TabStop && current.Enabled && current.Visible)
            {
                return current;
            }
        }
    }

    private static Control? FindFirstHeader(Control root)
    {
        if (IsHeaderControl(root))
        {
            return root;
        }

        foreach (Control child in root.Controls)
        {
            Control? match = FindFirstHeader(child);
            if (match != null)
            {
                return match;
            }
        }

        return null;
    }

    private static bool IsHeaderControl(Control control) =>
        control is KryptonHeaderGroup
        || control is KryptonGroupBox
        || control is KryptonLabel label && (label.LabelStyle == LabelStyle.TitlePanel || label.LabelStyle == LabelStyle.TitleControl)
        || control.AccessibleRole == AccessibleRole.StaticText && control.Text.Contains(' ');

    private static Control? FindBySelector(Control root, string selector)
    {
        selector = selector.Trim();
        if (selector.StartsWith("#", StringComparison.Ordinal) && root.Name == selector.Substring(1))
        {
            return root;
        }

        if (selector.StartsWith(".", StringComparison.Ordinal))
        {
            string className = selector.Substring(1);
            if (string.Equals(root.GetType().Name, className, StringComparison.OrdinalIgnoreCase)
                || string.Equals(root.Name, className, StringComparison.OrdinalIgnoreCase))
            {
                return root;
            }
        }
        else if (string.Equals(root.Name, selector, StringComparison.OrdinalIgnoreCase))
        {
            return root;
        }

        foreach (Control child in root.Controls)
        {
            Control? match = FindBySelector(child, selector);
            if (match != null)
            {
                return match;
            }
        }

        return null;
    }
}

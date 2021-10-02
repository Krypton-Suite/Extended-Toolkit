/// <summary>
/// Public class for the underlying editing control
/// </summary>
[ToolboxItem(false)]
public class PercentageEditingControl : DataGridViewTextBoxEditingControl
{
    /// <summary>
    /// Constructor
    /// </summary>
    public PercentageEditingControl()
        : base()
    {
    }

    /// <summary>
    /// Returns if the character is a valid digit
    /// </summary>
    /// <param name="c">The character.</param>
    /// <returns>True if valid digit, false otherwise.</returns>
    private bool IsValidForNumberInput(char c)
    {
        return Char.IsDigit(c);
        // OrElse c = Chr(8) OrElse c = "."c OrElse c = "-"c OrElse c = "("c OrElse c = ")"c
    }

    /// <summary>
    /// Overrides onKeypPress
    /// </summary>
    /// <param name="e"></param>
    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        if (!IsValidForNumberInput(e.KeyChar))
        {
            e.Handled = true;
        }
    }
}
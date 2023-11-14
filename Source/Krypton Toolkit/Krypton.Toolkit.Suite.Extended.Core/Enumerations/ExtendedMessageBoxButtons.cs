namespace Krypton.Toolkit.Suite.Extended.Core;

/// <summary>Specifies the button layout in the <see cref="KryptonMessageBoxExtended"/>.</summary>
public enum ExtendedMessageBoxButtons
{
    /// <summary>Defines a custom button layout. Linked to <see cref="ExtendedMessageBoxCustomButtonOptions"/> values.</summary>
    Custom = 0,
    /// <summary>Defines a 'OK' button only.</summary>
    OK = 5,
    /// <summary>Defines both 'OK' and 'Cancel' buttons.</summary>
    OkCancel = 6,
    /// <summary>Defines 'Abort', 'Retry' and 'Ignore' buttons.</summary>
    AbortRetryIgnore = 7,
    /// <summary>Defines 'Yes', 'No' and 'Cancel' buttons.</summary>
    YesNoCancel = 8,
    /// <summary>Defines both 'Yes' and 'No' buttons.</summary>
    YesNo = 9,
    /// <summary>Defines both 'Retry' and 'Cancel' buttons.</summary>
    RetryCancel = 10,
    /// <summary>Defines 'Cancel', 'Try Again' and 'Continue' buttons.</summary>
    CancelTryContinue = 11
}
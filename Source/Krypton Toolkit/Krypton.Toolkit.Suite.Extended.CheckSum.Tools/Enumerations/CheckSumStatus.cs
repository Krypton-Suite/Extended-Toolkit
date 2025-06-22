namespace Krypton.Toolkit.Suite.Extended.CheckSum.Tools;

public enum CheckSumStatus
{
    Cancelling = 0,
    Canceled = 1,
    Computing = 2,
    Ready = 3,
    Saving = 4,
    Opening = 5,
    Verifying = 6,
    Invalid = 7,
    Valid = 8,
    Waiting = 9,
}
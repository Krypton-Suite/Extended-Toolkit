namespace Krypton.Toolkit.Suite.Extended.Specialised.Dialogs;

public interface IAboutDialogInformation
{
    Bitmap ApplicationImage { get; set; }

    string ApplicationName { get; set; }

    string ApplicationCopyright { get; set; }

    string ApplicationCompanyName { get; set; }

    string ApplicationDescription { get; set; }

    Version ApplicationVersion { get; set; }
}
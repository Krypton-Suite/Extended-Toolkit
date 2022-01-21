public class TypeConverter
{
    public static string ProcessType(string FullQualifiedName)
    {
        //Translate types here to accomodate code changes, namespaces and version
        //Select Case FullQualifiedName
        //    Case "JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.OutlookGridAlphabeticGroup, JDHSoftware.Krypton.Toolkit, Version=1.2.0.0, Culture=neutral, PublicKeyToken=e12f297423986ef5",
        //        "JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.OutlookGridAlphabeticGroup, JDHSoftware.Krypton.Toolkit, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null"
        //        'Change with new version or namespace or both !
        //        FullQualifiedName = "TestMe, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null"
        //        Exit Select
        //End Select
        return FullQualifiedName;
    }
}
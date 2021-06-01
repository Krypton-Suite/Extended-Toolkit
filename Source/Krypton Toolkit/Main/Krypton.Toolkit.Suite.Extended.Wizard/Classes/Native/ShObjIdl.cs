#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    /// <summary>
    /// A representation of a shell item property key.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct ShellItemPropertyKey : IComparable<ShellItemPropertyKey>
    {
        private readonly Guid fmtid;
        private readonly int pid;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShellItemPropertyKey"/> struct.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="id">The identifier.</param>
        public ShellItemPropertyKey(Guid key, int id = 2)
        {
            fmtid = key;
            pid = id;
        }

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public Guid Key => fmtid;

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id => pid;

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => KnownShellItemPropertyKeys.ReverseLookup(this) ?? $"{fmtid:B} {pid}";

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is ShellItemPropertyKey)
                return Guid.Equals(fmtid, ((ShellItemPropertyKey)obj).fmtid) && pid == ((ShellItemPropertyKey)obj).pid;
            return false;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => new { fmtid, pid }.GetHashCode();

        int IComparable<ShellItemPropertyKey>.CompareTo(ShellItemPropertyKey other)
        {
            int ret = fmtid.GetHashCode() - other.fmtid.GetHashCode();
            if (ret == 0)
                ret = pid - other.pid;
            return ret;
        }
    }

    /// <summary>
    /// Listing of known shell item property keys.
    /// </summary>
    public static class KnownShellItemPropertyKeys
    {
        private static Dictionary<ShellItemPropertyKey, string> revIndex = null;

        /// <summary>
        /// <para>Name:     System.AcquisitionID -- PKEY_AcquisitionID</para>
        /// <para>Description: Hash to determine acquisition session.
        ///</para>
        /// <para>Type:     Int32 -- VT_I4</para>
        /// <para>FormatID: {65A98875-3C80-40AB-ABBC-EFDAF77DBEE2}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey AcquisitionID => new ShellItemPropertyKey(new Guid("{65A98875-3C80-40AB-ABBC-EFDAF77DBEE2}"), 100);

        /// <summary>
        /// <para>Name:     System.ApplicationName -- PKEY_ApplicationName</para>
        /// <para>Description:
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)  Legacy code may treat this as VT_LPSTR.</para>
        /// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 18 (PIDSI_APPNAME)</para>
        /// </summary>
        public static ShellItemPropertyKey ApplicationName => new ShellItemPropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 18);

        /// <summary>
        /// <para>Name:     System.Author -- PKEY_Author</para>
        /// <para>Description:
        ///</para>
        /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)  Legacy code may treat this as VT_LPSTR.</para>
        /// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 4 (PIDSI_AUTHOR)</para>
        /// </summary>
        public static ShellItemPropertyKey Author => new ShellItemPropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 4);

        /// <summary>
        /// <para>Name:     System.Capacity -- PKEY_Capacity</para>
        /// <para>Description: The amount of total space in bytes.
        ///</para>
        /// <para>Type:     UInt64 -- VT_UI8</para>
        /// <para>FormatID: (FMTID_Volume) {9B174B35-40FF-11D2-A27E-00C04FC30871}, 3 (PID_VOLUME_CAPACITY)  (Filesystem Volume Properties)</para>
        /// </summary>
        public static ShellItemPropertyKey Capacity => new ShellItemPropertyKey(new Guid("{9B174B35-40FF-11D2-A27E-00C04FC30871}"), 3);

        /// <summary>
        /// <para>Name:     System.Category -- PKEY_Category</para>
        /// <para>Description: Legacy code treats this as VT_LPSTR.
        ///</para>
        /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
        /// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 2 (PIDDSI_CATEGORY)</para>
        /// </summary>
        public static ShellItemPropertyKey Category => new ShellItemPropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 2);

        /// <summary>
        /// <para>Name:     System.Comment -- PKEY_Comment</para>
        /// <para>Description: Comments.
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)  Legacy code may treat this as VT_LPSTR.</para>
        /// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 6 (PIDSI_COMMENTS)</para>
        /// </summary>
        public static ShellItemPropertyKey Comment => new ShellItemPropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 6);

        /// <summary>
        /// <para>Name:     System.Company -- PKEY_Company</para>
        /// <para>Description: The company or publisher.
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 15 (PIDDSI_COMPANY)</para>
        /// </summary>
        public static ShellItemPropertyKey Company => new ShellItemPropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 15);

        /// <summary>
        /// <para>Name:     System.ComputerName -- PKEY_ComputerName</para>
        /// <para>Description:
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: (FMTID_ShellDetails) {28636AA6-953D-11D2-B5D6-00C04FD918D0}, 5 (PID_COMPUTERNAME)</para>
        /// </summary>
        public static ShellItemPropertyKey ComputerName => new ShellItemPropertyKey(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 5);

        /// <summary>
        /// <para>Name:     System.ContainedItems -- PKEY_ContainedItems</para>
        /// <para>Description: The list of type of items, this item contains. For example, this item contains urls, attachments etc.
        ///This is represented as a vector array of GUIDs where each GUID represents certain type.
        ///</para>
        /// <para>Type:     Multivalue Guid -- VT_VECTOR | VT_CLSID  (For variants: VT_ARRAY | VT_CLSID)</para>
        /// <para>FormatID: (FMTID_ShellDetails) {28636AA6-953D-11D2-B5D6-00C04FD918D0}, 29</para>
        /// </summary>
        public static ShellItemPropertyKey ContainedItems => new ShellItemPropertyKey(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 29);

        /// <summary>
        /// <para>Name:     System.ContentStatus -- PKEY_ContentStatus</para>
        /// <para>Description:</para>
        /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
        /// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 27</para>
        /// </summary>
        public static ShellItemPropertyKey ContentStatus => new ShellItemPropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 27);

        /// <summary>
        /// <para>Name:     System.ContentType -- PKEY_ContentType</para>
        /// <para>Description:</para>
        /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
        /// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 26</para>
        /// </summary>
        public static ShellItemPropertyKey ContentType => new ShellItemPropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 26);

        /// <summary>
        /// <para>Name:     System.Copyright -- PKEY_Copyright</para>
        /// <para>Description:
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 11 (PIDMSI_COPYRIGHT)</para>
        /// </summary>
        public static ShellItemPropertyKey Copyright => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 11);

        /// <summary>
        /// <para>Name:     System.DateAccessed -- PKEY_DateAccessed</para>
        /// <para>Description: The time of the last access to the item.  The Indexing Service friendly name is 'access'.
        ///</para>
        /// <para>Type:     DateTime -- VT_FILETIME  (For variants: VT_DATE)</para>
        /// <para>FormatID: (FMTID_Storage) {B725F130-47EF-101A-A5F1-02608C9EEBAC}, 16 (PID_STG_ACCESSTIME)</para>
        /// </summary>
        public static ShellItemPropertyKey DateAccessed => new ShellItemPropertyKey(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 16);

        /// <summary>
        /// <para>Name:     System.DateAcquired -- PKEY_DateAcquired</para>
        /// <para>Description: The time the file entered the system via acquisition.  This is not the same as System.DateImported.
        ///Examples are when pictures are acquired from a camera, or when music is purchased online.
        ///</para>
        /// <para>Type:     DateTime -- VT_FILETIME  (For variants: VT_DATE)</para>
        /// <para>FormatID: {2CBAA8F5-D81F-47CA-B17A-F8D822300131}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey DateAcquired => new ShellItemPropertyKey(new Guid("{2CBAA8F5-D81F-47CA-B17A-F8D822300131}"), 100);

        /// <summary>
        /// <para>Name:     System.DateArchived -- PKEY_DateArchived</para>
        /// <para>Description:</para>
        /// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
        /// <para>FormatID: {43F8D7B7-A444-4F87-9383-52271C9B915C}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey DateArchived => new ShellItemPropertyKey(new Guid("{43F8D7B7-A444-4F87-9383-52271C9B915C}"), 100);

        /// <summary>
        /// <para>Name:     System.DateCompleted -- PKEY_DateCompleted</para>
        /// <para>Description:</para>
        /// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
        /// <para>FormatID: {72FAB781-ACDA-43E5-B155-B2434F85E678}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey DateCompleted => new ShellItemPropertyKey(new Guid("{72FAB781-ACDA-43E5-B155-B2434F85E678}"), 100);

        /// <summary>
        /// <para>Name:     System.DateCreated -- PKEY_DateCreated</para>
        /// <para>Description: The date and time the item was created. The Indexing Service friendly name is 'create'.
        ///</para>
        /// <para>Type:     DateTime -- VT_FILETIME  (For variants: VT_DATE)</para>
        /// <para>FormatID: (FMTID_Storage) {B725F130-47EF-101A-A5F1-02608C9EEBAC}, 15 (PID_STG_CREATETIME)</para>
        /// </summary>
        public static ShellItemPropertyKey DateCreated => new ShellItemPropertyKey(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 15);

        /// <summary>
        /// <para>Name:     System.DateImported -- PKEY_DateImported</para>
        /// <para>Description: The time the file is imported into a separate database.  This is not the same as System.DateAcquired.  (Eg, 2003:05:22 13:55:04)
        ///</para>
        /// <para>Type:     DateTime -- VT_FILETIME  (For variants: VT_DATE)</para>
        /// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 18258</para>
        /// </summary>
        public static ShellItemPropertyKey DateImported => new ShellItemPropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 18258);

        /// <summary>
        /// <para>Name:     System.DateModified -- PKEY_DateModified</para>
        /// <para>Description: The date and time of the last write to the item. The Indexing Service friendly name is 'write'.
        ///</para>
        /// <para>Type:     DateTime -- VT_FILETIME  (For variants: VT_DATE)</para>
        /// <para>FormatID: (FMTID_Storage) {B725F130-47EF-101A-A5F1-02608C9EEBAC}, 14 (PID_STG_WRITETIME)</para>
        /// </summary>
        public static ShellItemPropertyKey DateModified => new ShellItemPropertyKey(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 14);

        /// <summary>
        /// <para>Name:     System.DescriptionID -- PKEY_DescriptionID</para>
        /// <para>Description: The contents of a SHDESCRIPTIONID structure as a buffer of bytes.
        ///</para>
        /// <para>Type:     Buffer -- VT_VECTOR | VT_UI1  (For variants: VT_ARRAY | VT_UI1)</para>
        /// <para>FormatID: (FMTID_ShellDetails) {28636AA6-953D-11D2-B5D6-00C04FD918D0}, 2 (PID_DESCRIPTIONID)</para>
        /// </summary>
        public static ShellItemPropertyKey DescriptionID => new ShellItemPropertyKey(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 2);

        /// <summary>
        /// <para>Name:     System.DueDate -- PKEY_DueDate</para>
        /// <para>Description:</para>
        /// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
        /// <para>FormatID: {3F8470B5-E0AF-4DB2-8071-C53FE76AE7CE}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey DueDate => new ShellItemPropertyKey(new Guid("{3F8470B5-E0AF-4DB2-8071-C53FE76AE7CE}"), 100);

        /// <summary>
        /// <para>Name:     System.EndDate -- PKEY_EndDate</para>
        /// <para>Description:</para>
        /// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
        /// <para>FormatID: {C75FAA05-96FD-49E7-9CB4-9F601082D553}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey EndDate => new ShellItemPropertyKey(new Guid("{C75FAA05-96FD-49E7-9CB4-9F601082D553}"), 100);

        /// <summary>
        /// <para>Name:     System.FileAllocationSize -- PKEY_FileAllocationSize</para>
        /// <para>Description:
        ///</para>
        /// <para>Type:     UInt64 -- VT_UI8</para>
        /// <para>FormatID: (FMTID_Storage) {B725F130-47EF-101A-A5F1-02608C9EEBAC}, 18 (PID_STG_ALLOCSIZE)</para>
        /// </summary>
        public static ShellItemPropertyKey FileAllocationSize => new ShellItemPropertyKey(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 18);

        /// <summary>
        /// <para>Name:     System.FileAttributes -- PKEY_FileAttributes</para>
        /// <para>Description: This is the WIN32_FIND_DATA dwFileAttributes for the file-based item.
        ///</para>
        /// <para>Type:     UInt32 -- VT_UI4</para>
        /// <para>FormatID: (FMTID_Storage) {B725F130-47EF-101A-A5F1-02608C9EEBAC}, 13 (PID_STG_ATTRIBUTES)</para>
        /// </summary>
        public static ShellItemPropertyKey FileAttributes => new ShellItemPropertyKey(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 13);

        /// <summary>
        /// <para>Name:     System.FileCount -- PKEY_FileCount</para>
        /// <para>Description:
        ///</para>
        /// <para>Type:     UInt64 -- VT_UI8</para>
        /// <para>FormatID: (FMTID_ShellDetails) {28636AA6-953D-11D2-B5D6-00C04FD918D0}, 12</para>
        /// </summary>
        public static ShellItemPropertyKey FileCount => new ShellItemPropertyKey(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 12);

        /// <summary>
        /// <para>Name:     System.FileDescription -- PKEY_FileDescription</para>
        /// <para>Description: This is a user-friendly description of the file.
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: (PSFMTID_VERSION) {0CEF7D53-FA64-11D1-A203-0000F81FEDEE}, 3 (PIDVSI_FileDescription)</para>
        /// </summary>
        public static ShellItemPropertyKey FileDescription => new ShellItemPropertyKey(new Guid("{0CEF7D53-FA64-11D1-A203-0000F81FEDEE}"), 3);

        /// <summary>
        /// <para>Name:     System.FileExtension -- PKEY_FileExtension</para>
        /// <para>Description: This is the file extension of the file based item, including the leading period.
        ///
        ///If System.FileName is VT_EMPTY, then this property should be too.  Otherwise, it should be derived
        ///appropriately by the data source from System.FileName.  If System.FileName does not have a file
        ///extension, this value should be VT_EMPTY.
        ///
        ///To obtain the type of any item (including an item that is not a file), use System.ItemType.
        ///
        ///Example values:
        ///
        ///    If the path is...                     The property value is...
        ///    -----------------                     ------------------------
        ///    "c:\foo\bar\hello.txt"                ".txt"
        ///    "\\server\share\mydir\goodnews.doc"   ".doc"
        ///    "\\server\share\numbers.xls"          ".xls"
        ///    "\\server\share\folder"               VT_EMPTY
        ///    "c:\foo\MyFolder"                     VT_EMPTY
        ///    [desktop]                             VT_EMPTY
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: {E4F10A3C-49E6-405D-8288-A23BD4EEAA6C}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey FileExtension => new ShellItemPropertyKey(new Guid("{E4F10A3C-49E6-405D-8288-A23BD4EEAA6C}"), 100);

        /// <summary>
        /// <para>Name:     System.FileFRN -- PKEY_FileFRN</para>
        /// <para>Description: This is the unique file ID, also known as the File Reference Number. For a given file, this is the same value
        ///as is found in the structure variable FILE_ID_BOTH_DIR_INFO.FileId, via GetFileInformationByHandleEx().
        ///</para>
        /// <para>Type:     UInt64 -- VT_UI8</para>
        /// <para>FormatID: (FMTID_Storage) {B725F130-47EF-101A-A5F1-02608C9EEBAC}, 21 (PID_STG_FRN)</para>
        /// </summary>
        public static ShellItemPropertyKey FileFRN => new ShellItemPropertyKey(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 21);

        /// <summary>
        /// <para>Name:     System.FileName -- PKEY_FileName</para>
        /// <para>Description: This is the file name (including extension) of the file.
        ///
        ///It is possible that the item might not exist on a filesystem (ie, it may not be opened
        ///using CreateFile).  Nonetheless, if the item is represented as a file from the logical sense
        ///(and its name follows standard Win32 file-naming syntax), then the data source should emit this property.
        ///
        ///If an item is not a file, then the value for this property is VT_EMPTY.  See
        ///System.ItemNameDisplay.
        ///
        ///This has the same value as System.ParsingName for items that are provided by the Shell's file folder.
        ///
        ///Example values:
        ///
        ///    If the path is...                     The property value is...
        ///    -----------------                     ------------------------
        ///    "c:\foo\bar\hello.txt"                "hello.txt"
        ///    "\\server\share\mydir\goodnews.doc"   "goodnews.doc"
        ///    "\\server\share\numbers.xls"          "numbers.xls"
        ///    "c:\foo\MyFolder"                     "MyFolder"
        ///    (email message)                       VT_EMPTY
        ///    (song on portable device)             "song.wma"
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: {41CF5AE0-F75A-4706-BD87-59C7D9248EB9}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey FileName => new ShellItemPropertyKey(new Guid("{41CF5AE0-F75A-4706-BD87-59C7D9248EB9}"), 100);

        /// <summary>
        /// <para>Name:     System.FileOwner -- PKEY_FileOwner</para>
        /// <para>Description: This is the owner of the file, according to the file system.
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: (FMTID_Misc) {9B174B34-40FF-11D2-A27E-00C04FC30871}, 4 (PID_MISC_OWNER)</para>
        /// </summary>
        public static ShellItemPropertyKey FileOwner => new ShellItemPropertyKey(new Guid("{9B174B34-40FF-11D2-A27E-00C04FC30871}"), 4);

        /// <summary>
        /// <para>Name:     System.FileVersion -- PKEY_FileVersion</para>
        /// <para>Description:
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: (PSFMTID_VERSION) {0CEF7D53-FA64-11D1-A203-0000F81FEDEE}, 4 (PIDVSI_FileVersion)</para>
        /// </summary>
        public static ShellItemPropertyKey FileVersion => new ShellItemPropertyKey(new Guid("{0CEF7D53-FA64-11D1-A203-0000F81FEDEE}"), 4);

        /// <summary>
        /// <para>Name:     System.FindData -- PKEY_FindData</para>
        /// <para>Description: WIN32_FIND_DATAW in buffer of bytes.
        ///</para>
        /// <para>Type:     Buffer -- VT_VECTOR | VT_UI1  (For variants: VT_ARRAY | VT_UI1)</para>
        /// <para>FormatID: (FMTID_ShellDetails) {28636AA6-953D-11D2-B5D6-00C04FD918D0}, 0 (PID_FINDDATA)</para>
        /// </summary>
        public static ShellItemPropertyKey FindData => new ShellItemPropertyKey(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 0);

        /// <summary>
        /// <para>Name:     System.FlagColor -- PKEY_FlagColor</para>
        /// <para>Description:
        ///</para>
        /// <para>Type:     UInt16 -- VT_UI2</para>
        /// <para>FormatID: {67DF94DE-0CA7-4D6F-B792-053A3E4F03CF}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey FlagColor => new ShellItemPropertyKey(new Guid("{67DF94DE-0CA7-4D6F-B792-053A3E4F03CF}"), 100);

        /// <summary>
        /// <para>Name:     System.FlagColorText -- PKEY_FlagColorText</para>
        /// <para>Description: This is the user-friendly form of System.FlagColor.  Not intended to be parsed
        ///programmatically.
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: {45EAE747-8E2A-40AE-8CBF-CA52ABA6152A}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey FlagColorText => new ShellItemPropertyKey(new Guid("{45EAE747-8E2A-40AE-8CBF-CA52ABA6152A}"), 100);

        /// <summary>
        /// <para>Name:     System.FlagStatus -- PKEY_FlagStatus</para>
        /// <para>Description: Status of Flag.  Values: (0=none 1=white 2=Red).  cdoPR_FLAG_STATUS
        ///</para>
        /// <para>Type:     Int32 -- VT_I4</para>
        /// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 12</para>
        /// </summary>
        public static ShellItemPropertyKey FlagStatus => new ShellItemPropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 12);

        /// <summary>
        /// <para>Name:     System.FlagStatusText -- PKEY_FlagStatusText</para>
        /// <para>Description: This is the user-friendly form of System.FlagStatus.  Not intended to be parsed
        ///programmatically.
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: {DC54FD2E-189D-4871-AA01-08C2F57A4ABC}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey FlagStatusText => new ShellItemPropertyKey(new Guid("{DC54FD2E-189D-4871-AA01-08C2F57A4ABC}"), 100);

        /// <summary>
        /// <para>Name:     System.FreeSpace -- PKEY_FreeSpace</para>
        /// <para>Description: The amount of free space in bytes.
        ///</para>
        /// <para>Type:     UInt64 -- VT_UI8</para>
        /// <para>FormatID: (FMTID_Volume) {9B174B35-40FF-11D2-A27E-00C04FC30871}, 2 (PID_VOLUME_FREE)  (Filesystem Volume Properties)</para>
        /// </summary>
        public static ShellItemPropertyKey FreeSpace => new ShellItemPropertyKey(new Guid("{9B174B35-40FF-11D2-A27E-00C04FC30871}"), 2);

        /// <summary>
        /// <para>Name:     System.FullText -- PKEY_FullText</para>
        /// <para>Description: This PKEY is used to specify search terms that should be applied as broadly as possible,
        ///across all valid properties for the data source(s) being searched.  It should not be
        ///emitted from a data source.
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: {1E3EE840-BC2B-476C-8237-2ACD1A839B22}, 6</para>
        /// </summary>
        public static ShellItemPropertyKey FullText => new ShellItemPropertyKey(new Guid("{1E3EE840-BC2B-476C-8237-2ACD1A839B22}"), 6);

        /// <summary>
        /// <para>Name:     System.Identity -- PKEY_Identity</para>
        /// <para>Description:</para>
        /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
        /// <para>FormatID: {A26F4AFC-7346-4299-BE47-EB1AE613139F}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey IdentityProperty => new ShellItemPropertyKey(new Guid("{A26F4AFC-7346-4299-BE47-EB1AE613139F}"), 100);

        /// <summary>
        /// <para>Name:     System.ImageParsingName -- PKEY_ImageParsingName</para>
        /// <para>Description:</para>
        /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
        /// <para>FormatID: {D7750EE0-C6A4-48EC-B53E-B87B52E6D073}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey ImageParsingName => new ShellItemPropertyKey(new Guid("{D7750EE0-C6A4-48EC-B53E-B87B52E6D073}"), 100);

        /// <summary>
        /// <para>Name:     System.Importance -- PKEY_Importance</para>
        /// <para>Description:</para>
        /// <para>Type:     Int32 -- VT_I4</para>
        /// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 11</para>
        /// </summary>
        public static ShellItemPropertyKey Importance => new ShellItemPropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 11);

        /// <summary>
        /// <para>Name:     System.ImportanceText -- PKEY_ImportanceText</para>
        /// <para>Description: This is the user-friendly form of System.Importance.  Not intended to be parsed
        ///programmatically.
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: {A3B29791-7713-4E1D-BB40-17DB85F01831}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey ImportanceText => new ShellItemPropertyKey(new Guid("{A3B29791-7713-4E1D-BB40-17DB85F01831}"), 100);

        /// <summary>
        /// <para>Name:     System.InfoTipText -- PKEY_InfoTipText</para>
        /// <para>Description: The text (with formatted property values) to show in the infotip.
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: {C9944A21-A406-48FE-8225-AEC7E24C211B}, 17</para>
        /// </summary>
        public static ShellItemPropertyKey InfoTipText => new ShellItemPropertyKey(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 17);

        /// <summary>
        /// <para>Name:     System.InternalName -- PKEY_InternalName</para>
        /// <para>Description:
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: (PSFMTID_VERSION) {0CEF7D53-FA64-11D1-A203-0000F81FEDEE}, 5 (PIDVSI_InternalName)</para>
        /// </summary>
        public static ShellItemPropertyKey InternalName => new ShellItemPropertyKey(new Guid("{0CEF7D53-FA64-11D1-A203-0000F81FEDEE}"), 5);

        /// <summary>
        /// <para>Name:     System.IsAttachment -- PKEY_IsAttachment</para>
        /// <para>Description: Identifies if this item is an attachment.
        ///</para>
        /// <para>Type:     Boolean -- VT_BOOL</para>
        /// <para>FormatID: {F23F425C-71A1-4FA8-922F-678EA4A60408}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey IsAttachment => new ShellItemPropertyKey(new Guid("{F23F425C-71A1-4FA8-922F-678EA4A60408}"), 100);

        /// <summary>
        /// <para>Name:     System.IsDefaultNonOwnerSaveLocation -- PKEY_IsDefaultNonOwnerSaveLocation</para>
        /// <para>Description: Identifies the default save location for a library for non-owners of the library
        ///</para>
        /// <para>Type:     Boolean -- VT_BOOL</para>
        /// <para>FormatID: {5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}, 5</para>
        /// </summary>
        public static ShellItemPropertyKey IsDefaultNonOwnerSaveLocation => new ShellItemPropertyKey(new Guid("{5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}"), 5);

        /// <summary>
        /// <para>Name:     System.IsDefaultSaveLocation -- PKEY_IsDefaultSaveLocation</para>
        /// <para>Description: Identifies the default save location for a library for the owner of the library
        ///</para>
        /// <para>Type:     Boolean -- VT_BOOL</para>
        /// <para>FormatID: {5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}, 3</para>
        /// </summary>
        public static ShellItemPropertyKey IsDefaultSaveLocation => new ShellItemPropertyKey(new Guid("{5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}"), 3);

        /// <summary>
        /// <para>Name:     System.IsDeleted -- PKEY_IsDeleted</para>
        /// <para>Description:</para>
        /// <para>Type:     Boolean -- VT_BOOL</para>
        /// <para>FormatID: {5CDA5FC8-33EE-4FF3-9094-AE7BD8868C4D}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey IsDeleted => new ShellItemPropertyKey(new Guid("{5CDA5FC8-33EE-4FF3-9094-AE7BD8868C4D}"), 100);

        /// <summary>
        /// <para>Name:     System.IsEncrypted -- PKEY_IsEncrypted</para>
        /// <para>Description: Is the item encrypted?
        ///</para>
        /// <para>Type:     Boolean -- VT_BOOL</para>
        /// <para>FormatID: {90E5E14E-648B-4826-B2AA-ACAF790E3513}, 10</para>
        /// </summary>
        public static ShellItemPropertyKey IsEncrypted => new ShellItemPropertyKey(new Guid("{90E5E14E-648B-4826-B2AA-ACAF790E3513}"), 10);

        /// <summary>
        /// <para>Name:     System.IsFlagged -- PKEY_IsFlagged</para>
        /// <para>Description:</para>
        /// <para>Type:     Boolean -- VT_BOOL</para>
        /// <para>FormatID: {5DA84765-E3FF-4278-86B0-A27967FBDD03}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey IsFlagged => new ShellItemPropertyKey(new Guid("{5DA84765-E3FF-4278-86B0-A27967FBDD03}"), 100);

        /// <summary>
        /// <para>Name:     System.IsFlaggedComplete -- PKEY_IsFlaggedComplete</para>
        /// <para>Description:</para>
        /// <para>Type:     Boolean -- VT_BOOL</para>
        /// <para>FormatID: {A6F360D2-55F9-48DE-B909-620E090A647C}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey IsFlaggedComplete => new ShellItemPropertyKey(new Guid("{A6F360D2-55F9-48DE-B909-620E090A647C}"), 100);

        /// <summary>
        /// <para>Name:     System.IsIncomplete -- PKEY_IsIncomplete</para>
        /// <para>Description: Identifies if the message was not completely received for some error condition.
        ///</para>
        /// <para>Type:     Boolean -- VT_BOOL</para>
        /// <para>FormatID: {346C8BD1-2E6A-4C45-89A4-61B78E8E700F}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey IsIncomplete => new ShellItemPropertyKey(new Guid("{346C8BD1-2E6A-4C45-89A4-61B78E8E700F}"), 100);

        /// <summary>
        /// <para>Name:     System.IsLocationSupported -- PKEY_IsLocationSupported</para>
        /// <para>Description: A bool value to know if a location is supported (locally indexable, or remotely indexed).
        ///</para>
        /// <para>Type:     Boolean -- VT_BOOL</para>
        /// <para>FormatID: {5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}, 8</para>
        /// </summary>
        public static ShellItemPropertyKey IsLocationSupported => new ShellItemPropertyKey(new Guid("{5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}"), 8);

        /// <summary>
        /// <para>Name:     System.IsPinnedToNameSpaceTree -- PKEY_IsPinnedToNameSpaceTree</para>
        /// <para>Description: A bool value to know if a shell folder is pinned to the navigation pane
        ///</para>
        /// <para>Type:     Boolean -- VT_BOOL</para>
        /// <para>FormatID: {5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}, 2</para>
        /// </summary>
        public static ShellItemPropertyKey IsPinnedToNameSpaceTree => new ShellItemPropertyKey(new Guid("{5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}"), 2);

        /// <summary>
        /// <para>Name:     System.IsRead -- PKEY_IsRead</para>
        /// <para>Description: Has the item been read?
        ///</para>
        /// <para>Type:     Boolean -- VT_BOOL</para>
        /// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 10</para>
        /// </summary>
        public static ShellItemPropertyKey IsRead => new ShellItemPropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 10);

        /// <summary>
        /// <para>Name:     System.IsSearchOnlyItem -- PKEY_IsSearchOnlyItem</para>
        /// <para>Description: Identifies if a location or a library is search only
        ///</para>
        /// <para>Type:     Boolean -- VT_BOOL</para>
        /// <para>FormatID: {5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}, 4</para>
        /// </summary>
        public static ShellItemPropertyKey IsSearchOnlyItem => new ShellItemPropertyKey(new Guid("{5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}"), 4);

        /// <summary>
        /// <para>Name:     System.IsSendToTarget -- PKEY_IsSendToTarget</para>
        /// <para>Description: Provided by certain shell folders. Return TRUE if the folder is a valid Send To target.
        ///</para>
        /// <para>Type:     Boolean -- VT_BOOL</para>
        /// <para>FormatID: (FMTID_ShellDetails) {28636AA6-953D-11D2-B5D6-00C04FD918D0}, 33</para>
        /// </summary>
        public static ShellItemPropertyKey IsSendToTarget => new ShellItemPropertyKey(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 33);

        /// <summary>
        /// <para>Name:     System.IsShared -- PKEY_IsShared</para>
        /// <para>Description: Is this item shared?  This only checks for ACLs that are not inherited.
        ///</para>
        /// <para>Type:     Boolean -- VT_BOOL</para>
        /// <para>FormatID: {EF884C5B-2BFE-41BB-AAE5-76EEDF4F9902}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey IsShared => new ShellItemPropertyKey(new Guid("{EF884C5B-2BFE-41BB-AAE5-76EEDF4F9902}"), 100);

        /// <summary>
        /// <para>Name:     System.ItemAuthors -- PKEY_ItemAuthors</para>
        /// <para>Description: This is the generic list of authors associated with an item.
        ///
        ///For example, the artist name for a track is the item author.
        ///</para>
        /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
        /// <para>FormatID: {D0A04F0A-462A-48A4-BB2F-3706E88DBD7D}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey ItemAuthors => new ShellItemPropertyKey(new Guid("{D0A04F0A-462A-48A4-BB2F-3706E88DBD7D}"), 100);

        /// <summary>
        /// <para>Name:     System.ItemClassType -- PKEY_ItemClassType</para>
        /// <para>Description:</para>
        /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
        /// <para>FormatID: {048658AD-2DB8-41A4-BBB6-AC1EF1207EB1}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey ItemClassType => new ShellItemPropertyKey(new Guid("{048658AD-2DB8-41A4-BBB6-AC1EF1207EB1}"), 100);

        /// <summary>
        /// <para>Name:     System.ItemDate -- PKEY_ItemDate</para>
        /// <para>Description: This is the main date for an item. The date of interest.
        ///
        ///For example, for photos this maps to System.Photo.DateTaken.
        ///</para>
        /// <para>Type:     DateTime -- VT_FILETIME  (For variants: VT_DATE)</para>
        /// <para>FormatID: {F7DB74B4-4287-4103-AFBA-F1B13DCD75CF}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey ItemDate => new ShellItemPropertyKey(new Guid("{F7DB74B4-4287-4103-AFBA-F1B13DCD75CF}"), 100);

        /// <summary>
        /// <para>Name:     System.ItemFolderNameDisplay -- PKEY_ItemFolderNameDisplay</para>
        /// <para>Description: This is the user-friendly display name of the parent folder of an item.
        ///
        ///If System.ItemFolderPathDisplay is VT_EMPTY, then this property should be too.  Otherwise, it
        ///should be derived appropriately by the data source from System.ItemFolderPathDisplay.
        ///
        ///If the folder is a file folder, the value will be localized if a localized name is available.
        ///
        ///Example values:
        ///
        ///    If the path is...                     The property value is...
        ///    -----------------                     ------------------------
        ///    "c:\foo\bar\hello.txt"                "bar"
        ///    "\\server\share\mydir\goodnews.doc"   "mydir"
        ///    "\\server\share\numbers.xls"          "share"
        ///    "c:\foo\MyFolder"                     "foo"
        ///    "/Mailbox Account/Inbox/'Re: Hello!'" "Inbox"
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: (FMTID_Storage) {B725F130-47EF-101A-A5F1-02608C9EEBAC}, 2 (PID_STG_DIRECTORY)</para>
        /// </summary>
        public static ShellItemPropertyKey ItemFolderNameDisplay => new ShellItemPropertyKey(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 2);

        /// <summary>
        /// <para>Name:     System.ItemFolderPathDisplay -- PKEY_ItemFolderPathDisplay</para>
        /// <para>Description: This is the user-friendly display path of the parent folder of an item.
        ///
        ///If System.ItemPathDisplay is VT_EMPTY, then this property should be too.  Otherwise, it should
        ///be derived appropriately by the data source from System.ItemPathDisplay.
        ///
        ///Example values:
        ///
        ///    If the path is...                     The property value is...
        ///    -----------------                     ------------------------
        ///    "c:\foo\bar\hello.txt"                "c:\foo\bar"
        ///    "\\server\share\mydir\goodnews.doc"   "\\server\share\mydir"
        ///    "\\server\share\numbers.xls"          "\\server\share"
        ///    "c:\foo\MyFolder"                     "c:\foo"
        ///    "/Mailbox Account/Inbox/'Re: Hello!'" "/Mailbox Account/Inbox"
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 6</para>
        /// </summary>
        public static ShellItemPropertyKey ItemFolderPathDisplay => new ShellItemPropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 6);

        /// <summary>
        /// <para>Name:     System.ItemFolderPathDisplayNarrow -- PKEY_ItemFolderPathDisplayNarrow</para>
        /// <para>Description: This is the user-friendly display path of the parent folder of an item.  The format of the string
        ///should be tailored such that the folder name comes first, to optimize for a narrow viewing column.
        ///
        ///If the folder is a file folder, the value includes localized names if they are present.
        ///
        ///If System.ItemFolderPathDisplay is VT_EMPTY, then this property should be too.  Otherwise, it should
        ///be derived appropriately by the data source from System.ItemFolderPathDisplay.
        ///
        ///Example values:
        ///
        ///    If the path is...                     The property value is...
        ///    -----------------                     ------------------------
        ///    "c:\foo\bar\hello.txt"                "bar (c:\foo)"
        ///    "\\server\share\mydir\goodnews.doc"   "mydir (\\server\share)"
        ///    "\\server\share\numbers.xls"          "share (\\server)"
        ///    "c:\foo\MyFolder"                     "foo (c:\)"
        ///    "/Mailbox Account/Inbox/'Re: Hello!'" "Inbox (/Mailbox Account)"
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: {DABD30ED-0043-4789-A7F8-D013A4736622}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey ItemFolderPathDisplayNarrow => new ShellItemPropertyKey(new Guid("{DABD30ED-0043-4789-A7F8-D013A4736622}"), 100);

        /// <summary>
        /// <para>Name:     System.ItemName -- PKEY_ItemName</para>
        /// <para>Description: This is the base-name of the System.ItemNameDisplay.
        ///
        ///If the item is a file this property
        ///includes the extension in all cases, and will be localized if a localized name is available.
        ///
        ///If the item is a message, then the value of this property does not include the forwarding or
        ///reply prefixes (see System.ItemNamePrefix).
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: {6B8DA074-3B5C-43BC-886F-0A2CDCE00B6F}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey ItemName => new ShellItemPropertyKey(new Guid("{6B8DA074-3B5C-43BC-886F-0A2CDCE00B6F}"), 100);

        /// <summary>
        /// <para>Name:     System.ItemNameDisplay -- PKEY_ItemNameDisplay</para>
        /// <para>Description: This is the display name in "most complete" form.  This is the best effort unique representation
        ///of the name of an item that makes sense for end users to read.  It is the concatentation of
        ///System.ItemNamePrefix and System.ItemName.
        ///
        ///If the item is a file this property
        ///includes the extension in all cases, and will be localized if a localized name is available.
        ///
        ///There are acceptable cases when System.FileName is not VT_EMPTY, yet the value of this property
        ///is completely different.  Email messages are a key example.  If the item is an email message,
        ///the item name is likely the subject.  In that case, the value must be the concatenation of the
        ///System.ItemNamePrefix and System.ItemName.  Since the value of System.ItemNamePrefix excludes
        ///any trailing whitespace, the concatenation must include a whitespace when generating System.ItemNameDisplay.
        ///
        ///Note that this property is not guaranteed to be unique, but the idea is to promote the most likely
        ///candidate that can be unique and also makes sense for end users. For example, for documents, you
        ///might think about using System.Title as the System.ItemNameDisplay, but in practice the title of
        ///the documents may not be useful or unique enough to be of value as the sole System.ItemNameDisplay.
        ///Instead, providing the value of System.FileName as the value of System.ItemNameDisplay is a better
        ///candidate.  In Windows Mail, the emails are stored in the file system as .eml files and the
        ///System.FileName for those files are not human-friendly as they contain GUIDs. In this example,
        ///promoting System.Subject as System.ItemNameDisplay makes more sense.
        ///
        ///Compatibility notes:
        ///
        ///Shell folder implementations on Vista: use PKEY_ItemNameDisplay for the name column when
        ///you want Explorer to call ISF::GetDisplayNameOf(SHGDN_NORMAL) to get the value of the name. Use
        ///another PKEY (like PKEY_ItemName) when you want Explorer to call either the folder's property store or
        ///ISF2::GetDetailsEx in order to get the value of the name.
        ///
        ///Shell folder implementations on XP: the first column needs to be the name column, and Explorer
        ///will call ISF::GetDisplayNameOf to get the value of the name.  The PKEY/SCID does not matter.
        ///
        ///Example values:
        ///
        ///    File:          "hello.txt"
        ///    Message:       "Re: Let's talk about Tom's argyle socks!"
        ///    Device folder: "song.wma"
        ///    Folder:        "Documents"
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: (FMTID_Storage) {B725F130-47EF-101A-A5F1-02608C9EEBAC}, 10 (PID_STG_NAME)</para>
        /// </summary>
        public static ShellItemPropertyKey ItemNameDisplay => new ShellItemPropertyKey(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 10);

        /// <summary>
        /// <para>Name:     System.ItemNamePrefix -- PKEY_ItemNamePrefix</para>
        /// <para>Description: This is the prefix of an item, used for email messages.
        ///where the subject begins with "Re:" which is the prefix.
        ///
        ///If the item is a file, then the value of this property is VT_EMPTY.
        ///
        ///If the item is a message, then the value of this property is the forwarding or reply
        ///prefixes (including delimiting colon, but no whitespace), or VT_EMPTY if there is no prefix.
        ///
        ///Example values:
        ///
        ///System.ItemNamePrefix    System.ItemName      System.ItemNameDisplay
        ///---------------------    -------------------  ----------------------
        ///VT_EMPTY                 "Great day"          "Great day"
        ///"Re:"                    "Great day"          "Re: Great day"
        ///"Fwd: "                  "Monthly budget"     "Fwd: Monthly budget"
        ///VT_EMPTY                 "accounts.xls"       "accounts.xls"
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: {D7313FF1-A77A-401C-8C99-3DBDD68ADD36}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey ItemNamePrefix => new ShellItemPropertyKey(new Guid("{D7313FF1-A77A-401C-8C99-3DBDD68ADD36}"), 100);

        /// <summary>
        /// <para>Name:     System.ItemParticipants -- PKEY_ItemParticipants</para>
        /// <para>Description: This is the generic list of people associated with an item and who contributed
        ///to the item.
        ///
        ///For example, this is the combination of people in the To list, Cc list and
        ///sender of an email message.
        ///</para>
        /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
        /// <para>FormatID: {D4D0AA16-9948-41A4-AA85-D97FF9646993}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey ItemParticipants => new ShellItemPropertyKey(new Guid("{D4D0AA16-9948-41A4-AA85-D97FF9646993}"), 100);

        /// <summary>
        /// <para>Name:     System.ItemPathDisplay -- PKEY_ItemPathDisplay</para>
        /// <para>Description: This is the user-friendly display path to the item.
        ///
        ///If the item is a file or folder this property
        ///includes the extension in all cases, and will be localized if a localized name is available.
        ///
        ///For other items,this is the user-friendly equivalent, assuming the item exists in hierarchical storage.
        ///
        ///Unlike System.ItemUrl, this property value does not include the URL scheme.
        ///
        ///To parse an item path, use System.ItemUrl or System.ParsingPath.  To reference shell
        ///namespace items using shell APIs, use System.ParsingPath.
        ///
        ///Example values:
        ///
        ///    If the path is...                     The property value is...
        ///    -----------------                     ------------------------
        ///    "c:\foo\bar\hello.txt"                "c:\foo\bar\hello.txt"
        ///    "\\server\share\mydir\goodnews.doc"   "\\server\share\mydir\goodnews.doc"
        ///    "\\server\share\numbers.xls"          "\\server\share\numbers.xls"
        ///    "c:\foo\MyFolder"                     "c:\foo\MyFolder"
        ///    "/Mailbox Account/Inbox/'Re: Hello!'" "/Mailbox Account/Inbox/'Re: Hello!'"
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 7</para>
        /// </summary>
        public static ShellItemPropertyKey ItemPathDisplay => new ShellItemPropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 7);

        /// <summary>
        /// <para>Name:     System.ItemPathDisplayNarrow -- PKEY_ItemPathDisplayNarrow</para>
        /// <para>Description: This is the user-friendly display path to the item. The format of the string should be
        ///tailored such that the name comes first, to optimize for a narrow viewing column.
        ///
        ///If the item is a file, the value excludes the file extension, and includes localized names if they are present.
        ///If the item is a message, the value includes the System.ItemNamePrefix.
        ///
        ///To parse an item path, use System.ItemUrl or System.ParsingPath.
        ///
        ///Example values:
        ///
        ///    If the path is...                     The property value is...
        ///    -----------------                     ------------------------
        ///    "c:\foo\bar\hello.txt"                "hello (c:\foo\bar)"
        ///    "\\server\share\mydir\goodnews.doc"   "goodnews (\\server\share\mydir)"
        ///    "\\server\share\folder"               "folder (\\server\share)"
        ///    "c:\foo\MyFolder"                     "MyFolder (c:\foo)"
        ///    "/Mailbox Account/Inbox/'Re: Hello!'" "Re: Hello! (/Mailbox Account/Inbox)"
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: (FMTID_ShellDetails) {28636AA6-953D-11D2-B5D6-00C04FD918D0}, 8</para>
        /// </summary>
        public static ShellItemPropertyKey ItemPathDisplayNarrow => new ShellItemPropertyKey(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 8);

        /// <summary>
        /// <para>Name:     System.ItemType -- PKEY_ItemType</para>
        /// <para>Description: This is the canonical type of the item and is intended to be programmatically
        ///parsed.
        ///
        ///If there is no canonical type, the value is VT_EMPTY.
        ///
        ///If the item is a file (ie, System.FileName is not VT_EMPTY), the value is the same as
        ///System.FileExtension.
        ///
        ///Use System.ItemTypeText when you want to display the type to end users in a view.  (If
        /// the item is a file, passing the System.ItemType value to PSFormatForDisplay will
        /// result in the same value as System.ItemTypeText.)
        ///
        ///Example values:
        ///
        ///    If the path is...                     The property value is...
        ///    -----------------                     ------------------------
        ///    "c:\foo\bar\hello.txt"                ".txt"
        ///    "\\server\share\mydir\goodnews.doc"   ".doc"
        ///    "\\server\share\folder"               "Directory"
        ///    "c:\foo\MyFolder"                     "Directory"
        ///    [desktop]                             "Folder"
        ///    "/Mailbox Account/Inbox/'Re: Hello!'" "MAPI/IPM.Message"
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: (FMTID_ShellDetails) {28636AA6-953D-11D2-B5D6-00C04FD918D0}, 11</para>
        /// </summary>
        public static ShellItemPropertyKey ItemType => new ShellItemPropertyKey(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 11);

        /// <summary>
        /// <para>Name:     System.ItemTypeText -- PKEY_ItemTypeText</para>
        /// <para>Description: This is the user friendly type name of the item.  This is not intended to be
        ///programmatically parsed.
        ///
        ///If System.ItemType is VT_EMPTY, the value of this property is also VT_EMPTY.
        ///
        ///If the item is a file, the value of this property is the same as if you passed the
        ///file's System.ItemType value to PSFormatForDisplay.
        ///
        ///This property should not be confused with System.Kind, where System.Kind is a high-level
        ///user friendly kind name. For example, for a document, System.Kind = "Document" and
        ///System.Item.Type = ".doc" and System.Item.TypeText = "Microsoft Word Document"
        ///
        ///Example values:
        ///
        ///    If the path is...                     The property value is...
        ///    -----------------                     ------------------------
        ///    "c:\foo\bar\hello.txt"                "Text File"
        ///    "\\server\share\mydir\goodnews.doc"   "Microsoft Word Document"
        ///    "\\server\share\folder"               "File Folder"
        ///    "c:\foo\MyFolder"                     "File Folder"
        ///    "/Mailbox Account/Inbox/'Re: Hello!'" "Outlook E-Mail Message"
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: (FMTID_Storage) {B725F130-47EF-101A-A5F1-02608C9EEBAC}, 4 (PID_STG_STORAGETYPE)</para>
        /// </summary>
        public static ShellItemPropertyKey ItemTypeText => new ShellItemPropertyKey(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 4);

        /// <summary>
        /// <para>Name:     System.ItemUrl -- PKEY_ItemUrl</para>
        /// <para>Description: This always represents a well formed URL that points to the item.
        ///
        ///To reference shell namespace items using shell APIs, use System.ParsingPath.
        ///
        ///Example values:
        ///
        ///    Files:    "file:///c:/foo/bar/hello.txt"
        ///              "csc://{GUID}/..."
        ///    Messages: "mapi://..."
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: (FMTID_Query) {49691C90-7E17-101A-A91C-08002B2ECDA9}, 9 (DISPID_QUERY_VIRTUALPATH)</para>
        /// </summary>
        public static ShellItemPropertyKey ItemUrl => new ShellItemPropertyKey(new Guid("{49691C90-7E17-101A-A91C-08002B2ECDA9}"), 9);

        /// <summary>
        /// <para>Name:     System.Keywords -- PKEY_Keywords</para>
        /// <para>Description: The keywords for the item.  Also referred to as tags.
        ///</para>
        /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)  Legacy code may treat this as VT_LPSTR.</para>
        /// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 5 (PIDSI_KEYWORDS)</para>
        /// </summary>
        public static ShellItemPropertyKey Keywords => new ShellItemPropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 5);

        /// <summary>
        /// <para>Name:     System.Kind -- PKEY_Kind</para>
        /// <para>Description: System.Kind is used to map extensions to various .Search folders.
        ///Extensions are mapped to Kinds at HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Explorer\KindMap
        ///The list of kinds is not extensible.
        ///</para>
        /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
        /// <para>FormatID: {1E3EE840-BC2B-476C-8237-2ACD1A839B22}, 3</para>
        /// </summary>
        public static ShellItemPropertyKey Kind => new ShellItemPropertyKey(new Guid("{1E3EE840-BC2B-476C-8237-2ACD1A839B22}"), 3);

        /// <summary>
        /// <para>Name:     System.KindText -- PKEY_KindText</para>
        /// <para>Description: This is the user-friendly form of System.Kind.  Not intended to be parsed
        ///programmatically.
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: {F04BEF95-C585-4197-A2B7-DF46FDC9EE6D}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey KindText => new ShellItemPropertyKey(new Guid("{F04BEF95-C585-4197-A2B7-DF46FDC9EE6D}"), 100);

        /// <summary>
        /// <para>Name:     System.Language -- PKEY_Language</para>
        /// <para>Description:
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 28</para>
        /// </summary>
        public static ShellItemPropertyKey Language => new ShellItemPropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 28);

        /// <summary>
        /// <para>Name:     System.MileageInformation -- PKEY_MileageInformation</para>
        /// <para>Description:</para>
        /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
        /// <para>FormatID: {FDF84370-031A-4ADD-9E91-0D775F1C6605}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey MileageInformation => new ShellItemPropertyKey(new Guid("{FDF84370-031A-4ADD-9E91-0D775F1C6605}"), 100);

        /// <summary>
        /// <para>Name:     System.MIMEType -- PKEY_MIMEType</para>
        /// <para>Description: The MIME type.  Eg, for EML files: 'message/rfc822'.
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: {0B63E350-9CCC-11D0-BCDB-00805FCCCE04}, 5</para>
        /// </summary>
        public static ShellItemPropertyKey MIMEType => new ShellItemPropertyKey(new Guid("{0B63E350-9CCC-11D0-BCDB-00805FCCCE04}"), 5);

        /// <summary>
        /// <para>Name:     System.NamespaceCLSID -- PKEY_NamespaceCLSID</para>
        /// <para>Description: The CLSID of the name space extension for an item, the object that implements IShellFolder for this item
        ///</para>
        /// <para>Type:     Guid -- VT_CLSID</para>
        /// <para>FormatID: (FMTID_ShellDetails) {28636AA6-953D-11D2-B5D6-00C04FD918D0}, 6</para>
        /// </summary>
        public static ShellItemPropertyKey NamespaceCLSID => new ShellItemPropertyKey(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 6);

        /// <summary>
        /// <para>Name:     System.Null -- PKEY_Null</para>
        /// <para>Description:</para>
        /// <para>Type:     Null -- VT_NULL</para>
        /// <para>FormatID: {00000000-0000-0000-0000-000000000000}, 0</para>
        /// </summary>
        public static ShellItemPropertyKey Null => new ShellItemPropertyKey(new Guid("{00000000-0000-0000-0000-000000000000}"), 0);

        /// <summary>
        /// <para>Name:     System.OfflineAvailability -- PKEY_OfflineAvailability</para>
        /// <para>Description:</para>
        /// <para>Type:     UInt32 -- VT_UI4</para>
        /// <para>FormatID: {A94688B6-7D9F-4570-A648-E3DFC0AB2B3F}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey OfflineAvailability => new ShellItemPropertyKey(new Guid("{A94688B6-7D9F-4570-A648-E3DFC0AB2B3F}"), 100);

        /// <summary>
        /// <para>Name:     System.OfflineStatus -- PKEY_OfflineStatus</para>
        /// <para>Description:</para>
        /// <para>Type:     UInt32 -- VT_UI4</para>
        /// <para>FormatID: {6D24888F-4708-4BDA-AFED-EA0FB4386CD8}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey OfflineStatus => new ShellItemPropertyKey(new Guid("{6D24888F-4708-4BDA-AFED-EA0FB4386CD8}"), 100);

        /// <summary>
        /// <para>Name:     System.OriginalFileName -- PKEY_OriginalFileName</para>
        /// <para>Description:
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: (PSFMTID_VERSION) {0CEF7D53-FA64-11D1-A203-0000F81FEDEE}, 6</para>
        /// </summary>
        public static ShellItemPropertyKey OriginalFileName => new ShellItemPropertyKey(new Guid("{0CEF7D53-FA64-11D1-A203-0000F81FEDEE}"), 6);

        /// <summary>
        /// <para>Name:     System.OwnerSID -- PKEY_OwnerSID</para>
        /// <para>Description: SID of the user that owns the library.
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: {5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}, 6</para>
        /// </summary>
        public static ShellItemPropertyKey OwnerSID => new ShellItemPropertyKey(new Guid("{5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}"), 6);

        /// <summary>
        /// <para>Name:     System.ParentalRating -- PKEY_ParentalRating</para>
        /// <para>Description:
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 21 (PIDMSI_PARENTAL_RATING)</para>
        /// </summary>
        public static ShellItemPropertyKey ParentalRating => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 21);

        /// <summary>
        /// <para>Name:     System.ParentalRatingReason -- PKEY_ParentalRatingReason</para>
        /// <para>Description:</para>
        /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
        /// <para>FormatID: {10984E0A-F9F2-4321-B7EF-BAF195AF4319}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey ParentalRatingReason => new ShellItemPropertyKey(new Guid("{10984E0A-F9F2-4321-B7EF-BAF195AF4319}"), 100);

        /// <summary>
        /// <para>Name:     System.ParentalRatingsOrganization -- PKEY_ParentalRatingsOrganization</para>
        /// <para>Description:</para>
        /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
        /// <para>FormatID: {A7FE0840-1344-46F0-8D37-52ED712A4BF9}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey ParentalRatingsOrganization => new ShellItemPropertyKey(new Guid("{A7FE0840-1344-46F0-8D37-52ED712A4BF9}"), 100);

        /// <summary>
        /// <para>Name:     System.ParsingBindContext -- PKEY_ParsingBindContext</para>
        /// <para>Description: used to get the IBindCtx for an item for parsing
        ///</para>
        /// <para>Type:     Any -- VT_NULL  Legacy code may treat this as VT_UNKNOWN.</para>
        /// <para>FormatID: {DFB9A04D-362F-4CA3-B30B-0254B17B5B84}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey ParsingBindContext => new ShellItemPropertyKey(new Guid("{DFB9A04D-362F-4CA3-B30B-0254B17B5B84}"), 100);

        /// <summary>
        /// <para>Name:     System.ParsingName -- PKEY_ParsingName</para>
        /// <para>Description: The shell namespace name of an item relative to a parent folder.  This name may be passed to
        ///IShellFolder::ParseDisplayName() of the parent shell folder.
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: (FMTID_ShellDetails) {28636AA6-953D-11D2-B5D6-00C04FD918D0}, 24</para>
        /// </summary>
        public static ShellItemPropertyKey ParsingName => new ShellItemPropertyKey(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 24);

        /// <summary>
        /// <para>Name:     System.ParsingPath -- PKEY_ParsingPath</para>
        /// <para>Description: This is the shell namespace path to the item.  This path may be passed to
        ///SHParseDisplayName to parse the path to the correct shell folder.
        ///
        ///If the item is a file, the value is identical to System.ItemPathDisplay.
        ///
        ///If the item cannot be accessed through the shell namespace, this value is VT_EMPTY.
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: (FMTID_ShellDetails) {28636AA6-953D-11D2-B5D6-00C04FD918D0}, 30</para>
        /// </summary>
        public static ShellItemPropertyKey ParsingPath => new ShellItemPropertyKey(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 30);

        /// <summary>
        /// <para>Name:     System.PerceivedType -- PKEY_PerceivedType</para>
        /// <para>Description: The perceived type of a shell item, based upon its canonical type.
        ///</para>
        /// <para>Type:     Int32 -- VT_I4</para>
        /// <para>FormatID: (FMTID_ShellDetails) {28636AA6-953D-11D2-B5D6-00C04FD918D0}, 9</para>
        /// </summary>
        public static ShellItemPropertyKey PerceivedType => new ShellItemPropertyKey(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 9);

        /// <summary>
        /// <para>Name:     System.PercentFull -- PKEY_PercentFull</para>
        /// <para>Description: The amount filled as a percentage, multiplied by 100 (ie, the valid range is 0 through 100).
        ///</para>
        /// <para>Type:     UInt32 -- VT_UI4</para>
        /// <para>FormatID: (FMTID_Volume) {9B174B35-40FF-11D2-A27E-00C04FC30871}, 5  (Filesystem Volume Properties)</para>
        /// </summary>
        public static ShellItemPropertyKey PercentFull => new ShellItemPropertyKey(new Guid("{9B174B35-40FF-11D2-A27E-00C04FC30871}"), 5);

        /// <summary>
        /// <para>Name:     System.Priority -- PKEY_Priority</para>
        /// <para>Description:
        ///</para>
        /// <para>Type:     UInt16 -- VT_UI2</para>
        /// <para>FormatID: {9C1FCF74-2D97-41BA-B4AE-CB2E3661A6E4}, 5</para>
        /// </summary>
        public static ShellItemPropertyKey Priority => new ShellItemPropertyKey(new Guid("{9C1FCF74-2D97-41BA-B4AE-CB2E3661A6E4}"), 5);

        /// <summary>
        /// <para>Name:     System.PriorityText -- PKEY_PriorityText</para>
        /// <para>Description: This is the user-friendly form of System.Priority.  Not intended to be parsed
        ///programmatically.
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: {D98BE98B-B86B-4095-BF52-9D23B2E0A752}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey PriorityText => new ShellItemPropertyKey(new Guid("{D98BE98B-B86B-4095-BF52-9D23B2E0A752}"), 100);

        /// <summary>
        /// <para>Name:     System.Project -- PKEY_Project</para>
        /// <para>Description:</para>
        /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
        /// <para>FormatID: {39A7F922-477C-48DE-8BC8-B28441E342E3}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey Project => new ShellItemPropertyKey(new Guid("{39A7F922-477C-48DE-8BC8-B28441E342E3}"), 100);

        /// <summary>
        /// <para>Name:     System.ProviderItemID -- PKEY_ProviderItemID</para>
        /// <para>Description:
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: {F21D9941-81F0-470A-ADEE-4E74B49217ED}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey ProviderItemID => new ShellItemPropertyKey(new Guid("{F21D9941-81F0-470A-ADEE-4E74B49217ED}"), 100);

        /// <summary>
        /// <para>Name:     System.Rating -- PKEY_Rating</para>
        /// <para>Description: Indicates the users preference rating of an item on a scale of 1-99 (1-12 = One Star,
        ///13-37 = Two Stars, 38-62 = Three Stars, 63-87 = Four Stars, 88-99 = Five Stars).
        ///</para>
        /// <para>Type:     UInt32 -- VT_UI4</para>
        /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 9 (PIDMSI_RATING)</para>
        /// </summary>
        public static ShellItemPropertyKey Rating => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 9);

        /// <summary>
        /// <para>Name:     System.RatingText -- PKEY_RatingText</para>
        /// <para>Description: This is the user-friendly form of System.Rating.  Not intended to be parsed
        ///programmatically.
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: {90197CA7-FD8F-4E8C-9DA3-B57E1E609295}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey RatingText => new ShellItemPropertyKey(new Guid("{90197CA7-FD8F-4E8C-9DA3-B57E1E609295}"), 100);

        /// <summary>
        /// <para>Name:     System.Sensitivity -- PKEY_Sensitivity</para>
        /// <para>Description:
        ///</para>
        /// <para>Type:     UInt16 -- VT_UI2</para>
        /// <para>FormatID: {F8D3F6AC-4874-42CB-BE59-AB454B30716A}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey Sensitivity => new ShellItemPropertyKey(new Guid("{F8D3F6AC-4874-42CB-BE59-AB454B30716A}"), 100);

        /// <summary>
        /// <para>Name:     System.SensitivityText -- PKEY_SensitivityText</para>
        /// <para>Description: This is the user-friendly form of System.Sensitivity.  Not intended to be parsed
        ///programmatically.
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: {D0C7F054-3F72-4705-8527-129A577CB269}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey SensitivityText => new ShellItemPropertyKey(new Guid("{D0C7F054-3F72-4705-8527-129A577CB269}"), 100);

        /// <summary>
        /// <para>Name:     System.SFGAOFlags -- PKEY_SFGAOFlags</para>
        /// <para>Description: IShellFolder::GetAttributesOf flags, with SFGAO_PKEYSFGAOMASK attributes masked out.
        ///</para>
        /// <para>Type:     UInt32 -- VT_UI4</para>
        /// <para>FormatID: (FMTID_ShellDetails) {28636AA6-953D-11D2-B5D6-00C04FD918D0}, 25</para>
        /// </summary>
        public static ShellItemPropertyKey SFGAOFlags => new ShellItemPropertyKey(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 25);

        /// <summary>
        /// <para>Name:     System.SharedWith -- PKEY_SharedWith</para>
        /// <para>Description: Who is the item shared with?
        ///</para>
        /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
        /// <para>FormatID: {EF884C5B-2BFE-41BB-AAE5-76EEDF4F9902}, 200</para>
        /// </summary>
        public static ShellItemPropertyKey SharedWith => new ShellItemPropertyKey(new Guid("{EF884C5B-2BFE-41BB-AAE5-76EEDF4F9902}"), 200);

        /// <summary>
        /// <para>Name:     System.ShareUserRating -- PKEY_ShareUserRating</para>
        /// <para>Description:
        ///</para>
        /// <para>Type:     UInt32 -- VT_UI4</para>
        /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 12 (PIDMSI_SHARE_USER_RATING)</para>
        /// </summary>
        public static ShellItemPropertyKey ShareUserRating => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 12);

        /// <summary>
        /// <para>Name:     System.SharingStatus -- PKEY_SharingStatus</para>
        /// <para>Description: What is the item's sharing status (not shared, shared, everyone (homegroup or everyone), or private)?
        ///</para>
        /// <para>Type:     UInt32 -- VT_UI4</para>
        /// <para>FormatID: {EF884C5B-2BFE-41BB-AAE5-76EEDF4F9902}, 300</para>
        /// </summary>
        public static ShellItemPropertyKey SharingStatus => new ShellItemPropertyKey(new Guid("{EF884C5B-2BFE-41BB-AAE5-76EEDF4F9902}"), 300);

        /// <summary>
        /// <para>Name:     System.SimpleRating -- PKEY_SimpleRating</para>
        /// <para>Description: Indicates the users preference rating of an item on a scale of 0-5 (0=unrated, 1=One Star, 2=Two Stars, 3=Three Stars,
        ///4=Four Stars, 5=Five Stars)
        ///</para>
        /// <para>Type:     UInt32 -- VT_UI4</para>
        /// <para>FormatID: {A09F084E-AD41-489F-8076-AA5BE3082BCA}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey SimpleRating => new ShellItemPropertyKey(new Guid("{A09F084E-AD41-489F-8076-AA5BE3082BCA}"), 100);

        /// <summary>
        /// <para>Name:     System.Size -- PKEY_Size</para>
        /// <para>Description:
        ///</para>
        /// <para>Type:     UInt64 -- VT_UI8</para>
        /// <para>FormatID: (FMTID_Storage) {B725F130-47EF-101A-A5F1-02608C9EEBAC}, 12 (PID_STG_SIZE)</para>
        /// </summary>
        public static ShellItemPropertyKey Size => new ShellItemPropertyKey(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 12);

        /// <summary>
        /// <para>Name:     System.SoftwareUsed -- PKEY_SoftwareUsed</para>
        /// <para>Description: PropertyTagSoftwareUsed
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 305</para>
        /// </summary>
        public static ShellItemPropertyKey SoftwareUsed => new ShellItemPropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 305);

        /// <summary>
        /// <para>Name:     System.SourceItem -- PKEY_SourceItem</para>
        /// <para>Description:</para>
        /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
        /// <para>FormatID: {668CDFA5-7A1B-4323-AE4B-E527393A1D81}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey SourceItem => new ShellItemPropertyKey(new Guid("{668CDFA5-7A1B-4323-AE4B-E527393A1D81}"), 100);

        /// <summary>
        /// <para>Name:     System.StartDate -- PKEY_StartDate</para>
        /// <para>Description:</para>
        /// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
        /// <para>FormatID: {48FD6EC8-8A12-4CDF-A03E-4EC5A511EDDE}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey StartDate => new ShellItemPropertyKey(new Guid("{48FD6EC8-8A12-4CDF-A03E-4EC5A511EDDE}"), 100);

        /// <summary>
        /// <para>Name:     System.Status -- PKEY_Status</para>
        /// <para>Description:</para>
        /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
        /// <para>FormatID: (FMTID_IntSite) {000214A1-0000-0000-C000-000000000046}, 9</para>
        /// </summary>
        public static ShellItemPropertyKey Status => new ShellItemPropertyKey(new Guid("{000214A1-0000-0000-C000-000000000046}"), 9);

        /// <summary>
        /// <para>Name:     System.Subject -- PKEY_Subject</para>
        /// <para>Description:
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 3 (PIDSI_SUBJECT)</para>
        /// </summary>
        public static ShellItemPropertyKey Subject => new ShellItemPropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 3);

        /// <summary>
        /// <para>Name:     System.Thumbnail -- PKEY_Thumbnail</para>
        /// <para>Description: A data that represents the thumbnail in VT_CF format.
        ///</para>
        /// <para>Type:     Clipboard -- VT_CF</para>
        /// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 17 (PIDSI_THUMBNAIL)</para>
        /// </summary>
        public static ShellItemPropertyKey Thumbnail => new ShellItemPropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 17);

        /// <summary>
        /// <para>Name:     System.ThumbnailCacheId -- PKEY_ThumbnailCacheId</para>
        /// <para>Description: Unique value that can be used as a key to cache thumbnails. The value changes when the name, volume, or data modified
        ///of an item changes.
        ///</para>
        /// <para>Type:     UInt64 -- VT_UI8</para>
        /// <para>FormatID: {446D16B1-8DAD-4870-A748-402EA43D788C}, 100</para>
        /// </summary>
        public static ShellItemPropertyKey ThumbnailCacheId => new ShellItemPropertyKey(new Guid("{446D16B1-8DAD-4870-A748-402EA43D788C}"), 100);

        /// <summary>
        /// <para>Name:     System.ThumbnailStream -- PKEY_ThumbnailStream</para>
        /// <para>Description: Data that represents the thumbnail in VT_STREAM format that GDI+/WindowsCodecs supports (jpg, png, etc).
        ///</para>
        /// <para>Type:     Stream -- VT_STREAM</para>
        /// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 27</para>
        /// </summary>
        public static ShellItemPropertyKey ThumbnailStream => new ShellItemPropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 27);

        /// <summary>
        /// <para>Name:     System.Title -- PKEY_Title</para>
        /// <para>Description: Title of item.
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)  Legacy code may treat this as VT_LPSTR.</para>
        /// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 2 (PIDSI_TITLE)</para>
        /// </summary>
        public static ShellItemPropertyKey Title => new ShellItemPropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 2);

        /// <summary>
        /// <para>Name:     System.TotalFileSize -- PKEY_TotalFileSize</para>
        /// <para>Description:
        ///</para>
        /// <para>Type:     UInt64 -- VT_UI8</para>
        /// <para>FormatID: (FMTID_ShellDetails) {28636AA6-953D-11D2-B5D6-00C04FD918D0}, 14</para>
        /// </summary>
        public static ShellItemPropertyKey TotalFileSize => new ShellItemPropertyKey(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 14);

        /// <summary>
        /// <para>Name:     System.Trademarks -- PKEY_Trademarks</para>
        /// <para>Description:
        ///</para>
        /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
        /// <para>FormatID: (PSFMTID_VERSION) {0CEF7D53-FA64-11D1-A203-0000F81FEDEE}, 9 (PIDVSI_Trademarks)</para>
        /// </summary>
        public static ShellItemPropertyKey Trademarks => new ShellItemPropertyKey(new Guid("{0CEF7D53-FA64-11D1-A203-0000F81FEDEE}"), 9);

        internal static string ReverseLookup(ShellItemPropertyKey key)
        {
            if (revIndex == null)
            {
                revIndex = new Dictionary<ShellItemPropertyKey, string>();
                AddMembersToIndex(typeof(KnownShellItemPropertyKeys));
            }
            string ret = null;
            revIndex.TryGetValue(key, out ret);
            return ret;
        }

        private static void AddMembersToIndex(Type type, int level = 0)
        {
            foreach (PropertyInfo pi in type.GetProperties(BindingFlags.Public | BindingFlags.Static))
            {
                if (pi.PropertyType == typeof(ShellItemPropertyKey))
                {
                    Type pType = type;
                    StringBuilder name = new StringBuilder(pi.Name);
                    for (int i = 0; i < level; i++)
                    {
                        name.Insert(0, pType.Name + ".");
                        pType = pType.DeclaringType;
                    }
                    try { revIndex.Add((ShellItemPropertyKey)pi.GetValue(null, null), name.ToString()); } catch { }
                }
            }
            foreach (Type ti in type.GetNestedTypes(BindingFlags.Public))
                AddMembersToIndex(ti, level + 1);
        }

        /// <summary>AppUserModel Properties</summary>
        public static class AppUserModel
        {
            /// <summary>
            /// <para>Name:     System.AppUserModel.ExcludeFromShowInNewInstall -- PKEY_AppUserModel_ExcludeFromShowInNewInstall</para>
            /// <para>Description:</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}, 8</para>
            /// </summary>
            public static ShellItemPropertyKey ExcludeFromShowInNewInstall => new ShellItemPropertyKey(new Guid("{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}"), 8);

            /// <summary>
            /// <para>Name:     System.AppUserModel.ID -- PKEY_AppUserModel_ID</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}, 5</para>
            /// </summary>
            public static ShellItemPropertyKey ID => new ShellItemPropertyKey(new Guid("{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}"), 5);

            /// <summary>
            /// <para>Name:     System.AppUserModel.IsDestListSeparator -- PKEY_AppUserModel_IsDestListSeparator</para>
            /// <para>Description:</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}, 6</para>
            /// </summary>
            public static ShellItemPropertyKey IsDestListSeparator => new ShellItemPropertyKey(new Guid("{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}"), 6);

            /// <summary>
            /// <para>Name:     System.AppUserModel.PreventPinning -- PKEY_AppUserModel_PreventPinning</para>
            /// <para>Description:</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}, 9</para>
            /// </summary>
            public static ShellItemPropertyKey PreventPinning => new ShellItemPropertyKey(new Guid("{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}"), 9);

            /// <summary>
            /// <para>Name:     System.AppUserModel.RelaunchCommand -- PKEY_AppUserModel_RelaunchCommand</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}, 2</para>
            /// </summary>
            public static ShellItemPropertyKey RelaunchCommand => new ShellItemPropertyKey(new Guid("{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}"), 2);

            /// <summary>
            /// <para>Name:     System.AppUserModel.RelaunchDisplayNameResource -- PKEY_AppUserModel_RelaunchDisplayNameResource</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}, 4</para>
            /// </summary>
            public static ShellItemPropertyKey RelaunchDisplayNameResource => new ShellItemPropertyKey(new Guid("{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}"), 4);

            /// <summary>
            /// <para>Name:     System.AppUserModel.RelaunchIconResource -- PKEY_AppUserModel_RelaunchIconResource</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}, 3</para>
            /// </summary>
            public static ShellItemPropertyKey RelaunchIconResource => new ShellItemPropertyKey(new Guid("{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}"), 3);
        }

        /// <summary>Audio Properties</summary>
        public static class Audio
        {
            /// <summary>
            /// <para>Name:     System.Audio.ChannelCount -- PKEY_Audio_ChannelCount</para>
            /// <para>Description: Indicates the channel count for the audio file.  Values: 1 (mono), 2 (stereo).
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: (FMTID_AudioSummaryInformation) {64440490-4C8B-11D1-8B70-080036B11A03}, 7 (PIDASI_CHANNEL_COUNT)</para>
            /// </summary>
            public static ShellItemPropertyKey ChannelCount => new ShellItemPropertyKey(new Guid("{64440490-4C8B-11D1-8B70-080036B11A03}"), 7);

            /// <summary>
            /// <para>Name:     System.Audio.Compression -- PKEY_Audio_Compression</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (FMTID_AudioSummaryInformation) {64440490-4C8B-11D1-8B70-080036B11A03}, 10 (PIDASI_COMPRESSION)</para>
            /// </summary>
            public static ShellItemPropertyKey Compression => new ShellItemPropertyKey(new Guid("{64440490-4C8B-11D1-8B70-080036B11A03}"), 10);

            /// <summary>
            /// <para>Name:     System.Audio.EncodingBitrate -- PKEY_Audio_EncodingBitrate</para>
            /// <para>Description: Indicates the average data rate in Hz for the audio file in "bits per second".
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: (FMTID_AudioSummaryInformation) {64440490-4C8B-11D1-8B70-080036B11A03}, 4 (PIDASI_AVG_DATA_RATE)</para>
            /// </summary>
            public static ShellItemPropertyKey EncodingBitrate => new ShellItemPropertyKey(new Guid("{64440490-4C8B-11D1-8B70-080036B11A03}"), 4);

            /// <summary>
            /// <para>Name:     System.Audio.Format -- PKEY_Audio_Format</para>
            /// <para>Description: Indicates the format of the audio file.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)  Legacy code may treat this as VT_BSTR.</para>
            /// <para>FormatID: (FMTID_AudioSummaryInformation) {64440490-4C8B-11D1-8B70-080036B11A03}, 2 (PIDASI_FORMAT)</para>
            /// </summary>
            public static ShellItemPropertyKey Format => new ShellItemPropertyKey(new Guid("{64440490-4C8B-11D1-8B70-080036B11A03}"), 2);

            /// <summary>
            /// <para>Name:     System.Audio.IsVariableBitRate -- PKEY_Audio_IsVariableBitRate</para>
            /// <para>Description:</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {E6822FEE-8C17-4D62-823C-8E9CFCBD1D5C}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey IsVariableBitRate => new ShellItemPropertyKey(new Guid("{E6822FEE-8C17-4D62-823C-8E9CFCBD1D5C}"), 100);

            /// <summary>
            /// <para>Name:     System.Audio.PeakValue -- PKEY_Audio_PeakValue</para>
            /// <para>Description:</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {2579E5D0-1116-4084-BD9A-9B4F7CB4DF5E}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey PeakValue => new ShellItemPropertyKey(new Guid("{2579E5D0-1116-4084-BD9A-9B4F7CB4DF5E}"), 100);

            /// <summary>
            /// <para>Name:     System.Audio.SampleRate -- PKEY_Audio_SampleRate</para>
            /// <para>Description: Indicates the audio sample rate for the audio file in "samples per second".
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: (FMTID_AudioSummaryInformation) {64440490-4C8B-11D1-8B70-080036B11A03}, 5 (PIDASI_SAMPLE_RATE)</para>
            /// </summary>
            public static ShellItemPropertyKey SampleRate => new ShellItemPropertyKey(new Guid("{64440490-4C8B-11D1-8B70-080036B11A03}"), 5);

            /// <summary>
            /// <para>Name:     System.Audio.SampleSize -- PKEY_Audio_SampleSize</para>
            /// <para>Description: Indicates the audio sample size for the audio file in "bits per sample".
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: (FMTID_AudioSummaryInformation) {64440490-4C8B-11D1-8B70-080036B11A03}, 6 (PIDASI_SAMPLE_SIZE)</para>
            /// </summary>
            public static ShellItemPropertyKey SampleSize => new ShellItemPropertyKey(new Guid("{64440490-4C8B-11D1-8B70-080036B11A03}"), 6);

            /// <summary>
            /// <para>Name:     System.Audio.StreamName -- PKEY_Audio_StreamName</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (FMTID_AudioSummaryInformation) {64440490-4C8B-11D1-8B70-080036B11A03}, 9 (PIDASI_STREAM_NAME)</para>
            /// </summary>
            public static ShellItemPropertyKey StreamName => new ShellItemPropertyKey(new Guid("{64440490-4C8B-11D1-8B70-080036B11A03}"), 9);

            /// <summary>
            /// <para>Name:     System.Audio.StreamNumber -- PKEY_Audio_StreamNumber</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     UInt16 -- VT_UI2</para>
            /// <para>FormatID: (FMTID_AudioSummaryInformation) {64440490-4C8B-11D1-8B70-080036B11A03}, 8 (PIDASI_STREAM_NUMBER)</para>
            /// </summary>
            public static ShellItemPropertyKey StreamNumber => new ShellItemPropertyKey(new Guid("{64440490-4C8B-11D1-8B70-080036B11A03}"), 8);
        }

        /// <summary>Calendar Properties</summary>
        public static class Calendar
        {
            /// <summary>
            /// <para>Name:     System.Calendar.Duration -- PKEY_Calendar_Duration</para>
            /// <para>Description: The duration as specified in a string.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {293CA35A-09AA-4DD2-B180-1FE245728A52}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Duration => new ShellItemPropertyKey(new Guid("{293CA35A-09AA-4DD2-B180-1FE245728A52}"), 100);

            /// <summary>
            /// <para>Name:     System.Calendar.IsOnline -- PKEY_Calendar_IsOnline</para>
            /// <para>Description: Identifies if the event is an online event.
            ///</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {BFEE9149-E3E2-49A7-A862-C05988145CEC}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey IsOnline => new ShellItemPropertyKey(new Guid("{BFEE9149-E3E2-49A7-A862-C05988145CEC}"), 100);

            /// <summary>
            /// <para>Name:     System.Calendar.IsRecurring -- PKEY_Calendar_IsRecurring</para>
            /// <para>Description:</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {315B9C8D-80A9-4EF9-AE16-8E746DA51D70}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey IsRecurring => new ShellItemPropertyKey(new Guid("{315B9C8D-80A9-4EF9-AE16-8E746DA51D70}"), 100);

            /// <summary>
            /// <para>Name:     System.Calendar.Location -- PKEY_Calendar_Location</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {F6272D18-CECC-40B1-B26A-3911717AA7BD}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Location => new ShellItemPropertyKey(new Guid("{F6272D18-CECC-40B1-B26A-3911717AA7BD}"), 100);

            /// <summary>
            /// <para>Name:     System.Calendar.OptionalAttendeeAddresses -- PKEY_Calendar_OptionalAttendeeAddresses</para>
            /// <para>Description:</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: {D55BAE5A-3892-417A-A649-C6AC5AAAEAB3}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey OptionalAttendeeAddresses => new ShellItemPropertyKey(new Guid("{D55BAE5A-3892-417A-A649-C6AC5AAAEAB3}"), 100);

            /// <summary>
            /// <para>Name:     System.Calendar.OptionalAttendeeNames -- PKEY_Calendar_OptionalAttendeeNames</para>
            /// <para>Description:</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: {09429607-582D-437F-84C3-DE93A2B24C3C}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey OptionalAttendeeNames => new ShellItemPropertyKey(new Guid("{09429607-582D-437F-84C3-DE93A2B24C3C}"), 100);

            /// <summary>
            /// <para>Name:     System.Calendar.OrganizerAddress -- PKEY_Calendar_OrganizerAddress</para>
            /// <para>Description: Address of the organizer organizing the event.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {744C8242-4DF5-456C-AB9E-014EFB9021E3}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey OrganizerAddress => new ShellItemPropertyKey(new Guid("{744C8242-4DF5-456C-AB9E-014EFB9021E3}"), 100);

            /// <summary>
            /// <para>Name:     System.Calendar.OrganizerName -- PKEY_Calendar_OrganizerName</para>
            /// <para>Description: Name of the organizer organizing the event.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {AAA660F9-9865-458E-B484-01BC7FE3973E}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey OrganizerName => new ShellItemPropertyKey(new Guid("{AAA660F9-9865-458E-B484-01BC7FE3973E}"), 100);

            /// <summary>
            /// <para>Name:     System.Calendar.ReminderTime -- PKEY_Calendar_ReminderTime</para>
            /// <para>Description:</para>
            /// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
            /// <para>FormatID: {72FC5BA4-24F9-4011-9F3F-ADD27AFAD818}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ReminderTime => new ShellItemPropertyKey(new Guid("{72FC5BA4-24F9-4011-9F3F-ADD27AFAD818}"), 100);

            /// <summary>
            /// <para>Name:     System.Calendar.RequiredAttendeeAddresses -- PKEY_Calendar_RequiredAttendeeAddresses</para>
            /// <para>Description:</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: {0BA7D6C3-568D-4159-AB91-781A91FB71E5}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey RequiredAttendeeAddresses => new ShellItemPropertyKey(new Guid("{0BA7D6C3-568D-4159-AB91-781A91FB71E5}"), 100);

            /// <summary>
            /// <para>Name:     System.Calendar.RequiredAttendeeNames -- PKEY_Calendar_RequiredAttendeeNames</para>
            /// <para>Description:</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: {B33AF30B-F552-4584-936C-CB93E5CDA29F}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey RequiredAttendeeNames => new ShellItemPropertyKey(new Guid("{B33AF30B-F552-4584-936C-CB93E5CDA29F}"), 100);

            /// <summary>
            /// <para>Name:     System.Calendar.Resources -- PKEY_Calendar_Resources</para>
            /// <para>Description:</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: {00F58A38-C54B-4C40-8696-97235980EAE1}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Resources => new ShellItemPropertyKey(new Guid("{00F58A38-C54B-4C40-8696-97235980EAE1}"), 100);

            /// <summary>
            /// <para>Name:     System.Calendar.ResponseStatus -- PKEY_Calendar_ResponseStatus</para>
            /// <para>Description: This property stores the status of the user responses to meetings in her calendar.
            ///</para>
            /// <para>Type:     UInt16 -- VT_UI2</para>
            /// <para>FormatID: {188C1F91-3C40-4132-9EC5-D8B03B72A8A2}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ResponseStatus => new ShellItemPropertyKey(new Guid("{188C1F91-3C40-4132-9EC5-D8B03B72A8A2}"), 100);

            /// <summary>
            /// <para>Name:     System.Calendar.ShowTimeAs -- PKEY_Calendar_ShowTimeAs</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     UInt16 -- VT_UI2</para>
            /// <para>FormatID: {5BF396D4-5EB2-466F-BDE9-2FB3F2361D6E}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ShowTimeAs => new ShellItemPropertyKey(new Guid("{5BF396D4-5EB2-466F-BDE9-2FB3F2361D6E}"), 100);

            /// <summary>
            /// <para>Name:     System.Calendar.ShowTimeAsText -- PKEY_Calendar_ShowTimeAsText</para>
            /// <para>Description: This is the user-friendly form of System.Calendar.ShowTimeAs.  Not intended to be parsed
            ///programmatically.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {53DA57CF-62C0-45C4-81DE-7610BCEFD7F5}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ShowTimeAsText => new ShellItemPropertyKey(new Guid("{53DA57CF-62C0-45C4-81DE-7610BCEFD7F5}"), 100);
        }

        /// <summary>Communication Properties</summary>
        public static class Communication
        {
            /// <summary>
            /// <para>Name:     System.Communication.AccountName -- PKEY_Communication_AccountName</para>
            /// <para>Description: Account Name
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 9</para>
            /// </summary>
            public static ShellItemPropertyKey AccountName => new ShellItemPropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 9);

            /// <summary>
            /// <para>Name:     System.Communication.DateItemExpires -- PKEY_Communication_DateItemExpires</para>
            /// <para>Description: Date the item expires due to the retention policy.
            ///</para>
            /// <para>Type:     DateTime -- VT_FILETIME  (For variants: VT_DATE)</para>
            /// <para>FormatID: {428040AC-A177-4C8A-9760-F6F761227F9A}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey DateItemExpires => new ShellItemPropertyKey(new Guid("{428040AC-A177-4C8A-9760-F6F761227F9A}"), 100);

            /// <summary>
            /// <para>Name:     System.Communication.FollowupIconIndex -- PKEY_Communication_FollowupIconIndex</para>
            /// <para>Description: This is the icon index used on messages marked for followup.
            ///</para>
            /// <para>Type:     Int32 -- VT_I4</para>
            /// <para>FormatID: {83A6347E-6FE4-4F40-BA9C-C4865240D1F4}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey FollowupIconIndex => new ShellItemPropertyKey(new Guid("{83A6347E-6FE4-4F40-BA9C-C4865240D1F4}"), 100);

            /// <summary>
            /// <para>Name:     System.Communication.HeaderItem -- PKEY_Communication_HeaderItem</para>
            /// <para>Description: This property will be true if the item is a header item which means the item hasn't been fully downloaded.
            ///</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {C9C34F84-2241-4401-B607-BD20ED75AE7F}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey HeaderItem => new ShellItemPropertyKey(new Guid("{C9C34F84-2241-4401-B607-BD20ED75AE7F}"), 100);

            /// <summary>
            /// <para>Name:     System.Communication.PolicyTag -- PKEY_Communication_PolicyTag</para>
            /// <para>Description: This a string used to identify the retention policy applied to the item.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {EC0B4191-AB0B-4C66-90B6-C6637CDEBBAB}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey PolicyTag => new ShellItemPropertyKey(new Guid("{EC0B4191-AB0B-4C66-90B6-C6637CDEBBAB}"), 100);

            /// <summary>
            /// <para>Name:     System.Communication.SecurityFlags -- PKEY_Communication_SecurityFlags</para>
            /// <para>Description: Security flags associated with the item to know if the item is encrypted, signed or DRM enabled.
            ///</para>
            /// <para>Type:     Int32 -- VT_I4</para>
            /// <para>FormatID: {8619A4B6-9F4D-4429-8C0F-B996CA59E335}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey SecurityFlags => new ShellItemPropertyKey(new Guid("{8619A4B6-9F4D-4429-8C0F-B996CA59E335}"), 100);

            /// <summary>
            /// <para>Name:     System.Communication.Suffix -- PKEY_Communication_Suffix</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {807B653A-9E91-43EF-8F97-11CE04EE20C5}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Suffix => new ShellItemPropertyKey(new Guid("{807B653A-9E91-43EF-8F97-11CE04EE20C5}"), 100);

            /// <summary>
            /// <para>Name:     System.Communication.TaskStatus -- PKEY_Communication_TaskStatus</para>
            /// <para>Description:</para>
            /// <para>Type:     UInt16 -- VT_UI2</para>
            /// <para>FormatID: {BE1A72C6-9A1D-46B7-AFE7-AFAF8CEF4999}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey TaskStatus => new ShellItemPropertyKey(new Guid("{BE1A72C6-9A1D-46B7-AFE7-AFAF8CEF4999}"), 100);

            /// <summary>
            /// <para>Name:     System.Communication.TaskStatusText -- PKEY_Communication_TaskStatusText</para>
            /// <para>Description: This is the user-friendly form of System.Communication.TaskStatus.  Not intended to be parsed
            ///programmatically.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {A6744477-C237-475B-A075-54F34498292A}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey TaskStatusText => new ShellItemPropertyKey(new Guid("{A6744477-C237-475B-A075-54F34498292A}"), 100);
        }

        /// <summary>Computer Properties</summary>
        public static class Computer
        {
            /// <summary>
            /// <para>Name:     System.Computer.DecoratedFreeSpace -- PKEY_Computer_DecoratedFreeSpace</para>
            /// <para>Description: Free space and total space: "%s free of %s"
            ///</para>
            /// <para>Type:     Multivalue UInt64 -- VT_VECTOR | VT_UI8  (For variants: VT_ARRAY | VT_UI8)</para>
            /// <para>FormatID: (FMTID_Volume) {9B174B35-40FF-11D2-A27E-00C04FC30871}, 7  (Filesystem Volume Properties)</para>
            /// </summary>
            public static ShellItemPropertyKey DecoratedFreeSpace => new ShellItemPropertyKey(new Guid("{9B174B35-40FF-11D2-A27E-00C04FC30871}"), 7);
        }

        /// <summary>Contact Properties</summary>
        public static class Contact
        {
            /// <summary>
            /// <para>Name:     System.Contact.Anniversary -- PKEY_Contact_Anniversary</para>
            /// <para>Description:</para>
            /// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
            /// <para>FormatID: {9AD5BADB-CEA7-4470-A03D-B84E51B9949E}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Anniversary => new ShellItemPropertyKey(new Guid("{9AD5BADB-CEA7-4470-A03D-B84E51B9949E}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.AssistantName -- PKEY_Contact_AssistantName</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {CD102C9C-5540-4A88-A6F6-64E4981C8CD1}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey AssistantName => new ShellItemPropertyKey(new Guid("{CD102C9C-5540-4A88-A6F6-64E4981C8CD1}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.AssistantTelephone -- PKEY_Contact_AssistantTelephone</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {9A93244D-A7AD-4FF8-9B99-45EE4CC09AF6}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey AssistantTelephone => new ShellItemPropertyKey(new Guid("{9A93244D-A7AD-4FF8-9B99-45EE4CC09AF6}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.Birthday -- PKEY_Contact_Birthday</para>
            /// <para>Description:</para>
            /// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
            /// <para>FormatID: {176DC63C-2688-4E89-8143-A347800F25E9}, 47</para>
            /// </summary>
            public static ShellItemPropertyKey Birthday => new ShellItemPropertyKey(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 47);

            /// <summary>
            /// <para>Name:     System.Contact.BusinessAddress -- PKEY_Contact_BusinessAddress</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {730FB6DD-CF7C-426B-A03F-BD166CC9EE24}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey BusinessAddress => new ShellItemPropertyKey(new Guid("{730FB6DD-CF7C-426B-A03F-BD166CC9EE24}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.BusinessAddressCity -- PKEY_Contact_BusinessAddressCity</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {402B5934-EC5A-48C3-93E6-85E86A2D934E}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey BusinessAddressCity => new ShellItemPropertyKey(new Guid("{402B5934-EC5A-48C3-93E6-85E86A2D934E}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.BusinessAddressCountry -- PKEY_Contact_BusinessAddressCountry</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {B0B87314-FCF6-4FEB-8DFF-A50DA6AF561C}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey BusinessAddressCountry => new ShellItemPropertyKey(new Guid("{B0B87314-FCF6-4FEB-8DFF-A50DA6AF561C}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.BusinessAddressPostalCode -- PKEY_Contact_BusinessAddressPostalCode</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {E1D4A09E-D758-4CD1-B6EC-34A8B5A73F80}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey BusinessAddressPostalCode => new ShellItemPropertyKey(new Guid("{E1D4A09E-D758-4CD1-B6EC-34A8B5A73F80}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.BusinessAddressPostOfficeBox -- PKEY_Contact_BusinessAddressPostOfficeBox</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {BC4E71CE-17F9-48D5-BEE9-021DF0EA5409}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey BusinessAddressPostOfficeBox => new ShellItemPropertyKey(new Guid("{BC4E71CE-17F9-48D5-BEE9-021DF0EA5409}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.BusinessAddressState -- PKEY_Contact_BusinessAddressState</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {446F787F-10C4-41CB-A6C4-4D0343551597}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey BusinessAddressState => new ShellItemPropertyKey(new Guid("{446F787F-10C4-41CB-A6C4-4D0343551597}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.BusinessAddressStreet -- PKEY_Contact_BusinessAddressStreet</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {DDD1460F-C0BF-4553-8CE4-10433C908FB0}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey BusinessAddressStreet => new ShellItemPropertyKey(new Guid("{DDD1460F-C0BF-4553-8CE4-10433C908FB0}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.BusinessFaxNumber -- PKEY_Contact_BusinessFaxNumber</para>
            /// <para>Description: Business fax number of the contact.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {91EFF6F3-2E27-42CA-933E-7C999FBE310B}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey BusinessFaxNumber => new ShellItemPropertyKey(new Guid("{91EFF6F3-2E27-42CA-933E-7C999FBE310B}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.BusinessHomePage -- PKEY_Contact_BusinessHomePage</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {56310920-2491-4919-99CE-EADB06FAFDB2}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey BusinessHomePage => new ShellItemPropertyKey(new Guid("{56310920-2491-4919-99CE-EADB06FAFDB2}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.BusinessTelephone -- PKEY_Contact_BusinessTelephone</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {6A15E5A0-0A1E-4CD7-BB8C-D2F1B0C929BC}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey BusinessTelephone => new ShellItemPropertyKey(new Guid("{6A15E5A0-0A1E-4CD7-BB8C-D2F1B0C929BC}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.CallbackTelephone -- PKEY_Contact_CallbackTelephone</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {BF53D1C3-49E0-4F7F-8567-5A821D8AC542}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey CallbackTelephone => new ShellItemPropertyKey(new Guid("{BF53D1C3-49E0-4F7F-8567-5A821D8AC542}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.CarTelephone -- PKEY_Contact_CarTelephone</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {8FDC6DEA-B929-412B-BA90-397A257465FE}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey CarTelephone => new ShellItemPropertyKey(new Guid("{8FDC6DEA-B929-412B-BA90-397A257465FE}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.Children -- PKEY_Contact_Children</para>
            /// <para>Description:</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: {D4709704-8EF1-43EF-9024-2BD381187FD5}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Children => new ShellItemPropertyKey(new Guid("{D4709704-8EF1-43EF-9024-2BD381187FD5}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.CompanyMainTelephone -- PKEY_Contact_CompanyMainTelephone</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {8589E481-6040-473D-B171-7FA89C2708ED}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey CompanyMainTelephone => new ShellItemPropertyKey(new Guid("{8589E481-6040-473D-B171-7FA89C2708ED}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.Department -- PKEY_Contact_Department</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {FC9F7306-FF8F-4D49-9FB6-3FFE5C0951EC}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Department => new ShellItemPropertyKey(new Guid("{FC9F7306-FF8F-4D49-9FB6-3FFE5C0951EC}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.EmailAddress -- PKEY_Contact_EmailAddress</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {F8FA7FA3-D12B-4785-8A4E-691A94F7A3E7}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey EmailAddress => new ShellItemPropertyKey(new Guid("{F8FA7FA3-D12B-4785-8A4E-691A94F7A3E7}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.EmailAddress2 -- PKEY_Contact_EmailAddress2</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {38965063-EDC8-4268-8491-B7723172CF29}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey EmailAddress2 => new ShellItemPropertyKey(new Guid("{38965063-EDC8-4268-8491-B7723172CF29}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.EmailAddress3 -- PKEY_Contact_EmailAddress3</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {644D37B4-E1B3-4BAD-B099-7E7C04966ACA}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey EmailAddress3 => new ShellItemPropertyKey(new Guid("{644D37B4-E1B3-4BAD-B099-7E7C04966ACA}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.EmailAddresses -- PKEY_Contact_EmailAddresses</para>
            /// <para>Description:</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: {84D8F337-981D-44B3-9615-C7596DBA17E3}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey EmailAddresses => new ShellItemPropertyKey(new Guid("{84D8F337-981D-44B3-9615-C7596DBA17E3}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.EmailName -- PKEY_Contact_EmailName</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {CC6F4F24-6083-4BD4-8754-674D0DE87AB8}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey EmailName => new ShellItemPropertyKey(new Guid("{CC6F4F24-6083-4BD4-8754-674D0DE87AB8}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.FileAsName -- PKEY_Contact_FileAsName</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {F1A24AA7-9CA7-40F6-89EC-97DEF9FFE8DB}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey FileAsName => new ShellItemPropertyKey(new Guid("{F1A24AA7-9CA7-40F6-89EC-97DEF9FFE8DB}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.FirstName -- PKEY_Contact_FirstName</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {14977844-6B49-4AAD-A714-A4513BF60460}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey FirstName => new ShellItemPropertyKey(new Guid("{14977844-6B49-4AAD-A714-A4513BF60460}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.FullName -- PKEY_Contact_FullName</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {635E9051-50A5-4BA2-B9DB-4ED056C77296}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey FullName => new ShellItemPropertyKey(new Guid("{635E9051-50A5-4BA2-B9DB-4ED056C77296}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.Gender -- PKEY_Contact_Gender</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {3C8CEE58-D4F0-4CF9-B756-4E5D24447BCD}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Gender => new ShellItemPropertyKey(new Guid("{3C8CEE58-D4F0-4CF9-B756-4E5D24447BCD}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.GenderValue -- PKEY_Contact_GenderValue</para>
            /// <para>Description:</para>
            /// <para>Type:     UInt16 -- VT_UI2</para>
            /// <para>FormatID: {3C8CEE58-D4F0-4CF9-B756-4E5D24447BCD}, 101</para>
            /// </summary>
            public static ShellItemPropertyKey GenderValue => new ShellItemPropertyKey(new Guid("{3C8CEE58-D4F0-4CF9-B756-4E5D24447BCD}"), 101);

            /// <summary>
            /// <para>Name:     System.Contact.Hobbies -- PKEY_Contact_Hobbies</para>
            /// <para>Description:</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: {5DC2253F-5E11-4ADF-9CFE-910DD01E3E70}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Hobbies => new ShellItemPropertyKey(new Guid("{5DC2253F-5E11-4ADF-9CFE-910DD01E3E70}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.HomeAddress -- PKEY_Contact_HomeAddress</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {98F98354-617A-46B8-8560-5B1B64BF1F89}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey HomeAddress => new ShellItemPropertyKey(new Guid("{98F98354-617A-46B8-8560-5B1B64BF1F89}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.HomeAddressCity -- PKEY_Contact_HomeAddressCity</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {176DC63C-2688-4E89-8143-A347800F25E9}, 65</para>
            /// </summary>
            public static ShellItemPropertyKey HomeAddressCity => new ShellItemPropertyKey(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 65);

            /// <summary>
            /// <para>Name:     System.Contact.HomeAddressCountry -- PKEY_Contact_HomeAddressCountry</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {08A65AA1-F4C9-43DD-9DDF-A33D8E7EAD85}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey HomeAddressCountry => new ShellItemPropertyKey(new Guid("{08A65AA1-F4C9-43DD-9DDF-A33D8E7EAD85}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.HomeAddressPostalCode -- PKEY_Contact_HomeAddressPostalCode</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {8AFCC170-8A46-4B53-9EEE-90BAE7151E62}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey HomeAddressPostalCode => new ShellItemPropertyKey(new Guid("{8AFCC170-8A46-4B53-9EEE-90BAE7151E62}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.HomeAddressPostOfficeBox -- PKEY_Contact_HomeAddressPostOfficeBox</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {7B9F6399-0A3F-4B12-89BD-4ADC51C918AF}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey HomeAddressPostOfficeBox => new ShellItemPropertyKey(new Guid("{7B9F6399-0A3F-4B12-89BD-4ADC51C918AF}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.HomeAddressState -- PKEY_Contact_HomeAddressState</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {C89A23D0-7D6D-4EB8-87D4-776A82D493E5}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey HomeAddressState => new ShellItemPropertyKey(new Guid("{C89A23D0-7D6D-4EB8-87D4-776A82D493E5}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.HomeAddressStreet -- PKEY_Contact_HomeAddressStreet</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {0ADEF160-DB3F-4308-9A21-06237B16FA2A}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey HomeAddressStreet => new ShellItemPropertyKey(new Guid("{0ADEF160-DB3F-4308-9A21-06237B16FA2A}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.HomeFaxNumber -- PKEY_Contact_HomeFaxNumber</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {660E04D6-81AB-4977-A09F-82313113AB26}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey HomeFaxNumber => new ShellItemPropertyKey(new Guid("{660E04D6-81AB-4977-A09F-82313113AB26}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.HomeTelephone -- PKEY_Contact_HomeTelephone</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {176DC63C-2688-4E89-8143-A347800F25E9}, 20</para>
            /// </summary>
            public static ShellItemPropertyKey HomeTelephone => new ShellItemPropertyKey(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 20);

            /// <summary>
            /// <para>Name:     System.Contact.IMAddress -- PKEY_Contact_IMAddress</para>
            /// <para>Description:</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: {D68DBD8A-3374-4B81-9972-3EC30682DB3D}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey IMAddress => new ShellItemPropertyKey(new Guid("{D68DBD8A-3374-4B81-9972-3EC30682DB3D}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.Initials -- PKEY_Contact_Initials</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {F3D8F40D-50CB-44A2-9718-40CB9119495D}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Initials => new ShellItemPropertyKey(new Guid("{F3D8F40D-50CB-44A2-9718-40CB9119495D}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.JobTitle -- PKEY_Contact_JobTitle</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {176DC63C-2688-4E89-8143-A347800F25E9}, 6</para>
            /// </summary>
            public static ShellItemPropertyKey JobTitle => new ShellItemPropertyKey(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 6);

            /// <summary>
            /// <para>Name:     System.Contact.Label -- PKEY_Contact_Label</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {97B0AD89-DF49-49CC-834E-660974FD755B}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Label => new ShellItemPropertyKey(new Guid("{97B0AD89-DF49-49CC-834E-660974FD755B}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.LastName -- PKEY_Contact_LastName</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {8F367200-C270-457C-B1D4-E07C5BCD90C7}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey LastName => new ShellItemPropertyKey(new Guid("{8F367200-C270-457C-B1D4-E07C5BCD90C7}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.MailingAddress -- PKEY_Contact_MailingAddress</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {C0AC206A-827E-4650-95AE-77E2BB74FCC9}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey MailingAddress => new ShellItemPropertyKey(new Guid("{C0AC206A-827E-4650-95AE-77E2BB74FCC9}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.MiddleName -- PKEY_Contact_MiddleName</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {176DC63C-2688-4E89-8143-A347800F25E9}, 71</para>
            /// </summary>
            public static ShellItemPropertyKey MiddleName => new ShellItemPropertyKey(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 71);

            /// <summary>
            /// <para>Name:     System.Contact.MobileTelephone -- PKEY_Contact_MobileTelephone</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {176DC63C-2688-4E89-8143-A347800F25E9}, 35</para>
            /// </summary>
            public static ShellItemPropertyKey MobileTelephone => new ShellItemPropertyKey(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 35);

            /// <summary>
            /// <para>Name:     System.Contact.NickName -- PKEY_Contact_NickName</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {176DC63C-2688-4E89-8143-A347800F25E9}, 74</para>
            /// </summary>
            public static ShellItemPropertyKey NickName => new ShellItemPropertyKey(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 74);

            /// <summary>
            /// <para>Name:     System.Contact.OfficeLocation -- PKEY_Contact_OfficeLocation</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {176DC63C-2688-4E89-8143-A347800F25E9}, 7</para>
            /// </summary>
            public static ShellItemPropertyKey OfficeLocation => new ShellItemPropertyKey(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 7);

            /// <summary>
            /// <para>Name:     System.Contact.OtherAddress -- PKEY_Contact_OtherAddress</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {508161FA-313B-43D5-83A1-C1ACCF68622C}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey OtherAddress => new ShellItemPropertyKey(new Guid("{508161FA-313B-43D5-83A1-C1ACCF68622C}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.OtherAddressCity -- PKEY_Contact_OtherAddressCity</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {6E682923-7F7B-4F0C-A337-CFCA296687BF}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey OtherAddressCity => new ShellItemPropertyKey(new Guid("{6E682923-7F7B-4F0C-A337-CFCA296687BF}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.OtherAddressCountry -- PKEY_Contact_OtherAddressCountry</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {8F167568-0AAE-4322-8ED9-6055B7B0E398}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey OtherAddressCountry => new ShellItemPropertyKey(new Guid("{8F167568-0AAE-4322-8ED9-6055B7B0E398}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.OtherAddressPostalCode -- PKEY_Contact_OtherAddressPostalCode</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {95C656C1-2ABF-4148-9ED3-9EC602E3B7CD}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey OtherAddressPostalCode => new ShellItemPropertyKey(new Guid("{95C656C1-2ABF-4148-9ED3-9EC602E3B7CD}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.OtherAddressPostOfficeBox -- PKEY_Contact_OtherAddressPostOfficeBox</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {8B26EA41-058F-43F6-AECC-4035681CE977}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey OtherAddressPostOfficeBox => new ShellItemPropertyKey(new Guid("{8B26EA41-058F-43F6-AECC-4035681CE977}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.OtherAddressState -- PKEY_Contact_OtherAddressState</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {71B377D6-E570-425F-A170-809FAE73E54E}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey OtherAddressState => new ShellItemPropertyKey(new Guid("{71B377D6-E570-425F-A170-809FAE73E54E}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.OtherAddressStreet -- PKEY_Contact_OtherAddressStreet</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {FF962609-B7D6-4999-862D-95180D529AEA}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey OtherAddressStreet => new ShellItemPropertyKey(new Guid("{FF962609-B7D6-4999-862D-95180D529AEA}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.PagerTelephone -- PKEY_Contact_PagerTelephone</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {D6304E01-F8F5-4F45-8B15-D024A6296789}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey PagerTelephone => new ShellItemPropertyKey(new Guid("{D6304E01-F8F5-4F45-8B15-D024A6296789}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.PersonalTitle -- PKEY_Contact_PersonalTitle</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {176DC63C-2688-4E89-8143-A347800F25E9}, 69</para>
            /// </summary>
            public static ShellItemPropertyKey PersonalTitle => new ShellItemPropertyKey(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 69);

            /// <summary>
            /// <para>Name:     System.Contact.PrimaryAddressCity -- PKEY_Contact_PrimaryAddressCity</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {C8EA94F0-A9E3-4969-A94B-9C62A95324E0}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey PrimaryAddressCity => new ShellItemPropertyKey(new Guid("{C8EA94F0-A9E3-4969-A94B-9C62A95324E0}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.PrimaryAddressCountry -- PKEY_Contact_PrimaryAddressCountry</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {E53D799D-0F3F-466E-B2FF-74634A3CB7A4}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey PrimaryAddressCountry => new ShellItemPropertyKey(new Guid("{E53D799D-0F3F-466E-B2FF-74634A3CB7A4}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.PrimaryAddressPostalCode -- PKEY_Contact_PrimaryAddressPostalCode</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {18BBD425-ECFD-46EF-B612-7B4A6034EDA0}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey PrimaryAddressPostalCode => new ShellItemPropertyKey(new Guid("{18BBD425-ECFD-46EF-B612-7B4A6034EDA0}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.PrimaryAddressPostOfficeBox -- PKEY_Contact_PrimaryAddressPostOfficeBox</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {DE5EF3C7-46E1-484E-9999-62C5308394C1}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey PrimaryAddressPostOfficeBox => new ShellItemPropertyKey(new Guid("{DE5EF3C7-46E1-484E-9999-62C5308394C1}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.PrimaryAddressState -- PKEY_Contact_PrimaryAddressState</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {F1176DFE-7138-4640-8B4C-AE375DC70A6D}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey PrimaryAddressState => new ShellItemPropertyKey(new Guid("{F1176DFE-7138-4640-8B4C-AE375DC70A6D}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.PrimaryAddressStreet -- PKEY_Contact_PrimaryAddressStreet</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {63C25B20-96BE-488F-8788-C09C407AD812}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey PrimaryAddressStreet => new ShellItemPropertyKey(new Guid("{63C25B20-96BE-488F-8788-C09C407AD812}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.PrimaryEmailAddress -- PKEY_Contact_PrimaryEmailAddress</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {176DC63C-2688-4E89-8143-A347800F25E9}, 48</para>
            /// </summary>
            public static ShellItemPropertyKey PrimaryEmailAddress => new ShellItemPropertyKey(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 48);

            /// <summary>
            /// <para>Name:     System.Contact.PrimaryTelephone -- PKEY_Contact_PrimaryTelephone</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {176DC63C-2688-4E89-8143-A347800F25E9}, 25</para>
            /// </summary>
            public static ShellItemPropertyKey PrimaryTelephone => new ShellItemPropertyKey(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 25);

            /// <summary>
            /// <para>Name:     System.Contact.Profession -- PKEY_Contact_Profession</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {7268AF55-1CE4-4F6E-A41F-B6E4EF10E4A9}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Profession => new ShellItemPropertyKey(new Guid("{7268AF55-1CE4-4F6E-A41F-B6E4EF10E4A9}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.SpouseName -- PKEY_Contact_SpouseName</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {9D2408B6-3167-422B-82B0-F583B7A7CFE3}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey SpouseName => new ShellItemPropertyKey(new Guid("{9D2408B6-3167-422B-82B0-F583B7A7CFE3}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.Suffix -- PKEY_Contact_Suffix</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {176DC63C-2688-4E89-8143-A347800F25E9}, 73</para>
            /// </summary>
            public static ShellItemPropertyKey Suffix => new ShellItemPropertyKey(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 73);

            /// <summary>
            /// <para>Name:     System.Contact.TelexNumber -- PKEY_Contact_TelexNumber</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {C554493C-C1F7-40C1-A76C-EF8C0614003E}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey TelexNumber => new ShellItemPropertyKey(new Guid("{C554493C-C1F7-40C1-A76C-EF8C0614003E}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.TTYTDDTelephone -- PKEY_Contact_TTYTDDTelephone</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {AAF16BAC-2B55-45E6-9F6D-415EB94910DF}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey TTYTDDTelephone => new ShellItemPropertyKey(new Guid("{AAF16BAC-2B55-45E6-9F6D-415EB94910DF}"), 100);

            /// <summary>
            /// <para>Name:     System.Contact.WebPage -- PKEY_Contact_WebPage</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 18</para>
            /// </summary>
            public static ShellItemPropertyKey WebPage => new ShellItemPropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 18);

            /// <summary>JA Properties</summary>
            public static class JA
            {
                /// <summary>
                /// <para>Name:     System.Contact.JA.CompanyNamePhonetic -- PKEY_Contact_JA_CompanyNamePhonetic</para>
                /// <para>Description:
                ///</para>
                /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
                /// <para>FormatID: {897B3694-FE9E-43E6-8066-260F590C0100}, 2</para>
                /// </summary>
                public static ShellItemPropertyKey CompanyNamePhonetic => new ShellItemPropertyKey(new Guid("{897B3694-FE9E-43E6-8066-260F590C0100}"), 2);

                /// <summary>
                /// <para>Name:     System.Contact.JA.FirstNamePhonetic -- PKEY_Contact_JA_FirstNamePhonetic</para>
                /// <para>Description:
                ///</para>
                /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
                /// <para>FormatID: {897B3694-FE9E-43E6-8066-260F590C0100}, 3</para>
                /// </summary>
                public static ShellItemPropertyKey FirstNamePhonetic => new ShellItemPropertyKey(new Guid("{897B3694-FE9E-43E6-8066-260F590C0100}"), 3);

                /// <summary>
                /// <para>Name:     System.Contact.JA.LastNamePhonetic -- PKEY_Contact_JA_LastNamePhonetic</para>
                /// <para>Description:
                ///</para>
                /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
                /// <para>FormatID: {897B3694-FE9E-43E6-8066-260F590C0100}, 4</para>
                /// </summary>
                public static ShellItemPropertyKey LastNamePhonetic => new ShellItemPropertyKey(new Guid("{897B3694-FE9E-43E6-8066-260F590C0100}"), 4);
            }
        }

        /// <summary>Device Properties</summary>
        public static class Device
        {
            /// <summary>
            /// <para>Name:     System.Device.PrinterURL -- PKEY_Device_PrinterURL</para>
            /// <para>Description: Printer information Printer URL.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {0B48F35A-BE6E-4F17-B108-3C4073D1669A}, 15</para>
            /// </summary>
            public static ShellItemPropertyKey PrinterURL => new ShellItemPropertyKey(new Guid("{0B48F35A-BE6E-4F17-B108-3C4073D1669A}"), 15);
        }

        /// <summary>DeviceInterface Properties</summary>
        public static class DeviceInterface
        {
            /// <summary>
            /// <para>Name:     System.DeviceInterface.PrinterDriverDirectory -- PKEY_DeviceInterface_PrinterDriverDirectory</para>
            /// <para>Description: Printer information Printer Driver Directory.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {847C66DE-B8D6-4AF9-ABC3-6F4F926BC039}, 14</para>
            /// </summary>
            public static ShellItemPropertyKey PrinterDriverDirectory => new ShellItemPropertyKey(new Guid("{847C66DE-B8D6-4AF9-ABC3-6F4F926BC039}"), 14);

            /// <summary>
            /// <para>Name:     System.DeviceInterface.PrinterDriverName -- PKEY_DeviceInterface_PrinterDriverName</para>
            /// <para>Description: Printer information Driver Name.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {AFC47070-14F5-498C-8F30-B0D19BE449C6}, 11</para>
            /// </summary>
            public static ShellItemPropertyKey PrinterDriverName => new ShellItemPropertyKey(new Guid("{AFC47070-14F5-498C-8F30-B0D19BE449C6}"), 11);

            /// <summary>
            /// <para>Name:     System.DeviceInterface.PrinterName -- PKEY_DeviceInterface_PrinterName</para>
            /// <para>Description: Printer information Printer Name.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {0A7B84EF-0C27-463F-84EF-06C5070001BE}, 10</para>
            /// </summary>
            public static ShellItemPropertyKey PrinterName => new ShellItemPropertyKey(new Guid("{0A7B84EF-0C27-463F-84EF-06C5070001BE}"), 10);

            /// <summary>
            /// <para>Name:     System.DeviceInterface.PrinterPortName -- PKEY_DeviceInterface_PrinterPortName</para>
            /// <para>Description: Printer information Port Name.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {EEC7B761-6F94-41B1-949F-C729720DD13C}, 12</para>
            /// </summary>
            public static ShellItemPropertyKey PrinterPortName => new ShellItemPropertyKey(new Guid("{EEC7B761-6F94-41B1-949F-C729720DD13C}"), 12);
        }

        /// <summary>Devices Properties</summary>
        public static class Devices
        {
            /// <summary>
            /// <para>Name:     System.Devices.BatteryLife -- PKEY_Devices_BatteryLife</para>
            /// <para>Description: Remaining battery life of the device as an integer between 0 and 100 percent.
            ///</para>
            /// <para>Type:     Byte -- VT_UI1</para>
            /// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 10</para>
            /// </summary>
            public static ShellItemPropertyKey BatteryLife => new ShellItemPropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 10);

            /// <summary>
            /// <para>Name:     System.Devices.BatteryPlusCharging -- PKEY_Devices_BatteryPlusCharging</para>
            /// <para>Description: Remaining battery life of the device as an integer between 0 and 100 percent and the device's charging state.
            ///</para>
            /// <para>Type:     Byte -- VT_UI1</para>
            /// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 22</para>
            /// </summary>
            public static ShellItemPropertyKey BatteryPlusCharging => new ShellItemPropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 22);

            /// <summary>
            /// <para>Name:     System.Devices.BatteryPlusChargingText -- PKEY_Devices_BatteryPlusChargingText</para>
            /// <para>Description: Remaining battery life of the device and the device's charging state as a string.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 23</para>
            /// </summary>
            public static ShellItemPropertyKey BatteryPlusChargingText => new ShellItemPropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 23);

            /// <summary>
            /// <para>Name:     System.Devices.Category -- PKEY_Devices_Category_Desc_Singular</para>
            /// <para>Description: Singular form of device category.
            ///</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: {78C34FC8-104A-4ACA-9EA4-524D52996E57}, 91</para>
            /// </summary>
            public static ShellItemPropertyKey Category => new ShellItemPropertyKey(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 91);

            /// <summary>
            /// <para>Name:     System.Devices.CategoryGroup -- PKEY_Devices_CategoryGroup_Desc</para>
            /// <para>Description: Plural form of device category.
            ///</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: {78C34FC8-104A-4ACA-9EA4-524D52996E57}, 94</para>
            /// </summary>
            public static ShellItemPropertyKey CategoryGroup => new ShellItemPropertyKey(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 94);

            /// <summary>
            /// <para>Name:     System.Devices.CategoryPlural -- PKEY_Devices_Category_Desc_Plural</para>
            /// <para>Description: Plural form of device category.
            ///</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: {78C34FC8-104A-4ACA-9EA4-524D52996E57}, 92</para>
            /// </summary>
            public static ShellItemPropertyKey CategoryPlural => new ShellItemPropertyKey(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 92);

            /// <summary>
            /// <para>Name:     System.Devices.ChargingState -- PKEY_Devices_ChargingState</para>
            /// <para>Description: Boolean value representing if the device is currently charging.
            ///</para>
            /// <para>Type:     Byte -- VT_UI1</para>
            /// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 11</para>
            /// </summary>
            public static ShellItemPropertyKey ChargingState => new ShellItemPropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 11);

            /// <summary>
            /// <para>Name:     System.Devices.Connected -- PKEY_Devices_IsConnected</para>
            /// <para>Description: Device connection state. If VARIANT_TRUE, indicates the device is currently connected to the computer.
            ///</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {78C34FC8-104A-4ACA-9EA4-524D52996E57}, 55</para>
            /// </summary>
            public static ShellItemPropertyKey Connected => new ShellItemPropertyKey(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 55);

            /// <summary>
            /// <para>Name:     System.Devices.ContainerId -- PKEY_Devices_ContainerId</para>
            /// <para>Description: Device container ID.
            ///</para>
            /// <para>Type:     Guid -- VT_CLSID</para>
            /// <para>FormatID: {8C7ED206-3F8A-4827-B3AB-AE9E1FAEFC6C}, 2</para>
            /// </summary>
            public static ShellItemPropertyKey ContainerId => new ShellItemPropertyKey(new Guid("{8C7ED206-3F8A-4827-B3AB-AE9E1FAEFC6C}"), 2);

            /// <summary>
            /// <para>Name:     System.Devices.DefaultTooltip -- PKEY_Devices_DefaultTooltip</para>
            /// <para>Description: Tooltip for default state
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {880F70A2-6082-47AC-8AAB-A739D1A300C3}, 153</para>
            /// </summary>
            public static ShellItemPropertyKey DefaultTooltip => new ShellItemPropertyKey(new Guid("{880F70A2-6082-47AC-8AAB-A739D1A300C3}"), 153);

            /// <summary>
            /// <para>Name:     System.Devices.DeviceDescription1 -- PKEY_Devices_DeviceDescription1</para>
            /// <para>Description: First line of descriptive text about the device.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {78C34FC8-104A-4ACA-9EA4-524D52996E57}, 81</para>
            /// </summary>
            public static ShellItemPropertyKey DeviceDescription1 => new ShellItemPropertyKey(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 81);

            /// <summary>
            /// <para>Name:     System.Devices.DeviceDescription2 -- PKEY_Devices_DeviceDescription2</para>
            /// <para>Description: Second line of descriptive text about the device.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {78C34FC8-104A-4ACA-9EA4-524D52996E57}, 82</para>
            /// </summary>
            public static ShellItemPropertyKey DeviceDescription2 => new ShellItemPropertyKey(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 82);

            /// <summary>
            /// <para>Name:     System.Devices.DiscoveryMethod -- PKEY_Devices_DiscoveryMethod</para>
            /// <para>Description: Device discovery method. This indicates on what transport or physical connection the device is discovered.
            ///</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: {78C34FC8-104A-4ACA-9EA4-524D52996E57}, 52</para>
            /// </summary>
            public static ShellItemPropertyKey DiscoveryMethod => new ShellItemPropertyKey(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 52);

            /// <summary>
            /// <para>Name:     System.Devices.FriendlyName -- PKEY_Devices_FriendlyName</para>
            /// <para>Description: Device friendly name.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {656A3BB3-ECC0-43FD-8477-4AE0404A96CD}, 12288</para>
            /// </summary>
            public static ShellItemPropertyKey FriendlyName => new ShellItemPropertyKey(new Guid("{656A3BB3-ECC0-43FD-8477-4AE0404A96CD}"), 12288);

            /// <summary>
            /// <para>Name:     System.Devices.FunctionPaths -- PKEY_Devices_FunctionPaths</para>
            /// <para>Description: Available functions for this device.
            ///</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: {D08DD4C0-3A9E-462E-8290-7B636B2576B9}, 3</para>
            /// </summary>
            public static ShellItemPropertyKey FunctionPaths => new ShellItemPropertyKey(new Guid("{D08DD4C0-3A9E-462E-8290-7B636B2576B9}"), 3);

            /// <summary>
            /// <para>Name:     System.Devices.InterfacePaths -- PKEY_Devices_InterfacePaths</para>
            /// <para>Description: Available interfaces for this device.
            ///</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: {D08DD4C0-3A9E-462E-8290-7B636B2576B9}, 2</para>
            /// </summary>
            public static ShellItemPropertyKey InterfacePaths => new ShellItemPropertyKey(new Guid("{D08DD4C0-3A9E-462E-8290-7B636B2576B9}"), 2);

            /// <summary>
            /// <para>Name:     System.Devices.IsDefault -- PKEY_Devices_IsDefaultDevice</para>
            /// <para>Description: If VARIANT_TRUE, the device is not working properly.
            ///</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {78C34FC8-104A-4ACA-9EA4-524D52996E57}, 86</para>
            /// </summary>
            public static ShellItemPropertyKey IsDefault => new ShellItemPropertyKey(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 86);

            /// <summary>
            /// <para>Name:     System.Devices.IsNetworkConnected -- PKEY_Devices_IsNetworkDevice</para>
            /// <para>Description: If VARIANT_TRUE, the device is not working properly.
            ///</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {78C34FC8-104A-4ACA-9EA4-524D52996E57}, 85</para>
            /// </summary>
            public static ShellItemPropertyKey IsNetworkConnected => new ShellItemPropertyKey(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 85);

            /// <summary>
            /// <para>Name:     System.Devices.IsShared -- PKEY_Devices_IsSharedDevice</para>
            /// <para>Description: If VARIANT_TRUE, the device is not working properly.
            ///</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {78C34FC8-104A-4ACA-9EA4-524D52996E57}, 84</para>
            /// </summary>
            public static ShellItemPropertyKey IsShared => new ShellItemPropertyKey(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 84);

            /// <summary>
            /// <para>Name:     System.Devices.IsSoftwareInstalling -- PKEY_Devices_IsSoftwareInstalling</para>
            /// <para>Description: If VARIANT_TRUE, the device installer is currently installing software.
            ///</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {83DA6326-97A6-4088-9453-A1923F573B29}, 9</para>
            /// </summary>
            public static ShellItemPropertyKey IsSoftwareInstalling => new ShellItemPropertyKey(new Guid("{83DA6326-97A6-4088-9453-A1923F573B29}"), 9);

            /// <summary>
            /// <para>Name:     System.Devices.LaunchDeviceStageFromExplorer -- PKEY_Devices_LaunchDeviceStageFromExplorer</para>
            /// <para>Description: Indicates whether to launch Device Stage or not
            ///</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {78C34FC8-104A-4ACA-9EA4-524D52996E57}, 77</para>
            /// </summary>
            public static ShellItemPropertyKey LaunchDeviceStageFromExplorer => new ShellItemPropertyKey(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 77);

            /// <summary>
            /// <para>Name:     System.Devices.LocalMachine -- PKEY_Devices_IsLocalMachine</para>
            /// <para>Description: If VARIANT_TRUE, the device in question is actually the computer.
            ///</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {78C34FC8-104A-4ACA-9EA4-524D52996E57}, 70</para>
            /// </summary>
            public static ShellItemPropertyKey LocalMachine => new ShellItemPropertyKey(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 70);

            /// <summary>
            /// <para>Name:     System.Devices.Manufacturer -- PKEY_Devices_Manufacturer</para>
            /// <para>Description: Device manufacturer.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {656A3BB3-ECC0-43FD-8477-4AE0404A96CD}, 8192</para>
            /// </summary>
            public static ShellItemPropertyKey Manufacturer => new ShellItemPropertyKey(new Guid("{656A3BB3-ECC0-43FD-8477-4AE0404A96CD}"), 8192);

            /// <summary>
            /// <para>Name:     System.Devices.MissedCalls -- PKEY_Devices_MissedCalls</para>
            /// <para>Description: Number of missed calls on the device.
            ///</para>
            /// <para>Type:     Byte -- VT_UI1</para>
            /// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 5</para>
            /// </summary>
            public static ShellItemPropertyKey MissedCalls => new ShellItemPropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 5);

            /// <summary>
            /// <para>Name:     System.Devices.ModelName -- PKEY_Devices_ModelName</para>
            /// <para>Description: Model name of the device.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {656A3BB3-ECC0-43FD-8477-4AE0404A96CD}, 8194</para>
            /// </summary>
            public static ShellItemPropertyKey ModelName => new ShellItemPropertyKey(new Guid("{656A3BB3-ECC0-43FD-8477-4AE0404A96CD}"), 8194);

            /// <summary>
            /// <para>Name:     System.Devices.ModelNumber -- PKEY_Devices_ModelNumber</para>
            /// <para>Description: Model number of the device.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {656A3BB3-ECC0-43FD-8477-4AE0404A96CD}, 8195</para>
            /// </summary>
            public static ShellItemPropertyKey ModelNumber => new ShellItemPropertyKey(new Guid("{656A3BB3-ECC0-43FD-8477-4AE0404A96CD}"), 8195);

            /// <summary>
            /// <para>Name:     System.Devices.NetworkedTooltip -- PKEY_Devices_NetworkedTooltip</para>
            /// <para>Description: Tooltip for connection state
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {880F70A2-6082-47AC-8AAB-A739D1A300C3}, 152</para>
            /// </summary>
            public static ShellItemPropertyKey NetworkedTooltip => new ShellItemPropertyKey(new Guid("{880F70A2-6082-47AC-8AAB-A739D1A300C3}"), 152);

            /// <summary>
            /// <para>Name:     System.Devices.NetworkName -- PKEY_Devices_NetworkName</para>
            /// <para>Description: Name of the device's network.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 7</para>
            /// </summary>
            public static ShellItemPropertyKey NetworkName => new ShellItemPropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 7);

            /// <summary>
            /// <para>Name:     System.Devices.NetworkType -- PKEY_Devices_NetworkType</para>
            /// <para>Description: String representing the type of the device's network.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 8</para>
            /// </summary>
            public static ShellItemPropertyKey NetworkType => new ShellItemPropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 8);

            /// <summary>
            /// <para>Name:     System.Devices.NewPictures -- PKEY_Devices_NewPictures</para>
            /// <para>Description: Number of new pictures on the device.
            ///</para>
            /// <para>Type:     UInt16 -- VT_UI2</para>
            /// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 4</para>
            /// </summary>
            public static ShellItemPropertyKey NewPictures => new ShellItemPropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 4);

            /// <summary>
            /// <para>Name:     System.Devices.Notification -- PKEY_Devices_Notification</para>
            /// <para>Description: Device Notification Property.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {06704B0C-E830-4C81-9178-91E4E95A80A0}, 3</para>
            /// </summary>
            public static ShellItemPropertyKey Notification => new ShellItemPropertyKey(new Guid("{06704B0C-E830-4C81-9178-91E4E95A80A0}"), 3);

            /// <summary>
            /// <para>Name:     System.Devices.NotificationStore -- PKEY_Devices_NotificationStore</para>
            /// <para>Description: Device Notification Store.
            ///</para>
            /// <para>Type:     Object -- VT_UNKNOWN</para>
            /// <para>FormatID: {06704B0C-E830-4C81-9178-91E4E95A80A0}, 2</para>
            /// </summary>
            public static ShellItemPropertyKey NotificationStore => new ShellItemPropertyKey(new Guid("{06704B0C-E830-4C81-9178-91E4E95A80A0}"), 2);

            /// <summary>
            /// <para>Name:     System.Devices.NotWorkingProperly -- PKEY_Devices_IsNotWorkingProperly</para>
            /// <para>Description: If VARIANT_TRUE, the device is not working properly.
            ///</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {78C34FC8-104A-4ACA-9EA4-524D52996E57}, 83</para>
            /// </summary>
            public static ShellItemPropertyKey NotWorkingProperly => new ShellItemPropertyKey(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 83);

            /// <summary>
            /// <para>Name:     System.Devices.Paired -- PKEY_Devices_IsPaired</para>
            /// <para>Description: Device paired state. If VARIANT_TRUE, indicates the device is not paired with the computer.
            ///</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {78C34FC8-104A-4ACA-9EA4-524D52996E57}, 56</para>
            /// </summary>
            public static ShellItemPropertyKey Paired => new ShellItemPropertyKey(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 56);

            /// <summary>
            /// <para>Name:     System.Devices.PrimaryCategory -- PKEY_Devices_PrimaryCategory</para>
            /// <para>Description: Primary category group for this device.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {D08DD4C0-3A9E-462E-8290-7B636B2576B9}, 10</para>
            /// </summary>
            public static ShellItemPropertyKey PrimaryCategory => new ShellItemPropertyKey(new Guid("{D08DD4C0-3A9E-462E-8290-7B636B2576B9}"), 10);

            /// <summary>
            /// <para>Name:     System.Devices.Roaming -- PKEY_Devices_Roaming</para>
            /// <para>Description: Status indicator used to indicate if the device is roaming.
            ///</para>
            /// <para>Type:     Byte -- VT_UI1</para>
            /// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 9</para>
            /// </summary>
            public static ShellItemPropertyKey Roaming => new ShellItemPropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 9);

            /// <summary>
            /// <para>Name:     System.Devices.SafeRemovalRequired -- PKEY_Devices_SafeRemovalRequired</para>
            /// <para>Description: Indicates if a device requires safe removal or not
            ///</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {AFD97640-86A3-4210-B67C-289C41AABE55}, 2</para>
            /// </summary>
            public static ShellItemPropertyKey SafeRemovalRequired => new ShellItemPropertyKey(new Guid("{AFD97640-86A3-4210-B67C-289C41AABE55}"), 2);

            /// <summary>
            /// <para>Name:     System.Devices.SharedTooltip -- PKEY_Devices_SharedTooltip</para>
            /// <para>Description: Tooltip for sharing state
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {880F70A2-6082-47AC-8AAB-A739D1A300C3}, 151</para>
            /// </summary>
            public static ShellItemPropertyKey SharedTooltip => new ShellItemPropertyKey(new Guid("{880F70A2-6082-47AC-8AAB-A739D1A300C3}"), 151);

            /// <summary>
            /// <para>Name:     System.Devices.SignalStrength -- PKEY_Devices_SignalStrength</para>
            /// <para>Description: Device signal strength.
            ///</para>
            /// <para>Type:     Byte -- VT_UI1</para>
            /// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 2</para>
            /// </summary>
            public static ShellItemPropertyKey SignalStrength => new ShellItemPropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 2);

            /// <summary>
            /// <para>Name:     System.Devices.Status1 -- PKEY_Devices_Status1</para>
            /// <para>Description: 1st line of device status.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {D08DD4C0-3A9E-462E-8290-7B636B2576B9}, 257</para>
            /// </summary>
            public static ShellItemPropertyKey Status1 => new ShellItemPropertyKey(new Guid("{D08DD4C0-3A9E-462E-8290-7B636B2576B9}"), 257);

            /// <summary>
            /// <para>Name:     System.Devices.Status2 -- PKEY_Devices_Status2</para>
            /// <para>Description: 2nd line of device status.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {D08DD4C0-3A9E-462E-8290-7B636B2576B9}, 258</para>
            /// </summary>
            public static ShellItemPropertyKey Status2 => new ShellItemPropertyKey(new Guid("{D08DD4C0-3A9E-462E-8290-7B636B2576B9}"), 258);

            /// <summary>
            /// <para>Name:     System.Devices.StorageCapacity -- PKEY_Devices_StorageCapacity</para>
            /// <para>Description: Total storage capacity of the device.
            ///</para>
            /// <para>Type:     UInt64 -- VT_UI8</para>
            /// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 12</para>
            /// </summary>
            public static ShellItemPropertyKey StorageCapacity => new ShellItemPropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 12);

            /// <summary>
            /// <para>Name:     System.Devices.StorageFreeSpace -- PKEY_Devices_StorageFreeSpace</para>
            /// <para>Description: Total free space of the storage of the device.
            ///</para>
            /// <para>Type:     UInt64 -- VT_UI8</para>
            /// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 13</para>
            /// </summary>
            public static ShellItemPropertyKey StorageFreeSpace => new ShellItemPropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 13);

            /// <summary>
            /// <para>Name:     System.Devices.StorageFreeSpacePercent -- PKEY_Devices_StorageFreeSpacePercent</para>
            /// <para>Description: Total free space of the storage of the device as a percentage.
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 14</para>
            /// </summary>
            public static ShellItemPropertyKey StorageFreeSpacePercent => new ShellItemPropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 14);

            /// <summary>
            /// <para>Name:     System.Devices.TextMessages -- PKEY_Devices_TextMessages</para>
            /// <para>Description: Number of unread text messages on the device.
            ///</para>
            /// <para>Type:     Byte -- VT_UI1</para>
            /// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 3</para>
            /// </summary>
            public static ShellItemPropertyKey TextMessages => new ShellItemPropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 3);

            /// <summary>
            /// <para>Name:     System.Devices.Voicemail -- PKEY_Devices_Voicemail</para>
            /// <para>Description: Status indicator used to indicate if the device has voicemail.
            ///</para>
            /// <para>Type:     Byte -- VT_UI1</para>
            /// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 6</para>
            /// </summary>
            public static ShellItemPropertyKey Voicemail => new ShellItemPropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 6);

            /// <summary>Notifications Properties</summary>
            public static class Notifications
            {
                /// <summary>
                /// <para>Name:     System.Devices.Notifications.LowBattery -- PKEY_Devices_Notification_LowBattery</para>
                /// <para>Description: Device Low Battery Notification.
                ///</para>
                /// <para>Type:     Byte -- VT_UI1</para>
                /// <para>FormatID: {C4C07F2B-8524-4E66-AE3A-A6235F103BEB}, 2</para>
                /// </summary>
                public static ShellItemPropertyKey LowBattery => new ShellItemPropertyKey(new Guid("{C4C07F2B-8524-4E66-AE3A-A6235F103BEB}"), 2);

                /// <summary>
                /// <para>Name:     System.Devices.Notifications.MissedCall -- PKEY_Devices_Notification_MissedCall</para>
                /// <para>Description: Device Missed Call Notification.
                ///</para>
                /// <para>Type:     Byte -- VT_UI1</para>
                /// <para>FormatID: {6614EF48-4EFE-4424-9EDA-C79F404EDF3E}, 2</para>
                /// </summary>
                public static ShellItemPropertyKey MissedCall => new ShellItemPropertyKey(new Guid("{6614EF48-4EFE-4424-9EDA-C79F404EDF3E}"), 2);

                /// <summary>
                /// <para>Name:     System.Devices.Notifications.NewMessage -- PKEY_Devices_Notification_NewMessage</para>
                /// <para>Description: Device New Message Notification.
                ///</para>
                /// <para>Type:     Byte -- VT_UI1</para>
                /// <para>FormatID: {2BE9260A-2012-4742-A555-F41B638B7DCB}, 2</para>
                /// </summary>
                public static ShellItemPropertyKey NewMessage => new ShellItemPropertyKey(new Guid("{2BE9260A-2012-4742-A555-F41B638B7DCB}"), 2);

                /// <summary>
                /// <para>Name:     System.Devices.Notifications.NewVoicemail -- PKEY_Devices_Notification_NewVoicemail</para>
                /// <para>Description: Device Voicemail Notification.
                ///</para>
                /// <para>Type:     Byte -- VT_UI1</para>
                /// <para>FormatID: {59569556-0A08-4212-95B9-FAE2AD6413DB}, 2</para>
                /// </summary>
                public static ShellItemPropertyKey NewVoicemail => new ShellItemPropertyKey(new Guid("{59569556-0A08-4212-95B9-FAE2AD6413DB}"), 2);

                /// <summary>
                /// <para>Name:     System.Devices.Notifications.StorageFull -- PKEY_Devices_Notification_StorageFull</para>
                /// <para>Description: Device Storage Full Notification.
                ///</para>
                /// <para>Type:     UInt64 -- VT_UI8</para>
                /// <para>FormatID: {A0E00EE1-F0C7-4D41-B8E7-26A7BD8D38B0}, 2</para>
                /// </summary>
                public static ShellItemPropertyKey StorageFull => new ShellItemPropertyKey(new Guid("{A0E00EE1-F0C7-4D41-B8E7-26A7BD8D38B0}"), 2);

                /// <summary>
                /// <para>Name:     System.Devices.Notifications.StorageFullLinkText -- PKEY_Devices_Notification_StorageFullLinkText</para>
                /// <para>Description: Link Text for the Device Storage Full Notification.
                ///</para>
                /// <para>Type:     UInt64 -- VT_UI8</para>
                /// <para>FormatID: {A0E00EE1-F0C7-4D41-B8E7-26A7BD8D38B0}, 3</para>
                /// </summary>
                public static ShellItemPropertyKey StorageFullLinkText => new ShellItemPropertyKey(new Guid("{A0E00EE1-F0C7-4D41-B8E7-26A7BD8D38B0}"), 3);
            }
        }

        /// <summary>Document Properties</summary>
        public static class Document
        {
            /// <summary>
            /// <para>Name:     System.Document.ByteCount -- PKEY_Document_ByteCount</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     Int32 -- VT_I4</para>
            /// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 4 (PIDDSI_BYTECOUNT)</para>
            /// </summary>
            public static ShellItemPropertyKey ByteCount => new ShellItemPropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 4);

            /// <summary>
            /// <para>Name:     System.Document.CharacterCount -- PKEY_Document_CharacterCount</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     Int32 -- VT_I4</para>
            /// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 16 (PIDSI_CHARCOUNT)</para>
            /// </summary>
            public static ShellItemPropertyKey CharacterCount => new ShellItemPropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 16);

            /// <summary>
            /// <para>Name:     System.Document.ClientID -- PKEY_Document_ClientID</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {276D7BB0-5B34-4FB0-AA4B-158ED12A1809}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ClientID => new ShellItemPropertyKey(new Guid("{276D7BB0-5B34-4FB0-AA4B-158ED12A1809}"), 100);

            /// <summary>
            /// <para>Name:     System.Document.Contributor -- PKEY_Document_Contributor</para>
            /// <para>Description:</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: {F334115E-DA1B-4509-9B3D-119504DC7ABB}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Contributor => new ShellItemPropertyKey(new Guid("{F334115E-DA1B-4509-9B3D-119504DC7ABB}"), 100);

            /// <summary>
            /// <para>Name:     System.Document.DateCreated -- PKEY_Document_DateCreated</para>
            /// <para>Description: This property is stored in the document, not obtained from the file system.
            ///</para>
            /// <para>Type:     DateTime -- VT_FILETIME  (For variants: VT_DATE)</para>
            /// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 12 (PIDSI_CREATE_DTM)</para>
            /// </summary>
            public static ShellItemPropertyKey DateCreated => new ShellItemPropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 12);

            /// <summary>
            /// <para>Name:     System.Document.DatePrinted -- PKEY_Document_DatePrinted</para>
            /// <para>Description: Legacy name: "DocLastPrinted".
            ///</para>
            /// <para>Type:     DateTime -- VT_FILETIME  (For variants: VT_DATE)</para>
            /// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 11 (PIDSI_LASTPRINTED)</para>
            /// </summary>
            public static ShellItemPropertyKey DatePrinted => new ShellItemPropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 11);

            /// <summary>
            /// <para>Name:     System.Document.DateSaved -- PKEY_Document_DateSaved</para>
            /// <para>Description: Legacy name: "DocLastSavedTm".
            ///</para>
            /// <para>Type:     DateTime -- VT_FILETIME  (For variants: VT_DATE)</para>
            /// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 13 (PIDSI_LASTSAVE_DTM)</para>
            /// </summary>
            public static ShellItemPropertyKey DateSaved => new ShellItemPropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 13);

            /// <summary>
            /// <para>Name:     System.Document.Division -- PKEY_Document_Division</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {1E005EE6-BF27-428B-B01C-79676ACD2870}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Division => new ShellItemPropertyKey(new Guid("{1E005EE6-BF27-428B-B01C-79676ACD2870}"), 100);

            /// <summary>
            /// <para>Name:     System.Document.DocumentID -- PKEY_Document_DocumentID</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {E08805C8-E395-40DF-80D2-54F0D6C43154}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey DocumentID => new ShellItemPropertyKey(new Guid("{E08805C8-E395-40DF-80D2-54F0D6C43154}"), 100);

            /// <summary>
            /// <para>Name:     System.Document.HiddenSlideCount -- PKEY_Document_HiddenSlideCount</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     Int32 -- VT_I4</para>
            /// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 9 (PIDDSI_HIDDENCOUNT)</para>
            /// </summary>
            public static ShellItemPropertyKey HiddenSlideCount => new ShellItemPropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 9);

            /// <summary>
            /// <para>Name:     System.Document.LastAuthor -- PKEY_Document_LastAuthor</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 8 (PIDSI_LASTAUTHOR)</para>
            /// </summary>
            public static ShellItemPropertyKey LastAuthor => new ShellItemPropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 8);

            /// <summary>
            /// <para>Name:     System.Document.LineCount -- PKEY_Document_LineCount</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     Int32 -- VT_I4</para>
            /// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 5 (PIDDSI_LINECOUNT)</para>
            /// </summary>
            public static ShellItemPropertyKey LineCount => new ShellItemPropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 5);

            /// <summary>
            /// <para>Name:     System.Document.Manager -- PKEY_Document_Manager</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 14 (PIDDSI_MANAGER)</para>
            /// </summary>
            public static ShellItemPropertyKey Manager => new ShellItemPropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 14);

            /// <summary>
            /// <para>Name:     System.Document.MultimediaClipCount -- PKEY_Document_MultimediaClipCount</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     Int32 -- VT_I4</para>
            /// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 10 (PIDDSI_MMCLIPCOUNT)</para>
            /// </summary>
            public static ShellItemPropertyKey MultimediaClipCount => new ShellItemPropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 10);

            /// <summary>
            /// <para>Name:     System.Document.NoteCount -- PKEY_Document_NoteCount</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     Int32 -- VT_I4</para>
            /// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 8 (PIDDSI_NOTECOUNT)</para>
            /// </summary>
            public static ShellItemPropertyKey NoteCount => new ShellItemPropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 8);

            /// <summary>
            /// <para>Name:     System.Document.PageCount -- PKEY_Document_PageCount</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     Int32 -- VT_I4</para>
            /// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 14 (PIDSI_PAGECOUNT)</para>
            /// </summary>
            public static ShellItemPropertyKey PageCount => new ShellItemPropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 14);

            /// <summary>
            /// <para>Name:     System.Document.ParagraphCount -- PKEY_Document_ParagraphCount</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     Int32 -- VT_I4</para>
            /// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 6 (PIDDSI_PARCOUNT)</para>
            /// </summary>
            public static ShellItemPropertyKey ParagraphCount => new ShellItemPropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 6);

            /// <summary>
            /// <para>Name:     System.Document.PresentationFormat -- PKEY_Document_PresentationFormat</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 3 (PIDDSI_PRESFORMAT)</para>
            /// </summary>
            public static ShellItemPropertyKey PresentationFormat => new ShellItemPropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 3);

            /// <summary>
            /// <para>Name:     System.Document.RevisionNumber -- PKEY_Document_RevisionNumber</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 9 (PIDSI_REVNUMBER)</para>
            /// </summary>
            public static ShellItemPropertyKey RevisionNumber => new ShellItemPropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 9);

            /// <summary>
            /// <para>Name:     System.Document.Security -- PKEY_Document_Security</para>
            /// <para>Description: Access control information, from SummaryInfo propset
            ///</para>
            /// <para>Type:     Int32 -- VT_I4</para>
            /// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 19</para>
            /// </summary>
            public static ShellItemPropertyKey Security => new ShellItemPropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 19);

            /// <summary>
            /// <para>Name:     System.Document.SlideCount -- PKEY_Document_SlideCount</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     Int32 -- VT_I4</para>
            /// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 7 (PIDDSI_SLIDECOUNT)</para>
            /// </summary>
            public static ShellItemPropertyKey SlideCount => new ShellItemPropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 7);

            /// <summary>
            /// <para>Name:     System.Document.Template -- PKEY_Document_Template</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 7 (PIDSI_TEMPLATE)</para>
            /// </summary>
            public static ShellItemPropertyKey Template => new ShellItemPropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 7);

            /// <summary>
            /// <para>Name:     System.Document.TotalEditingTime -- PKEY_Document_TotalEditingTime</para>
            /// <para>Description: 100ns units, not milliseconds. VT_FILETIME for IPropertySetStorage handlers (legacy)
            ///</para>
            /// <para>Type:     UInt64 -- VT_UI8</para>
            /// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 10 (PIDSI_EDITTIME)</para>
            /// </summary>
            public static ShellItemPropertyKey TotalEditingTime => new ShellItemPropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 10);

            /// <summary>
            /// <para>Name:     System.Document.Version -- PKEY_Document_Version</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 29</para>
            /// </summary>
            public static ShellItemPropertyKey Version => new ShellItemPropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 29);

            /// <summary>
            /// <para>Name:     System.Document.WordCount -- PKEY_Document_WordCount</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     Int32 -- VT_I4</para>
            /// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 15 (PIDSI_WORDCOUNT)</para>
            /// </summary>
            public static ShellItemPropertyKey WordCount => new ShellItemPropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 15);
        }

        /// <summary>DRM Properties</summary>
        public static class DRM
        {
            /// <summary>
            /// <para>Name:     System.DRM.DatePlayExpires -- PKEY_DRM_DatePlayExpires</para>
            /// <para>Description: Indicates when play expires for digital rights management.
            ///</para>
            /// <para>Type:     DateTime -- VT_FILETIME  (For variants: VT_DATE)</para>
            /// <para>FormatID: (FMTID_DRM) {AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED}, 6 (PIDDRSI_PLAYEXPIRES)</para>
            /// </summary>
            public static ShellItemPropertyKey DatePlayExpires => new ShellItemPropertyKey(new Guid("{AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED}"), 6);

            /// <summary>
            /// <para>Name:     System.DRM.DatePlayStarts -- PKEY_DRM_DatePlayStarts</para>
            /// <para>Description: Indicates when play starts for digital rights management.
            ///</para>
            /// <para>Type:     DateTime -- VT_FILETIME  (For variants: VT_DATE)</para>
            /// <para>FormatID: (FMTID_DRM) {AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED}, 5 (PIDDRSI_PLAYSTARTS)</para>
            /// </summary>
            public static ShellItemPropertyKey DatePlayStarts => new ShellItemPropertyKey(new Guid("{AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED}"), 5);

            /// <summary>
            /// <para>Name:     System.DRM.Description -- PKEY_DRM_Description</para>
            /// <para>Description: Displays the description for digital rights management.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (FMTID_DRM) {AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED}, 3 (PIDDRSI_DESCRIPTION)</para>
            /// </summary>
            public static ShellItemPropertyKey Description => new ShellItemPropertyKey(new Guid("{AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED}"), 3);

            /// <summary>
            /// <para>Name:     System.DRM.IsProtected -- PKEY_DRM_IsProtected</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: (FMTID_DRM) {AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED}, 2 (PIDDRSI_PROTECTED)</para>
            /// </summary>
            public static ShellItemPropertyKey IsProtected => new ShellItemPropertyKey(new Guid("{AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED}"), 2);

            /// <summary>
            /// <para>Name:     System.DRM.PlayCount -- PKEY_DRM_PlayCount</para>
            /// <para>Description: Indicates the play count for digital rights management.
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: (FMTID_DRM) {AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED}, 4 (PIDDRSI_PLAYCOUNT)</para>
            /// </summary>
            public static ShellItemPropertyKey PlayCount => new ShellItemPropertyKey(new Guid("{AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED}"), 4);
        }

        /// <summary>GPS Properties</summary>
        public static class GPS
        {
            /// <summary>
            /// <para>Name:     System.GPS.Altitude -- PKEY_GPS_Altitude</para>
            /// <para>Description: Indicates the altitude based on the reference in PKEY_GPS_AltitudeRef.  Calculated from PKEY_GPS_AltitudeNumerator and
            ///PKEY_GPS_AltitudeDenominator
            ///</para>
            /// <para>Type:     Double -- VT_R8</para>
            /// <para>FormatID: {827EDB4F-5B73-44A7-891D-FDFFABEA35CA}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Altitude => new ShellItemPropertyKey(new Guid("{827EDB4F-5B73-44A7-891D-FDFFABEA35CA}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.AltitudeDenominator -- PKEY_GPS_AltitudeDenominator</para>
            /// <para>Description: Denominator of PKEY_GPS_Altitude
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {78342DCB-E358-4145-AE9A-6BFE4E0F9F51}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey AltitudeDenominator => new ShellItemPropertyKey(new Guid("{78342DCB-E358-4145-AE9A-6BFE4E0F9F51}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.AltitudeNumerator -- PKEY_GPS_AltitudeNumerator</para>
            /// <para>Description: Numerator of PKEY_GPS_Altitude
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {2DAD1EB7-816D-40D3-9EC3-C9773BE2AADE}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey AltitudeNumerator => new ShellItemPropertyKey(new Guid("{2DAD1EB7-816D-40D3-9EC3-C9773BE2AADE}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.AltitudeRef -- PKEY_GPS_AltitudeRef</para>
            /// <para>Description: Indicates the reference for the altitude property. (eg: above sea level, below sea level, absolute value)
            ///</para>
            /// <para>Type:     Byte -- VT_UI1</para>
            /// <para>FormatID: {46AC629D-75EA-4515-867F-6DC4321C5844}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey AltitudeRef => new ShellItemPropertyKey(new Guid("{46AC629D-75EA-4515-867F-6DC4321C5844}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.AreaInformation -- PKEY_GPS_AreaInformation</para>
            /// <para>Description: Represents the name of the GPS area
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {972E333E-AC7E-49F1-8ADF-A70D07A9BCAB}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey AreaInformation => new ShellItemPropertyKey(new Guid("{972E333E-AC7E-49F1-8ADF-A70D07A9BCAB}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.Date -- PKEY_GPS_Date</para>
            /// <para>Description: Date and time of the GPS record
            ///</para>
            /// <para>Type:     DateTime -- VT_FILETIME  (For variants: VT_DATE)</para>
            /// <para>FormatID: {3602C812-0F3B-45F0-85AD-603468D69423}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Date => new ShellItemPropertyKey(new Guid("{3602C812-0F3B-45F0-85AD-603468D69423}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.DestBearing -- PKEY_GPS_DestBearing</para>
            /// <para>Description: Indicates the bearing to the destination point.  Calculated from PKEY_GPS_DestBearingNumerator and
            ///PKEY_GPS_DestBearingDenominator.
            ///</para>
            /// <para>Type:     Double -- VT_R8</para>
            /// <para>FormatID: {C66D4B3C-E888-47CC-B99F-9DCA3EE34DEA}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey DestBearing => new ShellItemPropertyKey(new Guid("{C66D4B3C-E888-47CC-B99F-9DCA3EE34DEA}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.DestBearingDenominator -- PKEY_GPS_DestBearingDenominator</para>
            /// <para>Description: Denominator of PKEY_GPS_DestBearing
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {7ABCF4F8-7C3F-4988-AC91-8D2C2E97ECA5}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey DestBearingDenominator => new ShellItemPropertyKey(new Guid("{7ABCF4F8-7C3F-4988-AC91-8D2C2E97ECA5}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.DestBearingNumerator -- PKEY_GPS_DestBearingNumerator</para>
            /// <para>Description: Numerator of PKEY_GPS_DestBearing
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {BA3B1DA9-86EE-4B5D-A2A4-A271A429F0CF}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey DestBearingNumerator => new ShellItemPropertyKey(new Guid("{BA3B1DA9-86EE-4B5D-A2A4-A271A429F0CF}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.DestBearingRef -- PKEY_GPS_DestBearingRef</para>
            /// <para>Description: Indicates the reference used for the giving the bearing to the destination point.  (eg: true direction, magnetic direction)
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {9AB84393-2A0F-4B75-BB22-7279786977CB}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey DestBearingRef => new ShellItemPropertyKey(new Guid("{9AB84393-2A0F-4B75-BB22-7279786977CB}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.DestDistance -- PKEY_GPS_DestDistance</para>
            /// <para>Description: Indicates the distance to the destination point.  Calculated from PKEY_GPS_DestDistanceNumerator and
            ///PKEY_GPS_DestDistanceDenominator.
            ///</para>
            /// <para>Type:     Double -- VT_R8</para>
            /// <para>FormatID: {A93EAE04-6804-4F24-AC81-09B266452118}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey DestDistance => new ShellItemPropertyKey(new Guid("{A93EAE04-6804-4F24-AC81-09B266452118}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.DestDistanceDenominator -- PKEY_GPS_DestDistanceDenominator</para>
            /// <para>Description: Denominator of PKEY_GPS_DestDistance
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {9BC2C99B-AC71-4127-9D1C-2596D0D7DCB7}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey DestDistanceDenominator => new ShellItemPropertyKey(new Guid("{9BC2C99B-AC71-4127-9D1C-2596D0D7DCB7}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.DestDistanceNumerator -- PKEY_GPS_DestDistanceNumerator</para>
            /// <para>Description: Numerator of PKEY_GPS_DestDistance
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {2BDA47DA-08C6-4FE1-80BC-A72FC517C5D0}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey DestDistanceNumerator => new ShellItemPropertyKey(new Guid("{2BDA47DA-08C6-4FE1-80BC-A72FC517C5D0}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.DestDistanceRef -- PKEY_GPS_DestDistanceRef</para>
            /// <para>Description: Indicates the unit used to express the distance to the destination.  (eg: kilometers, miles, knots)
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {ED4DF2D3-8695-450B-856F-F5C1C53ACB66}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey DestDistanceRef => new ShellItemPropertyKey(new Guid("{ED4DF2D3-8695-450B-856F-F5C1C53ACB66}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.DestLatitude -- PKEY_GPS_DestLatitude</para>
            /// <para>Description: Indicates the latitude of the destination point.  This is an array of three values.  Index 0 is the degrees, index 1
            ///is the minutes, index 2 is the seconds.  Each is calculated from the values in PKEY_GPS_DestLatitudeNumerator and
            ///PKEY_GPS_DestLatitudeDenominator.
            ///</para>
            /// <para>Type:     Multivalue Double -- VT_VECTOR | VT_R8  (For variants: VT_ARRAY | VT_R8)</para>
            /// <para>FormatID: {9D1D7CC5-5C39-451C-86B3-928E2D18CC47}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey DestLatitude => new ShellItemPropertyKey(new Guid("{9D1D7CC5-5C39-451C-86B3-928E2D18CC47}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.DestLatitudeDenominator -- PKEY_GPS_DestLatitudeDenominator</para>
            /// <para>Description: Denominator of PKEY_GPS_DestLatitude
            ///</para>
            /// <para>Type:     Multivalue UInt32 -- VT_VECTOR | VT_UI4  (For variants: VT_ARRAY | VT_UI4)</para>
            /// <para>FormatID: {3A372292-7FCA-49A7-99D5-E47BB2D4E7AB}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey DestLatitudeDenominator => new ShellItemPropertyKey(new Guid("{3A372292-7FCA-49A7-99D5-E47BB2D4E7AB}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.DestLatitudeNumerator -- PKEY_GPS_DestLatitudeNumerator</para>
            /// <para>Description: Numerator of PKEY_GPS_DestLatitude
            ///</para>
            /// <para>Type:     Multivalue UInt32 -- VT_VECTOR | VT_UI4  (For variants: VT_ARRAY | VT_UI4)</para>
            /// <para>FormatID: {ECF4B6F6-D5A6-433C-BB92-4076650FC890}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey DestLatitudeNumerator => new ShellItemPropertyKey(new Guid("{ECF4B6F6-D5A6-433C-BB92-4076650FC890}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.DestLatitudeRef -- PKEY_GPS_DestLatitudeRef</para>
            /// <para>Description: Indicates whether the latitude destination point is north or south latitude
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {CEA820B9-CE61-4885-A128-005D9087C192}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey DestLatitudeRef => new ShellItemPropertyKey(new Guid("{CEA820B9-CE61-4885-A128-005D9087C192}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.DestLongitude -- PKEY_GPS_DestLongitude</para>
            /// <para>Description: Indicates the latitude of the destination point.  This is an array of three values.  Index 0 is the degrees, index 1
            ///is the minutes, index 2 is the seconds.  Each is calculated from the values in PKEY_GPS_DestLongitudeNumerator and
            ///PKEY_GPS_DestLongitudeDenominator.
            ///</para>
            /// <para>Type:     Multivalue Double -- VT_VECTOR | VT_R8  (For variants: VT_ARRAY | VT_R8)</para>
            /// <para>FormatID: {47A96261-CB4C-4707-8AD3-40B9D9DBC6BC}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey DestLongitude => new ShellItemPropertyKey(new Guid("{47A96261-CB4C-4707-8AD3-40B9D9DBC6BC}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.DestLongitudeDenominator -- PKEY_GPS_DestLongitudeDenominator</para>
            /// <para>Description: Denominator of PKEY_GPS_DestLongitude
            ///</para>
            /// <para>Type:     Multivalue UInt32 -- VT_VECTOR | VT_UI4  (For variants: VT_ARRAY | VT_UI4)</para>
            /// <para>FormatID: {425D69E5-48AD-4900-8D80-6EB6B8D0AC86}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey DestLongitudeDenominator => new ShellItemPropertyKey(new Guid("{425D69E5-48AD-4900-8D80-6EB6B8D0AC86}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.DestLongitudeNumerator -- PKEY_GPS_DestLongitudeNumerator</para>
            /// <para>Description: Numerator of PKEY_GPS_DestLongitude
            ///</para>
            /// <para>Type:     Multivalue UInt32 -- VT_VECTOR | VT_UI4  (For variants: VT_ARRAY | VT_UI4)</para>
            /// <para>FormatID: {A3250282-FB6D-48D5-9A89-DBCACE75CCCF}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey DestLongitudeNumerator => new ShellItemPropertyKey(new Guid("{A3250282-FB6D-48D5-9A89-DBCACE75CCCF}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.DestLongitudeRef -- PKEY_GPS_DestLongitudeRef</para>
            /// <para>Description: Indicates whether the longitude destination point is east or west longitude
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {182C1EA6-7C1C-4083-AB4B-AC6C9F4ED128}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey DestLongitudeRef => new ShellItemPropertyKey(new Guid("{182C1EA6-7C1C-4083-AB4B-AC6C9F4ED128}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.Differential -- PKEY_GPS_Differential</para>
            /// <para>Description: Indicates whether differential correction was applied to the GPS receiver
            ///</para>
            /// <para>Type:     UInt16 -- VT_UI2</para>
            /// <para>FormatID: {AAF4EE25-BD3B-4DD7-BFC4-47F77BB00F6D}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Differential => new ShellItemPropertyKey(new Guid("{AAF4EE25-BD3B-4DD7-BFC4-47F77BB00F6D}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.DOP -- PKEY_GPS_DOP</para>
            /// <para>Description: Indicates the GPS DOP (data degree of precision).  Calculated from PKEY_GPS_DOPNumerator and PKEY_GPS_DOPDenominator
            ///</para>
            /// <para>Type:     Double -- VT_R8</para>
            /// <para>FormatID: {0CF8FB02-1837-42F1-A697-A7017AA289B9}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey DOP => new ShellItemPropertyKey(new Guid("{0CF8FB02-1837-42F1-A697-A7017AA289B9}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.DOPDenominator -- PKEY_GPS_DOPDenominator</para>
            /// <para>Description: Denominator of PKEY_GPS_DOP
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {A0BE94C5-50BA-487B-BD35-0654BE8881ED}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey DOPDenominator => new ShellItemPropertyKey(new Guid("{A0BE94C5-50BA-487B-BD35-0654BE8881ED}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.DOPNumerator -- PKEY_GPS_DOPNumerator</para>
            /// <para>Description: Numerator of PKEY_GPS_DOP
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {47066B16-364F-4AA0-9F31-E2AB3DF449C3}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey DOPNumerator => new ShellItemPropertyKey(new Guid("{47066B16-364F-4AA0-9F31-E2AB3DF449C3}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.ImgDirection -- PKEY_GPS_ImgDirection</para>
            /// <para>Description: Indicates direction of the image when it was captured.  Calculated from PKEY_GPS_ImgDirectionNumerator and
            ///PKEY_GPS_ImgDirectionDenominator.
            ///</para>
            /// <para>Type:     Double -- VT_R8</para>
            /// <para>FormatID: {16473C91-D017-4ED9-BA4D-B6BAA55DBCF8}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ImgDirection => new ShellItemPropertyKey(new Guid("{16473C91-D017-4ED9-BA4D-B6BAA55DBCF8}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.ImgDirectionDenominator -- PKEY_GPS_ImgDirectionDenominator</para>
            /// <para>Description: Denominator of PKEY_GPS_ImgDirection
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {10B24595-41A2-4E20-93C2-5761C1395F32}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ImgDirectionDenominator => new ShellItemPropertyKey(new Guid("{10B24595-41A2-4E20-93C2-5761C1395F32}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.ImgDirectionNumerator -- PKEY_GPS_ImgDirectionNumerator</para>
            /// <para>Description: Numerator of PKEY_GPS_ImgDirection
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {DC5877C7-225F-45F7-BAC7-E81334B6130A}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ImgDirectionNumerator => new ShellItemPropertyKey(new Guid("{DC5877C7-225F-45F7-BAC7-E81334B6130A}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.ImgDirectionRef -- PKEY_GPS_ImgDirectionRef</para>
            /// <para>Description: Indicates reference for giving the direction of the image when it was captured.  (eg: true direction, magnetic direction)
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {A4AAA5B7-1AD0-445F-811A-0F8F6E67F6B5}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ImgDirectionRef => new ShellItemPropertyKey(new Guid("{A4AAA5B7-1AD0-445F-811A-0F8F6E67F6B5}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.Latitude -- PKEY_GPS_Latitude</para>
            /// <para>Description: Indicates the latitude.  This is an array of three values.  Index 0 is the degrees, index 1 is the minutes, index 2
            ///is the seconds.  Each is calculated from the values in PKEY_GPS_LatitudeNumerator and PKEY_GPS_LatitudeDenominator.
            ///</para>
            /// <para>Type:     Multivalue Double -- VT_VECTOR | VT_R8  (For variants: VT_ARRAY | VT_R8)</para>
            /// <para>FormatID: {8727CFFF-4868-4EC6-AD5B-81B98521D1AB}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Latitude => new ShellItemPropertyKey(new Guid("{8727CFFF-4868-4EC6-AD5B-81B98521D1AB}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.LatitudeDenominator -- PKEY_GPS_LatitudeDenominator</para>
            /// <para>Description: Denominator of PKEY_GPS_Latitude
            ///</para>
            /// <para>Type:     Multivalue UInt32 -- VT_VECTOR | VT_UI4  (For variants: VT_ARRAY | VT_UI4)</para>
            /// <para>FormatID: {16E634EE-2BFF-497B-BD8A-4341AD39EEB9}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey LatitudeDenominator => new ShellItemPropertyKey(new Guid("{16E634EE-2BFF-497B-BD8A-4341AD39EEB9}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.LatitudeNumerator -- PKEY_GPS_LatitudeNumerator</para>
            /// <para>Description: Numerator of PKEY_GPS_Latitude
            ///</para>
            /// <para>Type:     Multivalue UInt32 -- VT_VECTOR | VT_UI4  (For variants: VT_ARRAY | VT_UI4)</para>
            /// <para>FormatID: {7DDAAAD1-CCC8-41AE-B750-B2CB8031AEA2}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey LatitudeNumerator => new ShellItemPropertyKey(new Guid("{7DDAAAD1-CCC8-41AE-B750-B2CB8031AEA2}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.LatitudeRef -- PKEY_GPS_LatitudeRef</para>
            /// <para>Description: Indicates whether latitude is north or south latitude
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {029C0252-5B86-46C7-ACA0-2769FFC8E3D4}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey LatitudeRef => new ShellItemPropertyKey(new Guid("{029C0252-5B86-46C7-ACA0-2769FFC8E3D4}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.Longitude -- PKEY_GPS_Longitude</para>
            /// <para>Description: Indicates the longitude.  This is an array of three values.  Index 0 is the degrees, index 1 is the minutes, index 2
            ///is the seconds.  Each is calculated from the values in PKEY_GPS_LongitudeNumerator and PKEY_GPS_LongitudeDenominator.
            ///</para>
            /// <para>Type:     Multivalue Double -- VT_VECTOR | VT_R8  (For variants: VT_ARRAY | VT_R8)</para>
            /// <para>FormatID: {C4C4DBB2-B593-466B-BBDA-D03D27D5E43A}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Longitude => new ShellItemPropertyKey(new Guid("{C4C4DBB2-B593-466B-BBDA-D03D27D5E43A}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.LongitudeDenominator -- PKEY_GPS_LongitudeDenominator</para>
            /// <para>Description: Denominator of PKEY_GPS_Longitude
            ///</para>
            /// <para>Type:     Multivalue UInt32 -- VT_VECTOR | VT_UI4  (For variants: VT_ARRAY | VT_UI4)</para>
            /// <para>FormatID: {BE6E176C-4534-4D2C-ACE5-31DEDAC1606B}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey LongitudeDenominator => new ShellItemPropertyKey(new Guid("{BE6E176C-4534-4D2C-ACE5-31DEDAC1606B}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.LongitudeNumerator -- PKEY_GPS_LongitudeNumerator</para>
            /// <para>Description: Numerator of PKEY_GPS_Longitude
            ///</para>
            /// <para>Type:     Multivalue UInt32 -- VT_VECTOR | VT_UI4  (For variants: VT_ARRAY | VT_UI4)</para>
            /// <para>FormatID: {02B0F689-A914-4E45-821D-1DDA452ED2C4}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey LongitudeNumerator => new ShellItemPropertyKey(new Guid("{02B0F689-A914-4E45-821D-1DDA452ED2C4}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.LongitudeRef -- PKEY_GPS_LongitudeRef</para>
            /// <para>Description: Indicates whether longitude is east or west longitude
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {33DCF22B-28D5-464C-8035-1EE9EFD25278}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey LongitudeRef => new ShellItemPropertyKey(new Guid("{33DCF22B-28D5-464C-8035-1EE9EFD25278}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.MapDatum -- PKEY_GPS_MapDatum</para>
            /// <para>Description: Indicates the geodetic survey data used by the GPS receiver
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {2CA2DAE6-EDDC-407D-BEF1-773942ABFA95}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey MapDatum => new ShellItemPropertyKey(new Guid("{2CA2DAE6-EDDC-407D-BEF1-773942ABFA95}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.MeasureMode -- PKEY_GPS_MeasureMode</para>
            /// <para>Description: Indicates the GPS measurement mode.  (eg: 2-dimensional, 3-dimensional)
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {A015ED5D-AAEA-4D58-8A86-3C586920EA0B}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey MeasureMode => new ShellItemPropertyKey(new Guid("{A015ED5D-AAEA-4D58-8A86-3C586920EA0B}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.ProcessingMethod -- PKEY_GPS_ProcessingMethod</para>
            /// <para>Description: Indicates the name of the method used for location finding
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {59D49E61-840F-4AA9-A939-E2099B7F6399}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ProcessingMethod => new ShellItemPropertyKey(new Guid("{59D49E61-840F-4AA9-A939-E2099B7F6399}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.Satellites -- PKEY_GPS_Satellites</para>
            /// <para>Description: Indicates the GPS satellites used for measurements
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {467EE575-1F25-4557-AD4E-B8B58B0D9C15}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Satellites => new ShellItemPropertyKey(new Guid("{467EE575-1F25-4557-AD4E-B8B58B0D9C15}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.Speed -- PKEY_GPS_Speed</para>
            /// <para>Description: Indicates the speed of the GPS receiver movement.  Calculated from PKEY_GPS_SpeedNumerator and
            ///PKEY_GPS_SpeedDenominator.
            ///</para>
            /// <para>Type:     Double -- VT_R8</para>
            /// <para>FormatID: {DA5D0862-6E76-4E1B-BABD-70021BD25494}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Speed => new ShellItemPropertyKey(new Guid("{DA5D0862-6E76-4E1B-BABD-70021BD25494}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.SpeedDenominator -- PKEY_GPS_SpeedDenominator</para>
            /// <para>Description: Denominator of PKEY_GPS_Speed
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {7D122D5A-AE5E-4335-8841-D71E7CE72F53}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey SpeedDenominator => new ShellItemPropertyKey(new Guid("{7D122D5A-AE5E-4335-8841-D71E7CE72F53}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.SpeedNumerator -- PKEY_GPS_SpeedNumerator</para>
            /// <para>Description: Numerator of PKEY_GPS_Speed
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {ACC9CE3D-C213-4942-8B48-6D0820F21C6D}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey SpeedNumerator => new ShellItemPropertyKey(new Guid("{ACC9CE3D-C213-4942-8B48-6D0820F21C6D}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.SpeedRef -- PKEY_GPS_SpeedRef</para>
            /// <para>Description: Indicates the unit used to express the speed of the GPS receiver movement.  (eg: kilometers per hour,
            ///miles per hour, knots).
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {ECF7F4C9-544F-4D6D-9D98-8AD79ADAF453}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey SpeedRef => new ShellItemPropertyKey(new Guid("{ECF7F4C9-544F-4D6D-9D98-8AD79ADAF453}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.Status -- PKEY_GPS_Status</para>
            /// <para>Description: Indicates the status of the GPS receiver when the image was recorded.  (eg: measurement in progress,
            ///measurement interoperability).
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {125491F4-818F-46B2-91B5-D537753617B2}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Status => new ShellItemPropertyKey(new Guid("{125491F4-818F-46B2-91B5-D537753617B2}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.Track -- PKEY_GPS_Track</para>
            /// <para>Description: Indicates the direction of the GPS receiver movement.  Calculated from PKEY_GPS_TrackNumerator and
            ///PKEY_GPS_TrackDenominator.
            ///</para>
            /// <para>Type:     Double -- VT_R8</para>
            /// <para>FormatID: {76C09943-7C33-49E3-9E7E-CDBA872CFADA}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Track => new ShellItemPropertyKey(new Guid("{76C09943-7C33-49E3-9E7E-CDBA872CFADA}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.TrackDenominator -- PKEY_GPS_TrackDenominator</para>
            /// <para>Description: Denominator of PKEY_GPS_Track
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {C8D1920C-01F6-40C0-AC86-2F3A4AD00770}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey TrackDenominator => new ShellItemPropertyKey(new Guid("{C8D1920C-01F6-40C0-AC86-2F3A4AD00770}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.TrackNumerator -- PKEY_GPS_TrackNumerator</para>
            /// <para>Description: Numerator of PKEY_GPS_Track
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {702926F4-44A6-43E1-AE71-45627116893B}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey TrackNumerator => new ShellItemPropertyKey(new Guid("{702926F4-44A6-43E1-AE71-45627116893B}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.TrackRef -- PKEY_GPS_TrackRef</para>
            /// <para>Description: Indicates reference for the direction of the GPS receiver movement.  (eg: true direction, magnetic direction)
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {35DBE6FE-44C3-4400-AAAE-D2C799C407E8}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey TrackRef => new ShellItemPropertyKey(new Guid("{35DBE6FE-44C3-4400-AAAE-D2C799C407E8}"), 100);

            /// <summary>
            /// <para>Name:     System.GPS.VersionID -- PKEY_GPS_VersionID</para>
            /// <para>Description: Indicates the version of the GPS information
            ///</para>
            /// <para>Type:     Buffer -- VT_VECTOR | VT_UI1  (For variants: VT_ARRAY | VT_UI1)</para>
            /// <para>FormatID: {22704DA4-C6B2-4A99-8E56-F16DF8C92599}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey VersionID => new ShellItemPropertyKey(new Guid("{22704DA4-C6B2-4A99-8E56-F16DF8C92599}"), 100);
        }

        /// <summary>Identity Properties</summary>
        public static class Identity
        {
            /// <summary>
            /// <para>Name:     System.Identity.Blob -- PKEY_Identity_Blob</para>
            /// <para>Description: Blob used to import/export identities
            ///</para>
            /// <para>Type:     Blob -- VT_BLOB</para>
            /// <para>FormatID: {8C3B93A4-BAED-1A83-9A32-102EE313F6EB}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Blob => new ShellItemPropertyKey(new Guid("{8C3B93A4-BAED-1A83-9A32-102EE313F6EB}"), 100);

            /// <summary>
            /// <para>Name:     System.Identity.DisplayName -- PKEY_Identity_DisplayName</para>
            /// <para>Description: Display Name
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {7D683FC9-D155-45A8-BB1F-89D19BCB792F}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey DisplayName => new ShellItemPropertyKey(new Guid("{7D683FC9-D155-45A8-BB1F-89D19BCB792F}"), 100);

            /// <summary>
            /// <para>Name:     System.Identity.IsMeIdentity -- PKEY_Identity_IsMeIdentity</para>
            /// <para>Description: Is it Me Identity
            ///</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {A4108708-09DF-4377-9DFC-6D99986D5A67}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey IsMeIdentity => new ShellItemPropertyKey(new Guid("{A4108708-09DF-4377-9DFC-6D99986D5A67}"), 100);

            /// <summary>
            /// <para>Name:     System.Identity.PrimaryEmailAddress -- PKEY_Identity_PrimaryEmailAddress</para>
            /// <para>Description: Primary Email Address
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {FCC16823-BAED-4F24-9B32-A0982117F7FA}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey PrimaryEmailAddress => new ShellItemPropertyKey(new Guid("{FCC16823-BAED-4F24-9B32-A0982117F7FA}"), 100);

            /// <summary>
            /// <para>Name:     System.Identity.ProviderID -- PKEY_Identity_ProviderID</para>
            /// <para>Description: Provider ID
            ///</para>
            /// <para>Type:     Guid -- VT_CLSID</para>
            /// <para>FormatID: {74A7DE49-FA11-4D3D-A006-DB7E08675916}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ProviderID => new ShellItemPropertyKey(new Guid("{74A7DE49-FA11-4D3D-A006-DB7E08675916}"), 100);

            /// <summary>
            /// <para>Name:     System.Identity.UniqueID -- PKEY_Identity_UniqueID</para>
            /// <para>Description: Unique ID
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {E55FC3B0-2B60-4220-918E-B21E8BF16016}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey UniqueID => new ShellItemPropertyKey(new Guid("{E55FC3B0-2B60-4220-918E-B21E8BF16016}"), 100);

            /// <summary>
            /// <para>Name:     System.Identity.UserName -- PKEY_Identity_UserName</para>
            /// <para>Description: Identity User Name
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {C4322503-78CA-49C6-9ACC-A68E2AFD7B6B}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey UserName => new ShellItemPropertyKey(new Guid("{C4322503-78CA-49C6-9ACC-A68E2AFD7B6B}"), 100);
        }

        /// <summary>IdentityProvider Properties</summary>
        public static class IdentityProvider
        {
            /// <summary>
            /// <para>Name:     System.IdentityProvider.Name -- PKEY_IdentityProvider_Name</para>
            /// <para>Description: Identity Provider Name
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {B96EFF7B-35CA-4A35-8607-29E3A54C46EA}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Name => new ShellItemPropertyKey(new Guid("{B96EFF7B-35CA-4A35-8607-29E3A54C46EA}"), 100);

            /// <summary>
            /// <para>Name:     System.IdentityProvider.Picture -- PKEY_IdentityProvider_Picture</para>
            /// <para>Description: Picture for the Identity Provider
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {2425166F-5642-4864-992F-98FD98F294C3}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Picture => new ShellItemPropertyKey(new Guid("{2425166F-5642-4864-992F-98FD98F294C3}"), 100);
        }

        /// <summary>Image Properties</summary>
        public static class Image
        {
            /// <summary>
            /// <para>Name:     System.Image.BitDepth -- PKEY_Image_BitDepth</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: (PSGUID_IMAGESUMMARYINFORMATION) {6444048F-4C8B-11D1-8B70-080036B11A03}, 7 (PIDISI_BITDEPTH)</para>
            /// </summary>
            public static ShellItemPropertyKey BitDepth => new ShellItemPropertyKey(new Guid("{6444048F-4C8B-11D1-8B70-080036B11A03}"), 7);

            /// <summary>
            /// <para>Name:     System.Image.ColorSpace -- PKEY_Image_ColorSpace</para>
            /// <para>Description: PropertyTagExifColorSpace
            ///</para>
            /// <para>Type:     UInt16 -- VT_UI2</para>
            /// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 40961</para>
            /// </summary>
            public static ShellItemPropertyKey ColorSpace => new ShellItemPropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 40961);

            /// <summary>
            /// <para>Name:     System.Image.CompressedBitsPerPixel -- PKEY_Image_CompressedBitsPerPixel</para>
            /// <para>Description: Calculated from PKEY_Image_CompressedBitsPerPixelNumerator and PKEY_Image_CompressedBitsPerPixelDenominator.
            ///</para>
            /// <para>Type:     Double -- VT_R8</para>
            /// <para>FormatID: {364B6FA9-37AB-482A-BE2B-AE02F60D4318}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey CompressedBitsPerPixel => new ShellItemPropertyKey(new Guid("{364B6FA9-37AB-482A-BE2B-AE02F60D4318}"), 100);

            /// <summary>
            /// <para>Name:     System.Image.CompressedBitsPerPixelDenominator -- PKEY_Image_CompressedBitsPerPixelDenominator</para>
            /// <para>Description: Denominator of PKEY_Image_CompressedBitsPerPixel.
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {1F8844E1-24AD-4508-9DFD-5326A415CE02}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey CompressedBitsPerPixelDenominator => new ShellItemPropertyKey(new Guid("{1F8844E1-24AD-4508-9DFD-5326A415CE02}"), 100);

            /// <summary>
            /// <para>Name:     System.Image.CompressedBitsPerPixelNumerator -- PKEY_Image_CompressedBitsPerPixelNumerator</para>
            /// <para>Description: Numerator of PKEY_Image_CompressedBitsPerPixel.
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {D21A7148-D32C-4624-8900-277210F79C0F}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey CompressedBitsPerPixelNumerator => new ShellItemPropertyKey(new Guid("{D21A7148-D32C-4624-8900-277210F79C0F}"), 100);

            /// <summary>
            /// <para>Name:     System.Image.Compression -- PKEY_Image_Compression</para>
            /// <para>Description: Indicates the image compression level.  PropertyTagCompression.
            ///</para>
            /// <para>Type:     UInt16 -- VT_UI2</para>
            /// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 259</para>
            /// </summary>
            public static ShellItemPropertyKey Compression => new ShellItemPropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 259);

            /// <summary>
            /// <para>Name:     System.Image.CompressionText -- PKEY_Image_CompressionText</para>
            /// <para>Description: This is the user-friendly form of System.Image.Compression.  Not intended to be parsed
            ///programmatically.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {3F08E66F-2F44-4BB9-A682-AC35D2562322}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey CompressionText => new ShellItemPropertyKey(new Guid("{3F08E66F-2F44-4BB9-A682-AC35D2562322}"), 100);

            /// <summary>
            /// <para>Name:     System.Image.Dimensions -- PKEY_Image_Dimensions</para>
            /// <para>Description: Indicates the dimensions of the image.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_IMAGESUMMARYINFORMATION) {6444048F-4C8B-11D1-8B70-080036B11A03}, 13 (PIDISI_DIMENSIONS)</para>
            /// </summary>
            public static ShellItemPropertyKey Dimensions => new ShellItemPropertyKey(new Guid("{6444048F-4C8B-11D1-8B70-080036B11A03}"), 13);

            /// <summary>
            /// <para>Name:     System.Image.HorizontalResolution -- PKEY_Image_HorizontalResolution</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     Double -- VT_R8</para>
            /// <para>FormatID: (PSGUID_IMAGESUMMARYINFORMATION) {6444048F-4C8B-11D1-8B70-080036B11A03}, 5 (PIDISI_RESOLUTIONX)</para>
            /// </summary>
            public static ShellItemPropertyKey HorizontalResolution => new ShellItemPropertyKey(new Guid("{6444048F-4C8B-11D1-8B70-080036B11A03}"), 5);

            /// <summary>
            /// <para>Name:     System.Image.HorizontalSize -- PKEY_Image_HorizontalSize</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: (PSGUID_IMAGESUMMARYINFORMATION) {6444048F-4C8B-11D1-8B70-080036B11A03}, 3 (PIDISI_CX)</para>
            /// </summary>
            public static ShellItemPropertyKey HorizontalSize => new ShellItemPropertyKey(new Guid("{6444048F-4C8B-11D1-8B70-080036B11A03}"), 3);

            /// <summary>
            /// <para>Name:     System.Image.ImageID -- PKEY_Image_ImageID</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {10DABE05-32AA-4C29-BF1A-63E2D220587F}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ImageID => new ShellItemPropertyKey(new Guid("{10DABE05-32AA-4C29-BF1A-63E2D220587F}"), 100);

            /// <summary>
            /// <para>Name:     System.Image.ResolutionUnit -- PKEY_Image_ResolutionUnit</para>
            /// <para>Description:</para>
            /// <para>Type:     Int16 -- VT_I2</para>
            /// <para>FormatID: {19B51FA6-1F92-4A5C-AB48-7DF0ABD67444}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ResolutionUnit => new ShellItemPropertyKey(new Guid("{19B51FA6-1F92-4A5C-AB48-7DF0ABD67444}"), 100);

            /// <summary>
            /// <para>Name:     System.Image.VerticalResolution -- PKEY_Image_VerticalResolution</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     Double -- VT_R8</para>
            /// <para>FormatID: (PSGUID_IMAGESUMMARYINFORMATION) {6444048F-4C8B-11D1-8B70-080036B11A03}, 6 (PIDISI_RESOLUTIONY)</para>
            /// </summary>
            public static ShellItemPropertyKey VerticalResolution => new ShellItemPropertyKey(new Guid("{6444048F-4C8B-11D1-8B70-080036B11A03}"), 6);

            /// <summary>
            /// <para>Name:     System.Image.VerticalSize -- PKEY_Image_VerticalSize</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: (PSGUID_IMAGESUMMARYINFORMATION) {6444048F-4C8B-11D1-8B70-080036B11A03}, 4 (PIDISI_CY)</para>
            /// </summary>
            public static ShellItemPropertyKey VerticalSize => new ShellItemPropertyKey(new Guid("{6444048F-4C8B-11D1-8B70-080036B11A03}"), 4);
        }

        /// <summary>JA Properties</summary>
        public static class JA
        {
            /// <summary>
            /// <para>Name:     System.Contact.JA.CompanyNamePhonetic -- PKEY_Contact_JA_CompanyNamePhonetic</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {897B3694-FE9E-43E6-8066-260F590C0100}, 2</para>
            /// </summary>
            public static ShellItemPropertyKey CompanyNamePhonetic => new ShellItemPropertyKey(new Guid("{897B3694-FE9E-43E6-8066-260F590C0100}"), 2);

            /// <summary>
            /// <para>Name:     System.Contact.JA.FirstNamePhonetic -- PKEY_Contact_JA_FirstNamePhonetic</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {897B3694-FE9E-43E6-8066-260F590C0100}, 3</para>
            /// </summary>
            public static ShellItemPropertyKey FirstNamePhonetic => new ShellItemPropertyKey(new Guid("{897B3694-FE9E-43E6-8066-260F590C0100}"), 3);

            /// <summary>
            /// <para>Name:     System.Contact.JA.LastNamePhonetic -- PKEY_Contact_JA_LastNamePhonetic</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {897B3694-FE9E-43E6-8066-260F590C0100}, 4</para>
            /// </summary>
            public static ShellItemPropertyKey LastNamePhonetic => new ShellItemPropertyKey(new Guid("{897B3694-FE9E-43E6-8066-260F590C0100}"), 4);
        }

        /// <summary>Journal Properties</summary>
        public static class Journal
        {
            /// <summary>
            /// <para>Name:     System.Journal.Contacts -- PKEY_Journal_Contacts</para>
            /// <para>Description:</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: {DEA7C82C-1D89-4A66-9427-A4E3DEBABCB1}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Contacts => new ShellItemPropertyKey(new Guid("{DEA7C82C-1D89-4A66-9427-A4E3DEBABCB1}"), 100);

            /// <summary>
            /// <para>Name:     System.Journal.EntryType -- PKEY_Journal_EntryType</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {95BEB1FC-326D-4644-B396-CD3ED90E6DDF}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey EntryType => new ShellItemPropertyKey(new Guid("{95BEB1FC-326D-4644-B396-CD3ED90E6DDF}"), 100);
        }

        /// <summary>LayoutPattern Properties</summary>
        public static class LayoutPattern
        {
            /// <summary>
            /// <para>Name:     System.LayoutPattern.ContentViewModeForBrowse -- PKEY_LayoutPattern_ContentViewModeForBrowse</para>
            /// <para>Description: Specifies the layout pattern that the content view mode should apply for this item in the context of browsing.
            ///Register the regvalue under the name of "ContentViewModeLayoutPatternForBrowse".
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {C9944A21-A406-48FE-8225-AEC7E24C211B}, 500</para>
            /// </summary>
            public static ShellItemPropertyKey ContentViewModeForBrowse => new ShellItemPropertyKey(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 500);

            /// <summary>
            /// <para>Name:     System.LayoutPattern.ContentViewModeForSearch -- PKEY_LayoutPattern_ContentViewModeForSearch</para>
            /// <para>Description: Specifies the layout pattern that the content view mode should apply for this item in the context of searching.
            ///Register the regvalue under the name of "ContentViewModeLayoutPatternForSearch".
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {C9944A21-A406-48FE-8225-AEC7E24C211B}, 501</para>
            /// </summary>
            public static ShellItemPropertyKey ContentViewModeForSearch => new ShellItemPropertyKey(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 501);
        }

        /// <summary>Link Properties</summary>
        public static class Link
        {
            /// <summary>
            /// <para>Name:     System.Link.Arguments -- PKEY_Link_Arguments</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {436F2667-14E2-4FEB-B30A-146C53B5B674}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Arguments => new ShellItemPropertyKey(new Guid("{436F2667-14E2-4FEB-B30A-146C53B5B674}"), 100);

            /// <summary>
            /// <para>Name:     System.Link.Comment -- PKEY_Link_Comment</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_LINK) {B9B4B3FC-2B51-4A42-B5D8-324146AFCF25}, 5</para>
            /// </summary>
            public static ShellItemPropertyKey Comment => new ShellItemPropertyKey(new Guid("{B9B4B3FC-2B51-4A42-B5D8-324146AFCF25}"), 5);

            /// <summary>
            /// <para>Name:     System.Link.DateVisited -- PKEY_Link_DateVisited</para>
            /// <para>Description:</para>
            /// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
            /// <para>FormatID: {5CBF2787-48CF-4208-B90E-EE5E5D420294}, 23 (PKEYs relating to URLs. Used by IE History.)</para>
            /// </summary>
            public static ShellItemPropertyKey DateVisited => new ShellItemPropertyKey(new Guid("{5CBF2787-48CF-4208-B90E-EE5E5D420294}"), 23);

            /// <summary>
            /// <para>Name:     System.Link.Description -- PKEY_Link_Description</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {5CBF2787-48CF-4208-B90E-EE5E5D420294}, 21 (PKEYs relating to URLs. Used by IE History.)</para>
            /// </summary>
            public static ShellItemPropertyKey Description => new ShellItemPropertyKey(new Guid("{5CBF2787-48CF-4208-B90E-EE5E5D420294}"), 21);

            /// <summary>
            /// <para>Name:     System.Link.Status -- PKEY_Link_Status</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     Int32 -- VT_I4</para>
            /// <para>FormatID: (PSGUID_LINK) {B9B4B3FC-2B51-4A42-B5D8-324146AFCF25}, 3 (PID_LINK_TARGET_TYPE)</para>
            /// </summary>
            public static ShellItemPropertyKey Status => new ShellItemPropertyKey(new Guid("{B9B4B3FC-2B51-4A42-B5D8-324146AFCF25}"), 3);

            /// <summary>
            /// <para>Name:     System.Link.TargetExtension -- PKEY_Link_TargetExtension</para>
            /// <para>Description: The file extension of the link target.  See System.File.Extension
            ///</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: {7A7D76F4-B630-4BD7-95FF-37CC51A975C9}, 2</para>
            /// </summary>
            public static ShellItemPropertyKey TargetExtension => new ShellItemPropertyKey(new Guid("{7A7D76F4-B630-4BD7-95FF-37CC51A975C9}"), 2);

            /// <summary>
            /// <para>Name:     System.Link.TargetParsingPath -- PKEY_Link_TargetParsingPath</para>
            /// <para>Description: This is the shell namespace path to the target of the link item.  This path may be passed to
            ///SHParseDisplayName to parse the path to the correct shell folder.
            ///
            ///If the target item is a file, the value is identical to System.ItemPathDisplay.
            ///
            ///If the target item cannot be accessed through the shell namespace, this value is VT_EMPTY.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_LINK) {B9B4B3FC-2B51-4A42-B5D8-324146AFCF25}, 2 (PID_LINK_TARGET)</para>
            /// </summary>
            public static ShellItemPropertyKey TargetParsingPath => new ShellItemPropertyKey(new Guid("{B9B4B3FC-2B51-4A42-B5D8-324146AFCF25}"), 2);

            /// <summary>
            /// <para>Name:     System.Link.TargetSFGAOFlags -- PKEY_Link_TargetSFGAOFlags</para>
            /// <para>Description: IShellFolder::GetAttributesOf flags for the target of a link, with SFGAO_PKEYSFGAOMASK
            ///attributes masked out.
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: (PSGUID_LINK) {B9B4B3FC-2B51-4A42-B5D8-324146AFCF25}, 8</para>
            /// </summary>
            public static ShellItemPropertyKey TargetSFGAOFlags => new ShellItemPropertyKey(new Guid("{B9B4B3FC-2B51-4A42-B5D8-324146AFCF25}"), 8);

            /// <summary>
            /// <para>Name:     System.Link.TargetSFGAOFlagsStrings -- PKEY_Link_TargetSFGAOFlagsStrings</para>
            /// <para>Description: Expresses the SFGAO flags of a link as string values and is used as a query optimization.  See
            ///PKEY_Shell_SFGAOFlagsStrings for possible values of this.
            ///</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: {D6942081-D53B-443D-AD47-5E059D9CD27A}, 3</para>
            /// </summary>
            public static ShellItemPropertyKey TargetSFGAOFlagsStrings => new ShellItemPropertyKey(new Guid("{D6942081-D53B-443D-AD47-5E059D9CD27A}"), 3);

            /// <summary>
            /// <para>Name:     System.Link.TargetUrl -- PKEY_Link_TargetUrl</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {5CBF2787-48CF-4208-B90E-EE5E5D420294}, 2 (PKEYs relating to URLs. Used by IE History.)</para>
            /// </summary>
            public static ShellItemPropertyKey TargetUrl => new ShellItemPropertyKey(new Guid("{5CBF2787-48CF-4208-B90E-EE5E5D420294}"), 2);
        }

        /// <summary>Media Properties</summary>
        public static class Media
        {
            /// <summary>
            /// <para>Name:     System.Media.AuthorUrl -- PKEY_Media_AuthorUrl</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 32 (PIDMSI_AUTHOR_URL)</para>
            /// </summary>
            public static ShellItemPropertyKey AuthorUrl => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 32);

            /// <summary>
            /// <para>Name:     System.Media.AverageLevel -- PKEY_Media_AverageLevel</para>
            /// <para>Description:</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {09EDD5B6-B301-43C5-9990-D00302EFFD46}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey AverageLevel => new ShellItemPropertyKey(new Guid("{09EDD5B6-B301-43C5-9990-D00302EFFD46}"), 100);

            /// <summary>
            /// <para>Name:     System.Media.ClassPrimaryID -- PKEY_Media_ClassPrimaryID</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 13 (PIDMSI_CLASS_PRIMARY_ID)</para>
            /// </summary>
            public static ShellItemPropertyKey ClassPrimaryID => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 13);

            /// <summary>
            /// <para>Name:     System.Media.ClassSecondaryID -- PKEY_Media_ClassSecondaryID</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 14 (PIDMSI_CLASS_SECONDARY_ID)</para>
            /// </summary>
            public static ShellItemPropertyKey ClassSecondaryID => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 14);

            /// <summary>
            /// <para>Name:     System.Media.CollectionGroupID -- PKEY_Media_CollectionGroupID</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 24 (PIDMSI_COLLECTION_GROUP_ID)</para>
            /// </summary>
            public static ShellItemPropertyKey CollectionGroupID => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 24);

            /// <summary>
            /// <para>Name:     System.Media.CollectionID -- PKEY_Media_CollectionID</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 25 (PIDMSI_COLLECTION_ID)</para>
            /// </summary>
            public static ShellItemPropertyKey CollectionID => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 25);

            /// <summary>
            /// <para>Name:     System.Media.ContentDistributor -- PKEY_Media_ContentDistributor</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 18 (PIDMSI_CONTENTDISTRIBUTOR)</para>
            /// </summary>
            public static ShellItemPropertyKey ContentDistributor => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 18);

            /// <summary>
            /// <para>Name:     System.Media.ContentID -- PKEY_Media_ContentID</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 26 (PIDMSI_CONTENT_ID)</para>
            /// </summary>
            public static ShellItemPropertyKey ContentID => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 26);

            /// <summary>
            /// <para>Name:     System.Media.CreatorApplication -- PKEY_Media_CreatorApplication</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 27 (PIDMSI_TOOL_NAME)</para>
            /// </summary>
            public static ShellItemPropertyKey CreatorApplication => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 27);

            /// <summary>
            /// <para>Name:     System.Media.CreatorApplicationVersion -- PKEY_Media_CreatorApplicationVersion</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 28 (PIDMSI_TOOL_VERSION)</para>
            /// </summary>
            public static ShellItemPropertyKey CreatorApplicationVersion => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 28);

            /// <summary>
            /// <para>Name:     System.Media.DateEncoded -- PKEY_Media_DateEncoded</para>
            /// <para>Description: DateTime is in UTC (in the doc, not file system).
            ///</para>
            /// <para>Type:     DateTime -- VT_FILETIME  (For variants: VT_DATE)</para>
            /// <para>FormatID: {2E4B640D-5019-46D8-8881-55414CC5CAA0}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey DateEncoded => new ShellItemPropertyKey(new Guid("{2E4B640D-5019-46D8-8881-55414CC5CAA0}"), 100);

            /// <summary>
            /// <para>Name:     System.Media.DateReleased -- PKEY_Media_DateReleased</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {DE41CC29-6971-4290-B470-F59F2E2F31E2}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey DateReleased => new ShellItemPropertyKey(new Guid("{DE41CC29-6971-4290-B470-F59F2E2F31E2}"), 100);

            /// <summary>
            /// <para>Name:     System.Media.Duration -- PKEY_Media_Duration</para>
            /// <para>Description: 100ns units, not milliseconds
            ///</para>
            /// <para>Type:     UInt64 -- VT_UI8</para>
            /// <para>FormatID: (FMTID_AudioSummaryInformation) {64440490-4C8B-11D1-8B70-080036B11A03}, 3 (PIDASI_TIMELENGTH)</para>
            /// </summary>
            public static ShellItemPropertyKey Duration => new ShellItemPropertyKey(new Guid("{64440490-4C8B-11D1-8B70-080036B11A03}"), 3);

            /// <summary>
            /// <para>Name:     System.Media.DVDID -- PKEY_Media_DVDID</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 15 (PIDMSI_DVDID)</para>
            /// </summary>
            public static ShellItemPropertyKey DVDID => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 15);

            /// <summary>
            /// <para>Name:     System.Media.EncodedBy -- PKEY_Media_EncodedBy</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 36 (PIDMSI_ENCODED_BY)</para>
            /// </summary>
            public static ShellItemPropertyKey EncodedBy => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 36);

            /// <summary>
            /// <para>Name:     System.Media.EncodingSettings -- PKEY_Media_EncodingSettings</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 37 (PIDMSI_ENCODING_SETTINGS)</para>
            /// </summary>
            public static ShellItemPropertyKey EncodingSettings => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 37);

            /// <summary>
            /// <para>Name:     System.Media.FrameCount -- PKEY_Media_FrameCount</para>
            /// <para>Description: Indicates the frame count for the image.
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: (PSGUID_IMAGESUMMARYINFORMATION) {6444048F-4C8B-11D1-8B70-080036B11A03}, 12 (PIDISI_FRAMECOUNT)</para>
            /// </summary>
            public static ShellItemPropertyKey FrameCount => new ShellItemPropertyKey(new Guid("{6444048F-4C8B-11D1-8B70-080036B11A03}"), 12);

            /// <summary>
            /// <para>Name:     System.Media.MCDI -- PKEY_Media_MCDI</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 16 (PIDMSI_MCDI)</para>
            /// </summary>
            public static ShellItemPropertyKey MCDI => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 16);

            /// <summary>
            /// <para>Name:     System.Media.MetadataContentProvider -- PKEY_Media_MetadataContentProvider</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 17 (PIDMSI_PROVIDER)</para>
            /// </summary>
            public static ShellItemPropertyKey MetadataContentProvider => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 17);

            /// <summary>
            /// <para>Name:     System.Media.Producer -- PKEY_Media_Producer</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 22 (PIDMSI_PRODUCER)</para>
            /// </summary>
            public static ShellItemPropertyKey Producer => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 22);

            /// <summary>
            /// <para>Name:     System.Media.PromotionUrl -- PKEY_Media_PromotionUrl</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 33 (PIDMSI_PROMOTION_URL)</para>
            /// </summary>
            public static ShellItemPropertyKey PromotionUrl => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 33);

            /// <summary>
            /// <para>Name:     System.Media.ProtectionType -- PKEY_Media_ProtectionType</para>
            /// <para>Description: If media is protected, how is it protected?
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 38</para>
            /// </summary>
            public static ShellItemPropertyKey ProtectionType => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 38);

            /// <summary>
            /// <para>Name:     System.Media.ProviderRating -- PKEY_Media_ProviderRating</para>
            /// <para>Description: Rating (0 - 99) supplied by metadata provider
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 39</para>
            /// </summary>
            public static ShellItemPropertyKey ProviderRating => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 39);

            /// <summary>
            /// <para>Name:     System.Media.ProviderStyle -- PKEY_Media_ProviderStyle</para>
            /// <para>Description: Style of music or video, supplied by metadata provider
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 40</para>
            /// </summary>
            public static ShellItemPropertyKey ProviderStyle => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 40);

            /// <summary>
            /// <para>Name:     System.Media.Publisher -- PKEY_Media_Publisher</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 30 (PIDMSI_PUBLISHER)</para>
            /// </summary>
            public static ShellItemPropertyKey Publisher => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 30);

            /// <summary>
            /// <para>Name:     System.Media.SubscriptionContentId -- PKEY_Media_SubscriptionContentId</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {9AEBAE7A-9644-487D-A92C-657585ED751A}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey SubscriptionContentId => new ShellItemPropertyKey(new Guid("{9AEBAE7A-9644-487D-A92C-657585ED751A}"), 100);

            /// <summary>
            /// <para>Name:     System.Media.SubTitle -- PKEY_Media_SubTitle</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 38 (PIDSI_MUSIC_SUB_TITLE)</para>
            /// </summary>
            public static ShellItemPropertyKey SubTitle => new ShellItemPropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 38);

            /// <summary>
            /// <para>Name:     System.Media.UniqueFileIdentifier -- PKEY_Media_UniqueFileIdentifier</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 35 (PIDMSI_UNIQUE_FILE_IDENTIFIER)</para>
            /// </summary>
            public static ShellItemPropertyKey UniqueFileIdentifier => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 35);

            /// <summary>
            /// <para>Name:     System.Media.UserNoAutoInfo -- PKEY_Media_UserNoAutoInfo</para>
            /// <para>Description: If true, do NOT alter this file's metadata. Set by user.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 41</para>
            /// </summary>
            public static ShellItemPropertyKey UserNoAutoInfo => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 41);

            /// <summary>
            /// <para>Name:     System.Media.UserWebUrl -- PKEY_Media_UserWebUrl</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 34 (PIDMSI_USER_WEB_URL)</para>
            /// </summary>
            public static ShellItemPropertyKey UserWebUrl => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 34);

            /// <summary>
            /// <para>Name:     System.Media.Writer -- PKEY_Media_Writer</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 23 (PIDMSI_WRITER)</para>
            /// </summary>
            public static ShellItemPropertyKey Writer => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 23);

            /// <summary>
            /// <para>Name:     System.Media.Year -- PKEY_Media_Year</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 5 (PIDSI_MUSIC_YEAR)</para>
            /// </summary>
            public static ShellItemPropertyKey Year => new ShellItemPropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 5);
        }

        /// <summary>Message Properties</summary>
        public static class Message
        {
            /// <summary>
            /// <para>Name:     System.Message.AttachmentContents -- PKEY_Message_AttachmentContents</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {3143BF7C-80A8-4854-8880-E2E40189BDD0}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey AttachmentContents => new ShellItemPropertyKey(new Guid("{3143BF7C-80A8-4854-8880-E2E40189BDD0}"), 100);

            /// <summary>
            /// <para>Name:     System.Message.AttachmentNames -- PKEY_Message_AttachmentNames</para>
            /// <para>Description: The names of the attachments in a message
            ///</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 21</para>
            /// </summary>
            public static ShellItemPropertyKey AttachmentNames => new ShellItemPropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 21);

            /// <summary>
            /// <para>Name:     System.Message.BccAddress -- PKEY_Message_BccAddress</para>
            /// <para>Description: Addresses in Bcc: field
            ///</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 2</para>
            /// </summary>
            public static ShellItemPropertyKey BccAddress => new ShellItemPropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 2);

            /// <summary>
            /// <para>Name:     System.Message.BccName -- PKEY_Message_BccName</para>
            /// <para>Description: person names in Bcc: field
            ///</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 3</para>
            /// </summary>
            public static ShellItemPropertyKey BccName => new ShellItemPropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 3);

            /// <summary>
            /// <para>Name:     System.Message.CcAddress -- PKEY_Message_CcAddress</para>
            /// <para>Description: Addresses in Cc: field
            ///</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 4</para>
            /// </summary>
            public static ShellItemPropertyKey CcAddress => new ShellItemPropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 4);

            /// <summary>
            /// <para>Name:     System.Message.CcName -- PKEY_Message_CcName</para>
            /// <para>Description: person names in Cc: field
            ///</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 5</para>
            /// </summary>
            public static ShellItemPropertyKey CcName => new ShellItemPropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 5);

            /// <summary>
            /// <para>Name:     System.Message.ConversationID -- PKEY_Message_ConversationID</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {DC8F80BD-AF1E-4289-85B6-3DFC1B493992}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ConversationID => new ShellItemPropertyKey(new Guid("{DC8F80BD-AF1E-4289-85B6-3DFC1B493992}"), 100);

            /// <summary>
            /// <para>Name:     System.Message.ConversationIndex -- PKEY_Message_ConversationIndex</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     Buffer -- VT_VECTOR | VT_UI1  (For variants: VT_ARRAY | VT_UI1)</para>
            /// <para>FormatID: {DC8F80BD-AF1E-4289-85B6-3DFC1B493992}, 101</para>
            /// </summary>
            public static ShellItemPropertyKey ConversationIndex => new ShellItemPropertyKey(new Guid("{DC8F80BD-AF1E-4289-85B6-3DFC1B493992}"), 101);

            /// <summary>
            /// <para>Name:     System.Message.DateReceived -- PKEY_Message_DateReceived</para>
            /// <para>Description: Date and Time communication was received
            ///</para>
            /// <para>Type:     DateTime -- VT_FILETIME  (For variants: VT_DATE)</para>
            /// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 20</para>
            /// </summary>
            public static ShellItemPropertyKey DateReceived => new ShellItemPropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 20);

            /// <summary>
            /// <para>Name:     System.Message.DateSent -- PKEY_Message_DateSent</para>
            /// <para>Description: Date and Time communication was sent
            ///</para>
            /// <para>Type:     DateTime -- VT_FILETIME  (For variants: VT_DATE)</para>
            /// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 19</para>
            /// </summary>
            public static ShellItemPropertyKey DateSent => new ShellItemPropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 19);

            /// <summary>
            /// <para>Name:     System.Message.Flags -- PKEY_Message_Flags</para>
            /// <para>Description: These are flags associated with email messages to know if a read receipt is pending, etc.
            ///The values stored here by Outlook are defined for PR_MESSAGE_FLAGS on MSDN.
            ///</para>
            /// <para>Type:     Int32 -- VT_I4</para>
            /// <para>FormatID: {A82D9EE7-CA67-4312-965E-226BCEA85023}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Flags => new ShellItemPropertyKey(new Guid("{A82D9EE7-CA67-4312-965E-226BCEA85023}"), 100);

            /// <summary>
            /// <para>Name:     System.Message.FromAddress -- PKEY_Message_FromAddress</para>
            /// <para>Description:</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 13</para>
            /// </summary>
            public static ShellItemPropertyKey FromAddress => new ShellItemPropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 13);

            /// <summary>
            /// <para>Name:     System.Message.FromName -- PKEY_Message_FromName</para>
            /// <para>Description: Address in from field as person name
            ///</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 14</para>
            /// </summary>
            public static ShellItemPropertyKey FromName => new ShellItemPropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 14);

            /// <summary>
            /// <para>Name:     System.Message.HasAttachments -- PKEY_Message_HasAttachments</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {9C1FCF74-2D97-41BA-B4AE-CB2E3661A6E4}, 8</para>
            /// </summary>
            public static ShellItemPropertyKey HasAttachments => new ShellItemPropertyKey(new Guid("{9C1FCF74-2D97-41BA-B4AE-CB2E3661A6E4}"), 8);

            /// <summary>
            /// <para>Name:     System.Message.IsFwdOrReply -- PKEY_Message_IsFwdOrReply</para>
            /// <para>Description:</para>
            /// <para>Type:     Int32 -- VT_I4</para>
            /// <para>FormatID: {9A9BC088-4F6D-469E-9919-E705412040F9}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey IsFwdOrReply => new ShellItemPropertyKey(new Guid("{9A9BC088-4F6D-469E-9919-E705412040F9}"), 100);

            /// <summary>
            /// <para>Name:     System.Message.MessageClass -- PKEY_Message_MessageClass</para>
            /// <para>Description: What type of outlook msg this is (meeting, task, mail, etc.)
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {CD9ED458-08CE-418F-A70E-F912C7BB9C5C}, 103</para>
            /// </summary>
            public static ShellItemPropertyKey MessageClass => new ShellItemPropertyKey(new Guid("{CD9ED458-08CE-418F-A70E-F912C7BB9C5C}"), 103);

            /// <summary>
            /// <para>Name:     System.Message.ProofInProgress -- PKEY_Message_ProofInProgress</para>
            /// <para>Description: This property will be true if the message junk email proofing is still in progress.
            ///</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {9098F33C-9A7D-48A8-8DE5-2E1227A64E91}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ProofInProgress => new ShellItemPropertyKey(new Guid("{9098F33C-9A7D-48A8-8DE5-2E1227A64E91}"), 100);

            /// <summary>
            /// <para>Name:     System.Message.SenderAddress -- PKEY_Message_SenderAddress</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {0BE1C8E7-1981-4676-AE14-FDD78F05A6E7}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey SenderAddress => new ShellItemPropertyKey(new Guid("{0BE1C8E7-1981-4676-AE14-FDD78F05A6E7}"), 100);

            /// <summary>
            /// <para>Name:     System.Message.SenderName -- PKEY_Message_SenderName</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {0DA41CFA-D224-4A18-AE2F-596158DB4B3A}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey SenderName => new ShellItemPropertyKey(new Guid("{0DA41CFA-D224-4A18-AE2F-596158DB4B3A}"), 100);

            /// <summary>
            /// <para>Name:     System.Message.Store -- PKEY_Message_Store</para>
            /// <para>Description: The store (aka protocol handler) FILE, MAIL, OUTLOOKEXPRESS
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 15</para>
            /// </summary>
            public static ShellItemPropertyKey Store => new ShellItemPropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 15);

            /// <summary>
            /// <para>Name:     System.Message.ToAddress -- PKEY_Message_ToAddress</para>
            /// <para>Description: Addresses in To: field
            ///</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 16</para>
            /// </summary>
            public static ShellItemPropertyKey ToAddress => new ShellItemPropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 16);

            /// <summary>
            /// <para>Name:     System.Message.ToDoFlags -- PKEY_Message_ToDoFlags</para>
            /// <para>Description: Flags associated with a message flagged to know if it's still active, if it was custom flagged, etc.
            ///</para>
            /// <para>Type:     Int32 -- VT_I4</para>
            /// <para>FormatID: {1F856A9F-6900-4ABA-9505-2D5F1B4D66CB}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ToDoFlags => new ShellItemPropertyKey(new Guid("{1F856A9F-6900-4ABA-9505-2D5F1B4D66CB}"), 100);

            /// <summary>
            /// <para>Name:     System.Message.ToDoTitle -- PKEY_Message_ToDoTitle</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {BCCC8A3C-8CEF-42E5-9B1C-C69079398BC7}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ToDoTitle => new ShellItemPropertyKey(new Guid("{BCCC8A3C-8CEF-42E5-9B1C-C69079398BC7}"), 100);

            /// <summary>
            /// <para>Name:     System.Message.ToName -- PKEY_Message_ToName</para>
            /// <para>Description: Person names in To: field
            ///</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 17</para>
            /// </summary>
            public static ShellItemPropertyKey ToName => new ShellItemPropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 17);
        }

        /// <summary>Music Properties</summary>
        public static class Music
        {
            /// <summary>
            /// <para>Name:     System.Music.AlbumArtist -- PKEY_Music_AlbumArtist</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 13 (PIDSI_MUSIC_ALBUM_ARTIST)</para>
            /// </summary>
            public static ShellItemPropertyKey AlbumArtist => new ShellItemPropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 13);

            /// <summary>
            /// <para>Name:     System.Music.AlbumID -- PKEY_Music_AlbumID</para>
            /// <para>Description: Concatenation of System.Music.AlbumArtist and System.Music.AlbumTitle, suitable for indexing and display.
            ///Used to differentiate albums with the same title from different artists.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey AlbumID => new ShellItemPropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 100);

            /// <summary>
            /// <para>Name:     System.Music.AlbumTitle -- PKEY_Music_AlbumTitle</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 4 (PIDSI_MUSIC_ALBUM)</para>
            /// </summary>
            public static ShellItemPropertyKey AlbumTitle => new ShellItemPropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 4);

            /// <summary>
            /// <para>Name:     System.Music.Artist -- PKEY_Music_Artist</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 2 (PIDSI_MUSIC_ARTIST)</para>
            /// </summary>
            public static ShellItemPropertyKey Artist => new ShellItemPropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 2);

            /// <summary>
            /// <para>Name:     System.Music.BeatsPerMinute -- PKEY_Music_BeatsPerMinute</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 35 (PIDSI_MUSIC_BEATS_PER_MINUTE)</para>
            /// </summary>
            public static ShellItemPropertyKey BeatsPerMinute => new ShellItemPropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 35);

            /// <summary>
            /// <para>Name:     System.Music.Composer -- PKEY_Music_Composer</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 19 (PIDMSI_COMPOSER)</para>
            /// </summary>
            public static ShellItemPropertyKey Composer => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 19);

            /// <summary>
            /// <para>Name:     System.Music.Conductor -- PKEY_Music_Conductor</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 36 (PIDSI_MUSIC_CONDUCTOR)</para>
            /// </summary>
            public static ShellItemPropertyKey Conductor => new ShellItemPropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 36);

            /// <summary>
            /// <para>Name:     System.Music.ContentGroupDescription -- PKEY_Music_ContentGroupDescription</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 33 (PIDSI_MUSIC_CONTENT_GROUP_DESCRIPTION)</para>
            /// </summary>
            public static ShellItemPropertyKey ContentGroupDescription => new ShellItemPropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 33);

            /// <summary>
            /// <para>Name:     System.Music.DisplayArtist -- PKEY_Music_DisplayArtist</para>
            /// <para>Description: This property returns the best representation of Album Artist for a given music file
            ///based upon AlbumArtist, ContributingArtist and compilation info.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {FD122953-FA93-4EF7-92C3-04C946B2F7C8}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey DisplayArtist => new ShellItemPropertyKey(new Guid("{FD122953-FA93-4EF7-92C3-04C946B2F7C8}"), 100);

            /// <summary>
            /// <para>Name:     System.Music.Genre -- PKEY_Music_Genre</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 11 (PIDSI_MUSIC_GENRE)</para>
            /// </summary>
            public static ShellItemPropertyKey Genre => new ShellItemPropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 11);

            /// <summary>
            /// <para>Name:     System.Music.InitialKey -- PKEY_Music_InitialKey</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 34 (PIDSI_MUSIC_INITIAL_KEY)</para>
            /// </summary>
            public static ShellItemPropertyKey InitialKey => new ShellItemPropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 34);

            /// <summary>
            /// <para>Name:     System.Music.IsCompilation -- PKEY_Music_IsCompilation</para>
            /// <para>Description: Indicates whether the file is part of a compilation.
            ///</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {C449D5CB-9EA4-4709-82E8-AF9D59DED6D1}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey IsCompilation => new ShellItemPropertyKey(new Guid("{C449D5CB-9EA4-4709-82E8-AF9D59DED6D1}"), 100);

            /// <summary>
            /// <para>Name:     System.Music.Lyrics -- PKEY_Music_Lyrics</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 12 (PIDSI_MUSIC_LYRICS)</para>
            /// </summary>
            public static ShellItemPropertyKey Lyrics => new ShellItemPropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 12);

            /// <summary>
            /// <para>Name:     System.Music.Mood -- PKEY_Music_Mood</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 39 (PIDSI_MUSIC_MOOD)</para>
            /// </summary>
            public static ShellItemPropertyKey Mood => new ShellItemPropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 39);

            /// <summary>
            /// <para>Name:     System.Music.PartOfSet -- PKEY_Music_PartOfSet</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 37 (PIDSI_MUSIC_PART_OF_SET)</para>
            /// </summary>
            public static ShellItemPropertyKey PartOfSet => new ShellItemPropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 37);

            /// <summary>
            /// <para>Name:     System.Music.Period -- PKEY_Music_Period</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 31 (PIDMSI_PERIOD)</para>
            /// </summary>
            public static ShellItemPropertyKey Period => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 31);

            /// <summary>
            /// <para>Name:     System.Music.SynchronizedLyrics -- PKEY_Music_SynchronizedLyrics</para>
            /// <para>Description:</para>
            /// <para>Type:     Blob -- VT_BLOB</para>
            /// <para>FormatID: {6B223B6A-162E-4AA9-B39F-05D678FC6D77}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey SynchronizedLyrics => new ShellItemPropertyKey(new Guid("{6B223B6A-162E-4AA9-B39F-05D678FC6D77}"), 100);

            /// <summary>
            /// <para>Name:     System.Music.TrackNumber -- PKEY_Music_TrackNumber</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 7 (PIDSI_MUSIC_TRACK)</para>
            /// </summary>
            public static ShellItemPropertyKey TrackNumber => new ShellItemPropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 7);
        }

        /// <summary>Note Properties</summary>
        public static class Note
        {
            /// <summary>
            /// <para>Name:     System.Note.Color -- PKEY_Note_Color</para>
            /// <para>Description:</para>
            /// <para>Type:     UInt16 -- VT_UI2</para>
            /// <para>FormatID: {4776CAFA-BCE4-4CB1-A23E-265E76D8EB11}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Color => new ShellItemPropertyKey(new Guid("{4776CAFA-BCE4-4CB1-A23E-265E76D8EB11}"), 100);

            /// <summary>
            /// <para>Name:     System.Note.ColorText -- PKEY_Note_ColorText</para>
            /// <para>Description: This is the user-friendly form of System.Note.Color.  Not intended to be parsed
            ///programmatically.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {46B4E8DE-CDB2-440D-885C-1658EB65B914}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ColorText => new ShellItemPropertyKey(new Guid("{46B4E8DE-CDB2-440D-885C-1658EB65B914}"), 100);
        }

        /// <summary>Notifications Properties</summary>
        public static class Notifications
        {
            /// <summary>
            /// <para>Name:     System.Devices.Notifications.LowBattery -- PKEY_Devices_Notification_LowBattery</para>
            /// <para>Description: Device Low Battery Notification.
            ///</para>
            /// <para>Type:     Byte -- VT_UI1</para>
            /// <para>FormatID: {C4C07F2B-8524-4E66-AE3A-A6235F103BEB}, 2</para>
            /// </summary>
            public static ShellItemPropertyKey LowBattery => new ShellItemPropertyKey(new Guid("{C4C07F2B-8524-4E66-AE3A-A6235F103BEB}"), 2);

            /// <summary>
            /// <para>Name:     System.Devices.Notifications.MissedCall -- PKEY_Devices_Notification_MissedCall</para>
            /// <para>Description: Device Missed Call Notification.
            ///</para>
            /// <para>Type:     Byte -- VT_UI1</para>
            /// <para>FormatID: {6614EF48-4EFE-4424-9EDA-C79F404EDF3E}, 2</para>
            /// </summary>
            public static ShellItemPropertyKey MissedCall => new ShellItemPropertyKey(new Guid("{6614EF48-4EFE-4424-9EDA-C79F404EDF3E}"), 2);

            /// <summary>
            /// <para>Name:     System.Devices.Notifications.NewMessage -- PKEY_Devices_Notification_NewMessage</para>
            /// <para>Description: Device New Message Notification.
            ///</para>
            /// <para>Type:     Byte -- VT_UI1</para>
            /// <para>FormatID: {2BE9260A-2012-4742-A555-F41B638B7DCB}, 2</para>
            /// </summary>
            public static ShellItemPropertyKey NewMessage => new ShellItemPropertyKey(new Guid("{2BE9260A-2012-4742-A555-F41B638B7DCB}"), 2);

            /// <summary>
            /// <para>Name:     System.Devices.Notifications.NewVoicemail -- PKEY_Devices_Notification_NewVoicemail</para>
            /// <para>Description: Device Voicemail Notification.
            ///</para>
            /// <para>Type:     Byte -- VT_UI1</para>
            /// <para>FormatID: {59569556-0A08-4212-95B9-FAE2AD6413DB}, 2</para>
            /// </summary>
            public static ShellItemPropertyKey NewVoicemail => new ShellItemPropertyKey(new Guid("{59569556-0A08-4212-95B9-FAE2AD6413DB}"), 2);

            /// <summary>
            /// <para>Name:     System.Devices.Notifications.StorageFull -- PKEY_Devices_Notification_StorageFull</para>
            /// <para>Description: Device Storage Full Notification.
            ///</para>
            /// <para>Type:     UInt64 -- VT_UI8</para>
            /// <para>FormatID: {A0E00EE1-F0C7-4D41-B8E7-26A7BD8D38B0}, 2</para>
            /// </summary>
            public static ShellItemPropertyKey StorageFull => new ShellItemPropertyKey(new Guid("{A0E00EE1-F0C7-4D41-B8E7-26A7BD8D38B0}"), 2);

            /// <summary>
            /// <para>Name:     System.Devices.Notifications.StorageFullLinkText -- PKEY_Devices_Notification_StorageFullLinkText</para>
            /// <para>Description: Link Text for the Device Storage Full Notification.
            ///</para>
            /// <para>Type:     UInt64 -- VT_UI8</para>
            /// <para>FormatID: {A0E00EE1-F0C7-4D41-B8E7-26A7BD8D38B0}, 3</para>
            /// </summary>
            public static ShellItemPropertyKey StorageFullLinkText => new ShellItemPropertyKey(new Guid("{A0E00EE1-F0C7-4D41-B8E7-26A7BD8D38B0}"), 3);
        }

        /// <summary>Photo Properties</summary>
        public static class Photo
        {
            /// <summary>
            /// <para>Name:     System.Photo.Aperture -- PKEY_Photo_Aperture</para>
            /// <para>Description: PropertyTagExifAperture.  Calculated from PKEY_Photo_ApertureNumerator and PKEY_Photo_ApertureDenominator
            ///</para>
            /// <para>Type:     Double -- VT_R8</para>
            /// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 37378</para>
            /// </summary>
            public static ShellItemPropertyKey Aperture => new ShellItemPropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 37378);

            /// <summary>
            /// <para>Name:     System.Photo.ApertureDenominator -- PKEY_Photo_ApertureDenominator</para>
            /// <para>Description: Denominator of PKEY_Photo_Aperture
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {E1A9A38B-6685-46BD-875E-570DC7AD7320}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ApertureDenominator => new ShellItemPropertyKey(new Guid("{E1A9A38B-6685-46BD-875E-570DC7AD7320}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.ApertureNumerator -- PKEY_Photo_ApertureNumerator</para>
            /// <para>Description: Numerator of PKEY_Photo_Aperture
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {0337ECEC-39FB-4581-A0BD-4C4CC51E9914}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ApertureNumerator => new ShellItemPropertyKey(new Guid("{0337ECEC-39FB-4581-A0BD-4C4CC51E9914}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.Brightness -- PKEY_Photo_Brightness</para>
            /// <para>Description: This is the brightness of the photo.
            ///
            ///Calculated from PKEY_Photo_BrightnessNumerator and PKEY_Photo_BrightnessDenominator.
            ///
            ///The units are "APEX", normally in the range of -99.99 to 99.99. If the numerator of
            ///the recorded value is FFFFFFFF.H, "Unknown" should be indicated.
            ///</para>
            /// <para>Type:     Double -- VT_R8</para>
            /// <para>FormatID: {1A701BF6-478C-4361-83AB-3701BB053C58}, 100 (PropertyTagExifBrightness)</para>
            /// </summary>
            public static ShellItemPropertyKey Brightness => new ShellItemPropertyKey(new Guid("{1A701BF6-478C-4361-83AB-3701BB053C58}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.BrightnessDenominator -- PKEY_Photo_BrightnessDenominator</para>
            /// <para>Description: Denominator of PKEY_Photo_Brightness
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {6EBE6946-2321-440A-90F0-C043EFD32476}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey BrightnessDenominator => new ShellItemPropertyKey(new Guid("{6EBE6946-2321-440A-90F0-C043EFD32476}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.BrightnessNumerator -- PKEY_Photo_BrightnessNumerator</para>
            /// <para>Description: Numerator of PKEY_Photo_Brightness
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {9E7D118F-B314-45A0-8CFB-D654B917C9E9}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey BrightnessNumerator => new ShellItemPropertyKey(new Guid("{9E7D118F-B314-45A0-8CFB-D654B917C9E9}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.CameraManufacturer -- PKEY_Photo_CameraManufacturer</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 271 (PropertyTagEquipMake)</para>
            /// </summary>
            public static ShellItemPropertyKey CameraManufacturer => new ShellItemPropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 271);

            /// <summary>
            /// <para>Name:     System.Photo.CameraModel -- PKEY_Photo_CameraModel</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 272 (PropertyTagEquipModel)</para>
            /// </summary>
            public static ShellItemPropertyKey CameraModel => new ShellItemPropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 272);

            /// <summary>
            /// <para>Name:     System.Photo.CameraSerialNumber -- PKEY_Photo_CameraSerialNumber</para>
            /// <para>Description: Serial number of camera that produced this photo
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 273</para>
            /// </summary>
            public static ShellItemPropertyKey CameraSerialNumber => new ShellItemPropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 273);

            /// <summary>
            /// <para>Name:     System.Photo.Contrast -- PKEY_Photo_Contrast</para>
            /// <para>Description: This indicates the direction of contrast processing applied by the camera
            ///when the image was shot.
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {2A785BA9-8D23-4DED-82E6-60A350C86A10}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Contrast => new ShellItemPropertyKey(new Guid("{2A785BA9-8D23-4DED-82E6-60A350C86A10}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.ContrastText -- PKEY_Photo_ContrastText</para>
            /// <para>Description: This is the user-friendly form of System.Photo.Contrast.  Not intended to be parsed
            ///programmatically.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {59DDE9F2-5253-40EA-9A8B-479E96C6249A}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ContrastText => new ShellItemPropertyKey(new Guid("{59DDE9F2-5253-40EA-9A8B-479E96C6249A}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.DateTaken -- PKEY_Photo_DateTaken</para>
            /// <para>Description: PropertyTagExifDTOrig
            ///</para>
            /// <para>Type:     DateTime -- VT_FILETIME  (For variants: VT_DATE)</para>
            /// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 36867</para>
            /// </summary>
            public static ShellItemPropertyKey DateTaken => new ShellItemPropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 36867);

            /// <summary>
            /// <para>Name:     System.Photo.DigitalZoom -- PKEY_Photo_DigitalZoom</para>
            /// <para>Description: PropertyTagExifDigitalZoom.  Calculated from PKEY_Photo_DigitalZoomNumerator and PKEY_Photo_DigitalZoomDenominator
            ///</para>
            /// <para>Type:     Double -- VT_R8</para>
            /// <para>FormatID: {F85BF840-A925-4BC2-B0C4-8E36B598679E}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey DigitalZoom => new ShellItemPropertyKey(new Guid("{F85BF840-A925-4BC2-B0C4-8E36B598679E}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.DigitalZoomDenominator -- PKEY_Photo_DigitalZoomDenominator</para>
            /// <para>Description: Denominator of PKEY_Photo_DigitalZoom
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {745BAF0E-E5C1-4CFB-8A1B-D031A0A52393}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey DigitalZoomDenominator => new ShellItemPropertyKey(new Guid("{745BAF0E-E5C1-4CFB-8A1B-D031A0A52393}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.DigitalZoomNumerator -- PKEY_Photo_DigitalZoomNumerator</para>
            /// <para>Description: Numerator of PKEY_Photo_DigitalZoom
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {16CBB924-6500-473B-A5BE-F1599BCBE413}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey DigitalZoomNumerator => new ShellItemPropertyKey(new Guid("{16CBB924-6500-473B-A5BE-F1599BCBE413}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.Event -- PKEY_Photo_Event</para>
            /// <para>Description: The event at which the photo was taken
            ///</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 18248</para>
            /// </summary>
            public static ShellItemPropertyKey Event => new ShellItemPropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 18248);

            /// <summary>
            /// <para>Name:     System.Photo.EXIFVersion -- PKEY_Photo_EXIFVersion</para>
            /// <para>Description: The EXIF version.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {D35F743A-EB2E-47F2-A286-844132CB1427}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey EXIFVersion => new ShellItemPropertyKey(new Guid("{D35F743A-EB2E-47F2-A286-844132CB1427}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.ExposureBias -- PKEY_Photo_ExposureBias</para>
            /// <para>Description: PropertyTagExifExposureBias.  Calculated from PKEY_Photo_ExposureBiasNumerator and PKEY_Photo_ExposureBiasDenominator
            ///</para>
            /// <para>Type:     Double -- VT_R8</para>
            /// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 37380</para>
            /// </summary>
            public static ShellItemPropertyKey ExposureBias => new ShellItemPropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 37380);

            /// <summary>
            /// <para>Name:     System.Photo.ExposureBiasDenominator -- PKEY_Photo_ExposureBiasDenominator</para>
            /// <para>Description: Denominator of PKEY_Photo_ExposureBias
            ///</para>
            /// <para>Type:     Int32 -- VT_I4</para>
            /// <para>FormatID: {AB205E50-04B7-461C-A18C-2F233836E627}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ExposureBiasDenominator => new ShellItemPropertyKey(new Guid("{AB205E50-04B7-461C-A18C-2F233836E627}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.ExposureBiasNumerator -- PKEY_Photo_ExposureBiasNumerator</para>
            /// <para>Description: Numerator of PKEY_Photo_ExposureBias
            ///</para>
            /// <para>Type:     Int32 -- VT_I4</para>
            /// <para>FormatID: {738BF284-1D87-420B-92CF-5834BF6EF9ED}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ExposureBiasNumerator => new ShellItemPropertyKey(new Guid("{738BF284-1D87-420B-92CF-5834BF6EF9ED}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.ExposureIndex -- PKEY_Photo_ExposureIndex</para>
            /// <para>Description: PropertyTagExifExposureIndex.  Calculated from PKEY_Photo_ExposureIndexNumerator and PKEY_Photo_ExposureIndexDenominator
            ///</para>
            /// <para>Type:     Double -- VT_R8</para>
            /// <para>FormatID: {967B5AF8-995A-46ED-9E11-35B3C5B9782D}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ExposureIndex => new ShellItemPropertyKey(new Guid("{967B5AF8-995A-46ED-9E11-35B3C5B9782D}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.ExposureIndexDenominator -- PKEY_Photo_ExposureIndexDenominator</para>
            /// <para>Description: Denominator of PKEY_Photo_ExposureIndex
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {93112F89-C28B-492F-8A9D-4BE2062CEE8A}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ExposureIndexDenominator => new ShellItemPropertyKey(new Guid("{93112F89-C28B-492F-8A9D-4BE2062CEE8A}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.ExposureIndexNumerator -- PKEY_Photo_ExposureIndexNumerator</para>
            /// <para>Description: Numerator of PKEY_Photo_ExposureIndex
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {CDEDCF30-8919-44DF-8F4C-4EB2FFDB8D89}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ExposureIndexNumerator => new ShellItemPropertyKey(new Guid("{CDEDCF30-8919-44DF-8F4C-4EB2FFDB8D89}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.ExposureProgram -- PKEY_Photo_ExposureProgram</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 34850 (PropertyTagExifExposureProg)</para>
            /// </summary>
            public static ShellItemPropertyKey ExposureProgram => new ShellItemPropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 34850);

            /// <summary>
            /// <para>Name:     System.Photo.ExposureProgramText -- PKEY_Photo_ExposureProgramText</para>
            /// <para>Description: This is the user-friendly form of System.Photo.ExposureProgram.  Not intended to be parsed
            ///programmatically.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {FEC690B7-5F30-4646-AE47-4CAAFBA884A3}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ExposureProgramText => new ShellItemPropertyKey(new Guid("{FEC690B7-5F30-4646-AE47-4CAAFBA884A3}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.ExposureTime -- PKEY_Photo_ExposureTime</para>
            /// <para>Description: PropertyTagExifExposureTime.  Calculated from  PKEY_Photo_ExposureTimeNumerator and PKEY_Photo_ExposureTimeDenominator
            ///</para>
            /// <para>Type:     Double -- VT_R8</para>
            /// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 33434</para>
            /// </summary>
            public static ShellItemPropertyKey ExposureTime => new ShellItemPropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 33434);

            /// <summary>
            /// <para>Name:     System.Photo.ExposureTimeDenominator -- PKEY_Photo_ExposureTimeDenominator</para>
            /// <para>Description: Denominator of PKEY_Photo_ExposureTime
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {55E98597-AD16-42E0-B624-21599A199838}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ExposureTimeDenominator => new ShellItemPropertyKey(new Guid("{55E98597-AD16-42E0-B624-21599A199838}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.ExposureTimeNumerator -- PKEY_Photo_ExposureTimeNumerator</para>
            /// <para>Description: Numerator of PKEY_Photo_ExposureTime
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {257E44E2-9031-4323-AC38-85C552871B2E}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ExposureTimeNumerator => new ShellItemPropertyKey(new Guid("{257E44E2-9031-4323-AC38-85C552871B2E}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.Flash -- PKEY_Photo_Flash</para>
            /// <para>Description: PropertyTagExifFlash
            ///</para>
            /// <para>Type:     Byte -- VT_UI1</para>
            /// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 37385</para>
            /// </summary>
            public static ShellItemPropertyKey Flash => new ShellItemPropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 37385);

            /// <summary>
            /// <para>Name:     System.Photo.FlashEnergy -- PKEY_Photo_FlashEnergy</para>
            /// <para>Description: PropertyTagExifFlashEnergy.  Calculated from PKEY_Photo_FlashEnergyNumerator and PKEY_Photo_FlashEnergyDenominator
            ///</para>
            /// <para>Type:     Double -- VT_R8</para>
            /// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 41483</para>
            /// </summary>
            public static ShellItemPropertyKey FlashEnergy => new ShellItemPropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 41483);

            /// <summary>
            /// <para>Name:     System.Photo.FlashEnergyDenominator -- PKEY_Photo_FlashEnergyDenominator</para>
            /// <para>Description: Denominator of PKEY_Photo_FlashEnergy
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {D7B61C70-6323-49CD-A5FC-C84277162C97}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey FlashEnergyDenominator => new ShellItemPropertyKey(new Guid("{D7B61C70-6323-49CD-A5FC-C84277162C97}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.FlashEnergyNumerator -- PKEY_Photo_FlashEnergyNumerator</para>
            /// <para>Description: Numerator of PKEY_Photo_FlashEnergy
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {FCAD3D3D-0858-400F-AAA3-2F66CCE2A6BC}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey FlashEnergyNumerator => new ShellItemPropertyKey(new Guid("{FCAD3D3D-0858-400F-AAA3-2F66CCE2A6BC}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.FlashManufacturer -- PKEY_Photo_FlashManufacturer</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {AABAF6C9-E0C5-4709-8585-57B103E584FE}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey FlashManufacturer => new ShellItemPropertyKey(new Guid("{AABAF6C9-E0C5-4709-8585-57B103E584FE}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.FlashModel -- PKEY_Photo_FlashModel</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {FE83BB35-4D1A-42E2-916B-06F3E1AF719E}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey FlashModel => new ShellItemPropertyKey(new Guid("{FE83BB35-4D1A-42E2-916B-06F3E1AF719E}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.FlashText -- PKEY_Photo_FlashText</para>
            /// <para>Description: This is the user-friendly form of System.Photo.Flash.  Not intended to be parsed
            ///programmatically.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {6B8B68F6-200B-47EA-8D25-D8050F57339F}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey FlashText => new ShellItemPropertyKey(new Guid("{6B8B68F6-200B-47EA-8D25-D8050F57339F}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.FNumber -- PKEY_Photo_FNumber</para>
            /// <para>Description: PropertyTagExifFNumber.  Calculated from PKEY_Photo_FNumberNumerator and PKEY_Photo_FNumberDenominator
            ///</para>
            /// <para>Type:     Double -- VT_R8</para>
            /// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 33437</para>
            /// </summary>
            public static ShellItemPropertyKey FNumber => new ShellItemPropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 33437);

            /// <summary>
            /// <para>Name:     System.Photo.FNumberDenominator -- PKEY_Photo_FNumberDenominator</para>
            /// <para>Description: Denominator of PKEY_Photo_FNumber
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {E92A2496-223B-4463-A4E3-30EABBA79D80}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey FNumberDenominator => new ShellItemPropertyKey(new Guid("{E92A2496-223B-4463-A4E3-30EABBA79D80}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.FNumberNumerator -- PKEY_Photo_FNumberNumerator</para>
            /// <para>Description: Numerator of PKEY_Photo_FNumber
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {1B97738A-FDFC-462F-9D93-1957E08BE90C}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey FNumberNumerator => new ShellItemPropertyKey(new Guid("{1B97738A-FDFC-462F-9D93-1957E08BE90C}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.FocalLength -- PKEY_Photo_FocalLength</para>
            /// <para>Description: PropertyTagExifFocalLength.  Calculated from PKEY_Photo_FocalLengthNumerator and PKEY_Photo_FocalLengthDenominator
            ///</para>
            /// <para>Type:     Double -- VT_R8</para>
            /// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 37386</para>
            /// </summary>
            public static ShellItemPropertyKey FocalLength => new ShellItemPropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 37386);

            /// <summary>
            /// <para>Name:     System.Photo.FocalLengthDenominator -- PKEY_Photo_FocalLengthDenominator</para>
            /// <para>Description: Denominator of PKEY_Photo_FocalLength
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {305BC615-DCA1-44A5-9FD4-10C0BA79412E}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey FocalLengthDenominator => new ShellItemPropertyKey(new Guid("{305BC615-DCA1-44A5-9FD4-10C0BA79412E}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.FocalLengthInFilm -- PKEY_Photo_FocalLengthInFilm</para>
            /// <para>Description:</para>
            /// <para>Type:     UInt16 -- VT_UI2</para>
            /// <para>FormatID: {A0E74609-B84D-4F49-B860-462BD9971F98}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey FocalLengthInFilm => new ShellItemPropertyKey(new Guid("{A0E74609-B84D-4F49-B860-462BD9971F98}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.FocalLengthNumerator -- PKEY_Photo_FocalLengthNumerator</para>
            /// <para>Description: Numerator of PKEY_Photo_FocalLength
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {776B6B3B-1E3D-4B0C-9A0E-8FBAF2A8492A}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey FocalLengthNumerator => new ShellItemPropertyKey(new Guid("{776B6B3B-1E3D-4B0C-9A0E-8FBAF2A8492A}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.FocalPlaneXResolution -- PKEY_Photo_FocalPlaneXResolution</para>
            /// <para>Description: PropertyTagExifFocalXRes.  Calculated from PKEY_Photo_FocalPlaneXResolutionNumerator and
            ///PKEY_Photo_FocalPlaneXResolutionDenominator.
            ///</para>
            /// <para>Type:     Double -- VT_R8</para>
            /// <para>FormatID: {CFC08D97-C6F7-4484-89DD-EBEF4356FE76}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey FocalPlaneXResolution => new ShellItemPropertyKey(new Guid("{CFC08D97-C6F7-4484-89DD-EBEF4356FE76}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.FocalPlaneXResolutionDenominator -- PKEY_Photo_FocalPlaneXResolutionDenominator</para>
            /// <para>Description: Denominator of PKEY_Photo_FocalPlaneXResolution
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {0933F3F5-4786-4F46-A8E8-D64DD37FA521}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey FocalPlaneXResolutionDenominator => new ShellItemPropertyKey(new Guid("{0933F3F5-4786-4F46-A8E8-D64DD37FA521}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.FocalPlaneXResolutionNumerator -- PKEY_Photo_FocalPlaneXResolutionNumerator</para>
            /// <para>Description: Numerator of PKEY_Photo_FocalPlaneXResolution
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {DCCB10AF-B4E2-4B88-95F9-031B4D5AB490}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey FocalPlaneXResolutionNumerator => new ShellItemPropertyKey(new Guid("{DCCB10AF-B4E2-4B88-95F9-031B4D5AB490}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.FocalPlaneYResolution -- PKEY_Photo_FocalPlaneYResolution</para>
            /// <para>Description: PropertyTagExifFocalYRes.  Calculated from PKEY_Photo_FocalPlaneYResolutionNumerator and
            ///PKEY_Photo_FocalPlaneYResolutionDenominator.
            ///</para>
            /// <para>Type:     Double -- VT_R8</para>
            /// <para>FormatID: {4FFFE4D0-914F-4AC4-8D6F-C9C61DE169B1}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey FocalPlaneYResolution => new ShellItemPropertyKey(new Guid("{4FFFE4D0-914F-4AC4-8D6F-C9C61DE169B1}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.FocalPlaneYResolutionDenominator -- PKEY_Photo_FocalPlaneYResolutionDenominator</para>
            /// <para>Description: Denominator of PKEY_Photo_FocalPlaneYResolution
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {1D6179A6-A876-4031-B013-3347B2B64DC8}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey FocalPlaneYResolutionDenominator => new ShellItemPropertyKey(new Guid("{1D6179A6-A876-4031-B013-3347B2B64DC8}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.FocalPlaneYResolutionNumerator -- PKEY_Photo_FocalPlaneYResolutionNumerator</para>
            /// <para>Description: Numerator of PKEY_Photo_FocalPlaneYResolution
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {A2E541C5-4440-4BA8-867E-75CFC06828CD}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey FocalPlaneYResolutionNumerator => new ShellItemPropertyKey(new Guid("{A2E541C5-4440-4BA8-867E-75CFC06828CD}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.GainControl -- PKEY_Photo_GainControl</para>
            /// <para>Description: This indicates the degree of overall image gain adjustment.
            ///
            ///Calculated from PKEY_Photo_GainControlNumerator and PKEY_Photo_GainControlDenominator.
            ///</para>
            /// <para>Type:     Double -- VT_R8</para>
            /// <para>FormatID: {FA304789-00C7-4D80-904A-1E4DCC7265AA}, 100 (PropertyTagExifGainControl)</para>
            /// </summary>
            public static ShellItemPropertyKey GainControl => new ShellItemPropertyKey(new Guid("{FA304789-00C7-4D80-904A-1E4DCC7265AA}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.GainControlDenominator -- PKEY_Photo_GainControlDenominator</para>
            /// <para>Description: Denominator of PKEY_Photo_GainControl
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {42864DFD-9DA4-4F77-BDED-4AAD7B256735}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey GainControlDenominator => new ShellItemPropertyKey(new Guid("{42864DFD-9DA4-4F77-BDED-4AAD7B256735}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.GainControlNumerator -- PKEY_Photo_GainControlNumerator</para>
            /// <para>Description: Numerator of PKEY_Photo_GainControl
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {8E8ECF7C-B7B8-4EB8-A63F-0EE715C96F9E}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey GainControlNumerator => new ShellItemPropertyKey(new Guid("{8E8ECF7C-B7B8-4EB8-A63F-0EE715C96F9E}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.GainControlText -- PKEY_Photo_GainControlText</para>
            /// <para>Description: This is the user-friendly form of System.Photo.GainControl.  Not intended to be parsed
            ///programmatically.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {C06238B2-0BF9-4279-A723-25856715CB9D}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey GainControlText => new ShellItemPropertyKey(new Guid("{C06238B2-0BF9-4279-A723-25856715CB9D}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.ISOSpeed -- PKEY_Photo_ISOSpeed</para>
            /// <para>Description: PropertyTagExifISOSpeed
            ///</para>
            /// <para>Type:     UInt16 -- VT_UI2</para>
            /// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 34855</para>
            /// </summary>
            public static ShellItemPropertyKey ISOSpeed => new ShellItemPropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 34855);

            /// <summary>
            /// <para>Name:     System.Photo.LensManufacturer -- PKEY_Photo_LensManufacturer</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {E6DDCAF7-29C5-4F0A-9A68-D19412EC7090}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey LensManufacturer => new ShellItemPropertyKey(new Guid("{E6DDCAF7-29C5-4F0A-9A68-D19412EC7090}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.LensModel -- PKEY_Photo_LensModel</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {E1277516-2B5F-4869-89B1-2E585BD38B7A}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey LensModel => new ShellItemPropertyKey(new Guid("{E1277516-2B5F-4869-89B1-2E585BD38B7A}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.LightSource -- PKEY_Photo_LightSource</para>
            /// <para>Description: PropertyTagExifLightSource
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 37384</para>
            /// </summary>
            public static ShellItemPropertyKey LightSource => new ShellItemPropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 37384);

            /// <summary>
            /// <para>Name:     System.Photo.MakerNote -- PKEY_Photo_MakerNote</para>
            /// <para>Description:</para>
            /// <para>Type:     Buffer -- VT_VECTOR | VT_UI1 (For variants: VT_ARRAY | VT_UI1)</para>
            /// <para>FormatID: {FA303353-B659-4052-85E9-BCAC79549B84}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey MakerNote => new ShellItemPropertyKey(new Guid("{FA303353-B659-4052-85E9-BCAC79549B84}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.MakerNoteOffset -- PKEY_Photo_MakerNoteOffset</para>
            /// <para>Description:</para>
            /// <para>Type:     UInt64 -- VT_UI8</para>
            /// <para>FormatID: {813F4124-34E6-4D17-AB3E-6B1F3C2247A1}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey MakerNoteOffset => new ShellItemPropertyKey(new Guid("{813F4124-34E6-4D17-AB3E-6B1F3C2247A1}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.MaxAperture -- PKEY_Photo_MaxAperture</para>
            /// <para>Description: Calculated from PKEY_Photo_MaxApertureNumerator and PKEY_Photo_MaxApertureDenominator
            ///</para>
            /// <para>Type:     Double -- VT_R8</para>
            /// <para>FormatID: {08F6D7C2-E3F2-44FC-AF1E-5AA5C81A2D3E}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey MaxAperture => new ShellItemPropertyKey(new Guid("{08F6D7C2-E3F2-44FC-AF1E-5AA5C81A2D3E}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.MaxApertureDenominator -- PKEY_Photo_MaxApertureDenominator</para>
            /// <para>Description: Denominator of PKEY_Photo_MaxAperture
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {C77724D4-601F-46C5-9B89-C53F93BCEB77}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey MaxApertureDenominator => new ShellItemPropertyKey(new Guid("{C77724D4-601F-46C5-9B89-C53F93BCEB77}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.MaxApertureNumerator -- PKEY_Photo_MaxApertureNumerator</para>
            /// <para>Description: Numerator of PKEY_Photo_MaxAperture
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {C107E191-A459-44C5-9AE6-B952AD4B906D}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey MaxApertureNumerator => new ShellItemPropertyKey(new Guid("{C107E191-A459-44C5-9AE6-B952AD4B906D}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.MeteringMode -- PKEY_Photo_MeteringMode</para>
            /// <para>Description: PropertyTagExifMeteringMode
            ///</para>
            /// <para>Type:     UInt16 -- VT_UI2</para>
            /// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 37383</para>
            /// </summary>
            public static ShellItemPropertyKey MeteringMode => new ShellItemPropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 37383);

            /// <summary>
            /// <para>Name:     System.Photo.MeteringModeText -- PKEY_Photo_MeteringModeText</para>
            /// <para>Description: This is the user-friendly form of System.Photo.MeteringMode.  Not intended to be parsed
            ///programmatically.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {F628FD8C-7BA8-465A-A65B-C5AA79263A9E}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey MeteringModeText => new ShellItemPropertyKey(new Guid("{F628FD8C-7BA8-465A-A65B-C5AA79263A9E}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.Orientation -- PKEY_Photo_Orientation</para>
            /// <para>Description: This is the image orientation viewed in terms of rows and columns.
            ///</para>
            /// <para>Type:     UInt16 -- VT_UI2</para>
            /// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 274 (PropertyTagOrientation)</para>
            /// </summary>
            public static ShellItemPropertyKey Orientation => new ShellItemPropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 274);

            /// <summary>
            /// <para>Name:     System.Photo.OrientationText -- PKEY_Photo_OrientationText</para>
            /// <para>Description: This is the user-friendly form of System.Photo.Orientation.  Not intended to be parsed
            ///programmatically.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {A9EA193C-C511-498A-A06B-58E2776DCC28}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey OrientationText => new ShellItemPropertyKey(new Guid("{A9EA193C-C511-498A-A06B-58E2776DCC28}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.PeopleNames -- PKEY_Photo_PeopleNames</para>
            /// <para>Description: The people tags on an image.
            ///</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)  Legacy code may treat this as VT_LPSTR.</para>
            /// <para>FormatID: {E8309B6E-084C-49B4-B1FC-90A80331B638}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey PeopleNames => new ShellItemPropertyKey(new Guid("{E8309B6E-084C-49B4-B1FC-90A80331B638}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.PhotometricInterpretation -- PKEY_Photo_PhotometricInterpretation</para>
            /// <para>Description: This is the pixel composition. In JPEG compressed data, a JPEG marker is used
            ///instead of this property.
            ///</para>
            /// <para>Type:     UInt16 -- VT_UI2</para>
            /// <para>FormatID: {341796F1-1DF9-4B1C-A564-91BDEFA43877}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey PhotometricInterpretation => new ShellItemPropertyKey(new Guid("{341796F1-1DF9-4B1C-A564-91BDEFA43877}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.PhotometricInterpretationText -- PKEY_Photo_PhotometricInterpretationText</para>
            /// <para>Description: This is the user-friendly form of System.Photo.PhotometricInterpretation.  Not intended to be parsed
            ///programmatically.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {821437D6-9EAB-4765-A589-3B1CBBD22A61}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey PhotometricInterpretationText => new ShellItemPropertyKey(new Guid("{821437D6-9EAB-4765-A589-3B1CBBD22A61}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.ProgramMode -- PKEY_Photo_ProgramMode</para>
            /// <para>Description: This is the class of the program used by the camera to set exposure when the
            ///picture is taken.
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {6D217F6D-3F6A-4825-B470-5F03CA2FBE9B}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ProgramMode => new ShellItemPropertyKey(new Guid("{6D217F6D-3F6A-4825-B470-5F03CA2FBE9B}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.ProgramModeText -- PKEY_Photo_ProgramModeText</para>
            /// <para>Description: This is the user-friendly form of System.Photo.ProgramMode.  Not intended to be parsed
            ///programmatically.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {7FE3AA27-2648-42F3-89B0-454E5CB150C3}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ProgramModeText => new ShellItemPropertyKey(new Guid("{7FE3AA27-2648-42F3-89B0-454E5CB150C3}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.RelatedSoundFile -- PKEY_Photo_RelatedSoundFile</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {318A6B45-087F-4DC2-B8CC-05359551FC9E}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey RelatedSoundFile => new ShellItemPropertyKey(new Guid("{318A6B45-087F-4DC2-B8CC-05359551FC9E}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.Saturation -- PKEY_Photo_Saturation</para>
            /// <para>Description: This indicates the direction of saturation processing applied by the camera when
            ///the image was shot.
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {49237325-A95A-4F67-B211-816B2D45D2E0}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Saturation => new ShellItemPropertyKey(new Guid("{49237325-A95A-4F67-B211-816B2D45D2E0}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.SaturationText -- PKEY_Photo_SaturationText</para>
            /// <para>Description: This is the user-friendly form of System.Photo.Saturation.  Not intended to be parsed
            ///programmatically.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {61478C08-B600-4A84-BBE4-E99C45F0A072}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey SaturationText => new ShellItemPropertyKey(new Guid("{61478C08-B600-4A84-BBE4-E99C45F0A072}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.Sharpness -- PKEY_Photo_Sharpness</para>
            /// <para>Description: This indicates the direction of sharpness processing applied by the camera when
            ///the image was shot.
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {FC6976DB-8349-4970-AE97-B3C5316A08F0}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Sharpness => new ShellItemPropertyKey(new Guid("{FC6976DB-8349-4970-AE97-B3C5316A08F0}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.SharpnessText -- PKEY_Photo_SharpnessText</para>
            /// <para>Description: This is the user-friendly form of System.Photo.Sharpness.  Not intended to be parsed
            ///programmatically.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {51EC3F47-DD50-421D-8769-334F50424B1E}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey SharpnessText => new ShellItemPropertyKey(new Guid("{51EC3F47-DD50-421D-8769-334F50424B1E}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.ShutterSpeed -- PKEY_Photo_ShutterSpeed</para>
            /// <para>Description: PropertyTagExifShutterSpeed.  Calculated from PKEY_Photo_ShutterSpeedNumerator and PKEY_Photo_ShutterSpeedDenominator
            ///</para>
            /// <para>Type:     Double -- VT_R8</para>
            /// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 37377</para>
            /// </summary>
            public static ShellItemPropertyKey ShutterSpeed => new ShellItemPropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 37377);

            /// <summary>
            /// <para>Name:     System.Photo.ShutterSpeedDenominator -- PKEY_Photo_ShutterSpeedDenominator</para>
            /// <para>Description: Denominator of PKEY_Photo_ShutterSpeed
            ///</para>
            /// <para>Type:     Int32 -- VT_I4</para>
            /// <para>FormatID: {E13D8975-81C7-4948-AE3F-37CAE11E8FF7}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ShutterSpeedDenominator => new ShellItemPropertyKey(new Guid("{E13D8975-81C7-4948-AE3F-37CAE11E8FF7}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.ShutterSpeedNumerator -- PKEY_Photo_ShutterSpeedNumerator</para>
            /// <para>Description: Numerator of PKEY_Photo_ShutterSpeed
            ///</para>
            /// <para>Type:     Int32 -- VT_I4</para>
            /// <para>FormatID: {16EA4042-D6F4-4BCA-8349-7C78D30FB333}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ShutterSpeedNumerator => new ShellItemPropertyKey(new Guid("{16EA4042-D6F4-4BCA-8349-7C78D30FB333}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.SubjectDistance -- PKEY_Photo_SubjectDistance</para>
            /// <para>Description: PropertyTagExifSubjectDist.  Calculated from PKEY_Photo_SubjectDistanceNumerator and PKEY_Photo_SubjectDistanceDenominator
            ///</para>
            /// <para>Type:     Double -- VT_R8</para>
            /// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 37382</para>
            /// </summary>
            public static ShellItemPropertyKey SubjectDistance => new ShellItemPropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 37382);

            /// <summary>
            /// <para>Name:     System.Photo.SubjectDistanceDenominator -- PKEY_Photo_SubjectDistanceDenominator</para>
            /// <para>Description: Denominator of PKEY_Photo_SubjectDistance
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {0C840A88-B043-466D-9766-D4B26DA3FA77}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey SubjectDistanceDenominator => new ShellItemPropertyKey(new Guid("{0C840A88-B043-466D-9766-D4B26DA3FA77}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.SubjectDistanceNumerator -- PKEY_Photo_SubjectDistanceNumerator</para>
            /// <para>Description: Numerator of PKEY_Photo_SubjectDistance
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {8AF4961C-F526-43E5-AA81-DB768219178D}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey SubjectDistanceNumerator => new ShellItemPropertyKey(new Guid("{8AF4961C-F526-43E5-AA81-DB768219178D}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.TagViewAggregate -- PKEY_Photo_TagViewAggregate</para>
            /// <para>Description: A read-only aggregation of tag-like properties for use in building views.
            ///</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)  Legacy code may treat this as VT_LPSTR.</para>
            /// <para>FormatID: {B812F15D-C2D8-4BBF-BACD-79744346113F}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey TagViewAggregate => new ShellItemPropertyKey(new Guid("{B812F15D-C2D8-4BBF-BACD-79744346113F}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.TranscodedForSync -- PKEY_Photo_TranscodedForSync</para>
            /// <para>Description:</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {9A8EBB75-6458-4E82-BACB-35C0095B03BB}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey TranscodedForSync => new ShellItemPropertyKey(new Guid("{9A8EBB75-6458-4E82-BACB-35C0095B03BB}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.WhiteBalance -- PKEY_Photo_WhiteBalance</para>
            /// <para>Description: This indicates the white balance mode set when the image was shot.
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {EE3D3D8A-5381-4CFA-B13B-AAF66B5F4EC9}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey WhiteBalance => new ShellItemPropertyKey(new Guid("{EE3D3D8A-5381-4CFA-B13B-AAF66B5F4EC9}"), 100);

            /// <summary>
            /// <para>Name:     System.Photo.WhiteBalanceText -- PKEY_Photo_WhiteBalanceText</para>
            /// <para>Description: This is the user-friendly form of System.Photo.WhiteBalance.  Not intended to be parsed
            ///programmatically.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {6336B95E-C7A7-426D-86FD-7AE3D39C84B4}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey WhiteBalanceText => new ShellItemPropertyKey(new Guid("{6336B95E-C7A7-426D-86FD-7AE3D39C84B4}"), 100);
        }

        /// <summary>PropGroup Properties</summary>
        public static class PropGroup
        {
            /// <summary>
            /// <para>Name:     System.PropGroup.Advanced -- PKEY_PropGroup_Advanced</para>
            /// <para>Description:</para>
            /// <para>Type:     Null -- VT_NULL</para>
            /// <para>FormatID: {900A403B-097B-4B95-8AE2-071FDAEEB118}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Advanced => new ShellItemPropertyKey(new Guid("{900A403B-097B-4B95-8AE2-071FDAEEB118}"), 100);

            /// <summary>
            /// <para>Name:     System.PropGroup.Audio -- PKEY_PropGroup_Audio</para>
            /// <para>Description:</para>
            /// <para>Type:     Null -- VT_NULL</para>
            /// <para>FormatID: {2804D469-788F-48AA-8570-71B9C187E138}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Audio => new ShellItemPropertyKey(new Guid("{2804D469-788F-48AA-8570-71B9C187E138}"), 100);

            /// <summary>
            /// <para>Name:     System.PropGroup.Calendar -- PKEY_PropGroup_Calendar</para>
            /// <para>Description:</para>
            /// <para>Type:     Null -- VT_NULL</para>
            /// <para>FormatID: {9973D2B5-BFD8-438A-BA94-5349B293181A}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Calendar => new ShellItemPropertyKey(new Guid("{9973D2B5-BFD8-438A-BA94-5349B293181A}"), 100);

            /// <summary>
            /// <para>Name:     System.PropGroup.Camera -- PKEY_PropGroup_Camera</para>
            /// <para>Description:</para>
            /// <para>Type:     Null -- VT_NULL</para>
            /// <para>FormatID: {DE00DE32-547E-4981-AD4B-542F2E9007D8}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Camera => new ShellItemPropertyKey(new Guid("{DE00DE32-547E-4981-AD4B-542F2E9007D8}"), 100);

            /// <summary>
            /// <para>Name:     System.PropGroup.Contact -- PKEY_PropGroup_Contact</para>
            /// <para>Description:</para>
            /// <para>Type:     Null -- VT_NULL</para>
            /// <para>FormatID: {DF975FD3-250A-4004-858F-34E29A3E37AA}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Contact => new ShellItemPropertyKey(new Guid("{DF975FD3-250A-4004-858F-34E29A3E37AA}"), 100);

            /// <summary>
            /// <para>Name:     System.PropGroup.Content -- PKEY_PropGroup_Content</para>
            /// <para>Description:</para>
            /// <para>Type:     Null -- VT_NULL</para>
            /// <para>FormatID: {D0DAB0BA-368A-4050-A882-6C010FD19A4F}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Content => new ShellItemPropertyKey(new Guid("{D0DAB0BA-368A-4050-A882-6C010FD19A4F}"), 100);

            /// <summary>
            /// <para>Name:     System.PropGroup.Description -- PKEY_PropGroup_Description</para>
            /// <para>Description:</para>
            /// <para>Type:     Null -- VT_NULL</para>
            /// <para>FormatID: {8969B275-9475-4E00-A887-FF93B8B41E44}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Description => new ShellItemPropertyKey(new Guid("{8969B275-9475-4E00-A887-FF93B8B41E44}"), 100);

            /// <summary>
            /// <para>Name:     System.PropGroup.FileSystem -- PKEY_PropGroup_FileSystem</para>
            /// <para>Description:</para>
            /// <para>Type:     Null -- VT_NULL</para>
            /// <para>FormatID: {E3A7D2C1-80FC-4B40-8F34-30EA111BDC2E}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey FileSystem => new ShellItemPropertyKey(new Guid("{E3A7D2C1-80FC-4B40-8F34-30EA111BDC2E}"), 100);

            /// <summary>
            /// <para>Name:     System.PropGroup.General -- PKEY_PropGroup_General</para>
            /// <para>Description:</para>
            /// <para>Type:     Null -- VT_NULL</para>
            /// <para>FormatID: {CC301630-B192-4C22-B372-9F4C6D338E07}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey General => new ShellItemPropertyKey(new Guid("{CC301630-B192-4C22-B372-9F4C6D338E07}"), 100);

            /// <summary>
            /// <para>Name:     System.PropGroup.GPS -- PKEY_PropGroup_GPS</para>
            /// <para>Description:</para>
            /// <para>Type:     Null -- VT_NULL</para>
            /// <para>FormatID: {F3713ADA-90E3-4E11-AAE5-FDC17685B9BE}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey GPS => new ShellItemPropertyKey(new Guid("{F3713ADA-90E3-4E11-AAE5-FDC17685B9BE}"), 100);

            /// <summary>
            /// <para>Name:     System.PropGroup.Image -- PKEY_PropGroup_Image</para>
            /// <para>Description:</para>
            /// <para>Type:     Null -- VT_NULL</para>
            /// <para>FormatID: {E3690A87-0FA8-4A2A-9A9F-FCE8827055AC}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Image => new ShellItemPropertyKey(new Guid("{E3690A87-0FA8-4A2A-9A9F-FCE8827055AC}"), 100);

            /// <summary>
            /// <para>Name:     System.PropGroup.Media -- PKEY_PropGroup_Media</para>
            /// <para>Description:</para>
            /// <para>Type:     Null -- VT_NULL</para>
            /// <para>FormatID: {61872CF7-6B5E-4B4B-AC2D-59DA84459248}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Media => new ShellItemPropertyKey(new Guid("{61872CF7-6B5E-4B4B-AC2D-59DA84459248}"), 100);

            /// <summary>
            /// <para>Name:     System.PropGroup.MediaAdvanced -- PKEY_PropGroup_MediaAdvanced</para>
            /// <para>Description:</para>
            /// <para>Type:     Null -- VT_NULL</para>
            /// <para>FormatID: {8859A284-DE7E-4642-99BA-D431D044B1EC}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey MediaAdvanced => new ShellItemPropertyKey(new Guid("{8859A284-DE7E-4642-99BA-D431D044B1EC}"), 100);

            /// <summary>
            /// <para>Name:     System.PropGroup.Message -- PKEY_PropGroup_Message</para>
            /// <para>Description:</para>
            /// <para>Type:     Null -- VT_NULL</para>
            /// <para>FormatID: {7FD7259D-16B4-4135-9F97-7C96ECD2FA9E}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Message => new ShellItemPropertyKey(new Guid("{7FD7259D-16B4-4135-9F97-7C96ECD2FA9E}"), 100);

            /// <summary>
            /// <para>Name:     System.PropGroup.Music -- PKEY_PropGroup_Music</para>
            /// <para>Description:</para>
            /// <para>Type:     Null -- VT_NULL</para>
            /// <para>FormatID: {68DD6094-7216-40F1-A029-43FE7127043F}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Music => new ShellItemPropertyKey(new Guid("{68DD6094-7216-40F1-A029-43FE7127043F}"), 100);

            /// <summary>
            /// <para>Name:     System.PropGroup.Origin -- PKEY_PropGroup_Origin</para>
            /// <para>Description:</para>
            /// <para>Type:     Null -- VT_NULL</para>
            /// <para>FormatID: {2598D2FB-5569-4367-95DF-5CD3A177E1A5}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Origin => new ShellItemPropertyKey(new Guid("{2598D2FB-5569-4367-95DF-5CD3A177E1A5}"), 100);

            /// <summary>
            /// <para>Name:     System.PropGroup.PhotoAdvanced -- PKEY_PropGroup_PhotoAdvanced</para>
            /// <para>Description:</para>
            /// <para>Type:     Null -- VT_NULL</para>
            /// <para>FormatID: {0CB2BF5A-9EE7-4A86-8222-F01E07FDADAF}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey PhotoAdvanced => new ShellItemPropertyKey(new Guid("{0CB2BF5A-9EE7-4A86-8222-F01E07FDADAF}"), 100);

            /// <summary>
            /// <para>Name:     System.PropGroup.RecordedTV -- PKEY_PropGroup_RecordedTV</para>
            /// <para>Description:</para>
            /// <para>Type:     Null -- VT_NULL</para>
            /// <para>FormatID: {E7B33238-6584-4170-A5C0-AC25EFD9DA56}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey RecordedTV => new ShellItemPropertyKey(new Guid("{E7B33238-6584-4170-A5C0-AC25EFD9DA56}"), 100);

            /// <summary>
            /// <para>Name:     System.PropGroup.Video -- PKEY_PropGroup_Video</para>
            /// <para>Description:</para>
            /// <para>Type:     Null -- VT_NULL</para>
            /// <para>FormatID: {BEBE0920-7671-4C54-A3EB-49FDDFC191EE}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Video => new ShellItemPropertyKey(new Guid("{BEBE0920-7671-4C54-A3EB-49FDDFC191EE}"), 100);
        }

        /// <summary>PropList Properties</summary>
        public static class PropList
        {
            /// <summary>
            /// <para>Name:     System.PropList.ConflictPrompt -- PKEY_PropList_ConflictPrompt</para>
            /// <para>Description: The list of properties to show in the file operation conflict resolution dialog. Properties with empty
            ///values will not be displayed. Register under the regvalue of "ConflictPrompt".
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {C9944A21-A406-48FE-8225-AEC7E24C211B}, 11</para>
            /// </summary>
            public static ShellItemPropertyKey ConflictPrompt => new ShellItemPropertyKey(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 11);

            /// <summary>
            /// <para>Name:     System.PropList.ContentViewModeForBrowse -- PKEY_PropList_ContentViewModeForBrowse</para>
            /// <para>Description: The list of properties to show in the content view mode of an item in the context of browsing.
            ///Register the regvalue under the name of "ContentViewModeForBrowse".
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {C9944A21-A406-48FE-8225-AEC7E24C211B}, 13</para>
            /// </summary>
            public static ShellItemPropertyKey ContentViewModeForBrowse => new ShellItemPropertyKey(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 13);

            /// <summary>
            /// <para>Name:     System.PropList.ContentViewModeForSearch -- PKEY_PropList_ContentViewModeForSearch</para>
            /// <para>Description: The list of properties to show in the content view mode of an item in the context of searching.
            ///Register the regvalue under the name of "ContentViewModeForSearch".
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {C9944A21-A406-48FE-8225-AEC7E24C211B}, 14</para>
            /// </summary>
            public static ShellItemPropertyKey ContentViewModeForSearch => new ShellItemPropertyKey(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 14);

            /// <summary>
            /// <para>Name:     System.PropList.ExtendedTileInfo -- PKEY_PropList_ExtendedTileInfo</para>
            /// <para>Description: The list of properties to show in the listview on extended tiles. Register under the regvalue of
            ///"ExtendedTileInfo".
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {C9944A21-A406-48FE-8225-AEC7E24C211B}, 9</para>
            /// </summary>
            public static ShellItemPropertyKey ExtendedTileInfo => new ShellItemPropertyKey(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 9);

            /// <summary>
            /// <para>Name:     System.PropList.FileOperationPrompt -- PKEY_PropList_FileOperationPrompt</para>
            /// <para>Description: The list of properties to show in the file operation confirmation dialog. Properties with empty values
            ///will not be displayed. If this list is not specified, then the InfoTip property list is used instead.
            ///Register under the regvalue of "FileOperationPrompt".
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {C9944A21-A406-48FE-8225-AEC7E24C211B}, 10</para>
            /// </summary>
            public static ShellItemPropertyKey FileOperationPrompt => new ShellItemPropertyKey(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 10);

            /// <summary>
            /// <para>Name:     System.PropList.FullDetails -- PKEY_PropList_FullDetails</para>
            /// <para>Description: The list of all the properties to show in the details page.  Property groups can be included in this list
            ///in order to more easily organize the UI.  Register under the regvalue of "FullDetails".
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {C9944A21-A406-48FE-8225-AEC7E24C211B}, 2</para>
            /// </summary>
            public static ShellItemPropertyKey FullDetails => new ShellItemPropertyKey(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 2);

            /// <summary>
            /// <para>Name:     System.PropList.InfoTip -- PKEY_PropList_InfoTip</para>
            /// <para>Description: The list of properties to show in the infotip. Properties with empty values will not be displayed. Register
            ///under the regvalue of "InfoTip".
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {C9944A21-A406-48FE-8225-AEC7E24C211B}, 4 (PID_PROPLIST_INFOTIP)</para>
            /// </summary>
            public static ShellItemPropertyKey InfoTip => new ShellItemPropertyKey(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 4);

            /// <summary>
            /// <para>Name:     System.PropList.NonPersonal -- PKEY_PropList_NonPersonal</para>
            /// <para>Description: The list of properties that are considered 'non-personal'. When told to remove all non-personal properties
            ///from a given file, the system will leave these particular properties untouched. Register under the regvalue
            ///of "NonPersonal".
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {49D1091F-082E-493F-B23F-D2308AA9668C}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey NonPersonal => new ShellItemPropertyKey(new Guid("{49D1091F-082E-493F-B23F-D2308AA9668C}"), 100);

            /// <summary>
            /// <para>Name:     System.PropList.PreviewDetails -- PKEY_PropList_PreviewDetails</para>
            /// <para>Description: The list of properties to display in the preview pane.  Register under the regvalue of "PreviewDetails".
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {C9944A21-A406-48FE-8225-AEC7E24C211B}, 8</para>
            /// </summary>
            public static ShellItemPropertyKey PreviewDetails => new ShellItemPropertyKey(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 8);

            /// <summary>
            /// <para>Name:     System.PropList.PreviewTitle -- PKEY_PropList_PreviewTitle</para>
            /// <para>Description: The one or two properties to display in the preview pane title section.  The optional second property is
            ///displayed as a subtitle.  Register under the regvalue of "PreviewTitle".
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {C9944A21-A406-48FE-8225-AEC7E24C211B}, 6</para>
            /// </summary>
            public static ShellItemPropertyKey PreviewTitle => new ShellItemPropertyKey(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 6);

            /// <summary>
            /// <para>Name:     System.PropList.QuickTip -- PKEY_PropList_QuickTip</para>
            /// <para>Description: The list of properties to show in the infotip when the item is on a slow network. Properties with empty
            ///values will not be displayed. Register under the regvalue of "QuickTip".
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {C9944A21-A406-48FE-8225-AEC7E24C211B}, 5 (PID_PROPLIST_QUICKTIP)</para>
            /// </summary>
            public static ShellItemPropertyKey QuickTip => new ShellItemPropertyKey(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 5);

            /// <summary>
            /// <para>Name:     System.PropList.TileInfo -- PKEY_PropList_TileInfo</para>
            /// <para>Description: The list of properties to show in the listview on tiles. Register under the regvalue of "TileInfo".
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {C9944A21-A406-48FE-8225-AEC7E24C211B}, 3 (PID_PROPLIST_TILEINFO)</para>
            /// </summary>
            public static ShellItemPropertyKey TileInfo => new ShellItemPropertyKey(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 3);

            /// <summary>
            /// <para>Name:     System.PropList.XPDetailsPanel -- PKEY_PropList_XPDetailsPanel</para>
            /// <para>Description: The list of properties to display in the XP webview details panel. Obsolete.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (FMTID_WebView) {F2275470-F782-4291-BD94-F13693513AEC}, 0 (PID_DISPLAY_PROPERTIES)</para>
            /// </summary>
            public static ShellItemPropertyKey XPDetailsPanel => new ShellItemPropertyKey(new Guid("{F2275470-F782-4291-BD94-F13693513AEC}"), 0);
        }

        /// <summary>RecordedTV Properties</summary>
        public static class RecordedTV
        {
            /// <summary>
            /// <para>Name:     System.RecordedTV.ChannelNumber -- PKEY_RecordedTV_ChannelNumber</para>
            /// <para>Description: Example: 42
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {6D748DE2-8D38-4CC3-AC60-F009B057C557}, 7</para>
            /// </summary>
            public static ShellItemPropertyKey ChannelNumber => new ShellItemPropertyKey(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 7);

            /// <summary>
            /// <para>Name:     System.RecordedTV.Credits -- PKEY_RecordedTV_Credits</para>
            /// <para>Description: Example: "Don Messick/Frank Welker/Casey Kasem/Heather North/Nicole Jaffe;;;"
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {6D748DE2-8D38-4CC3-AC60-F009B057C557}, 4</para>
            /// </summary>
            public static ShellItemPropertyKey Credits => new ShellItemPropertyKey(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 4);

            /// <summary>
            /// <para>Name:     System.RecordedTV.DateContentExpires -- PKEY_RecordedTV_DateContentExpires</para>
            /// <para>Description:</para>
            /// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
            /// <para>FormatID: {6D748DE2-8D38-4CC3-AC60-F009B057C557}, 15</para>
            /// </summary>
            public static ShellItemPropertyKey DateContentExpires => new ShellItemPropertyKey(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 15);

            /// <summary>
            /// <para>Name:     System.RecordedTV.EpisodeName -- PKEY_RecordedTV_EpisodeName</para>
            /// <para>Description: Example: "Nowhere to Hyde"
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {6D748DE2-8D38-4CC3-AC60-F009B057C557}, 2</para>
            /// </summary>
            public static ShellItemPropertyKey EpisodeName => new ShellItemPropertyKey(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 2);

            /// <summary>
            /// <para>Name:     System.RecordedTV.IsATSCContent -- PKEY_RecordedTV_IsATSCContent</para>
            /// <para>Description:</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {6D748DE2-8D38-4CC3-AC60-F009B057C557}, 16</para>
            /// </summary>
            public static ShellItemPropertyKey IsATSCContent => new ShellItemPropertyKey(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 16);

            /// <summary>
            /// <para>Name:     System.RecordedTV.IsClosedCaptioningAvailable -- PKEY_RecordedTV_IsClosedCaptioningAvailable</para>
            /// <para>Description:</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {6D748DE2-8D38-4CC3-AC60-F009B057C557}, 12</para>
            /// </summary>
            public static ShellItemPropertyKey IsClosedCaptioningAvailable => new ShellItemPropertyKey(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 12);

            /// <summary>
            /// <para>Name:     System.RecordedTV.IsDTVContent -- PKEY_RecordedTV_IsDTVContent</para>
            /// <para>Description:</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {6D748DE2-8D38-4CC3-AC60-F009B057C557}, 17</para>
            /// </summary>
            public static ShellItemPropertyKey IsDTVContent => new ShellItemPropertyKey(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 17);

            /// <summary>
            /// <para>Name:     System.RecordedTV.IsHDContent -- PKEY_RecordedTV_IsHDContent</para>
            /// <para>Description:</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {6D748DE2-8D38-4CC3-AC60-F009B057C557}, 18</para>
            /// </summary>
            public static ShellItemPropertyKey IsHDContent => new ShellItemPropertyKey(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 18);

            /// <summary>
            /// <para>Name:     System.RecordedTV.IsRepeatBroadcast -- PKEY_RecordedTV_IsRepeatBroadcast</para>
            /// <para>Description:</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {6D748DE2-8D38-4CC3-AC60-F009B057C557}, 13</para>
            /// </summary>
            public static ShellItemPropertyKey IsRepeatBroadcast => new ShellItemPropertyKey(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 13);

            /// <summary>
            /// <para>Name:     System.RecordedTV.IsSAP -- PKEY_RecordedTV_IsSAP</para>
            /// <para>Description:</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {6D748DE2-8D38-4CC3-AC60-F009B057C557}, 14</para>
            /// </summary>
            public static ShellItemPropertyKey IsSAP => new ShellItemPropertyKey(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 14);

            /// <summary>
            /// <para>Name:     System.RecordedTV.NetworkAffiliation -- PKEY_RecordedTV_NetworkAffiliation</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {2C53C813-FB63-4E22-A1AB-0B331CA1E273}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey NetworkAffiliation => new ShellItemPropertyKey(new Guid("{2C53C813-FB63-4E22-A1AB-0B331CA1E273}"), 100);

            /// <summary>
            /// <para>Name:     System.RecordedTV.OriginalBroadcastDate -- PKEY_RecordedTV_OriginalBroadcastDate</para>
            /// <para>Description:</para>
            /// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
            /// <para>FormatID: {4684FE97-8765-4842-9C13-F006447B178C}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey OriginalBroadcastDate => new ShellItemPropertyKey(new Guid("{4684FE97-8765-4842-9C13-F006447B178C}"), 100);

            /// <summary>
            /// <para>Name:     System.RecordedTV.ProgramDescription -- PKEY_RecordedTV_ProgramDescription</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {6D748DE2-8D38-4CC3-AC60-F009B057C557}, 3</para>
            /// </summary>
            public static ShellItemPropertyKey ProgramDescription => new ShellItemPropertyKey(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 3);

            /// <summary>
            /// <para>Name:     System.RecordedTV.RecordingTime -- PKEY_RecordedTV_RecordingTime</para>
            /// <para>Description:</para>
            /// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
            /// <para>FormatID: {A5477F61-7A82-4ECA-9DDE-98B69B2479B3}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey RecordingTime => new ShellItemPropertyKey(new Guid("{A5477F61-7A82-4ECA-9DDE-98B69B2479B3}"), 100);

            /// <summary>
            /// <para>Name:     System.RecordedTV.StationCallSign -- PKEY_RecordedTV_StationCallSign</para>
            /// <para>Description: Example: "TOONP"
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {6D748DE2-8D38-4CC3-AC60-F009B057C557}, 5</para>
            /// </summary>
            public static ShellItemPropertyKey StationCallSign => new ShellItemPropertyKey(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 5);

            /// <summary>
            /// <para>Name:     System.RecordedTV.StationName -- PKEY_RecordedTV_StationName</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {1B5439E7-EBA1-4AF8-BDD7-7AF1D4549493}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey StationName => new ShellItemPropertyKey(new Guid("{1B5439E7-EBA1-4AF8-BDD7-7AF1D4549493}"), 100);
        }

        /// <summary>Search Properties</summary>
        public static class Search
        {
            /// <summary>
            /// <para>Name:     System.Search.AutoSummary -- PKEY_Search_AutoSummary</para>
            /// <para>Description: General Summary of the document.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {560C36C0-503A-11CF-BAA1-00004C752A9A}, 2</para>
            /// </summary>
            public static ShellItemPropertyKey AutoSummary => new ShellItemPropertyKey(new Guid("{560C36C0-503A-11CF-BAA1-00004C752A9A}"), 2);

            /// <summary>
            /// <para>Name:     System.Search.ContainerHash -- PKEY_Search_ContainerHash</para>
            /// <para>Description: Hash code used to identify attachments to be deleted based on a common container url
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {BCEEE283-35DF-4D53-826A-F36A3EEFC6BE}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ContainerHash => new ShellItemPropertyKey(new Guid("{BCEEE283-35DF-4D53-826A-F36A3EEFC6BE}"), 100);

            /// <summary>
            /// <para>Name:     System.Search.Contents -- PKEY_Search_Contents</para>
            /// <para>Description: The contents of the item. This property is for query restrictions only; it cannot be retrieved in a
            ///query result. The Indexing Service friendly name is 'contents'.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (FMTID_Storage) {B725F130-47EF-101A-A5F1-02608C9EEBAC}, 19 (PID_STG_CONTENTS)</para>
            /// </summary>
            public static ShellItemPropertyKey Contents => new ShellItemPropertyKey(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 19);

            /// <summary>
            /// <para>Name:     System.Search.EntryID -- PKEY_Search_EntryID</para>
            /// <para>Description: The entry ID for an item within a given catalog in the Windows Search Index.
            ///This value may be recycled, and therefore is not considered unique over time.
            ///</para>
            /// <para>Type:     Int32 -- VT_I4</para>
            /// <para>FormatID: (FMTID_Query) {49691C90-7E17-101A-A91C-08002B2ECDA9}, 5 (PROPID_QUERY_WORKID)</para>
            /// </summary>
            public static ShellItemPropertyKey EntryID => new ShellItemPropertyKey(new Guid("{49691C90-7E17-101A-A91C-08002B2ECDA9}"), 5);

            /// <summary>
            /// <para>Name:     System.Search.ExtendedProperties -- PKEY_Search_ExtendedProperties</para>
            /// <para>Description:</para>
            /// <para>Type:     Blob -- VT_BLOB</para>
            /// <para>FormatID: {7B03B546-FA4F-4A52-A2FE-03D5311E5865}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey ExtendedProperties => new ShellItemPropertyKey(new Guid("{7B03B546-FA4F-4A52-A2FE-03D5311E5865}"), 100);

            /// <summary>
            /// <para>Name:     System.Search.GatherTime -- PKEY_Search_GatherTime</para>
            /// <para>Description: The Datetime that the Windows Search Gatherer process last pushed properties of this document to the Windows Search Gatherer Plugins.
            ///</para>
            /// <para>Type:     DateTime -- VT_FILETIME  (For variants: VT_DATE)</para>
            /// <para>FormatID: {0B63E350-9CCC-11D0-BCDB-00805FCCCE04}, 8</para>
            /// </summary>
            public static ShellItemPropertyKey GatherTime => new ShellItemPropertyKey(new Guid("{0B63E350-9CCC-11D0-BCDB-00805FCCCE04}"), 8);

            /// <summary>
            /// <para>Name:     System.Search.HitCount -- PKEY_Search_HitCount</para>
            /// <para>Description: When using CONTAINS over the Windows Search Index, this is the number of matches of the term.
            ///If there are multiple CONTAINS, an AND computes the min number of hits and an OR the max number of hits.
            ///</para>
            /// <para>Type:     Int32 -- VT_I4</para>
            /// <para>FormatID: (FMTID_Query) {49691C90-7E17-101A-A91C-08002B2ECDA9}, 4 (PROPID_QUERY_HITCOUNT)</para>
            /// </summary>
            public static ShellItemPropertyKey HitCount => new ShellItemPropertyKey(new Guid("{49691C90-7E17-101A-A91C-08002B2ECDA9}"), 4);

            /// <summary>
            /// <para>Name:     System.Search.IsClosedDirectory -- PKEY_Search_IsClosedDirectory</para>
            /// <para>Description: If this property is emitted with a value of TRUE, then it indicates that this URL's last modified time applies to all of it's children, and if this URL is deleted then all of it's children are deleted as well.  For example, this would be emitted as TRUE when emitting the URL of an email so that all attachments are tied to the last modified time of that email.
            ///</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {0B63E343-9CCC-11D0-BCDB-00805FCCCE04}, 23</para>
            /// </summary>
            public static ShellItemPropertyKey IsClosedDirectory => new ShellItemPropertyKey(new Guid("{0B63E343-9CCC-11D0-BCDB-00805FCCCE04}"), 23);

            /// <summary>
            /// <para>Name:     System.Search.IsFullyContained -- PKEY_Search_IsFullyContained</para>
            /// <para>Description: Any child URL of a URL which has System.Search.IsClosedDirectory=TRUE must emit System.Search.IsFullyContained=TRUE.  This ensures that the URL is not deleted at the end of a crawl because it hasn't been visited (which is the normal mechanism for detecting deletes).  For example an email attachment would emit this property
            ///</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {0B63E343-9CCC-11D0-BCDB-00805FCCCE04}, 24</para>
            /// </summary>
            public static ShellItemPropertyKey IsFullyContained => new ShellItemPropertyKey(new Guid("{0B63E343-9CCC-11D0-BCDB-00805FCCCE04}"), 24);

            /// <summary>
            /// <para>Name:     System.Search.QueryFocusedSummary -- PKEY_Search_QueryFocusedSummary</para>
            /// <para>Description: Query Focused Summary of the document.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {560C36C0-503A-11CF-BAA1-00004C752A9A}, 3</para>
            /// </summary>
            public static ShellItemPropertyKey QueryFocusedSummary => new ShellItemPropertyKey(new Guid("{560C36C0-503A-11CF-BAA1-00004C752A9A}"), 3);

            /// <summary>
            /// <para>Name:     System.Search.QueryFocusedSummaryWithFallback -- PKEY_Search_QueryFocusedSummaryWithFallback</para>
            /// <para>Description: Query Focused Summary of the document, if none is available it returns the AutoSummary.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {560C36C0-503A-11CF-BAA1-00004C752A9A}, 4</para>
            /// </summary>
            public static ShellItemPropertyKey QueryFocusedSummaryWithFallback => new ShellItemPropertyKey(new Guid("{560C36C0-503A-11CF-BAA1-00004C752A9A}"), 4);

            /// <summary>
            /// <para>Name:     System.Search.Rank -- PKEY_Search_Rank</para>
            /// <para>Description: Relevance rank of row. Ranges from 0-1000. Larger numbers = better matches.  Query-time only.
            ///</para>
            /// <para>Type:     Int32 -- VT_I4</para>
            /// <para>FormatID: (FMTID_Query) {49691C90-7E17-101A-A91C-08002B2ECDA9}, 3 (PROPID_QUERY_RANK)</para>
            /// </summary>
            public static ShellItemPropertyKey Rank => new ShellItemPropertyKey(new Guid("{49691C90-7E17-101A-A91C-08002B2ECDA9}"), 3);

            /// <summary>
            /// <para>Name:     System.Search.Store -- PKEY_Search_Store</para>
            /// <para>Description: The identifier for the protocol handler that produced this item. (E.g. MAPI, CSC, FILE etc.)
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {A06992B3-8CAF-4ED7-A547-B259E32AC9FC}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Store => new ShellItemPropertyKey(new Guid("{A06992B3-8CAF-4ED7-A547-B259E32AC9FC}"), 100);

            /// <summary>
            /// <para>Name:     System.Search.UrlToIndex -- PKEY_Search_UrlToIndex</para>
            /// <para>Description: This property should be emitted by a container IFilter for each child URL within the container.  The children will eventually be crawled by the indexer if they are within scope.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {0B63E343-9CCC-11D0-BCDB-00805FCCCE04}, 2</para>
            /// </summary>
            public static ShellItemPropertyKey UrlToIndex => new ShellItemPropertyKey(new Guid("{0B63E343-9CCC-11D0-BCDB-00805FCCCE04}"), 2);

            /// <summary>
            /// <para>Name:     System.Search.UrlToIndexWithModificationTime -- PKEY_Search_UrlToIndexWithModificationTime</para>
            /// <para>Description: This property is the same as System.Search.UrlToIndex except that it includes the time the URL was last modified.  This is an optimization for the indexer as it doesn't have to call back into the protocol handler to ask for this information to determine if the content needs to be indexed again.  The property is a vector with two elements, a VT_LPWSTR with the URL and a VT_FILETIME for the last modified time.
            ///</para>
            /// <para>Type:     Multivalue Any -- VT_VECTOR | VT_NULL  (For variants: VT_ARRAY | VT_NULL)</para>
            /// <para>FormatID: {0B63E343-9CCC-11D0-BCDB-00805FCCCE04}, 12</para>
            /// </summary>
            public static ShellItemPropertyKey UrlToIndexWithModificationTime => new ShellItemPropertyKey(new Guid("{0B63E343-9CCC-11D0-BCDB-00805FCCCE04}"), 12);
        }

        /// <summary>Shell Properties</summary>
        public static class Shell
        {
            /// <summary>
            /// <para>Name:     System.Shell.OmitFromView -- PKEY_Shell_OmitFromView</para>
            /// <para>Description: Set this to a string value of 'True' to omit this item from shell views
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {DE35258C-C695-4CBC-B982-38B0AD24CED0}, 2</para>
            /// </summary>
            public static ShellItemPropertyKey OmitFromView => new ShellItemPropertyKey(new Guid("{DE35258C-C695-4CBC-B982-38B0AD24CED0}"), 2);

            /// <summary>
            /// <para>Name:     System.Shell.SFGAOFlagsStrings -- PKEY_Shell_SFGAOFlagsStrings</para>
            /// <para>Description: Expresses the SFGAO flags as string values and is used as a query optimization.
            ///</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: {D6942081-D53B-443D-AD47-5E059D9CD27A}, 2</para>
            /// </summary>
            public static ShellItemPropertyKey SFGAOFlagsStrings => new ShellItemPropertyKey(new Guid("{D6942081-D53B-443D-AD47-5E059D9CD27A}"), 2);
        }

        /// <summary>Software Properties</summary>
        public static class Software
        {
            /// <summary>
            /// <para>Name:     System.Software.DateLastUsed -- PKEY_Software_DateLastUsed</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     DateTime -- VT_FILETIME  (For variants: VT_DATE)</para>
            /// <para>FormatID: {841E4F90-FF59-4D16-8947-E81BBFFAB36D}, 16</para>
            /// </summary>
            public static ShellItemPropertyKey DateLastUsed => new ShellItemPropertyKey(new Guid("{841E4F90-FF59-4D16-8947-E81BBFFAB36D}"), 16);

            /// <summary>
            /// <para>Name:     System.Software.ProductName -- PKEY_Software_ProductName</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (PSFMTID_VERSION) {0CEF7D53-FA64-11D1-A203-0000F81FEDEE}, 7</para>
            /// </summary>
            public static ShellItemPropertyKey ProductName => new ShellItemPropertyKey(new Guid("{0CEF7D53-FA64-11D1-A203-0000F81FEDEE}"), 7);
        }

        /// <summary>Sync Properties</summary>
        public static class Sync
        {
            /// <summary>
            /// <para>Name:     System.Sync.Comments -- PKEY_Sync_Comments</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {7BD5533E-AF15-44DB-B8C8-BD6624E1D032}, 13</para>
            /// </summary>
            public static ShellItemPropertyKey Comments => new ShellItemPropertyKey(new Guid("{7BD5533E-AF15-44DB-B8C8-BD6624E1D032}"), 13);

            /// <summary>
            /// <para>Name:     System.Sync.ConflictDescription -- PKEY_Sync_ConflictDescription</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {CE50C159-2FB8-41FD-BE68-D3E042E274BC}, 4</para>
            /// </summary>
            public static ShellItemPropertyKey ConflictDescription => new ShellItemPropertyKey(new Guid("{CE50C159-2FB8-41FD-BE68-D3E042E274BC}"), 4);

            /// <summary>
            /// <para>Name:     System.Sync.ConflictFirstLocation -- PKEY_Sync_ConflictFirstLocation</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {CE50C159-2FB8-41FD-BE68-D3E042E274BC}, 6</para>
            /// </summary>
            public static ShellItemPropertyKey ConflictFirstLocation => new ShellItemPropertyKey(new Guid("{CE50C159-2FB8-41FD-BE68-D3E042E274BC}"), 6);

            /// <summary>
            /// <para>Name:     System.Sync.ConflictSecondLocation -- PKEY_Sync_ConflictSecondLocation</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {CE50C159-2FB8-41FD-BE68-D3E042E274BC}, 7</para>
            /// </summary>
            public static ShellItemPropertyKey ConflictSecondLocation => new ShellItemPropertyKey(new Guid("{CE50C159-2FB8-41FD-BE68-D3E042E274BC}"), 7);

            /// <summary>
            /// <para>Name:     System.Sync.HandlerCollectionID -- PKEY_Sync_HandlerCollectionID</para>
            /// <para>Description:</para>
            /// <para>Type:     Guid -- VT_CLSID</para>
            /// <para>FormatID: {7BD5533E-AF15-44DB-B8C8-BD6624E1D032}, 2</para>
            /// </summary>
            public static ShellItemPropertyKey HandlerCollectionID => new ShellItemPropertyKey(new Guid("{7BD5533E-AF15-44DB-B8C8-BD6624E1D032}"), 2);

            /// <summary>
            /// <para>Name:     System.Sync.HandlerID -- PKEY_Sync_HandlerID</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {7BD5533E-AF15-44DB-B8C8-BD6624E1D032}, 3</para>
            /// </summary>
            public static ShellItemPropertyKey HandlerID => new ShellItemPropertyKey(new Guid("{7BD5533E-AF15-44DB-B8C8-BD6624E1D032}"), 3);

            /// <summary>
            /// <para>Name:     System.Sync.HandlerName -- PKEY_Sync_HandlerName</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {CE50C159-2FB8-41FD-BE68-D3E042E274BC}, 2</para>
            /// </summary>
            public static ShellItemPropertyKey HandlerName => new ShellItemPropertyKey(new Guid("{CE50C159-2FB8-41FD-BE68-D3E042E274BC}"), 2);

            /// <summary>
            /// <para>Name:     System.Sync.HandlerType -- PKEY_Sync_HandlerType</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {7BD5533E-AF15-44DB-B8C8-BD6624E1D032}, 8</para>
            /// </summary>
            public static ShellItemPropertyKey HandlerType => new ShellItemPropertyKey(new Guid("{7BD5533E-AF15-44DB-B8C8-BD6624E1D032}"), 8);

            /// <summary>
            /// <para>Name:     System.Sync.HandlerTypeLabel -- PKEY_Sync_HandlerTypeLabel</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: {7BD5533E-AF15-44DB-B8C8-BD6624E1D032}, 9</para>
            /// </summary>
            public static ShellItemPropertyKey HandlerTypeLabel => new ShellItemPropertyKey(new Guid("{7BD5533E-AF15-44DB-B8C8-BD6624E1D032}"), 9);

            /// <summary>
            /// <para>Name:     System.Sync.ItemID -- PKEY_Sync_ItemID</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {7BD5533E-AF15-44DB-B8C8-BD6624E1D032}, 6</para>
            /// </summary>
            public static ShellItemPropertyKey ItemID => new ShellItemPropertyKey(new Guid("{7BD5533E-AF15-44DB-B8C8-BD6624E1D032}"), 6);

            /// <summary>
            /// <para>Name:     System.Sync.ItemName -- PKEY_Sync_ItemName</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {CE50C159-2FB8-41FD-BE68-D3E042E274BC}, 3</para>
            /// </summary>
            public static ShellItemPropertyKey ItemName => new ShellItemPropertyKey(new Guid("{CE50C159-2FB8-41FD-BE68-D3E042E274BC}"), 3);

            /// <summary>
            /// <para>Name:     System.Sync.ProgressPercentage -- PKEY_Sync_ProgressPercentage</para>
            /// <para>Description: An integer value between 0 and 100 representing the percentage completed.
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {7BD5533E-AF15-44DB-B8C8-BD6624E1D032}, 23</para>
            /// </summary>
            public static ShellItemPropertyKey ProgressPercentage => new ShellItemPropertyKey(new Guid("{7BD5533E-AF15-44DB-B8C8-BD6624E1D032}"), 23);

            /// <summary>
            /// <para>Name:     System.Sync.State -- PKEY_Sync_State</para>
            /// <para>Description: Sync state.
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: {7BD5533E-AF15-44DB-B8C8-BD6624E1D032}, 24</para>
            /// </summary>
            public static ShellItemPropertyKey State => new ShellItemPropertyKey(new Guid("{7BD5533E-AF15-44DB-B8C8-BD6624E1D032}"), 24);

            /// <summary>
            /// <para>Name:     System.Sync.Status -- PKEY_Sync_Status</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {7BD5533E-AF15-44DB-B8C8-BD6624E1D032}, 10</para>
            /// </summary>
            public static ShellItemPropertyKey Status => new ShellItemPropertyKey(new Guid("{7BD5533E-AF15-44DB-B8C8-BD6624E1D032}"), 10);
        }

        /// <summary>Task Properties</summary>
        public static class Task
        {
            /// <summary>
            /// <para>Name:     System.Task.BillingInformation -- PKEY_Task_BillingInformation</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {D37D52C6-261C-4303-82B3-08B926AC6F12}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey BillingInformation => new ShellItemPropertyKey(new Guid("{D37D52C6-261C-4303-82B3-08B926AC6F12}"), 100);

            /// <summary>
            /// <para>Name:     System.Task.CompletionStatus -- PKEY_Task_CompletionStatus</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {084D8A0A-E6D5-40DE-BF1F-C8820E7C877C}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey CompletionStatus => new ShellItemPropertyKey(new Guid("{084D8A0A-E6D5-40DE-BF1F-C8820E7C877C}"), 100);

            /// <summary>
            /// <para>Name:     System.Task.Owner -- PKEY_Task_Owner</para>
            /// <para>Description:</para>
            /// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
            /// <para>FormatID: {08C7CC5F-60F2-4494-AD75-55E3E0B5ADD0}, 100</para>
            /// </summary>
            public static ShellItemPropertyKey Owner => new ShellItemPropertyKey(new Guid("{08C7CC5F-60F2-4494-AD75-55E3E0B5ADD0}"), 100);
        }

        /// <summary>Video Properties</summary>
        public static class Video
        {
            /// <summary>
            /// <para>Name:     System.Video.Compression -- PKEY_Video_Compression</para>
            /// <para>Description: Indicates the level of compression for the video stream.  "Compression".
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (FMTID_VideoSummaryInformation) {64440491-4C8B-11D1-8B70-080036B11A03}, 10 (PIDVSI_COMPRESSION)</para>
            /// </summary>
            public static ShellItemPropertyKey Compression => new ShellItemPropertyKey(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 10);

            /// <summary>
            /// <para>Name:     System.Video.Director -- PKEY_Video_Director</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</para>
            /// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 20 (PIDMSI_DIRECTOR)</para>
            /// </summary>
            public static ShellItemPropertyKey Director => new ShellItemPropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 20);

            /// <summary>
            /// <para>Name:     System.Video.EncodingBitrate -- PKEY_Video_EncodingBitrate</para>
            /// <para>Description: Indicates the data rate in "bits per second" for the video stream. "DataRate".
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: (FMTID_VideoSummaryInformation) {64440491-4C8B-11D1-8B70-080036B11A03}, 8 (PIDVSI_DATA_RATE)</para>
            /// </summary>
            public static ShellItemPropertyKey EncodingBitrate => new ShellItemPropertyKey(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 8);

            /// <summary>
            /// <para>Name:     System.Video.FourCC -- PKEY_Video_FourCC</para>
            /// <para>Description: Indicates the 4CC for the video stream.
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: (FMTID_VideoSummaryInformation) {64440491-4C8B-11D1-8B70-080036B11A03}, 44</para>
            /// </summary>
            public static ShellItemPropertyKey FourCC => new ShellItemPropertyKey(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 44);

            /// <summary>
            /// <para>Name:     System.Video.FrameHeight -- PKEY_Video_FrameHeight</para>
            /// <para>Description: Indicates the frame height for the video stream.
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: (FMTID_VideoSummaryInformation) {64440491-4C8B-11D1-8B70-080036B11A03}, 4</para>
            /// </summary>
            public static ShellItemPropertyKey FrameHeight => new ShellItemPropertyKey(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 4);

            /// <summary>
            /// <para>Name:     System.Video.FrameRate -- PKEY_Video_FrameRate</para>
            /// <para>Description: Indicates the frame rate in "frames per millisecond" for the video stream.  "FrameRate".
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: (FMTID_VideoSummaryInformation) {64440491-4C8B-11D1-8B70-080036B11A03}, 6 (PIDVSI_FRAME_RATE)</para>
            /// </summary>
            public static ShellItemPropertyKey FrameRate => new ShellItemPropertyKey(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 6);

            /// <summary>
            /// <para>Name:     System.Video.FrameWidth -- PKEY_Video_FrameWidth</para>
            /// <para>Description: Indicates the frame width for the video stream.
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: (FMTID_VideoSummaryInformation) {64440491-4C8B-11D1-8B70-080036B11A03}, 3</para>
            /// </summary>
            public static ShellItemPropertyKey FrameWidth => new ShellItemPropertyKey(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 3);

            /// <summary>
            /// <para>Name:     System.Video.HorizontalAspectRatio -- PKEY_Video_HorizontalAspectRatio</para>
            /// <para>Description: Indicates the horizontal portion of the aspect ratio. The X portion of XX:YY,
            ///like 16:9.
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: (FMTID_VideoSummaryInformation) {64440491-4C8B-11D1-8B70-080036B11A03}, 42</para>
            /// </summary>
            public static ShellItemPropertyKey HorizontalAspectRatio => new ShellItemPropertyKey(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 42);

            /// <summary>
            /// <para>Name:     System.Video.SampleSize -- PKEY_Video_SampleSize</para>
            /// <para>Description: Indicates the sample size in bits for the video stream.  "SampleSize".
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: (FMTID_VideoSummaryInformation) {64440491-4C8B-11D1-8B70-080036B11A03}, 9 (PIDVSI_SAMPLE_SIZE)</para>
            /// </summary>
            public static ShellItemPropertyKey SampleSize => new ShellItemPropertyKey(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 9);

            /// <summary>
            /// <para>Name:     System.Video.StreamName -- PKEY_Video_StreamName</para>
            /// <para>Description: Indicates the name for the video stream. "StreamName".
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (FMTID_VideoSummaryInformation) {64440491-4C8B-11D1-8B70-080036B11A03}, 2 (PIDVSI_STREAM_NAME)</para>
            /// </summary>
            public static ShellItemPropertyKey StreamName => new ShellItemPropertyKey(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 2);

            /// <summary>
            /// <para>Name:     System.Video.StreamNumber -- PKEY_Video_StreamNumber</para>
            /// <para>Description: "Stream Number".
            ///</para>
            /// <para>Type:     UInt16 -- VT_UI2</para>
            /// <para>FormatID: (FMTID_VideoSummaryInformation) {64440491-4C8B-11D1-8B70-080036B11A03}, 11 (PIDVSI_STREAM_NUMBER)</para>
            /// </summary>
            public static ShellItemPropertyKey StreamNumber => new ShellItemPropertyKey(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 11);

            /// <summary>
            /// <para>Name:     System.Video.TotalBitrate -- PKEY_Video_TotalBitrate</para>
            /// <para>Description: Indicates the total data rate in "bits per second" for all video and audio streams.
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: (FMTID_VideoSummaryInformation) {64440491-4C8B-11D1-8B70-080036B11A03}, 43 (PIDVSI_TOTAL_BITRATE)</para>
            /// </summary>
            public static ShellItemPropertyKey TotalBitrate => new ShellItemPropertyKey(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 43);

            /// <summary>
            /// <para>Name:     System.Video.TranscodedForSync -- PKEY_Video_TranscodedForSync</para>
            /// <para>Description:</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: (FMTID_VideoSummaryInformation) {64440491-4C8B-11D1-8B70-080036B11A03}, 46</para>
            /// </summary>
            public static ShellItemPropertyKey TranscodedForSync => new ShellItemPropertyKey(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 46);

            /// <summary>
            /// <para>Name:     System.Video.VerticalAspectRatio -- PKEY_Video_VerticalAspectRatio</para>
            /// <para>Description: Indicates the vertical portion of the aspect ratio. The Y portion of
            ///XX:YY, like 16:9.
            ///</para>
            /// <para>Type:     UInt32 -- VT_UI4</para>
            /// <para>FormatID: (FMTID_VideoSummaryInformation) {64440491-4C8B-11D1-8B70-080036B11A03}, 45</para>
            /// </summary>
            public static ShellItemPropertyKey VerticalAspectRatio => new ShellItemPropertyKey(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 45);
        }

        /// <summary>Volume Properties</summary>
        public static class Volume
        {
            /// <summary>
            /// <para>Name:     System.Volume.FileSystem -- PKEY_Volume_FileSystem</para>
            /// <para>Description: Indicates the filesystem of the volume.
            ///</para>
            /// <para>Type:     String -- VT_LPWSTR  (For variants: VT_BSTR)</para>
            /// <para>FormatID: (FMTID_Volume) {9B174B35-40FF-11D2-A27E-00C04FC30871}, 4 (PID_VOLUME_FILESYSTEM)  (Filesystem Volume Properties)</para>
            /// </summary>
            public static ShellItemPropertyKey FileSystem => new ShellItemPropertyKey(new Guid("{9B174B35-40FF-11D2-A27E-00C04FC30871}"), 4);

            /// <summary>
            /// <para>Name:     System.Volume.IsMappedDrive -- PKEY_Volume_IsMappedDrive</para>
            /// <para>Description:</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: {149C0B69-2C2D-48FC-808F-D318D78C4636}, 2</para>
            /// </summary>
            public static ShellItemPropertyKey IsMappedDrive => new ShellItemPropertyKey(new Guid("{149C0B69-2C2D-48FC-808F-D318D78C4636}"), 2);

            /// <summary>
            /// <para>Name:     System.Volume.IsRoot -- PKEY_Volume_IsRoot</para>
            /// <para>Description:
            ///</para>
            /// <para>Type:     Boolean -- VT_BOOL</para>
            /// <para>FormatID: (FMTID_Volume) {9B174B35-40FF-11D2-A27E-00C04FC30871}, 10  (Filesystem Volume Properties)</para>
            /// </summary>
            public static ShellItemPropertyKey IsRoot => new ShellItemPropertyKey(new Guid("{9B174B35-40FF-11D2-A27E-00C04FC30871}"), 10);
        }
    }

    internal static partial class NativeMethods
    {
        internal enum ADLT
        {
            RECENT,
            FREQUENT
        }

        internal enum Facility
        {
            Control = 10,
            Dispatch = 2,
            Ese = 0xe5e,
            Itf = 4,
            Null = 0,
            Rpc = 1,
            Storage = 3,
            Win32 = 7,
            Windows = 8
        }

        internal enum FDAP : uint
        {
            BOTTOM = 0,
            TOP = 1
        }

        internal enum FDEOR
        {
            DEFAULT,
            ACCEPT,
            REFUSE
        }

        internal enum FDESVR
        {
            DEFAULT,
            ACCEPT,
            REFUSE
        }

        [Flags]
        internal enum FOS : uint
        {
            ALLNONSTORAGEITEMS = 0x80,
            ALLOWMULTISELECT = 0x200,
            CREATEPROMPT = 0x2000,
            DEFAULTNOMINIMODE = 0x20000000,
            DONTADDTORECENT = 0x2000000,
            FILEMUSTEXIST = 0x1000,
            FORCEFILESYSTEM = 0x40,
            FORCEPREVIEWPANEON = 0x40000000,
            FORCESHOWHIDDEN = 0x10000000,
            HIDEMRUPLACES = 0x20000,
            HIDEPINNEDPLACES = 0x40000,
            NOCHANGEDIR = 8,
            NODEREFERENCELINKS = 0x100000,
            NOREADONLYRETURN = 0x8000,
            NOTESTFILECREATE = 0x10000,
            NOVALIDATE = 0x100,
            OVERWRITEPROMPT = 2,
            PATHMUSTEXIST = 0x800,
            PICKFOLDERS = 0x20,
            SHAREAWARE = 0x4000,
            STRICTFILETYPES = 4
        }

        [Flags]
        internal enum GPS
        {
            BESTEFFORT = 0x40,
            DEFAULT = 0,
            DELAYCREATION = 0x20,
            FASTPROPERTIESONLY = 8,
            HANDLERPROPERTIESONLY = 1,
            MASK_VALID = 0xff,
            NO_OPLOCK = 0x80,
            OPENSLOWITEM = 0x10,
            READWRITE = 2,
            TEMPORARY = 4
        }

        internal enum KDC
        {
            FREQUENT = 1,
            RECENT = 2
        }

        [Flags]
        internal enum SFGAO : uint
        {
            BROWSABLE = 0x8000000,
            CANCOPY = 1,
            CANDELETE = 0x20,
            CANLINK = 4,
            CANMONIKER = 0x400000,
            CANMOVE = 2,
            CANRENAME = 0x10,
            CAPABILITYMASK = 0x177,
            COMPRESSED = 0x4000000,
            CONTENTSMASK = 0x80000000,
            DISPLAYATTRMASK = 0xfc000,
            DROPTARGET = 0x100,
            ENCRYPTED = 0x2000,
            FILESYSANCESTOR = 0x10000000,
            FILESYSTEM = 0x40000000,
            FOLDER = 0x20000000,
            GHOSTED = 0x8000,
            HASPROPSHEET = 0x40,
            HASSTORAGE = 0x400000,
            HASSUBFOLDER = 0x80000000,
            HIDDEN = 0x80000,
            ISSLOW = 0x4000,
            LINK = 0x10000,
            NEWCONTENT = 0x200000,
            NONENUMERATED = 0x100000,
            PKEYSFGAOMASK = 0x81044000,
            READONLY = 0x40000,
            REMOVABLE = 0x2000000,
            SHARE = 0x20000,
            STORAGE = 8,
            STORAGEANCESTOR = 0x800000,
            STORAGECAPMASK = 0x70c50008,
            STREAM = 0x400000,
            SYSTEM = 0x00001000,
            VALIDATE = 0x1000000
        }

        [Flags]
        internal enum SHCONTF
        {
            CHECKING_FOR_CHILDREN = 0x10,
            ENABLE_ASYNC = 0x8000,
            FASTITEMS = 0x2000,
            FLATLIST = 0x4000,
            FOLDERS = 0x20,
            INCLUDEHIDDEN = 0x80,
            INIT_ON_FIRST_NEXT = 0x100,
            NAVIGATION_ENUM = 0x1000,
            NETPRINTERSRCH = 0x200,
            NONFOLDERS = 0x40,
            SHAREABLE = 0x400,
            STORAGE = 0x800
        }

        [Flags]
        internal enum SHGDN
        {
            SHGDN_FORADDRESSBAR = 0x4000,
            SHGDN_FOREDITING = 0x1000,
            SHGDN_FORPARSING = 0x8000,
            SHGDN_INFOLDER = 1,
            SHGDN_NORMAL = 0
        }

        internal enum SIATTRIBFLAGS
        {
            AND = 1,
            APPCOMPAT = 3,
            OR = 2
        }

        [Flags]
        internal enum SICHINT : uint
        {
            ALLFIELDS = 0x80000000,
            CANONICAL = 0x10000000,
            DISPLAY = 0,
            TEST_FILESYSPATH_IF_NOT_EQUAL = 0x20000000
        }

        internal enum SIGDN : uint
        {
            DESKTOPABSOLUTEEDITING = 0x8004c000,
            DESKTOPABSOLUTEPARSING = 0x80028000,
            FILESYSPATH = 0x80058000,
            NORMALDISPLAY = 0,
            PARENTRELATIVE = 0x80080001,
            PARENTRELATIVEEDITING = 0x80031001,
            PARENTRELATIVEFORADDRESSBAR = 0x8007c001,
            PARENTRELATIVEFORUI = 0x80094001,
            PARENTRELATIVEPARSING = 0x80018001,
            URL = 0x80068000,
        }

        [Flags]
        internal enum SLGP
        {
            RAWPATH = 4,
            SHORTPATH = 1,
            UNCPRIORITY = 2,
            RELATIVEPRIORITY = 8
        }

        [Flags]
        internal enum STPF
        {
            NONE = 0,
            USEAPPPEEKALWAYS = 4,
            USEAPPPEEKWHENACTIVE = 8,
            USEAPPTHUMBNAILALWAYS = 1,
            USEAPPTHUMBNAILWHENACTIVE = 2
        }

        [Flags]
        internal enum TBPF
        {
            ERROR = 4,
            INDETERMINATE = 1,
            NOPROGRESS = 0,
            NORMAL = 2,
            PAUSED = 8
        }

        [Flags]
        internal enum THB : uint
        {
            BITMAP = 1,
            FLAGS = 8,
            ICON = 2,
            TOOLTIP = 4
        }

        [Flags]
        internal enum THBF : uint
        {
            DISABLED = 1,
            DISMISSONCLICK = 2,
            ENABLED = 0,
            HIDDEN = 8,
            NOBACKGROUND = 4,
            NONINTERACTIVE = 0x10
        }

        // Used to remove items from the automatic destination lists created when apps or the system call
        // SHAddToRecentDocs to report usage of a document.
        /// <securitynote>Critical: Suppresses unmanaged code security.</securitynote>
        [SuppressUnmanagedCodeSecurity]
        [ComImport, Guid("12337d35-94c6-48a0-bce7-6a9c69d4d600"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IApplicationDestinations
        {
            // Set the App User Model ID for the application removing destinations from its list. If an AppID is not
            // provided via this method, the system will use a heuristically determined ID. This method must be called
            // before RemoveDestination or RemoveAllDestinations.
            void SetAppID([MarshalAs(UnmanagedType.LPWStr)] string pszAppID);

            // Remove an IShellItem or an IShellLink from the automatic destination list
            void RemoveDestination([MarshalAs(UnmanagedType.IUnknown)] object punk);

            // Clear the frequent and recent destination lists for this application.
            void RemoveAllDestinations();
        }

        /// <summary>
        /// Allows an application to retrieve the most recent and frequent documents opened in that app, as reported via SHAddToRecentDocs
        /// </summary>
        /// <securitynote>Critical: Suppresses unmanaged code security.</securitynote>
        [SuppressUnmanagedCodeSecurity]
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("3c594f9f-9f30-47a1-979a-c9e83d3d0a06")]
        internal interface IApplicationDocumentLists
        {
            /// <summary>
            /// Set the App User Model ID for the application retrieving this list. If an AppID is not provided via this
            /// method, the system will use a heuristically determined ID. This method must be called before GetList.
            /// </summary>
            /// <param name="pszAppID">App Id.</param>
            void SetAppID([MarshalAs(UnmanagedType.LPWStr)] string pszAppID);

            /// <summary>
            /// Retrieve an IEnumObjects or IObjectArray for IShellItems and/or IShellLinks. Items may appear in both the
            /// frequent and recent lists.
            /// </summary>
            /// <param name="listtype">Which of the known list types to retrieve</param>
            /// <param name="cItemsDesired">The number of items desired.</param>
            /// <param name="riid">The interface Id that the return value should be queried for.</param>
            /// <returns>A COM object based on the IID passed for the riid parameter.</returns>
            [return: MarshalAs(UnmanagedType.IUnknown)]
            object GetList(ADLT listtype, uint cItemsDesired, [In] ref Guid riid);
        }

        // Custom Destination List
        /// <securitynote>Critical: Suppresses unmanaged code security.</securitynote>
        [SuppressUnmanagedCodeSecurity]
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("6332debf-87b5-4670-90c0-5e57b408a49e")]
        internal interface ICustomDestinationList
        {
            void SetAppID([MarshalAs(UnmanagedType.LPWStr)] string pszAppID);

            // Retrieve IObjectArray of IShellItems or IShellLinks that represent removed destinations
            [return: MarshalAs(UnmanagedType.Interface)]
            object BeginList(out uint pcMaxSlots, [In] ref Guid riid);

            // PreserveSig because this will return custom errors when attempting to add unregistered ShellItems. Can't
            // readily detect that case without just trying to append it.
            [PreserveSig]
            HRESULT AppendCategory([MarshalAs(UnmanagedType.LPWStr)] string pszCategory, IObjectArray poa);

            void AppendKnownCategory(KDC category);

            [PreserveSig]
            HRESULT AddUserTasks(IObjectArray poa);

            void CommitList();

            // Retrieve IObjectCollection of IShellItems
            [return: MarshalAs(UnmanagedType.Interface)]
            object GetRemovedDestinations([In] ref Guid riid);

            void DeleteList([MarshalAs(UnmanagedType.LPWStr)] string pszAppID);

            void AbortList();
        }

        /// <securitynote>Critical: Suppresses unmanaged code security.</securitynote>
        [SuppressUnmanagedCodeSecurity]
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("000214F2-0000-0000-C000-000000000046")]
        internal interface IEnumIDList
        {
            [PreserveSig()]
            HRESULT Next(uint celt, out IntPtr rgelt, out int pceltFetched);

            [PreserveSig()]
            HRESULT Skip(uint celt);

            void Reset();

            [return: MarshalAs(UnmanagedType.Interface)]
            IEnumIDList Clone();
        }

        /// <securitynote>Critical: Suppresses unmanaged code security.</securitynote>
        [SuppressUnmanagedCodeSecurity]
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("42f85136-db7e-439c-85f1-e4075d135fc8")]
        internal interface IFileDialog : IModalWindow
        {
            [PreserveSig]
            new HRESULT Show(IntPtr parent);

            void SetFileTypes(uint cFileTypes, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] COMDLG_FILTERSPEC[] rgFilterSpec);

            void SetFileTypeIndex(uint iFileType);

            uint GetFileTypeIndex();

            uint Advise(IFileDialogEvents pfde);

            void Unadvise(uint dwCookie);

            void SetOptions(FOS fos);

            FOS GetOptions();

            void SetDefaultFolder(IShellItem psi);

            void SetFolder(IShellItem psi);

            IShellItem GetFolder();

            IShellItem GetCurrentSelection();

            void SetFileName([MarshalAs(UnmanagedType.LPWStr)] string pszName);

            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetFileName();

            void SetTitle([MarshalAs(UnmanagedType.LPWStr)] string pszTitle);

            void SetOkButtonLabel([MarshalAs(UnmanagedType.LPWStr)] string pszText);

            void SetFileNameLabel([MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

            IShellItem GetResult();

            void AddPlace(IShellItem psi, FDAP alignment);

            void SetDefaultExtension([MarshalAs(UnmanagedType.LPWStr)] string pszDefaultExtension);

            void Close([MarshalAs(UnmanagedType.Error)] int hr);

            void SetClientGuid([In] ref Guid guid);

            void ClearClientData();

            void SetFilter([MarshalAs(UnmanagedType.Interface)] object pFilter);
        }

        /// <securitynote>Critical: Suppresses unmanaged code security.</securitynote>
        [SuppressUnmanagedCodeSecurity]
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("973510DB-7D7F-452B-8975-74A85828D354")]
        internal interface IFileDialogEvents
        {
            [PreserveSig]
            HRESULT OnFileOk(IFileDialog pfd);

            [PreserveSig]
            HRESULT OnFolderChanging(IFileDialog pfd, IShellItem psiFolder);

            [PreserveSig]
            HRESULT OnFolderChange(IFileDialog pfd);

            [PreserveSig]
            HRESULT OnSelectionChange(IFileDialog pfd);

            [PreserveSig]
            HRESULT OnShareViolation(IFileDialog pfd, IShellItem psi, out FDESVR pResponse);

            [PreserveSig]
            HRESULT OnTypeChange(IFileDialog pfd);

            [PreserveSig]
            HRESULT OnOverwrite(IFileDialog pfd, IShellItem psi, out FDEOR pResponse);
        }

        /// <securitynote>Critical: Suppresses unmanaged code security.</securitynote>
        [SuppressUnmanagedCodeSecurity]
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("d57c7288-d4ad-4768-be02-9d969532d960")]
        internal interface IFileOpenDialog : IFileDialog
        {
            [PreserveSig]
            new HRESULT Show(IntPtr parent);

            new void SetFileTypes(uint cFileTypes, [In] COMDLG_FILTERSPEC[] rgFilterSpec);

            new void SetFileTypeIndex(uint iFileType);

            new uint GetFileTypeIndex();

            new uint Advise(IFileDialogEvents pfde);

            new void Unadvise(uint dwCookie);

            new void SetOptions(FOS fos);

            new FOS GetOptions();

            new void SetDefaultFolder(IShellItem psi);

            new void SetFolder(IShellItem psi);

            new IShellItem GetFolder();

            new IShellItem GetCurrentSelection();

            new void SetFileName([MarshalAs(UnmanagedType.LPWStr)] string pszName);

            [return: MarshalAs(UnmanagedType.LPWStr)]
            new void GetFileName();

            new void SetTitle([MarshalAs(UnmanagedType.LPWStr)] string pszTitle);

            new void SetOkButtonLabel([MarshalAs(UnmanagedType.LPWStr)] string pszText);

            new void SetFileNameLabel([MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

            new IShellItem GetResult();

            new void AddPlace(IShellItem psi, FDAP fdcp);

            new void SetDefaultExtension([MarshalAs(UnmanagedType.LPWStr)] string pszDefaultExtension);

            new void Close([MarshalAs(UnmanagedType.Error)] int hr);

            new void SetClientGuid([In] ref Guid guid);

            new void ClearClientData();

            new void SetFilter([MarshalAs(UnmanagedType.Interface)] object pFilter);

            IShellItemArray GetResults();

            IShellItemArray GetSelectedItems();
        }

        /// <securitynote>Critical: Suppresses unmanaged code security.</securitynote>
        [SuppressUnmanagedCodeSecurity]
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("84bccd23-5fde-4cdb-aea4-af64b83d78ab")]
        internal interface IFileSaveDialog : IFileDialog
        {
            [PreserveSig]
            new HRESULT Show(IntPtr parent);

            new void SetFileTypes(uint cFileTypes, [In] COMDLG_FILTERSPEC[] rgFilterSpec);

            new void SetFileTypeIndex(uint iFileType);

            new uint GetFileTypeIndex();

            new uint Advise(IFileDialogEvents pfde);

            new void Unadvise(uint dwCookie);

            new void SetOptions(FOS fos);

            new FOS GetOptions();

            new void SetDefaultFolder(IShellItem psi);

            new void SetFolder(IShellItem psi);

            new IShellItem GetFolder();

            new IShellItem GetCurrentSelection();

            new void SetFileName([MarshalAs(UnmanagedType.LPWStr)] string pszName);

            [return: MarshalAs(UnmanagedType.LPWStr)]
            new void GetFileName();

            new void SetTitle([MarshalAs(UnmanagedType.LPWStr)] string pszTitle);

            new void SetOkButtonLabel([MarshalAs(UnmanagedType.LPWStr)] string pszText);

            new void SetFileNameLabel([MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

            new IShellItem GetResult();

            new void AddPlace(IShellItem psi, FDAP fdcp);

            new void SetDefaultExtension([MarshalAs(UnmanagedType.LPWStr)] string pszDefaultExtension);

            new void Close([MarshalAs(UnmanagedType.Error)] int hr);

            new void SetClientGuid([In] ref Guid guid);

            new void ClearClientData();

            new void SetFilter([MarshalAs(UnmanagedType.Interface)] object pFilter);

            void SetSaveAsItem(IShellItem psi);

            void SetProperties([In, MarshalAs(UnmanagedType.Interface)] object pStore);

            void SetCollectedProperties([In, MarshalAs(UnmanagedType.Interface)] object pList, [In] int fAppendDefault);

            [return: MarshalAs(UnmanagedType.Interface)]
            object GetProperties();

            void ApplyProperties(IShellItem psi, [MarshalAs(UnmanagedType.Interface)] object pStore, [In] ref IntPtr hwnd, [MarshalAs(UnmanagedType.Interface)] object pSink);
        }

        /// <securitynote>Critical: Suppresses unmanaged code security.</securitynote>
        [SuppressUnmanagedCodeSecurity]
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("b4db1657-70d7-485e-8e3e-6fcb5a5c1802")]
        internal interface IModalWindow
        {
            [PreserveSig]
            HRESULT Show(IntPtr parent);
        }

        /// <summary>Unknown Object Array</summary>
        /// <securitynote>Critical: Suppresses unmanaged code security.</securitynote>
        [SuppressUnmanagedCodeSecurity]
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("92CA9DCD-5622-4bba-A805-5E9F541BD8C9")]
        internal interface IObjectArray
        {
            uint GetCount();

            [return: MarshalAs(UnmanagedType.IUnknown)]
            object GetAt([In] uint uiIndex, [In] ref Guid riid);
        }

        /// <securitynote>Critical: Suppresses unmanaged code security.</securitynote>
        [SuppressUnmanagedCodeSecurity]
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("92CA9DCD-5622-4bba-A805-5E9F541BD8C9")]
        internal interface IObjectCollection : IObjectArray
        {
            new uint GetCount();

            [return: MarshalAs(UnmanagedType.IUnknown)]
            new object GetAt([In] uint uiIndex, [In] ref Guid riid);

            void AddObject([MarshalAs(UnmanagedType.IUnknown)] object punk);

            void AddFromArray(IObjectArray poaSource);

            void RemoveObjectAt(uint uiIndex);

            void Clear();
        }

        /// <summary>Provides access to the App User Model ID on objects supporting this value.</summary>
        /// <securitynote>Critical: Suppresses unmanaged code security.</securitynote>
        [SuppressUnmanagedCodeSecurity]
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("36db0196-9665-46d1-9ba7-d3709eecf9ed")]
        internal interface IObjectWithAppUserModelId
        {
            void SetAppID([MarshalAs(UnmanagedType.LPWStr)] string pszAppID);

            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetAppID();
        };

        /// <summary>Provides access to the ProgID associated with an object</summary>
        /// <securitynote>Critical: Suppresses unmanaged code security.</securitynote>
        [SuppressUnmanagedCodeSecurity]
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("71e806fb-8dee-46fc-bf8c-7748a8a1ae13")]
        internal interface IObjectWithProgId
        {
            void SetProgID([MarshalAs(UnmanagedType.LPWStr)] string pszProgID);

            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetProgID();
        };

        /// <securitynote>Critical: Suppresses unmanaged code security.</securitynote>
        [SuppressUnmanagedCodeSecurity]
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("886d8eeb-8cf2-4446-8d02-cdba1dbdcf99")]
        internal interface IPropertyStore
        {
            uint GetCount();

            ShellItemPropertyKey GetAt(uint iProp);

            void GetValue([In] ref ShellItemPropertyKey pkey, [Out] PROPVARIANT pv);

            void SetValue([In] ref ShellItemPropertyKey pkey, [In] PROPVARIANT pv);

            void Commit();
        }

        /// <securitynote>Critical: Suppresses unmanaged code security.</securitynote>
        [SuppressUnmanagedCodeSecurity]
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("000214E6-0000-0000-C000-000000000046")]
        internal interface IShellFolder
        {
            void ParseDisplayName(
                IntPtr hwnd,
                IBindCtx pbc,
                [MarshalAs(UnmanagedType.LPWStr)] string pszDisplayName,
                [In, Out] ref int pchEaten,
                out IntPtr ppidl,
                [In, Out] ref uint pdwAttributes);

            IEnumIDList EnumObjects(
                IntPtr hwnd,
                SHCONTF grfFlags);

            // returns an instance of a sub-folder which is specified by the IDList (pidl). IShellFolder or derived interfaces
            [return: MarshalAs(UnmanagedType.Interface)]
            object BindToObject(
                IntPtr pidl,
                IBindCtx pbc,
                [In] ref Guid riid);

            // produces the same result as BindToObject()
            [return: MarshalAs(UnmanagedType.Interface)]
            object BindToStorage(IntPtr pidl, IBindCtx pbc, [In] ref Guid riid);

            // compares two IDLists and returns the result. The shell explorer always passes 0 as lParam, which indicates
            // 'sort by name'. It should return 0 (as CODE of the scode), if two id indicates the same object; negative
            // value if pidl1 should be placed before pidl2; positive value if pidl2 should be placed before pidl1. use
            // the macro ResultFromShort() to extract the result comparison it deals with the casting and type conversion
            // issues for you
            [PreserveSig]
            HRESULT CompareIDs(IntPtr lParam, IntPtr pidl1, IntPtr pidl2);

            // creates a view object of the folder itself. The view object is a difference instance from the shell folder
            // object. 'hwndOwner' can be used as the owner window of its dialog box or menu during the lifetime of the
            // view object. This member function should always create a new instance which has only one reference count.
            // The explorer may create more than one instances of view object from one shell folder object and treat them
            // as separate instances. returns IShellView derived interface
            [return: MarshalAs(UnmanagedType.Interface)]
            object CreateViewObject(IntPtr hwndOwner, [In] ref Guid riid);

            // returns the attributes of specified objects in that folder. 'cidl' and 'apidl' specifies objects. 'apidl'
            // contains only simple IDLists. The explorer initializes *prgfInOut with a set of flags to be evaluated. The
            // shell folder may optimize the operation by not returning unspecified flags.
            void GetAttributesOf(
                uint cidl,
                IntPtr apidl,
                [In, Out] ref SFGAO rgfInOut);

            // creates a UI object to be used for specified objects. The shell explorer passes either IID_IDataObject
            // (for transfer operation) or IID_IContextMenu (for context menu operation) as riid and many other interfaces
            [return: MarshalAs(UnmanagedType.Interface)]
            object GetUIObjectOf(
                IntPtr hwndOwner,
                uint cidl,
                [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysInt, SizeParamIndex = 1)] IntPtr apidl,
                [In] ref Guid riid,
                [In, Out] ref uint rgfReserved);

            // returns the display name of the specified object. If the ID contains the display name (in the locale
            // character set), it returns the offset to the name. Otherwise, it returns a pointer to the display name
            // string (UNICODE), which is allocated by the task allocator, or fills in a buffer. use the helper APIS
            // StrRetToStr() or StrRetToBuf() to deal with the different forms of the STRRET structure
            void GetDisplayNameOf(IntPtr pidl, SHGDN uFlags, out IntPtr pName);

            // sets the display name of the specified object. If it changes the ID as well, it returns the new ID which
            // is alocated by the task allocator.
            void SetNameOf(IntPtr hwnd,
                IntPtr pidl,
                [MarshalAs(UnmanagedType.LPWStr)] string pszName,
                SHGDN uFlags,
                out IntPtr ppidlOut);
        }

        /// <securitynote>Critical: Suppresses unmanaged code security.</securitynote>
        [SuppressUnmanagedCodeSecurity]
        [
            ComImport,
            InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
            Guid("43826d1e-e718-42ee-bc55-a1e261c37bfe"),
        ]
        internal interface IShellItem
        {
            [return: MarshalAs(UnmanagedType.Interface)]
            object BindToHandler(IBindCtx pbc, [In] ref Guid bhid, [In] ref Guid riid);

            IShellItem GetParent();

            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetDisplayName(SIGDN sigdnName);

            uint GetAttributes(SFGAO sfgaoMask);

            int Compare(IShellItem psi, SICHINT hint);
        }

        /// <summary>Shell Namespace helper 2</summary>
        /// <securitynote>Critical: Suppresses unmanaged code security.</securitynote>
        [SuppressUnmanagedCodeSecurity]
        [
            ComImport,
            InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
            Guid("7e9fb0d3-919f-4307-ab2e-9b1860310c93"),
        ]
        internal interface IShellItem2 : IShellItem
        {
            [return: MarshalAs(UnmanagedType.Interface)]
            new object BindToHandler(IBindCtx pbc, [In] ref Guid bhid, [In] ref Guid riid);

            new IShellItem GetParent();

            [return: MarshalAs(UnmanagedType.LPWStr)]
            new string GetDisplayName(SIGDN sigdnName);

            new SFGAO GetAttributes(SFGAO sfgaoMask);

            new int Compare(IShellItem psi, SICHINT hint);

            [return: MarshalAs(UnmanagedType.Interface)]
            object GetPropertyStore(
                GPS flags,
                [In] ref Guid riid);

            [return: MarshalAs(UnmanagedType.Interface)]
            object GetPropertyStoreWithCreateObject(
                GPS flags,
                [MarshalAs(UnmanagedType.IUnknown)] object punkCreateObject,   // factory for low-rights creation of type ICreateObject
                [In] ref Guid riid);

            [return: MarshalAs(UnmanagedType.Interface)]
            object GetPropertyStoreForKeys(
                IntPtr rgKeys,
                uint cKeys,
                GPS flags,
                [In] ref Guid riid);

            [return: MarshalAs(UnmanagedType.Interface)]
            object GetPropertyDescriptionList(
                IntPtr keyType,
                [In] ref Guid riid);

            // Ensures any cached information in this item is up to date, or returns
            // __HRESULT_FROM_WIN32(ERROR_FILE_NOT_FOUND) if the item does not exist.
            void Update(IBindCtx pbc);

            void GetProperty([In] ref ShellItemPropertyKey key, ref PROPVARIANT pv);

            Guid GetCLSID([In] ref ShellItemPropertyKey key);

            FILETIME GetFileTime([In] ref ShellItemPropertyKey key);

            int GetInt32([In] ref ShellItemPropertyKey key);

            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetString([In] ref ShellItemPropertyKey key);

            uint GetUInt32([In] ref ShellItemPropertyKey key);

            ulong GetUInt64([In] ref ShellItemPropertyKey key);

            [return: MarshalAs(UnmanagedType.Bool)]
            bool GetBool([In] ref ShellItemPropertyKey key);
        }

        /// <securitynote>Critical: Suppresses unmanaged code security.</securitynote>
        [SuppressUnmanagedCodeSecurity]
        [
            ComImport,
            InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
            Guid("B63EA76D-1F85-456F-A19C-48159EFA858B"),
        ]
        internal interface IShellItemArray
        {
            [return: MarshalAs(UnmanagedType.Interface)]
            object BindToHandler(IBindCtx pbc, [In] ref Guid rbhid, [In] ref Guid riid);

            [return: MarshalAs(UnmanagedType.Interface)]
            object GetPropertyStore(int flags, [In] ref Guid riid);

            [return: MarshalAs(UnmanagedType.Interface)]
            object GetPropertyDescriptionList([In] ref ShellItemPropertyKey keyType, [In] ref Guid riid);

            uint GetAttributes(SIATTRIBFLAGS dwAttribFlags, uint sfgaoMask);

            uint GetCount();

            IShellItem GetItemAt(uint dwIndex);

            [return: MarshalAs(UnmanagedType.Interface)]
            object EnumItems();
        }

        /// <securitynote>Critical: Suppresses unmanaged code security.</securitynote>
        [SuppressUnmanagedCodeSecurity]
        [
            ComImport,
            InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown),
            Guid("000214F9-0000-0000-C000-000000000046"),
        ]
        internal interface IShellLinkW
        {
            void GetPath([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile, int cchMaxPath, [In, Out] WIN32_FIND_DATA pfd, SLGP fFlags);

            IntPtr GetIDList();

            void SetIDList(IntPtr pidl);

            void GetDescription([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile, int cchMaxName);

            void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);

            void GetWorkingDirectory([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir, int cchMaxPath);

            void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);

            void GetArguments([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs, int cchMaxPath);

            void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);

            short GetHotKey();

            void SetHotKey(short wHotKey);

            uint GetShowCmd();

            void SetShowCmd(uint iShowCmd);

            void GetIconLocation([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath, int cchIconPath, out int piIcon);

            void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);

            void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, uint dwReserved);

            void Resolve(IntPtr hwnd, uint fFlags);

            void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
        }

        /// <securitynote>Critical: Suppresses unmanaged code security.</securitynote>
        [SuppressUnmanagedCodeSecurity]
        [
            ComImport,
            InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
            Guid("56FDF342-FD6D-11d0-958A-006097C9A090"),
        ]
        internal interface ITaskbarList
        {
            /// <summary>This function must be called first to validate use of other members.</summary>
            void HrInit();

            /// <summary> This function adds a tab for hwnd to the taskbar.</summary>
            /// <param name="hwnd">The HWND for which to add the tab.</param>
            void AddTab(IntPtr hwnd);

            /// <summary> This function deletes a tab for hwnd from the taskbar.</summary>
            /// <param name="hwnd">The HWND for which the tab is to be deleted.</param>
            void DeleteTab(IntPtr hwnd);

            /// <summary> This function activates the tab associated with hwnd on the taskbar.</summary>
            /// <param name="hwnd">The HWND for which the tab is to be activated.</param>
            void ActivateTab(IntPtr hwnd);

            /// <summary> This function marks hwnd in the taskbar as the active tab.</summary>
            /// <param name="hwnd">The HWND to activate.</param>
            void SetActiveAlt(IntPtr hwnd);
        }

        /// <securitynote>Critical: Suppresses unmanaged code security.</securitynote>
        [SuppressUnmanagedCodeSecurity]
        [
            ComImport,
            InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
            Guid("602D4995-B13A-429b-A66E-1935E44F4317"),
        ]
        internal interface ITaskbarList2 : ITaskbarList
        {
            new void HrInit();

            new void AddTab(IntPtr hwnd);

            new void DeleteTab(IntPtr hwnd);

            new void ActivateTab(IntPtr hwnd);

            new void SetActiveAlt(IntPtr hwnd);

            /// <summary>Marks a window as full-screen.</summary>
            /// <param name="hwnd">The handle of the window to be marked.</param>
            /// <param name="fFullscreen">A Boolean value marking the desired full-screen status of the window.</param>
            /// <remarks>
            /// Setting the value of fFullscreen to true, the Shell treats this window as a full-screen window, and the taskbar is moved to the bottom of the
            /// z-order when this window is active. Setting the value of fFullscreen to false removes the full-screen marking, but <i>does not</i> cause the
            /// Shell to treat the window as though it were definitely not full-screen. With a false fFullscreen value, the Shell depends on its automatic
            /// detection facility to specify how the window should be treated, possibly still flagging the window as full-screen.
            /// </remarks>
            void MarkFullscreenWindow(IntPtr hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);
        }

        /// <securitynote>Critical: Suppresses unmanaged code security.</securitynote>
        /// <remarks>
        /// Methods on this interface are marked as PreserveSig because the implementation inconsistently surfaces errors
        /// in Explorer. Many of these methods are implemented by posting messages to the desktop window, but if explorer
        /// is not running or currently busy then we get back error codes that must be handled by the caller.
        /// </remarks>
        [SuppressUnmanagedCodeSecurity]
        [
            ComImport,
            InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
            Guid("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf"),
        ]
        internal interface ITaskbarList3 : ITaskbarList2
        {
            new void HrInit();

            new void AddTab(IntPtr hwnd);

            new void DeleteTab(IntPtr hwnd);

            new void ActivateTab(IntPtr hwnd);

            new void SetActiveAlt(IntPtr hwnd);

            new void MarkFullscreenWindow(IntPtr hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

            [PreserveSig]
            HRESULT SetProgressValue(IntPtr hwnd, ulong ullCompleted, ulong ullTotal);

            [PreserveSig]
            HRESULT SetProgressState(IntPtr hwnd, TBPF tbpFlags);

            [PreserveSig]
            HRESULT RegisterTab(IntPtr hwndTab, IntPtr hwndMDI);

            [PreserveSig]
            HRESULT UnregisterTab(IntPtr hwndTab);

            [PreserveSig]
            HRESULT SetTabOrder(IntPtr hwndTab, IntPtr hwndInsertBefore);

            [PreserveSig]
            HRESULT SetTabActive(IntPtr hwndTab, IntPtr hwndMDI, uint dwReserved);

            [PreserveSig]
            HRESULT ThumbBarAddButtons(IntPtr hwnd, uint cButtons, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] THUMBBUTTON[] pButtons);

            [PreserveSig]
            HRESULT ThumbBarUpdateButtons(IntPtr hwnd, uint cButtons, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] THUMBBUTTON[] pButtons);

            [PreserveSig]
            HRESULT ThumbBarSetImageList(IntPtr hwnd, IntPtr himl);

            [PreserveSig]
            HRESULT SetOverlayIcon(IntPtr hwnd, IntPtr hIcon, [MarshalAs(UnmanagedType.LPWStr)] string pszDescription);

            [PreserveSig]
            HRESULT SetThumbnailTooltip(IntPtr hwnd, [MarshalAs(UnmanagedType.LPWStr)] string pszTip);

            // Using RefRECT to making passing NULL possible. Removes clipping from the HWND.
            [PreserveSig]
            HRESULT SetThumbnailClip(IntPtr hwnd, ref RECT prcClip);
        }

        /// <securitynote>Critical: Suppresses unmanaged code security.</securitynote>
        [SuppressUnmanagedCodeSecurity]
        [
            ComImport,
            InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
            Guid("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf"),
        ]
        internal interface ITaskbarList4 : ITaskbarList3
        {
            new void HrInit();

            new void AddTab(IntPtr hwnd);

            new void DeleteTab(IntPtr hwnd);

            new void ActivateTab(IntPtr hwnd);

            new void SetActiveAlt(IntPtr hwnd);

            new void MarkFullscreenWindow(IntPtr hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

            [PreserveSig]
            new HRESULT SetProgressValue(IntPtr hwnd, ulong ullCompleted, ulong ullTotal);

            [PreserveSig]
            new HRESULT SetProgressState(IntPtr hwnd, TBPF tbpFlags);

            [PreserveSig]
            new HRESULT RegisterTab(IntPtr hwndTab, IntPtr hwndMDI);

            [PreserveSig]
            new HRESULT UnregisterTab(IntPtr hwndTab);

            [PreserveSig]
            new HRESULT SetTabOrder(IntPtr hwndTab, IntPtr hwndInsertBefore);

            [PreserveSig]
            new HRESULT SetTabActive(IntPtr hwndTab, IntPtr hwndMDI, uint dwReserved);

            [PreserveSig]
            new HRESULT ThumbBarAddButtons(IntPtr hwnd, uint cButtons, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] THUMBBUTTON[] pButtons);

            [PreserveSig]
            new HRESULT ThumbBarUpdateButtons(IntPtr hwnd, uint cButtons, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] THUMBBUTTON[] pButtons);

            [PreserveSig]
            new HRESULT ThumbBarSetImageList(IntPtr hwnd, IntPtr himl);

            [PreserveSig]
            new HRESULT SetOverlayIcon(IntPtr hwnd, IntPtr hIcon, [MarshalAs(UnmanagedType.LPWStr)] string pszDescription);

            [PreserveSig]
            new HRESULT SetThumbnailTooltip(IntPtr hwnd, [MarshalAs(UnmanagedType.LPWStr)] string pszTip);

            [PreserveSig]
            new HRESULT SetThumbnailClip(IntPtr hwnd, ref RECT prcClip);

            [PreserveSig]
            HRESULT SetTabProperties(IntPtr hwndTab, STPF stpFlags);
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct COMDLG_FILTERSPEC
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszName;

            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszSpec;
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct HRESULT
        {
            // Fields
            [FieldOffset(0)]
            private readonly uint _value;

            public static readonly HRESULT COR_E_OBJECTDISPOSED;
            public static readonly HRESULT DESTS_E_NO_MATCHING_ASSOC_HANDLER;
            public static readonly HRESULT DISP_E_BADINDEX;
            public static readonly HRESULT DISP_E_BADPARAMCOUNT;
            public static readonly HRESULT DISP_E_EXCEPTION;
            public static readonly HRESULT DISP_E_MEMBERNOTFOUND;
            public static readonly HRESULT DISP_E_OVERFLOW;
            public static readonly HRESULT DISP_E_PARAMNOTOPTIONAL;
            public static readonly HRESULT DISP_E_TYPEMISMATCH;
            public static readonly HRESULT DISP_E_UNKNOWNNAME;
            public static readonly HRESULT E_ABORT;
            public static readonly HRESULT E_ACCESSDENIED;
            public static readonly HRESULT E_FAIL;
            public static readonly HRESULT E_INVALIDARG;
            public static readonly HRESULT E_NOINTERFACE;
            public static readonly HRESULT E_NOTIMPL;
            public static readonly HRESULT E_OUTOFMEMORY;
            public static readonly HRESULT E_POINTER;
            public static readonly HRESULT E_UNEXPECTED;
            public static readonly HRESULT S_FALSE;
            public static readonly HRESULT S_OK;
            public static readonly HRESULT SCRIPT_E_REPORTED;
            public static readonly HRESULT STG_E_INVALIDFUNCTION;
            public static readonly HRESULT WC_E_GREATERTHAN;
            public static readonly HRESULT WC_E_SYNTAX;

            // Methods
            static HRESULT()
            {
                S_OK = new HRESULT(0);
                S_FALSE = new HRESULT(1);
                E_NOTIMPL = new HRESULT(0x80004001);
                E_NOINTERFACE = new HRESULT(0x80004002);
                E_POINTER = new HRESULT(0x80004003);
                E_ABORT = new HRESULT(0x80004004);
                E_FAIL = new HRESULT(0x80004005);
                E_UNEXPECTED = new HRESULT(0x8000ffff);
                DISP_E_MEMBERNOTFOUND = new HRESULT(0x80020003);
                DISP_E_TYPEMISMATCH = new HRESULT(0x80020005);
                DISP_E_UNKNOWNNAME = new HRESULT(0x80020006);
                DISP_E_EXCEPTION = new HRESULT(0x80020009);
                DISP_E_OVERFLOW = new HRESULT(0x8002000a);
                DISP_E_BADINDEX = new HRESULT(0x8002000b);
                DISP_E_BADPARAMCOUNT = new HRESULT(0x8002000e);
                DISP_E_PARAMNOTOPTIONAL = new HRESULT(0x8002000f);
                SCRIPT_E_REPORTED = new HRESULT(0x80020101);
                STG_E_INVALIDFUNCTION = new HRESULT(0x80030001);
                DESTS_E_NO_MATCHING_ASSOC_HANDLER = new HRESULT(0x80040f03);
                E_ACCESSDENIED = new HRESULT(0x80070005);
                E_OUTOFMEMORY = new HRESULT(0x8007000e);
                E_INVALIDARG = new HRESULT(0x80070057);
                COR_E_OBJECTDISPOSED = new HRESULT(0x80131622);
                WC_E_GREATERTHAN = new HRESULT(0xc00cee23);
                WC_E_SYNTAX = new HRESULT(0xc00cee2d);
            }

            public HRESULT(uint i)
            {
                _value = i;
            }

            public override bool Equals(object obj)
            {
                try
                {
                    return (((HRESULT)obj)._value == _value);
                }
                catch (InvalidCastException)
                {
                    return false;
                }
            }

            public static int GetCode(int error) => (error & 0xffff);

            public Exception GetException() => GetException(null);

            [SecurityCritical, SecuritySafeCritical]
            public Exception GetException(string message)
            {
                if (!Failed)
                {
                    return null;
                }
                Exception exceptionForHR = Marshal.GetExceptionForHR((int)_value, new IntPtr(-1));
                if (exceptionForHR.GetType() == typeof(COMException))
                {
                    if (Facility == Facility.Win32)
                    {
                        if (string.IsNullOrEmpty(message))
                        {
                            return new Win32Exception(Code);
                        }
                        return new Win32Exception(Code, message);
                    }
                    return new COMException(message ?? exceptionForHR.Message, (int)_value);
                }
                if (!string.IsNullOrEmpty(message))
                {
                    Type[] types = new Type[] { typeof(string) };
                    ConstructorInfo constructor = exceptionForHR.GetType().GetConstructor(types);
                    if (null != constructor)
                    {
                        object[] parameters = new object[] { message };
                        exceptionForHR = constructor.Invoke(parameters) as Exception;
                    }
                }
                return exceptionForHR;
            }

            public static Facility GetFacility(int errorCode) => (((Facility)(errorCode >> 0x10)) & ((Facility)0x1fff));

            public override int GetHashCode() => _value.GetHashCode();

            public static HRESULT Make(bool severe, Facility facility, int code) => new HRESULT((uint)(((severe ? -2147483648 : 0) | (((int)facility) << 0x10)) | code));

            public static bool operator ==(HRESULT hrLeft, HRESULT hrRight) => (hrLeft._value == hrRight._value);

            public static bool operator !=(HRESULT hrLeft, HRESULT hrRight) => !(hrLeft == hrRight);

            public void ThrowIfFailed()
            {
                ThrowIfFailed(null);
            }

            [SecurityCritical, SecuritySafeCritical]
            public void ThrowIfFailed(string message)
            {
                Exception exception = GetException(message);
                if (exception != null)
                {
                    throw exception;
                }
            }

            public override string ToString()
            {
                foreach (FieldInfo info in typeof(HRESULT).GetFields(BindingFlags.Public | BindingFlags.Static))
                {
                    if ((info.FieldType == typeof(HRESULT)) && (((HRESULT)info.GetValue(null)) == this))
                    {
                        return info.Name;
                    }
                }
                if (Facility == Facility.Win32)
                {
                    foreach (FieldInfo info2 in typeof(Win32Error).GetFields(BindingFlags.Public | BindingFlags.Static))
                    {
                        if ((info2.FieldType == typeof(Win32Error)) && (((HRESULT)((Win32Error)info2.GetValue(null))) == this))
                        {
                            return ("HRESULT_FROM_WIN32(" + info2.Name + ")");
                        }
                    }
                }
                object[] args = new object[] { _value };
                return string.Format(CultureInfo.InvariantCulture, "0x{0:X8}", args);
            }

            // Properties
            public int Code => GetCode((int)_value);

            public Facility Facility => GetFacility((int)_value);

            public bool Failed => (_value < 0);

            public bool Succeeded => (_value >= 0);
        }

        [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Unicode)]
        internal struct THUMBBUTTON
        {
            /// <summary>WPARAM value for a THUMBBUTTON being clicked.</summary>
            public const int THBN_CLICKED = 0x1800;

            public THB dwMask;
            public uint iId;
            public uint iBitmap;
            public IntPtr hIcon;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szTip;

            public THBF dwFlags;

            public static THUMBBUTTON Default = new THUMBBUTTON() { dwMask = THB.FLAGS, dwFlags = THBF.HIDDEN };
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct Win32Error
        {
            // Fields
            [FieldOffset(0)]
            private readonly int _value;

            public static readonly Win32Error ERROR_ACCESS_DENIED;
            public static readonly Win32Error ERROR_BAD_DEVICE;
            public static readonly Win32Error ERROR_CANCELLED;
            public static readonly Win32Error ERROR_FILE_NOT_FOUND;
            public static readonly Win32Error ERROR_INSUFFICIENT_BUFFER;
            public static readonly Win32Error ERROR_INVALID_DATATYPE;
            public static readonly Win32Error ERROR_INVALID_FUNCTION;
            public static readonly Win32Error ERROR_INVALID_HANDLE;
            public static readonly Win32Error ERROR_INVALID_PARAMETER;
            public static readonly Win32Error ERROR_INVALID_WINDOW_HANDLE;
            public static readonly Win32Error ERROR_KEY_DELETED;
            public static readonly Win32Error ERROR_NESTING_NOT_ALLOWED;
            public static readonly Win32Error ERROR_NO_MATCH;
            public static readonly Win32Error ERROR_NO_MORE_FILES;
            public static readonly Win32Error ERROR_OUTOFMEMORY;
            public static readonly Win32Error ERROR_PATH_NOT_FOUND;
            public static readonly Win32Error ERROR_SHARING_VIOLATION;
            public static readonly Win32Error ERROR_SUCCESS;
            public static readonly Win32Error ERROR_TIMEOUT;
            public static readonly Win32Error ERROR_TOO_MANY_OPEN_FILES;

            // Methods
            static Win32Error()
            {
                ERROR_SUCCESS = new Win32Error(0);
                ERROR_INVALID_FUNCTION = new Win32Error(1);
                ERROR_FILE_NOT_FOUND = new Win32Error(2);
                ERROR_PATH_NOT_FOUND = new Win32Error(3);
                ERROR_TOO_MANY_OPEN_FILES = new Win32Error(4);
                ERROR_ACCESS_DENIED = new Win32Error(5);
                ERROR_INVALID_HANDLE = new Win32Error(6);
                ERROR_OUTOFMEMORY = new Win32Error(14);
                ERROR_NO_MORE_FILES = new Win32Error(0x12);
                ERROR_SHARING_VIOLATION = new Win32Error(0x20);
                ERROR_INVALID_PARAMETER = new Win32Error(0x57);
                ERROR_INSUFFICIENT_BUFFER = new Win32Error(0x7a);
                ERROR_NESTING_NOT_ALLOWED = new Win32Error(0xd7);
                ERROR_KEY_DELETED = new Win32Error(0x3fa);
                ERROR_NO_MATCH = new Win32Error(0x491);
                ERROR_BAD_DEVICE = new Win32Error(0x4b0);
                ERROR_CANCELLED = new Win32Error(0x4c7);
                ERROR_INVALID_WINDOW_HANDLE = new Win32Error(0x578);
                ERROR_TIMEOUT = new Win32Error(0x5b4);
                ERROR_INVALID_DATATYPE = new Win32Error(0x70c);
            }

            public Win32Error(int i)
            {
                _value = i;
            }

            public override bool Equals(object obj)
            {
                try
                {
                    return (((Win32Error)obj)._value == _value);
                }
                catch (InvalidCastException)
                {
                    return false;
                }
            }

            public override int GetHashCode() => _value.GetHashCode();

            [SecurityCritical]
            public static Win32Error GetLastError() => new Win32Error(Marshal.GetLastWin32Error());

            public static bool operator ==(Win32Error errLeft, Win32Error errRight) => (errLeft._value == errRight._value);

            public static explicit operator HRESULT(Win32Error error)
            {
                if (error._value <= 0)
                {
                    return new HRESULT((uint)error._value);
                }
                return HRESULT.Make(true, Facility.Win32, error._value & 0xffff);
            }

            public static bool operator !=(Win32Error errLeft, Win32Error errRight) => !(errLeft == errRight);

            public HRESULT ToHRESULT() => (HRESULT)this;
        }

        [ComImport, Guid("77f10cf0-3db5-4966-b520-b7c54fd35ed6"), ClassInterface(ClassInterfaceType.None)]
        public class CDestinationList { }

        [ComImport, Guid("2d3468c1-36a7-43b6-ac24-d3f02fd9607a"), ClassInterface(ClassInterfaceType.None)]
        public class CEnumerableObjectCollection { }

        [ComImport, Guid("00021401-0000-0000-C000-000000000046"), ClassInterface(ClassInterfaceType.None)]
        public class CShellLinkW { }

        [ComImport, Guid("56FDF344-FD6D-11d0-958A-006097C9A090"), ClassInterface(ClassInterfaceType.None)]
        public class CTaskbarList { }

        /// <remarks>Methods in this class will only work on Vista and above.</remarks>
        internal static class ShellUtil
        {
            /// <securitynote>
            /// Critical: Resolves an opaque Guid into a path on the user's machine. Calls critical SHGetFolderPathEx
            /// </securitynote>
            [SecurityCritical]
            public static string GetPathForKnownFolder(Guid knownFolder)
            {
                if (knownFolder == default(Guid))
                    return null;

                var pathBuilder = new StringBuilder(260);
                HRESULT hr = SHGetFolderPathEx(ref knownFolder, 0, IntPtr.Zero, pathBuilder, (uint)pathBuilder.Capacity);
                return hr.Succeeded ? pathBuilder.ToString() : null;
            }

            /// <securitynote>Critical: Resolves an opaque interface into a path on the user's machine.</securitynote>
            [SecurityCritical]
            public static string GetPathFromShellItem(IShellItem item) => item.GetDisplayName(SIGDN.DESKTOPABSOLUTEPARSING);

            /// <securitynote>Critical: Calls SHCreateItemFromParsingName</securitynote>
            [SecurityCritical]
            public static IShellItem2 GetShellItemForPath(string path)
            {
                if (string.IsNullOrEmpty(path))
                    return null;

                IShellItem2 unk = null;
                SHCreateItemFromParsingName(path, null, Marshal.GenerateGuidForType(typeof(IShellItem2)), out unk);
                return unk;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        internal class PROPVARIANT : IDisposable
        {
            private ushort vt;
            private ushort wReserved1;
            private ushort wReserved2;
            private ushort wReserved3;
            private IntPtr valueData;
            private Int32 valueDataExt;

            public PROPVARIANT()
            {
            }

            public PROPVARIANT(object value)
            {
                Value = value;
            }

            [SecurityCritical, SecuritySafeCritical]
            public void Clear()
            {
                NativeMethods.PropVariantClear(this);
            }

            [SecurityCritical, SecuritySafeCritical]
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            [SecurityCritical, SecuritySafeCritical]
            private void Dispose(bool disposing)
            {
                Clear();
            }

            [SecurityCritical, SecuritySafeCritical]
            ~PROPVARIANT()
            {
                Dispose(false);
            }

            private byte[] ByteArray
            {
                get
                {
                    byte[] ret = new byte[IntPtr.Size + sizeof(int)];
                    if (IntPtr.Size == 4)
                        BitConverter.GetBytes(valueData.ToInt32()).CopyTo(ret, 0);
                    else if (IntPtr.Size == 8)
                        BitConverter.GetBytes(valueData.ToInt64()).CopyTo(ret, 0);
                    BitConverter.GetBytes(valueDataExt).CopyTo(ret, IntPtr.Size);
                    return ret;
                }
            }

            public T GetValue<T>() => (T)Value;

            public object Value
            {
                get
                {
                    switch ((VarEnum)vt)
                    {
                        case VarEnum.VT_EMPTY:
                        case VarEnum.VT_NULL:
                            return DBNull.Value;

                        case VarEnum.VT_I2:
                            return BitConverter.ToInt16(ByteArray, 0);

                        case VarEnum.VT_INT:
                        case VarEnum.VT_I4:
                        case VarEnum.VT_ERROR:
                            return BitConverter.ToInt32(ByteArray, 0);

                        case VarEnum.VT_BSTR:
                            return Marshal.PtrToStringBSTR(valueData);

                        case VarEnum.VT_DISPATCH:
                        case VarEnum.VT_UNKNOWN:
                            return valueData == IntPtr.Zero ? null : Marshal.GetObjectForIUnknown(valueData);

                        case VarEnum.VT_BOOL:
                            return BitConverter.ToBoolean(ByteArray, 0);

                        case VarEnum.VT_I1:
                            return BitConverter.ToChar(ByteArray, 0);

                        case VarEnum.VT_UI1:
                            return ByteArray[0];

                        case VarEnum.VT_UI2:
                            return BitConverter.ToUInt16(ByteArray, 0);

                        case VarEnum.VT_UINT:
                        case VarEnum.VT_UI4:
                            return BitConverter.ToUInt32(ByteArray, 0);

                        case VarEnum.VT_I8:
                            return BitConverter.ToInt64(ByteArray, 0);

                        case VarEnum.VT_UI8:
                            return BitConverter.ToUInt64(ByteArray, 0);

                        case VarEnum.VT_VOID:
                        case VarEnum.VT_HRESULT:
                        case VarEnum.VT_PTR:
                        case VarEnum.VT_USERDEFINED:
                            return valueData;

                        case VarEnum.VT_LPSTR:
                            return Marshal.PtrToStringAnsi(valueData);

                        case VarEnum.VT_LPWSTR:
                            return Marshal.PtrToStringUni(valueData);

                        case VarEnum.VT_R8:
                            return BitConverter.ToDouble(ByteArray, 0);

                        case VarEnum.VT_DATE:
                            return DateTime.FromOADate(BitConverter.ToDouble(ByteArray, 0));

                        case VarEnum.VT_CY:
                            return decimal.FromOACurrency(BitConverter.ToInt64(ByteArray, 0));

                        case VarEnum.VT_DECIMAL:
                            return new decimal(new int[] { (int)valueData, valueDataExt, (wReserved3 << 16) | wReserved2, (wReserved1 << 16) });

                        case VarEnum.VT_R4:
                            return BitConverter.ToSingle(ByteArray, 0);

                        case VarEnum.VT_FILETIME:
                            return DateTime.FromFileTime(BitConverter.ToInt64(ByteArray, 0));
                        /*case VarEnum.VT_VARIANT:
						case VarEnum.VT_CARRAY:
						case VarEnum.VT_RECORD:
						case VarEnum.VT_BLOB:
						case VarEnum.VT_SAFEARRAY:
						case VarEnum.VT_STREAM:
						case VarEnum.VT_STORAGE:
						case VarEnum.VT_STREAMED_OBJECT:
						case VarEnum.VT_STORED_OBJECT:
						case VarEnum.VT_BLOB_OBJECT:
						case VarEnum.VT_CF:
						case VarEnum.VT_CLSID:
						case VarEnum.VT_VECTOR:
						case VarEnum.VT_ARRAY:
						case VarEnum.VT_BYREF:*/
                        default:
                            break;
                    }
                    return null;
                }
                set
                {
                    Clear();
                    if (value == null || DBNull.Value.Equals(value))
                    {
                        vt = (ushort)VarEnum.VT_NULL;
                    }
                    else if (value is bool)
                    {
                        vt = (ushort)VarEnum.VT_BOOL;
                        valueData = ((bool)value) ? (IntPtr)(-1) : (IntPtr)0;
                    }
                    else if (value is string)
                    {
                        vt = (ushort)VarEnum.VT_BSTR;
                        valueData = Marshal.StringToCoTaskMemUni(value.ToString());
                    }
                    else if (value is byte)
                    {
                        vt = (ushort)VarEnum.VT_UI1;
                        valueData = (IntPtr)value;
                    }
                    else if (value is char)
                    {
                        vt = (ushort)VarEnum.VT_I1;
                        valueData = (IntPtr)value;
                    }
                    else if (value is double)
                    {
                        vt = (ushort)VarEnum.VT_R8;
                        valueData = (IntPtr)value;
                    }
                    else if (value is float)
                    {
                        vt = (ushort)VarEnum.VT_R4;
                        valueData = (IntPtr)value;
                    }
                    else if (value is decimal || value is float)
                    {
                        vt = (ushort)VarEnum.VT_DECIMAL;
                        int[] bits = decimal.GetBits((decimal)value);
                        valueData = (IntPtr)bits[0];
                        valueDataExt = bits[1];
                        wReserved3 = (ushort)(bits[2] >> 16);
                        wReserved2 = (ushort)(bits[2] & 0x0000FFFF);
                        wReserved1 = (ushort)(bits[3] >> 16);
                    }
                    else if (value is DateTime || value is FILETIME)
                    {
                        vt = (ushort)VarEnum.VT_FILETIME;
                        FILETIME ft;
                        if (value is FILETIME)
                            ft = (FILETIME)value;
                        else
                        {
                            long lft = ((DateTime)value).ToFileTime();
                            ft = new FILETIME { dwHighDateTime = (int)(lft >> 32), dwLowDateTime = (int)(lft & 0xFFFFFFFF) };
                        }
                        PROPVARIANT pv;
                        NativeMethods.InitPropVariantFromFileTime(ref ft, out pv);
                        valueData = pv.valueData;
                        valueDataExt = pv.valueDataExt;
                    }
                    else if (value is CurrencyWrapper)
                    {
                        vt = (ushort)VarEnum.VT_CY;
                        valueData = (IntPtr)decimal.ToOACurrency(((CurrencyWrapper)value).WrappedObject);
                    }
                    else if (value is ulong)
                    {
                        vt = (ushort)VarEnum.VT_UI8;
                        valueData = (IntPtr)value;
                    }
                    else if (value is long)
                    {
                        vt = (ushort)VarEnum.VT_I8;
                        valueData = (IntPtr)value;
                    }
                    else if (value is IntPtr)
                    {
                        vt = (ushort)VarEnum.VT_PTR;
                        valueData = (IntPtr)value;
                    }
                    else if (value is int)
                    {
                        vt = (ushort)VarEnum.VT_I4;
                        valueData = (IntPtr)value;
                    }
                    else if (value is uint)
                    {
                        vt = (ushort)VarEnum.VT_UI4;
                        valueData = (IntPtr)value;
                    }
                    else if (value is short)
                    {
                        vt = (ushort)VarEnum.VT_I2;
                        valueData = (IntPtr)value;
                    }
                    else if (value is ushort)
                    {
                        vt = (ushort)VarEnum.VT_UI2;
                        valueData = (IntPtr)value;
                    }
                    else if (Marshal.IsComObject(value))
                    {
                        var id = Marshal.GetIDispatchForObject(value);
                        if (id != null)
                        {
                            vt = (ushort)VarEnum.VT_DISPATCH;
                            valueData = id;
                        }
                        else
                        {
                            vt = (ushort)VarEnum.VT_UNKNOWN;
                            valueData = Marshal.GetIUnknownForObject(value);
                        }
                    }
                    else
                        throw new InvalidCastException("This supplied type is not supported.");
                }
            }

            public VarEnum VarType => (VarEnum)vt;

            public override string ToString() => Value?.ToString() ?? base.ToString();

            // Nested Types
            private static class NativeMethods
            {
                // Methods
                [SecurityCritical, SuppressUnmanagedCodeSecurity, DllImport("ole32.dll")]
                internal static extern int PropVariantClear(PROPVARIANT pvar);

                [DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
                internal static extern uint InitPropVariantFromFileTime([In] ref System.Runtime.InteropServices.ComTypes.FILETIME pftIn, out PROPVARIANT ppropvar);
            }
        }
    }
}
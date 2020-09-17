using System;

namespace Krypton.Toolkit.Suite.Extended.Networking
{
    #region FTP Enumerations
    public enum FTPEncryption
    {
        NONE,
        IMPLICIT,
        EXPLICIT
    } 

    public enum FTPNodeType
    {
        FILE,
        DIRECTORY,
        SYMBOLICLINK
    }

    public enum FTPStatusCode
    {
        UNDEFINED = 0,
        RESTARTMARKER = 110,
        SERVICETEMPORARILYNOTAVAILABLE = 120,
        DATAALREADYOPEN = 125,
        OPENINGDATA = 150,
        COMMANDOK = 200,
        COMMANDEXTRANEOUS = 202,
        SYSTEMHELPREPLY = 211,
        DIRECTORYSTATUS = 212,
        FILESTATUS = 213,
        SYSTEMTYPE = 215,
        SENDUSERCOMMAND = 220,
        CLOSINGCONTROL = 221,
        CLOSINGDATA = 226,
        ENTERINGPASSIVE = 227,
        ENTERINGEXTENDEDPASSIVE = 229,
        LOGGEDINPROCEED = 230,
        SERVERWANTSSECURESESSION = 234,
        FILEACTIONOK = 250,
        PATHNAMECREATED = 257,
        SENDPASSWORDCOMMAND = 331,
        NEEDLOGINACCOUNT = 332,
        FILECOMMANDPENDING = 350,
        SERVICENOTAVAILABLE = 421,
        CANTOPENDATA = 425,
        CONNECTIONCLOSED = 426,
        ACTIONNOTTAKENFILEUNAVAILABLEORBUSY = 450,
        ACTIONABORTEDLOCALPROCESSINGERROR = 451,
        ACTIONNOTTAKENINSUFFICIENTSPACE = 452,
        COMMANDSYNTAXERROR = 500,
        ARGUMENTSYNTAXERROR = 501,
        COMMANDNOTIMPLEMENTED = 502,
        BADCOMMANDSEQUENCE = 503,
        NOTLOGGEDIN = 530,
        ACCOUNTNEEDED = 532,
        ACTIONNOTTAKENFILEUNAVAILABLE = 550,
        ACTIONABORTEDUNKNOWNPAGETYPE = 551,
        FILEACTIONABORTED = 552,
        ACTIONNOTTAKENFILENAMENOTALLOWED = 553
    }

    public enum FTPTransferMode
    {
        ASCII = 'A',
        BINARY = 'I'
    }

    [Flags]
    public enum IPVersion
    {
        IPV4 = 1,
        IPV6 = 2
    }

    public enum FTPCommand
    {
        NOOP,
        USER,
        PASS,
        QUIT,
        EPSV,
        PASV,
        CWD,
        PWD,
        CLNT,
        NLST,
        LIST,
        MLSD,
        RETR,
        STOR,
        DELE,
        MKD,
        RMD,
        RNFR,
        RNTO,
        SIZE,
        TYPE,
        FEAT,
        PBSZ,
        PROT
    }
    #endregion
}
using System.Linq;

namespace Krypton.Toolkit.Suite.Extended.Networking
{
    public static class FTPClientFeaturesExtensions
    {
        public static bool UsesMlsd(this FTPClient operand)
        {
            return (operand.Features != null) && operand.Features.Any(x => x == "MLSD");
        }

        public static bool UsesEpsv(this FTPClient operand)
        {
            return (operand.Features != null) && operand.Features.Any(x => x == "EPSV");
        }

        public static bool UsesPasv(this FTPClient operand)
        {
            return (operand.Features != null) && operand.Features.Any(x => x == "PASV");
        }
    }
}
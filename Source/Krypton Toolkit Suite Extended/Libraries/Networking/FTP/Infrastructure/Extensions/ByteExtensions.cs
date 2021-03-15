using System.Text;

namespace Krypton.Toolkit.Suite.Extended.Networking
{
    public static class ByteExtensions
    {
        public static byte[] ToAsciiBytes(this string operand) => Encoding.ASCII.GetBytes($"{operand}\r\n".ToCharArray());
    }
}
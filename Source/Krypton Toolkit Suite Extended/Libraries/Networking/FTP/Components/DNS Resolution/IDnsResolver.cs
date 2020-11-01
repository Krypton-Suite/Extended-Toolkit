using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Networking
{
    public interface IDnsResolver
    {
        Task<IPEndPoint> ResolveAsync(string endpoint, int port, IPVersion ipVersion = IPVersion.IPV4, CancellationToken token = default(CancellationToken));
    }
}
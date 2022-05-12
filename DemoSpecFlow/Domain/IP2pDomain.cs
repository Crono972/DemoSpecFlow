using System.Collections.Generic;
using System.Threading.Tasks;
using DemoSpecFlow.Domain.Model;
using DemoSpecFlow.Payload;

namespace DemoSpecFlow.Domain
{
    public interface IP2pDomain
    {
        Task<P2pModel> CreateP2pAsync(string userId, P2PPayload payload);
        Task<IList<P2pModel>> ListP2P(string userId);
    }
}
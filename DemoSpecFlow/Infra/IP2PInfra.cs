using System.Collections.Generic;
using DemoSpecFlow.Domain.Model;

namespace DemoSpecFlow.Infra
{
    public interface IP2PInfra
    {
        void SaveP2P(P2pModel p2p);
        IList<P2pModel> ListP2P(string userId);
    }
}
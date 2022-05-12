using System.Collections.Generic;
using System.Linq;
using DemoSpecFlow.Domain.Model;

namespace DemoSpecFlow.Infra
{
    public class P2PInfra : IP2PInfra
    {
        public IList<P2pModel> _InMemoryDb = new List<P2pModel>();
        private object _lock = new();

        public void SaveP2P(P2pModel p2p)
        {
            lock (_lock)
            {
                _InMemoryDb.Add(p2p);
            }
        }

        public IList<P2pModel> ListP2P(string userId)
        {
            lock (_lock)
            {
                return _InMemoryDb.Where(p => p.Receiver.Equals(userId) || p.Sender.Equals(userId)).ToList();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DemoSpecFlow.Domain.Model;
using DemoSpecFlow.Infra;
using DemoSpecFlow.Payload;

namespace DemoSpecFlow.Domain
{
    public class P2PDomain : IP2pDomain
    {
        private readonly IUserDomain _userDomain;
        private readonly IP2PInfra _p2PInfra;

        public P2PDomain(IUserDomain userDomain, IP2PInfra p2PInfra)
        {
            _userDomain = userDomain;
            _p2PInfra = p2PInfra;
        }

        public async Task<P2pModel> CreateP2pAsync(string userId, P2PPayload payload)
        {
            if (string.IsNullOrEmpty(payload.Sender))
            {
                if (string.IsNullOrEmpty(userId))
                {
                    throw new ApplicationException("No sender");
                }

                payload.Sender = userId;
            }

            if (string.IsNullOrEmpty(payload.Receiver))
            {
                throw new ApplicationException("No receiver");
            }

            if (payload.Amount <= 0)
            {
                throw new ApplicationException("Invalid amount");
            }

            await _userDomain.ModifyUserAmountAsync(payload.Sender, payload.Amount * -1);
            await _userDomain.ModifyUserAmountAsync(payload.Receiver, payload.Amount);
            var p2PModel = new P2pModel
            {
                Sender = payload.Sender,
                Receiver = payload.Receiver,
                Amount = payload.Amount,
                Date = DateTime.Now
            };
            _p2PInfra.SaveP2P(p2PModel);
            return p2PModel;
        }

        public async Task<IList<P2pModel>> ListP2P(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ApplicationException("No userId");
            }

            return _p2PInfra.ListP2P(userId);
        }
    }
}
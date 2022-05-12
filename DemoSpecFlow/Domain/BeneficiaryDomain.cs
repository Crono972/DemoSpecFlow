using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DemoSpecFlow.Domain.Model;
using DemoSpecFlow.Payload;

namespace DemoSpecFlow.Domain
{
    public class BeneficiaryDomain : IBeneficiaryDomain
    {
        public Task<Beneficiary> RegisterBeneficiary(string userId, BeneficiaryPayload payload)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBeneficiary(string userId, Guid beneficiaryId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Beneficiary>> ListBeneficiary(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
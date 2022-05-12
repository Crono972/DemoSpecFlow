using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DemoSpecFlow.Domain.Model;
using DemoSpecFlow.Payload;

namespace DemoSpecFlow.Domain
{
    public interface IBeneficiaryDomain
    {
        Task<Beneficiary> RegisterBeneficiary(string userId, BeneficiaryPayload payload);
        Task DeleteBeneficiary(string userId, Guid beneficiaryId);
        Task<IList<Beneficiary>> ListBeneficiary(string userId);
    }
}
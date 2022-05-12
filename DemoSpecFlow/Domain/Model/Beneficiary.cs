using System;
using DemoSpecFlow.Payload;

namespace DemoSpecFlow.Domain.Model
{
    public class Beneficiary : BeneficiaryPayload
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
    }
}
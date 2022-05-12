using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using DemoSpecFlow.Domain;
using DemoSpecFlow.Payload;

namespace DemoSpecFlow.Controllers
{
    [ApiController]
    [Route("api")]
    public class PaymentOperation : ControllerBase
    {
        
        private readonly ILogger<PaymentOperation> _logger;
        private readonly IP2pDomain _p2PDomain;
        private readonly IBeneficiaryDomain _beneficiaryDomain;

        public PaymentOperation(ILogger<PaymentOperation> logger, IP2pDomain p2PDomain, IBeneficiaryDomain beneficiaryDomain)
        {
            _logger = logger;
            _p2PDomain = p2PDomain;
            _beneficiaryDomain = beneficiaryDomain;
        }

        [HttpPost("{userId}/p2p")]
        public async Task<IActionResult> CreateP2p(string userId, P2PPayload payload)
        {
            return Created($"api/{userId}/p2p", await _p2PDomain.CreateP2pAsync(userId, payload));
        }

        [HttpGet("{userId}/p2p")]
        public async Task<IActionResult> ListP2p(string userId)
        {
            return Ok(await _p2PDomain.ListP2P(userId));
            
        }

        [HttpPost("{userId}/bankAccount")]
        public async Task<IActionResult> RegisterBeneficiary(string userId, BeneficiaryPayload beneficiaryPayload)
        {
            var beneficiary = await _beneficiaryDomain.RegisterBeneficiary(userId, beneficiaryPayload);
            return Created($"api/{userId}/bankAccount/{beneficiary.Id}", beneficiary);
        }

        [HttpGet("{userId}/bankAccount")]
        public async Task<IActionResult> ListBankAccount(string userId)
        {
            var beneficiaries = await _beneficiaryDomain.ListBeneficiary(userId);
            return Ok(beneficiaries);
        }


        [HttpGet("{userId}/bankAccount/{id}")]
        public async Task<IActionResult> GetBeneficiary(string userId, Guid id)
        {
            var beneficiaries = await _beneficiaryDomain.ListBeneficiary(userId);
            var beneficiary = beneficiaries.SingleOrDefault(b => b.Active && b.Id == id);
            if (beneficiary == null)
            {
                return NotFound();
            }
            return Ok(beneficiary);
        }

        [HttpDelete("{userId}/bankAccount/{id}")]
        public async Task<IActionResult> DeleteBeneficiary(string userId, Guid id)
        {
            await _beneficiaryDomain.DeleteBeneficiary(userId, id);
            return NoContent();
        }
    }
}

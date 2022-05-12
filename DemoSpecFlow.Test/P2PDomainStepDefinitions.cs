using System;
using System.Linq;
using System.Threading.Tasks;
using DemoSpecFlow.Domain;
using DemoSpecFlow.Infra;
using DemoSpecFlow.Payload;
using NSubstitute;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace DemoSpecFlow.Test
{
    [Binding]
    public class P2PDomainStepDefinitions
    {
        private readonly ScenarioContext _context;
        private readonly IUserDomain _userDomain;
        private readonly IP2PInfra _p2pInfra;
        private readonly P2PDomain _p2PDomain;

        public P2PDomainStepDefinitions(ScenarioContext context)
        {
            _context = context;
            _userDomain = Substitute.For<IUserDomain>();
            _p2pInfra = Substitute.For<IP2PInfra>();
            _p2PDomain = new P2PDomain(_userDomain, _p2pInfra);
        }

        [Given(@"the following p2p payload:")]
        public void GivenTheFollowingP2pPayload(Table table)
        {
            if (table.RowCount != 1)
            {
                throw new ArgumentException("Invalid number of row for p2p payload");
            }

            var payload = table.CreateInstance<P2PPayload>();
            _context.Set(payload);
            //_context.Add("payload", payload);
        }

        [Given(@"the following userId (.*)")]
        public void GivenTheFollowingUserId(string userId)
        {
            //_context.Add("userId", userId);
            _context.Set(userId, "userId");
        }

        [When(@"creating P2P")]
        public async Task WhenCreatingP2P()
        {
            try
            {
                await _p2PDomain.CreateP2pAsync(_context.Get<string>("userId"), _context.Get<P2PPayload>());
            }
            catch (Exception e)
            {
                _context.Add("Exception", e);
            }
            
        }

        [Then(@"the following exception should be thrown")]
        public void ThenTheFollowingExceptionShouldBeThrown(Table table)
        {
            if (table.RowCount != 1)
            {
                throw new ArgumentException("Invalid definition of exception");
            }

            var row = table.Rows.Single();
            var type = row.GetString("Type");
            var message = row.GetString("Message");
            var thrownException = _context.Get<Exception>("Exception");
            Assert.IsInstanceOf(Type.GetType(type), thrownException);
            Assert.AreEqual(message, thrownException.Message);
        }
    }
}

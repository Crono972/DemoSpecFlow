using System;
using DemoSpecFlow.Domain;
using DemoSpecFlow.Infra;
using DemoSpecFlow.Payload;
using NSubstitute;
using NUnit.Framework;

namespace DemoSpecFlow.Test
{
    public class P2PDomainTest
    {

        [Test]
        public void Should_crash_if_no_sender_found()
        {
            var p2PDomain = new P2PDomain(Substitute.For<IUserDomain>(), Substitute.For<IP2PInfra>());
            Assert.ThrowsAsync<ApplicationException>(async () => await p2PDomain.CreateP2pAsync("", new P2PPayload()), "No sender");
        }
        
    }
}
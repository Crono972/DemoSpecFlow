using System;
using DemoSpecFlow.Payload;

namespace DemoSpecFlow.Domain.Model
{
    public class P2pModel : P2PPayload
    {
        public DateTime Date { get; set; }
    }
}
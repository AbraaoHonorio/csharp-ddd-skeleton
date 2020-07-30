using System;
using XPTO.Core.Messages;

namespace XPTO.Core.Domain
{
    public class DomainEvent : Event
    {
        public DomainEvent(Guid AggregateId) : base (AggregateId)
        {
        }
    }
}
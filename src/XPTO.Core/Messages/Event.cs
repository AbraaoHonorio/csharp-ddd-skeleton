using MediatR;
using System;

namespace XPTO.Core.Messages
{
    public abstract class Event : Message, INotification
    {
        public DateTime CreatedAt { get; private set; }

        protected Event(Guid AggregateId)
        {
            this.AggregateId = AggregateId;
            CreatedAt = DateTime.Now;
        }
    }
}
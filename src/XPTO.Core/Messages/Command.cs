using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using XPTO.Core.Domain;
using XPTO.Core.DomainNotification;

namespace XPTO.Core.Messages
{
    public abstract class Command : Message, IRequest<bool>
    {
        public DateTime CreatedAt { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command() => CreatedAt = DateTime.Now;
    }
}

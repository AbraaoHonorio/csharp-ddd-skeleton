using System;
using XPTO.Core.Domain;

namespace XPTO.Product.Domain.Events
{
    public class ProductBelowStock : DomainEvent
    {
        public int RemainingAmount { get; }

        public ProductBelowStock(Guid AggregateId, int remainingAmount) : base(AggregateId)
        {
            RemainingAmount = remainingAmount;
        }
    }
}
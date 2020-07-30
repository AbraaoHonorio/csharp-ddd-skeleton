using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace XPTO.Product.Domain.Events
{
    public class ProductEventHandler : INotificationHandler<ProductBelowStock>
    {
        public Task Handle(ProductBelowStock notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"ToDo : {notification.AggregateId}");

            return Task.CompletedTask;
        }
    }
}
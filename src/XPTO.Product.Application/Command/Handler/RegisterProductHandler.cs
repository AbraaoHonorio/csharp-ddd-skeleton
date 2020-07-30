using MediatR;
using System.Threading;
using System.Threading.Tasks;
using XPTO.Core.Bus;
using XPTO.Core.DomainNotification;
using XPTO.Product.Application.Command.Validation;
using XPTO.Product.Domain.Repository;

namespace XPTO.Product.Application.Command.Handler
{
    public class RegisterProductHandler : BaseHandler, IRequestHandler<RegisterProductCommand, bool>
    {
        public RegisterProductHandler(IProductRepository productRepository, IMediatrHandler mediatorHandler, IDomainNotification domainNotification) : base(domainNotification, mediatorHandler)
        {
            _productRepository = productRepository;
            _mediatorHandler = mediatorHandler;
        }

        private readonly IProductRepository _productRepository;
        private readonly IMediatrHandler _mediatorHandler;

        public async Task<bool> Handle(RegisterProductCommand request, CancellationToken cancellationToken)
        {
            if (!ValidateObject(new AddProductValidation(), request))
                return false;
            
            var product = new Domain.Product(request.Id, request.Name, request.StockBalance);

            await _productRepository.AddAsync(product);

            return true;
        }
    }
}
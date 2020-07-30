using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using XPTO.Core.Bus;
using XPTO.Product.Application.Command;
using XPTO.Product.Domain.Command.ViewModels;
using XPTO.Product.Domain.Queries;
using XPTO.Product.Domain.Queries.ViewModels.Request;

namespace XPTO.API.Controllers
{
    [ApiController]
    [Route("Products/")]
    public class ProductController : ControllerBase
    {

        public ProductController(IProductQueries productQueries, IMediatrHandler mediatorHandler, IMediator mediator)
        {
            _mediator = mediator;
            _productQueries = productQueries;
            _mediatorHandler = mediatorHandler;
        }
        public readonly IMediator _mediator;

        private readonly IProductQueries _productQueries;
        private readonly IMediatrHandler _mediatorHandler;

        [Route("{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _productQueries.GetByIdAsync(new ProductGetRequest { Id = id });

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductPostRequest request)
        {
            var productCommand = new RegisterProductCommand(request.Id, request.StockBalance, request.Name, request.Active);


           // await _mediator.Send(productCommand);
          var f =  await _mediatorHandler.SendCommand(productCommand);

            return Ok(f);
        }

    }
}

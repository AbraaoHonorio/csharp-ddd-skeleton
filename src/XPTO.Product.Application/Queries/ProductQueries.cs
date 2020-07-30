using System.Threading.Tasks;
using XPTO.Product.Domain.Queries;
using XPTO.Product.Domain.Queries.ViewModels.Request;
using XPTO.Product.Domain.Repository;
using XPTO.Product.Domain.Shared.Resource;

namespace XPTO.Product.Application
{
    public class ProductQueries : IProductQueries
    {
        public ProductQueries(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        private readonly IProductRepository _productRepository;

        public async Task<ProductResource> GetByIdAsync(ProductGetRequest productRequest)
        {
            var product = await _productRepository.GetByIdAsync(productRequest.Id);

            return new ProductResource().ToResource(product);
        }
    }
}

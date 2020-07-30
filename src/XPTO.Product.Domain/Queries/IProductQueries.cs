using System.Threading.Tasks;
using XPTO.Product.Domain.Queries.ViewModels.Request;
using XPTO.Product.Domain.Shared.Resource;

namespace XPTO.Product.Domain.Queries
{
    public interface IProductQueries
    {
        Task<ProductResource> GetByIdAsync(ProductGetRequest productId);
    }
}
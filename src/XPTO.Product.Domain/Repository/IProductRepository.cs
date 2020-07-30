using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XPTO.Product.Domain.Repository
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(Guid productId);
        Task<Product> AddAsync(Product product);

    }
}
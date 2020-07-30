using System;
using System.Threading.Tasks;
using XPTO.Product.Domain.Repository;

namespace XPTO.Product.Data
{
    public class ProductRepository : IProductRepository
    {
        public Task<Domain.Product> AddAsync(Domain.Product product)
        {
            //ToDo acess database 
            return Task.Run(() => (product));
        }

        public Task<Domain.Product> GetByIdAsync(Guid productId)
        {
            //ToDo acess database 
            return Task.Run(() => (new Domain.Product(productId, "Camisa do vasco", 10)));
        }
    }
}
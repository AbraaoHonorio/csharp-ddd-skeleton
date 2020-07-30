using System;

namespace XPTO.Product.Domain.Shared.Resource
{
    public class ProductResource
    {
        public int StockBalance { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public Guid Id { get; set; }

        public ProductResource ToResource(Product product)
        {
            if (product is null)
                return null;

            var productResource = new ProductResource
            {
                Id = product.Id,
                Name = product.Name,
                StockBalance = product.StockBalance,
                Active = product.Active,
            };

            return productResource;
        }
    }
}

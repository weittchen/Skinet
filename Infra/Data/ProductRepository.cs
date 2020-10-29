using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return new List<ProductBrand>();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return new Product
            {
                Id = 1,
                Name = "Product 1"
            };
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return new List<Product>();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return new List<ProductType>();
        }
    }
}
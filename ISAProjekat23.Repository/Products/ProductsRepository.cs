using ISAProjekat23.Database;
using ISAProjekat23.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace ISAProjekat23.Repository.Products
{
    public class ProductsRepository : IProductsRepository
    {
        private DatabaseContext databaseContext;

        public ProductsRepository(DatabaseContext dc)
        {
            databaseContext = dc;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await databaseContext.Products.Select(p => new Product()
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description
            })
            .ToListAsync();
        }
    }
}

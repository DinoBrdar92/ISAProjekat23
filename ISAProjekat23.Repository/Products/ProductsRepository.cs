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

        public async Task<List<Product>> GetAllProductsFromCompany(int companyId)
        {
            var productsFromCompanyDto = await databaseContext.Offers
                .Include(o => o.Product)
                .Where(o => o.CompanyId == companyId)
                .Select(o => o.Product)
                .ToListAsync();


            return productsFromCompanyDto.Select(p => new Product()
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price
            })
            .ToList();
        }
    }
}

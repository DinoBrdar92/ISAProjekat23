using ISAProjekat23.Model.Domain;

namespace ISAProjekat23.Repository.Products
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetAllProductsFromCompany(int companyId);


    }
}

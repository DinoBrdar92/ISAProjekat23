using ISAProjekat23.Model.Domain;

namespace ISAProjekat23.Repository.Companies
{
    public interface ICompaniesRepository
    {
        Task<List<Company>> GetAllCompanies();
    }
}

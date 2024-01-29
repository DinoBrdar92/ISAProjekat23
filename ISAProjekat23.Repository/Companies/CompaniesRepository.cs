using ISAProjekat23.Database;
using ISAProjekat23.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace ISAProjekat23.Repository.Companies
{
    public class CompaniesRepository : ICompaniesRepository
    {
        private DatabaseContext databaseContext;

        public CompaniesRepository(DatabaseContext dc)
        {
            databaseContext = dc;
        }

        public async Task<List<Company>> GetAllCompanies()
        {
            return await databaseContext.Companies.Select(c => new Company()
            {
                Id = c.Id,
                Name = c.Name,
                Address = c.Address,
                City = c.City,
                Country = c.Country,
                Phone = c.Phone
            })
            .ToListAsync();
        }

    }
}

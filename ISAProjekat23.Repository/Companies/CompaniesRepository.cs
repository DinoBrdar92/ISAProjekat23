using ISAProjekat23.Database;
using ISAProjekat23.Model.Domain;
using ISAProjekat23.Model.Entities;
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
                Description = c.Description,
                Rating = c.Rating
            })
            .ToListAsync();
        }

        public static Company? CreateDomainFromEntity(CompanyDto companyDto)
        {
            if (companyDto != null)
            {
                Company company = new Company()
                {
                    Id = companyDto.Id,
                    Name = companyDto.Name,
                    Address = companyDto.Address,
                    Description = companyDto.Description,
                    Rating = companyDto.Rating
                };
            }

            return null;
        }

    }
}

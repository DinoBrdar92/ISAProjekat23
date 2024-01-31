using ISAProjekat23.Repository.Companies;
using Microsoft.AspNetCore.Mvc;

namespace ISAProjekat23.Server.Controllers.Company
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;
        private ICompaniesRepository _companiesRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CompanyController(ILogger<CompanyController> logger, ICompaniesRepository companiesRepository, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _companiesRepository = companiesRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Route("GetAllCompanies")]
        public async Task<IEnumerable<Model.Domain.Company>> GetAllCompanies()
        {
            return await _companiesRepository.GetAllCompanies();
        }
    }
}

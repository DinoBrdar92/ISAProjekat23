using ISAProjekat23.Repository.Products;
using Microsoft.AspNetCore.Mvc;

namespace ISAProjekat23.Server.Controllers.Product
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private IProductsRepository _productsRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductController(ILogger<ProductController> logger, IProductsRepository productsRepository, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _productsRepository = productsRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        //TODO: testirati kupljenje Id-ja firme preko parametra, proveriti da li pravi problem razlicit route name i ime funkcije
        [Route("GetAllProductsByCompany")]
        public async Task<IEnumerable<Model.Domain.Product>> GetAllProductsByCompany([FromQuery] int companyId)
        {
            return await _productsRepository.GetAllProductsFromCompany(companyId);
        }


    }
}

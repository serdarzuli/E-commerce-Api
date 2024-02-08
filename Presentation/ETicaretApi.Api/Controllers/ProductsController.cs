using ETicaretApi.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }
        [HttpGet]
        //public async void Get() burada void ile yapsak service.singelton kullanmam lazim scoped'da her requstin icindeki istegi icin nesne olusturacagimizdan ve void bekleme yapmayacagindan dispose olacaktir

        public async Task Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {

                new() { Id = Guid.NewGuid(), Name = "Product 1", Price = 300 , Stock = 30, CreatedDate = DateTime.UtcNow},
                new() { Id = Guid.NewGuid(), Name = "Product 2", Price = 3400 , Stock = 40, CreatedDate = DateTime.UtcNow},
            });
            var count = await _productWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _productReadRepository.GetByIdAsync(id);
            Console.WriteLine(result);
            return Ok(result);
        }
    }
}

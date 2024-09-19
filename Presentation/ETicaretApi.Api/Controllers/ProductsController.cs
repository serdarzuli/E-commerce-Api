using ETicaretApi.Application.Features.Commands.Product.CreateProduct;
using ETicaretApi.Application.Features.Commands.Product.RemoveProduct;
using ETicaretApi.Application.Features.Queries.GetAllProducts;
using ETicaretApi.Application.Features.Queries.GetByIdProduct;
using ETicaretApi.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;
        readonly private IMediator _mediator;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository,IMediator mediator)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
            GetAllProductQueryResponse response = await _mediator.Send(getAllProductQueryRequest);
            return Ok(response);
        }

        [HttpGet("GetProductById/{id}")] // Correct route definition
        public async Task<IActionResult> GetByIdProductQueryRequest([FromRoute] string id) // Accepting string id from route
        {
            var getByIdProductQueryRequest = new GetByIdProductQueryRequest { Id = id }; // Using string id in request object
            GetByIdProductQueryResponse response = await _mediator.Send(getByIdProductQueryRequest);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommandRequest createProductCommandRequest)
        {
            CreateProductCommandResponse response = await _mediator.Send(createProductCommandRequest);
            return Ok(response);
        }

        [HttpDelete("DeleteProductById/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveProductCommandRequest removeProductCommandRequest)
        {
            RemoveProductCommandResponse response = await _mediator.Send(removeProductCommandRequest);
            return Ok(response);
        }


        #region DeleteByName
        //bunu yapamadik anlamsiz bir hata verir

        //[HttpDelete("DeleteproductByName/{Name}")]
        //public async Task<IActionResult> DeleteProductByName([FromRoute] string  name)
        //{
        //    var removeProductCommandRequest = new RemoveProductCommandRequest { Name = name };
        //    RemoveProductCommandResponse response = await _mediator.Send(removeProductCommandRequest);
        //    return Ok(response);
        //}
        #endregion

    }
}

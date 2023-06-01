using EntitiesLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Contracts;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IServicesManager _manager;

        public ProductsController(IServicesManager manager)
        {
            _manager=manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct() 
        {
            var entitys = await _manager.ProductServices.GetAllProductsAsync(false);
            return Ok(entitys);
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneProduct([FromRoute(Name = "id")]int id)
        {
            var entity = await _manager
                .ProductServices
                .GetOneProductByIdAsync(id, false);
            return Ok(entity);
        }

        [HttpPost("CreateOneProduct")]
        public async Task<IActionResult> CreateOneProduct([FromBody]Product category)
        {
            var entity = await _manager.ProductServices.CreateOneProductAsync(category);
            return StatusCode(201,entity);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneProduct([FromRoute(Name = "id")] int id,
            [FromBody]Product product)
        {
            await _manager.ProductServices.UpdateOneProductAsync(id,product,false);
            return NoContent(); // StatusCode 204
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneProduct([FromRoute(Name = "id")]int id)
        {
            await _manager.ProductServices.DeleteOneProductAsync(id,false);
            return NoContent();// 204
        }
    }
}

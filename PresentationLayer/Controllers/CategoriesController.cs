

using EntitiesLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Contracts;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IServicesManager _manager;

        public CategoriesController(IServicesManager manager)
        {
            _manager=manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var entities = await _manager.CategoryServices.GetAllCategoriesAsync(false);
            return Ok(entities);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneCategory([FromRoute(Name = "id")] int id)
        {
            var entity = await _manager.CategoryServices.GetOneCategoryByIdAsync(id, false);
            return Ok(entity);
        }

        [HttpPost("CreateOneCategory")]
        public async Task<IActionResult> CreateOneCategory([FromBody]Category category)
        {
            await _manager.CategoryServices.CreateOneCategoryAsync(category);
            return StatusCode(201, category);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneCategory([FromRoute(Name = "id")]int id,
            [FromBody]Category category)
        {
            await _manager.CategoryServices.UpdateOneCategoryAsync(id, category, false);
            return NoContent(); // StatusCode 204
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneCategory([FromRoute(Name = "id")] int id)
        {
            await _manager.ProductServices.DeleteOneProductAsync(id, false);
            return NoContent();// 204
        }
    }
}

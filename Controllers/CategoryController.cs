using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Day1.Model;
using Day1.DTO;

namespace Day1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryRepository categoryRepo;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            categoryRepo = categoryRepository;
        }

        [HttpGet("{id}")]
        public IActionResult getCategory([FromRoute] int id)
        {
            CategoryWithProductIdAndNameDTO categoryDTO = new CategoryWithProductIdAndNameDTO();
            categoryDTO = categoryRepo.getByIdWithProducts(id);

            return Ok(categoryDTO);
        }

        [HttpGet]
        public IActionResult getAll()
        {
            List<CategoryDTO> categories = categoryRepo.getAll();
            return Ok(categories);
        }
    }
}

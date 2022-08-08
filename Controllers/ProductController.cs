using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Day1.Model;
using Day1.DTO;
using Microsoft.AspNetCore.Authorization;

namespace Day1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductRepository productRepo;

        public ProductController(IProductRepository productRepository)
        {
            productRepo = productRepository;
        }

        
        [HttpGet]
        public IActionResult getProduct()
        {
            List<ProductDTO> products = productRepo.getAll();
            
            return Ok(products);
        }

        [HttpGet("{id}", Name ="ProductDetailsRoute")]//Product/id
        public IActionResult getById([FromRoute] int id)
        {
            Product pro = productRepo.getById(id);

            return Ok(pro);
        }

        [HttpPut("{id}")]
        public IActionResult putProduct([FromRoute] int id, [FromBody] ProductWithCategoryNameDTO newProDTO)
        {
            Product newProModel = new Product();
            newProModel.name = newProDTO.name;
            newProModel.price = newProDTO.price;
            newProModel.description = newProDTO.description;
            newProModel.category_id = newProDTO.category_id;
            newProModel.image = newProDTO.image;

            productRepo.update(id, newProModel);

            return StatusCode(StatusCodes.Status204NoContent);
        }

        
        //[ActionName("addProduct")]
        [HttpPost]
        public IActionResult postProduct(ProductWithCategoryNameDTO productDTO) //Product newPro
        {
            //productRepo.add(newPro);
            Product newPro = new Product();
            newPro.name = productDTO.name;
            newPro.price = productDTO.price;
            newPro.description = productDTO.description;
            newPro.category_id = productDTO.category_id;
            newPro.image = productDTO.image;

            productRepo.add(newPro);

            string url = Url.Link("ProductDetailsRoute", new { id = newPro.id });

            return Created(url, newPro);
            //return StatusCode(StatusCodes.Status201Created);
        }


        
        [HttpDelete("{id}")]
        public IActionResult delete([FromRoute] int id)
        {
            try
            {
                productRepo.delete(id);

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Day1.DTO;

namespace Day1.Model
{
    public class CategoryRepository: ICategoryRepository
    {
        ITIContext db;

        public CategoryRepository(ITIContext context)
        {
            db = context;
        }

        public List<CategoryDTO> getAll()
        {
            List<Category> catModelList = db.Categories.ToList();
            List<CategoryDTO> catDTOList = new List<CategoryDTO>();

            foreach(var cat in catModelList)
            {
                CategoryDTO catDTO = new CategoryDTO();

                catDTO.id = cat.id;
                catDTO.name = cat.name;

                catDTOList.Add(catDTO);
            }
            return catDTOList;
        }

        public CategoryWithProductIdAndNameDTO getByIdWithProducts(int id)
        {
            Category categoryModel = db.Categories.Include(n => n.products).FirstOrDefault(n => n.id == id);
            
            CategoryWithProductIdAndNameDTO CategoryDTO = new CategoryWithProductIdAndNameDTO();

            CategoryDTO.categoryName = categoryModel.name;

            foreach(var product in categoryModel.products)
            {
                CategoryDTO.products.Add(new productNameAndId { id = product.id, name = product.name });
            }

            return CategoryDTO;
        }
    }
}

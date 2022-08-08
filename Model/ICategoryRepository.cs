using Day1.DTO;

namespace Day1.Model
{
    public interface ICategoryRepository
    {
        public CategoryWithProductIdAndNameDTO getByIdWithProducts(int id);

        public List<CategoryDTO> getAll();
    }
}

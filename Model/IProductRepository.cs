using Day1.Model;

namespace Day1.Model
{
    public interface IProductRepository
    {

        public List<ProductDTO> getAll();
        public Product getById(int id);

        public void add(Product pro);

        public void update(int id, Product newPro);

        public void delete(int id);
    }
}

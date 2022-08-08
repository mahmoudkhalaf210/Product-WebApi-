using Day1.Model;
using Microsoft.EntityFrameworkCore;

namespace Day1.Model
{
    public class ProductRepository: IProductRepository
    {
        ITIContext db;

        public ProductRepository(ITIContext context)
        {
            db = context;
        }

        public List<ProductDTO> getAll()
        {
            List<Product> proModel = db.Products.Include(n => n.Category).Where(n => n.category_id == n.Category.id).ToList();
            List<ProductDTO> proListDTO = new List<ProductDTO>();
            
            foreach (var p in proModel)
            {
                ProductDTO proDTO = new ProductDTO();
                proDTO.name = p.name;
                proDTO.id = p.id;
                proDTO.price = p.price;
                proDTO.image = p.image;
                proDTO.description = p.description;
                proDTO.category = p.Category.name;
                proDTO.category_id = p.Category.id;

                proListDTO.Add(proDTO);
            }

            return proListDTO;
         
        }

        public Product getById(int id)
        {
            return db.Products.FirstOrDefault(n => n.id == id);
        }

        public void add(Product pro)
        {
            db.Products.Add(pro);
            db.SaveChanges();
        }

        public void update(int id, Product newPro)
        {
            Product oldPro = db.Products.FirstOrDefault(n => n.id == id);

            oldPro.name = newPro.name;
            oldPro.price = newPro.price;
            oldPro.description = newPro.description;
            oldPro.category_id = newPro.category_id;
            oldPro.image = newPro.image;

            db.SaveChanges();
        }

        public void delete(int id)
        {
            Product pro = db.Products.FirstOrDefault(n => n.id == id);

            db.Products.Remove(pro);
            db.SaveChanges();
        }
    }
}

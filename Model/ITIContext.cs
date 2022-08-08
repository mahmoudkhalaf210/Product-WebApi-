using Microsoft.EntityFrameworkCore;
namespace Day1.Model
{
    public class ITIContext: DbContext
    {
        public ITIContext()
        {
                
        }
        public ITIContext(DbContextOptions option):base(option)
        {

        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-GQJS1PP;Database=shop;Trusted_Connection=True;");
        }

    }
}

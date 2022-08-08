namespace Day1.Model
{
    public class Category
    {
        public Category()
        {
            products = new List<Product>();
        }
        public int id { get; set; }
        public string name { get; set; }

        public virtual List<Product> products { get; set; }
    }
}

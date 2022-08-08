using System.ComponentModel.DataAnnotations.Schema;

namespace Day1.Model
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string image { get; set; }
        public string description { get; set; }

        [ForeignKey("Category")]
        public int? category_id { get; set; }

        public virtual Category? Category { get; set; }
    }
}

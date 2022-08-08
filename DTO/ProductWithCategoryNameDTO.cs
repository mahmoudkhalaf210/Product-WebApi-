using Day1.Model;

namespace Day1.DTO
{
    public class ProductWithCategoryNameDTO
    {
        public string name { get; set; }
        public int price { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public int category_id { get; set; }
    }
}

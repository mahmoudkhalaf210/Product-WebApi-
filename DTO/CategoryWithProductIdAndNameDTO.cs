namespace Day1.DTO
{
    public class CategoryWithProductIdAndNameDTO
    {
        public CategoryWithProductIdAndNameDTO()
        {
            products = new List<productNameAndId>();
        }

        public string categoryName { get; set; }
        public List<productNameAndId> products { get; set; }
    }

    public class productNameAndId
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}

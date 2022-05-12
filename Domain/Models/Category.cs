namespace Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Category> SubCategory { get; set; }
        public List<Work> Works { get; set; }
    }
    
}

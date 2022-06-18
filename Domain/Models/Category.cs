namespace Domain.Models
{
    public class Category
    {
        public Category()
        {
            SubCategory= new List<Category>();
            Skill = new List<Skill>();
            Works = new List<Work> ();
        }
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public bool IsMainCategory { get; set; }
        public List<Category> SubCategory { get; set; }
        public List<Work> Works { get; set; }
        public List<Skill> Skill { get; set; }
        public string? ImgPath { get; set; }
    }
    
}

namespace Domain.Models
{
    public class Work
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Context { get; set; }
        public User CustomerUser { get; set; }
        public User Worker { get; set; }
        public bool IsFinished { get; set; }
        public  List<Category> Categories { get; set; }
        public double Price { get; set; }
        public List<Comment> Coments { get; set; }
        public List<File> Files { get; set; }
    }
}

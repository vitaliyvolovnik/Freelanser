namespace Domain.Models
{
    public class Work
    {
        public Work()
        {
            Skills = new List<Skill>();
            Coments = new List<Comment>();
            Files = new List<File>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Context { get; set; }
        public Customer Customer { get; set; }
        public Employee? Worker { get; set; }
        public bool IsFinished { get; set; }
        public bool IsPublicshed { get; set; }
        public Category Category { get; set; }
        public List<Skill> Skills { get; set; }
        public double Price { get; set; }
        public List<Comment> Coments { get; set; }
        public List<File> Files { get; set; }
    }
}

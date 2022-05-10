namespace Domain.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public double Rating { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Skill> Skills { get; set; }
        public int CountFinishedProject { get; set; }
        public double Account { get; set; }
        public string PhotoPath { get;set; }
        public string? Information { get; set; }
        public List<Work> ExecutedWorks { get; set; }
        public List<Work> Works { get; set; }
        public User User { get; set; }
        
    }
}

namespace Domain.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public DateTime CreatedTime { get; set; }
        public User Client { get; set; }
        public int Rating { get; set; }
        public User User { get; set; }
    }
}

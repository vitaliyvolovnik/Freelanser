namespace Domain.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public DateTime CreatedTime { get; set; }
        public Customer Customer { get; set; }
        public int Rating { get; set; }
        public Employee Worker { get; set; }
    }
}

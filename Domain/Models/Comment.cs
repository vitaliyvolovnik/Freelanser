namespace Domain.Models
{
    public class Comment
    {
        public Comment()
        {
            Comments = new List<Comment>();
        }
        public int Id { get; set; }
        public string Text { get; set; }
        public List<Comment> Comments { get; set; }
        public DateTime CreatedTime { get; set; }
        //public User CustomerUser { get; set; }
        public User User { get; set; }
        public Work Work { get; set; }
        public bool IsMainComment { get; set; }

    }
}

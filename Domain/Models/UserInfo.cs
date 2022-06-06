namespace Domain.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Account { get; set; }
        public string? Phone { get; set; }
        public string PhotoPath { get;set; }
        //public DateTime RegisterTime { get; set; }
        public string? Information { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        
    }
}

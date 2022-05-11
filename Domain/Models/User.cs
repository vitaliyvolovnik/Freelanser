namespace Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public UserInfo UserInfo { get; set; }
        public string AccountType { get; set; }
        /*public Customer Customer { get; set; }
        public Employee Employee { get; set; }*/

    }
}

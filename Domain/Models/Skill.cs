namespace Domain.Models
{
    public class Skill
    {
        public Skill()
        {
            Employees = new List<Employee>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }

    }
}

namespace Domain.Models
{
    public class Skill
    {
        public Skill()
        {
            Employees = new List<Employee>();
            Works = new List<Work>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Work> Works { get; set; }
        public Category Category { get;set; }

    }
}

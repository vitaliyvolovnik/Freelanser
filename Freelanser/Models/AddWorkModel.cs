using Domain.Models;

namespace Freelanser.Models
{
    public class AddWorkModel
    {
        public string Name { get; set; }


        public string Context { get; set; }

        public double Price { get; set; }
        
        public string TypeOfPayment { get; set; }
        public string SkillsStr { get; set; }
        public DateTime Finish { get; set; }

        public List<Category> Cateories { get; set; } 
        public string CategoryName { get; set; }
        public List<Skill> Skills { get; set; } = new List<Skill>();

    }
}

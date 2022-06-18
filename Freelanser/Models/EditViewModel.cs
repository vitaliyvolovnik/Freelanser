using Domain.Models;

namespace Freelanser.Models
{
    public class EditViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Phone { get; set; }
        public string? Information { get; set; }
        public string SkillsStr { get; set; } = "";
        public int UserInfoId { get; set; }
        public IReadOnlyCollection<Category> Categories { get; set; }
        
    }
}

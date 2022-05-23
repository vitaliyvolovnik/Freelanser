using Domain.Models;

namespace Freelanser.Models
{
    public class WorkViewModel
    {

        public List<Work>? Works { get; set; }
        public List<Category>? Categories { get;set; }
        public Category? CurrentCategory { get; set; }
        public Category? CurrentMainCategory { get; set; }
    }
}

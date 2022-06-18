using Domain.Models;

namespace Freelanser.Models
{
    public class EmployeeListModel
    {
        public List<Employee>? Employees { get; set; }
        public List<Category>? Categories { get; set; }
        public Category? CurrentCategory { get; set; }
        public Category? CurrentMainCategory { get; set; }
    }
}

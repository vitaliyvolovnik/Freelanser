using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public double Rating { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Work> ExecutedWorks { get; set; }

    }
}

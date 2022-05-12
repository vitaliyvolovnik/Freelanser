using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public User User { get; set; } 
        public List<Work> Work { get; set; }
        public List<Review> Reviews { get; set; }
    }
}

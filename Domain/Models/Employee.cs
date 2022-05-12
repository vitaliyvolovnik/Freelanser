﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public double Rating { get; set; }
        public User User { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Work> ExecutedWorks { get; set; }

    }
}

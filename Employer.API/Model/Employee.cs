﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employer.API.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string JobTitle { get; set; }
        public DateTime JoinedDate { get; set; }
        public string Department { get; set; }
    }
}

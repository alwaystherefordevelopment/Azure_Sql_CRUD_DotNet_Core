using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagerApp.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Designation { get; set; }

        public decimal Salary { get; set; }
    }
}

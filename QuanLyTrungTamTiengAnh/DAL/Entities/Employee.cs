using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Employee
    {
        public string Id { get; set; }
        public int BranhId { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        public string Qualification { get; set; }
        public string Nation { get; set; }
        public int Jobtitle { get; set; }
        public int Salary { get; set; }

    }
}

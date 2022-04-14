using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Employee
    {
        public string Id { get; set; } = null;
        public int BranhId { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        public string Qualification { get; set; }
        public string Nation { get; set; }
        public string Jobtitle { get; set; }
        public int Salary { get; set; }
        public Employee()
        {

        }
        public Employee(Employee emp)
        {
            this.Id = emp.Id;
            this.BranhId = emp.BranhId;
            this.FullName = emp.FullName;
            this.DOB = emp.DOB;
            this.Phone = emp.Phone;
            this.Qualification = emp.Qualification;
            this.Nation = emp.Nation;
            this.Jobtitle = emp.Jobtitle;
            this.Salary = emp.Salary;
        }
    }
}

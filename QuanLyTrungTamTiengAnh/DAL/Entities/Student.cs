using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
   public class Student 
    {
        public int? Id { get; set; } = null;
        public string FullName { get; set; }
        public DateTime DoB { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public Student(int? Id,string FullName,DateTime DoB,string Phone,string Address)
        {
            this.Id = Id;
            this.FullName = FullName;
            this.DoB = DoB;
            this.Phone = Phone;
            this.Address = Address;
        }
        public Student() { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
  public class Register
    {
        public int? Id { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public DateTime PaymentDate { get; set; }
        public Decimal Amount { get; set; }

        public bool Status { get; set; }

        public Register()
        {

        }
    }
}

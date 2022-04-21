using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
   public class Courses
    {
        public int Id { get; set; }

        public string Lesson { get; set; }

        public int Duration { get; set; }

        public decimal Cost { get; set; }
    }
}

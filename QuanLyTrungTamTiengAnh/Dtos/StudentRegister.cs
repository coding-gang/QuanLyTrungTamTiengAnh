using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
   public class StudentRegister
    {
        public int idCourses { get; set; }
        public string Lesson { get; set; }

        public int idCaseStudy { get; set; }

        public string NameCaseStudy { get; set; }

        public string StartTime { get; set; }

        public string DateStudy { get; set; }

        public string NameStudent { get; set; }
    }
}

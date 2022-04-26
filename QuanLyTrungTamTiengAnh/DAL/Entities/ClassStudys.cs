using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
   public class ClassStudys
    {
        public int Id { get; set; }

       public int? CourseId { get; set; }

        public int? CaseId { get; set; }

        public string EmpId { get; set; }

        public int BranchId { get; set; }

        public int Room { get; set; }

        public DateTime StartDate { get; set; }

        public int TimePerWeek { get; set; }

        public bool Active { get; set; }



    }
}

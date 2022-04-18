using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
namespace Dtos
{
   public class DetailRegister : Register
    {
        public string NameStudent { get; set; }

        public string Lessons { get; set; }

        public string CaseStudyName { get; set; }

        public string DateStudy { get; set; }

        public string Room { get; set; }

        public bool Active { get; set; }

        public string NameTeacher { get; set; }

        public string BranchName { get; set; }

        public decimal Cost { get; set; }

        public int Duration { get; set; }


    }
}

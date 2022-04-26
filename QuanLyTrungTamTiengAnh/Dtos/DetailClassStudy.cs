using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
namespace Dtos
{
   public class DetailClassStudy : ClassStudys
    {
        public string NameLessons { get; set; }

        public string NameCaseStudy { get; set; }

        public string NameTeacher { get; set; }

        public string BranchName { get; set; }
    }
}

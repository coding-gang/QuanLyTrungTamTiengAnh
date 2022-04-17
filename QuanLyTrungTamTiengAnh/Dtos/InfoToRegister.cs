using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
namespace Dtos
{
   public class InfoToRegister
    {
       public CaseStudys InfoCaseStudy { get; set; }

        public int IdClass { get; set; }
    }
}

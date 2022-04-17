using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.IConfiguration;
namespace BLL
{
   public class CoursesBLL
    {

        public IUnitOfWork unitOfWork { get; private set; }
        public CoursesBLL(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.IConfiguration;
namespace BLL
{
   public class CaseStudyBLL
    {
        public IUnitOfWork _unitOfWork { get; private set; }

        public CaseStudyBLL(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
    }
}

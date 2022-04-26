using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.IConfiguration;
using Core.UnitOfWork;
namespace BLL
{
   public class ClassStudyBLL
    {
       public IUnitOfWork _unitOfWork { get; private set; }
        public ClassStudyBLL(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
    }
}

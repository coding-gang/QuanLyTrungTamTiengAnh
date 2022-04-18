using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.UnitOfWork;
using Core.Repository.Students;
using Core.IConfiguration;
namespace BLL
{
    public class StudentBLL
    {
        public IUnitOfWork unitOfWork { get; private set; }
        public StudentBLL(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public StudentBLL()
        {
            this.unitOfWork = new UnitOfWork();
        }

    }
}

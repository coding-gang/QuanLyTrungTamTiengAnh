using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.IConfiguration;
using Core.UnitOfWork;
namespace BLL
{
    public class EmployeeBLL
    {
        public IUnitOfWork unitOfWork { get; private set; }
        public EmployeeBLL() 
        {
            this.unitOfWork = new UnitOfWork();
        } 
    

    }
}

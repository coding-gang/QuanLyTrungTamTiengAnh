using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository.Employees
{
    public interface IGenericEmployee
    {
        bool UpdateBranchEmployee(int idBranchCurrent, int idBranchExchange, string idEmployee);
    }
}

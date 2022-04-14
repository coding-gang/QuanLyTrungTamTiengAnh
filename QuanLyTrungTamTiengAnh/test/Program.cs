using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DAL;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var EmployeeBLL = new EmployeeBLL();
            EmployeeBLL.unitOfWork.employeeRepository.GetById("GV001");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DAL;
using DAL.Entities;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var EmployeeBLL = new EmployeeBLL();
            var emp = new Employee();
            EmployeeBLL.unitOfWork.employeeRepository.Add(emp);
        }
    }
}

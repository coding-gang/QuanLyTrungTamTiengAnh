using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repository.Students;
using Core.Repository.Employees;
namespace Core.IConfiguration
{
   public interface IUnitOfWork 
    {
        IEmployeeRepository employeeRepository { get; }
       IStudentRepository studentRepository { get;  }
    }
}

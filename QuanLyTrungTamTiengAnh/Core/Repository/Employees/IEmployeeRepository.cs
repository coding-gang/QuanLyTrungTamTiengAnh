using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.GenericRepositorys;
using DAL.Entities;

namespace Core.Repository.Employees
{
    interface IEmployeeRepository:IGenericRepository<Employee>
    {
    }
}

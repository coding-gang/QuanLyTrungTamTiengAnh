using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.GenericRepositorys;
using DAL.Entities;

namespace Core.Repository.Employees
{
    public class EmployeeRepository : GenericRepository, IEmployeeRepository
    {
        public string query { get; set; }
        public object[] para { get; set; }

        public EmployeeRepository():base()
        {


        }
        public bool Add(Employee item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(object id)
        {
            return Command(query, para);
        }

        public IEnumerable<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public Employee GetById(object id)
        {
            throw new NotImplementedException();
        }

        public bool Update(object id)
        {
            return Command(query, para);
        }
    };
}

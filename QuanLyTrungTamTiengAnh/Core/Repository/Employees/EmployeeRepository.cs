using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.GenericRepositorys;
using DAL.Entities;
using DAL;
using DAL.Extensions;

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
            query = "select * from Employees";
            var employee = new List<Employee>();
            var dataTable = DataProvider.Instance.ExcuteDataReader(query);
           var collectionRowData = dataTable.GetRows(listRow);
            foreach (var row in collectionRowData)
            {
                var emp = new Employee();
                emp.Id = row[0];
                emp.BranhId =int.Parse(row[1]);
                emp.FullName = row[2];
                emp.DOB = DateTime.Parse(row[3]);
                emp.Phone = row[4];
                emp.Qualification = row[5];
                emp.Nation = row[6];
                emp.Jobtitle = row[7];
                emp.Salary = int.Parse(row[8]);
                employee.Add(emp);
            }
            return employee;
        }

        public Employee GetById(object id)
        {
            throw new NotImplementedException();
        }

        public bool Update(object id)
        {
            return Command(query);
        }
    };
}

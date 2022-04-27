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

        public EmployeeRepository() : base()
        {

        }
        public bool Add(Employee item)
        {
            var id = CreateIdEmp(item.Jobtitle);
            query = $"[dbo].[Add_Employess] @id , @branch_id , @full_name , @dob "
                                + ", @phone , @qualification "
                                + ", @nation , @jobtitle "
                                 + ", @salary";
            para = new object[]
            {
                id,
                item.BranhId,
                item.FullName,
                item.DOB,
                item.Phone,
                item.Qualification,
                item.Nation,
                item.Jobtitle,
                item.Salary
            };
            return Command(query, para);
        }
        private string handleRoleEmployee(string roleDetail)
        {
            if (roleDetail.StartsWith("G"))
            {
                return "GV";

            }
            else
            {
                return "NV";
            }
        }
        private string CreateIdEmp(string role)
        {
            string codeRole = handleRoleEmployee(role);
            string id = "";
            query = "select count(*) from Employees";
            int totalEmp = DataProvider.Instance.ExcuteScalar(query);
            id = $"{codeRole}{totalEmp + 1}";
            return id;
        }



        public bool Delete(object id)
        {
            query = $"Delete from Employees where id = '{id}'";
            return Command(query);
        }

        public IEnumerable<Employee> GetAll()
        {
            query = "select * from Employees";
            var employees = new List<Employee>();
            var dataTable = DataProvider.Instance.ExcuteDataReader(query);
            var collectionRowData = dataTable.GetRows(listRow);
            foreach (var row in collectionRowData)
            {
                var emp = new Employee();
                emp.Id = row[0];
                emp.BranhId = int.Parse(row[1]);
                emp.FullName = row[2];
                emp.DOB = DateTime.Parse(row[3]);
                emp.Phone = row[4];
                emp.Qualification = row[5];
                emp.Nation = row[6];
                emp.Jobtitle = row[7];
                emp.Salary = int.Parse(row[8]);
                employees.Add(emp);
            }
            return employees;
        }

        public Employee GetById(object id)
        {

            query = $"select * from Employees where id ='{id}'";
            var dataTable = DataProvider.Instance.ExcuteDataReader(query);
            var row = dataTable.GetRow(listRow);
            var emp = new Employee();
            emp.Id = row[0];
            emp.BranhId = int.Parse(row[1]);
            emp.FullName = row[2];
            emp.DOB = DateTime.Parse(row[3]);
            emp.Phone = row[4];
            emp.Qualification = row[5];
            emp.Nation = row[6];
            emp.Jobtitle = row[7];
            emp.Salary = int.Parse(row[8]);
            return emp;
        }

        public bool Update(object id, Employee item)
        {
            query = $"dbo.update_Employee @id , @full_name , @dob "
                                + ", @phone , @qualification "
                                + ", @nation , @jobtitle "
                                 + ", @salary";
            para = new object[]
          {
                id,
                item.FullName,
                item.DOB,
                item.Phone,
                item.Qualification,
                item.Nation,
                item.Jobtitle,
                item.Salary
          };
            return Command(query, para);
        }



        public bool UpdateBranchEmployee(int idBranchCurrent, int idBranchExchange, string idEmployee)
        {
            query = $"Update_Branch_Emp @branchCurrentId " +
                $", @branchExchangeId , @EmpId ";
            para = new object[]
            {
                idBranchCurrent,
                idBranchExchange,
                idEmployee
            };
            return Command(query, para);
        }
    };
}

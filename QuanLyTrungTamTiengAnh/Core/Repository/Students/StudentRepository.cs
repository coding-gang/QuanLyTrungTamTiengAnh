using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.GenericRepositorys;
using Core.Extension;
using DAL.Entities;

namespace Core.Repository.Students
{
   public class StudentRepository : GenericRepository, IStudentRepository
    {
        public string query {  get; set; }
        public object[] para { get; set; }

        public StudentRepository():base()
        {   
                  
        }

        public  IEnumerable<Student> GetAll()
        {
            query = "Select * from Students";
            List<Student> Students = new List<Student>();
            DataTable dataTable = dataProvider.ExcuteDataReader(query);
            var NameColumn = dataTable.InitNameColumn();
            foreach (DataRow row in dataTable.Rows)
            {
                listRow = new List<string>();
                var data = row.GetValueRow(listRow, NameColumn);
                var student = new Student(Id: int.Parse(data[0]),
                               FullName: data[1], DoB: DateTime.Parse(data[2]),
                               Phone: data[3], Address: data[4]);
                Students.Add(student);
            }
            return Students;
        }

        public Student GetById(object id)
        {
            throw new NotImplementedException();
        }
        public bool Add(Student item)
        {
            query = "dbo.Add_Student @fullname , @dob , @phone , @address";
            para = new object[] { item.FullName, item.DoB, item.Phone, item.Address};
            return Command(query,para);
        }

        public bool Delete(object id)
        {
            return Command(query,para);
        }

        public bool Update(object id, Student item)
        {
            query = "Update_Student @id , @fullname , @dob , @phone , @address";
            para = new object[] { id, item.FullName, item.DoB, item.Phone, item.Address };
            return Command(query,para);
        }

       
    }
}
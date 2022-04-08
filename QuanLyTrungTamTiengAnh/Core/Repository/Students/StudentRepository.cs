﻿using System;
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
            return Command(item);
        }

        public bool Delete(object id)
        {
            return Command(id);
        }

        public bool Update(object id)
        {
            return Command(id);
        }

       
    }
}
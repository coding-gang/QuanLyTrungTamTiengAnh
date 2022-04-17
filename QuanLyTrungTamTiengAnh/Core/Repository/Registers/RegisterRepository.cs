﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.GenericRepositorys;
using DAL;
using DAL.Extensions;
using Dtos;
namespace Core.Repository.Registers
{
    class RegisterRepository : GenericRepository , IRegisterRepository
    {
        public  string query { get; set; }
        public object[] para { get; set; }

        public IEnumerable<Register> GetAll()
        {
            var detailRegisters = new List<DetailRegister>();
            query = " Select * from DetailRegister";
            var dataTable = DataProvider.Instance.ExcuteDataReader(query);
            var dataRow = dataTable.GetRows(listRow);
            foreach(var row in dataRow)
            {
                var register = new DetailRegister();
                register.Id = int.Parse(row[0]);
              //  register.StudentId = int.Parse(row[1]);
                register.ClassId = int.Parse(row[2]);
                register.PaymentDate = DateTime.Parse(row[3]);
                register.Amount = Decimal.Parse(row[4]);
                register.Status = bool.Parse(row[5]);
                register.NameStudent = row[6];
                register.Lessons = row[7];
                register.CaseStudyName = row[8];
                register.DateStudy = row[9];
                register.NameTeacher = row[10];
                register.BranchName = row[11];
                register.Room = row[12];
                register.Active = bool.Parse(row[13]);
                detailRegisters.Add(register);
            }
           
            return detailRegisters;
        }

        public Register GetById(object id)
        {
            throw new NotImplementedException();
        }

        public bool Add(Register item)
        {
            query = "dbo.Add_Register @studentId , @classId , @registerDate , @amount , @status";
            para = new object[] { item.StudentId, item.ClassId, item.PaymentDate, item.Amount, item.Status };
            return Command(query,para);
        }

        public bool Update(object id, Register item)
        {
            return Command(query);
        }

        public bool Delete(object id)
        {
            return Command(query);
        }
        public void SaveChanges()
        {
            this.para = null;
            this.listRow = null;
        }

        public List<InfoToRegister> GetInfoToRegisters(int idCourse)
        {

            var infoToRegisters = new List<InfoToRegister>();
            query = "dbo.getInfoRegisterByIdCourses @idCourses";
            para = new object[] { idCourse };
            var dataTable = DataProvider.Instance.ExcuteDataReader(query, para);
            var dataRows = dataTable.GetRows(listRow);
            foreach (var row in dataRows)
            {
                var caseStudy = new CaseStudys
                {
                    Id = int.Parse(row[0]),
                    Name = row[1],
                    StartTime = row[2],
                    DateStudy = row[3]
                };
                var infoRegister = new InfoToRegister
                {
                    IdClass = int.Parse(row[5]),
                    InfoCaseStudy = caseStudy
                };
               
                infoToRegisters.Add(infoRegister);
            }
            return infoToRegisters;
        }
    }
}

using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.GenericRepositorys;
using DAL;
using DAL.Extensions;
using Dtos;
using System.Data;

namespace Core.Repository.Reports
{
    public class ReportRepository : GenericRepository, IReportRepository
    {
        private string query;
        private object[] para;
        private const string linkServer = "LINK1.DatabaseEnglishCenter.";
        private const string linkServerMain = "LINK.DatabaseEnglishCenter.";
        private const string nameBranchMain = "Cả hai chi nhánh";
        Dictionary<string, string> serverName = new Dictionary<string, string> {
            { "Chi nhánh 1", @"DESKTOP-6HQ6JE6\MSSQLSERVER02" },
            {"Chi nhánh 2", @"DESKTOP-6HQ6JE6\MSSQLSERVER01" }
        };
          
        public List<BillStudent> PrintBillByStudent(int id)
        {
            query = "dbo.Xuat_DSBill_ByStudent @idStudent";
            para = new object[] { id };
            var listBill = new List<BillStudent>();
            var dataTable = DataProvider.Instance.ExcuteDataReader(query, para);
            var dataRows = dataTable.GetRows(listRow);
            foreach (var item in dataRows)
            {
                var bill = new BillStudent
                {
                    Id = int.Parse(item[0]),
                    Lesson = item[1],
                    Cost = decimal.Parse(item[2])
                };
                listBill.Add(bill);
            }
            return listBill;

        }

        public IEnumerable<ClassStudys> PrintClassByTeacher(string name, bool isRoleGiamDoc, string nameServer)
        {
            DataTable dataTable = null;
            query = "dbo.Xuat_DS_Lop_ByNameGV @nameGV";
            para = new object[] { name };
            if (isRoleGiamDoc && DataProvider.NameBranch != nameServer)
            {
                query = linkServer + query;
            }else if(isRoleGiamDoc && DataProvider.NameBranch == nameBranchMain)
            {
                query = linkServerMain + query;
            }
           
            dataTable = DataProvider.Instance.ExcuteDataReader(query, para);
            var listClass = new List<DetailClassStudy>();
          
            var dataRows = dataTable.GetRows(listRow);
            foreach (var item in dataRows)
            {
                var classStudy = new DetailClassStudy
                {
                    Id = int.Parse(item[0]),
                    NameLessons = item[1],
                    NameCaseStudy = item[2],
                    NameTeacher = item[3],
                    BranchName = item[4],
                    Room = int.Parse(item[5]),
                    StartDate = DateTime.Parse(item[6]),
                    TimePerWeek = int.Parse(item[7]),
                    Active = bool.Parse(item[8])
                };
                listClass.Add(classStudy);
            }
            return listClass;
        }

        public List<Student> PrintStudentInClass(int id)
        {
            query = "dbo.Xuat_DS_HV_ByIdClass @idClass";
            para = new object[] { id };
            var listStudent = new List<Student>();
            var dataTable = DataProvider.Instance.ExcuteDataReader(query,para);
            var dataRows = dataTable.GetRows(listRow);
            foreach (var item in dataRows)
            {
                var studentInClass = new Student
                {
                    Id = int.Parse(item[0]),
                    FullName = item[1],
                    DoB =   DateTime.Parse(item[2]),
                    Phone = item[3],
                    Address =item[4]
                };
                listStudent.Add(studentInClass);
            }
            return listStudent;

        }

        public List<Student> PrintStudentInCourses(int id, bool isRoleGiamDoc, string nameServer)
        {
            DataTable dataTable = null;
            query = "dbo.Xuat_DS_HV_ByIdCourses @idCourses";
            para = new object[] { id };
            if (isRoleGiamDoc && DataProvider.NameBranch != nameServer &&  nameBranchMain != nameServer)
            {
                query = linkServer + query;
            }
            else if (isRoleGiamDoc && nameBranchMain == nameServer)
            {
                query = linkServerMain + query;
            }
            dataTable = DataProvider.Instance.ExcuteDataReader(query, para);
            var listStudent = new List<Student>();
          
            var dataRows = dataTable.GetRows(listRow);
            foreach (var item in dataRows)
            {
                var studentInClass = new Student
                {
                    Id = int.Parse(item[0]),
                    FullName = item[1],
                    DoB = DateTime.Parse(item[2]),
                    Phone = item[3],
                    Address = item[4]
                };
                listStudent.Add(studentInClass);
            }
            return listStudent;

        }

        public List<CaseStudyMaxStudent> ReportCaHocMax(bool isRoleGiamDoc, string nameServer)
        {
            DataTable dataTable = null;
            query = "dbo.CaHocCoLopHocNhieuNhat";
            if (isRoleGiamDoc && DataProvider.NameBranch != nameServer && nameBranchMain != nameServer)
            {
                query = linkServer + query;
            }
            else if (isRoleGiamDoc && nameBranchMain == nameServer)
            {
                query = linkServerMain + query;
            }
            dataTable = DataProvider.Instance.ExcuteDataReader(query);
            var listMaxReport = new List<CaseStudyMaxStudent>();
            var dataRows = dataTable.GetRows(listRow);
            foreach (var item in dataRows)
            {
                var studentInClass = new CaseStudyMaxStudent
                {
                  Id = int.Parse(item[0]),
                  CourseId = int.Parse(item[1]),
                  CaseId =int.Parse(item[2]),
                  EmpId = item[3],
                  BranchId =int.Parse(item[4]),
                  Room = int.Parse(item[5]),
                  StartDate =DateTime.Parse(item[6]),
                  TimePerWeek = int.Parse(item[7]),
                  Active = bool.Parse(item[8]),
                  SoHocSinh = item[10]
                };
                listMaxReport.Add(studentInClass);
            }
            return listMaxReport;

        }

        public List<ReportMaxClass> ReportMax(string typeReport,bool isRoleGiamDoc,string nameServer)
        {
            DataTable dataTable = null;

            if (typeReport == "GVMax")
            {
                query = "dbo.GvDayNhieuLopNhat";
            }else if (typeReport == "HVMax")
            {
                query = "dbo.HvHocNhieuNhatLop";
            }
            else
            {
                query = "dbo.KhoaHocCoHvHocNhieuNhat";
            }
            var listMaxReport = new List<ReportMaxClass>();

            if (isRoleGiamDoc && DataProvider.NameBranch != nameServer && nameBranchMain != nameServer)
            {
                query = linkServer + query;
            }
            else if (isRoleGiamDoc && nameBranchMain == nameServer)
            {
                query = linkServerMain + query;
            }

            dataTable = DataProvider.Instance.ExcuteDataReader(query);
            var dataRows = dataTable.GetRows(listRow);
            foreach (var item in dataRows)
            {
                var studentInClass = new ReportMaxClass
                {
                  FullName = item[0],
                  Solop =int.Parse(item[1])
                };
                listMaxReport.Add(studentInClass);
            }
            return listMaxReport;

        }

        public List<Employee> TeacherNotInClass(bool isRoleGiamDoc, string nameServer)
        {
            DataTable dataTable = null;
            query = "dbo.GvChuaDuocPhanCong";
            if (isRoleGiamDoc && DataProvider.NameBranch != nameServer && nameBranchMain != nameServer)
            {
                query = linkServer + query;
            }
            else if (isRoleGiamDoc && nameBranchMain == nameServer)
            {
                query = linkServerMain + query;
            }
            dataTable = DataProvider.Instance.ExcuteDataReader(query);
            var listMaxReport = new List<Employee>();
            var dataRows = dataTable.GetRows(listRow);
            foreach (var row in dataRows)
            {
                var empNotInClass = new Employee
                {
                    Id = row[0],
                    BranhId = int.Parse(row[1]),
                    FullName = row[2],
                    DOB = DateTime.Parse(row[3]),
                    Phone = row[4],
                    Qualification = row[5],
                    Nation = row[6],
                    Jobtitle = row[7],
                    Salary = int.Parse(row[8])
                };
                listMaxReport.Add(empNotInClass);
            }
            return listMaxReport;
        }

        public List<Total> TotalByDate(DateTime start, DateTime end, bool isRoleGiamDoc, string nameServer)
        {
            query = "dbo.Report_Cost_By_Payment_Date @dateStart , @dateEnd";
            para = new object[] { start, end };
            if (isRoleGiamDoc && DataProvider.NameBranch != nameServer && nameBranchMain != nameServer)
            {
                query = linkServer + query;
            }
            else if (isRoleGiamDoc && nameBranchMain == nameServer)
            {
                query = linkServerMain + query;
            }
            var listMaxReport = new List<Total>();
            var dataTable = DataProvider.Instance.ExcuteDataReader(query,para);
            var dataRows = dataTable.GetRows(listRow);
            foreach (var row in dataRows)
            {
                if (!String.IsNullOrEmpty(row[0]))
                {
                    var cost = new Total
                    {
                        Cost = decimal.Parse(row[0])
                    };
                    listMaxReport.Add(cost);
                }
           
            }
            return listMaxReport;
        }
    }
}

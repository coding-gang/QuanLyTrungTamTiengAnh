using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using Dtos;
namespace Core.Repository.Reports
{
   public interface IReportRepository
    {
        List<Student> PrintStudentInClass(int id);

        List<Student> PrintStudentInCourses(int id, bool isRoleGiamDoc, string nameServer);

        IEnumerable<ClassStudys> PrintClassByTeacher(string name, bool isRoleGiamDoc, string nameServer);

        List<BillStudent> PrintBillByStudent(int id);

        List<ReportMaxClass> ReportMax(string typeReport, bool isRoleGiamDoc, string nameServer);

        List<CaseStudyMaxStudent> ReportCaHocMax(bool isRoleGiamDoc, string nameServer);

        List<Employee> TeacherNotInClass(bool isRoleGiamDoc, string nameServer);
        List<Total> TotalByDate(DateTime start, DateTime end, bool isRoleGiamDoc, string nameServer);
    }
}

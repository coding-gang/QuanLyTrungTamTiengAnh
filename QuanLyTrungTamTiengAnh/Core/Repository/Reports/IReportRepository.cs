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

        List<Student> PrintStudentInCourses(int id);

        IEnumerable<ClassStudys> PrintClassByTeacher(string name);

        List<BillStudent> PrintBillByStudent(int id);

        List<ReportMaxClass> ReportMax(string typeReport);

        List<CaseStudyMaxStudent> ReportCaHocMax();

        List<Employee> TeacherNotInClass();
        List<Total> TotalByDate(DateTime start, DateTime end);
    }
}

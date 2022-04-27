using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repository.Students;
using Core.Repository.Registers;
using Core.Repository.Courses;
using Core.Repository.Employees;
using Core.Repository.ClassStudy;
using Core.Repository.CaseStudy;
using Core.Repository.Reports;
using Core.Repository.Branchs;

namespace Core.IConfiguration
{
   public interface IUnitOfWork 
    {
       IEmployeeRepository employeeRepository { get; }
       IStudentRepository studentRepository { get;  }
       IRegisterRepository registerRepository { get; }
       ICoursesRepository coursesRepository { get; }
       IClassStudyRepository classStudyRepository { get; }

       ICaseStudyRepository caseStudyRepository { get; }

       IReportRepository reportRepository { get; }
        IBranchRepository branchRepository { get; }

    }
}

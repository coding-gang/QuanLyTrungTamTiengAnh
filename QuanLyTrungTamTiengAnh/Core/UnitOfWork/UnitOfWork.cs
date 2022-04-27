using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.IConfiguration;
using Core.Repository.Courses;
using Core.Repository.Registers;
using Core.Repository.Employees;
using Core.Repository.Students;
using Core.Repository.ClassStudy;
using Core.Repository.CaseStudy;
using Core.Repository.Reports;
using Core.Repository.Branchs;

namespace Core.UnitOfWork
{
  public class UnitOfWork : IUnitOfWork
    {
        public IStudentRepository studentRepository { get; private set; }
        public IRegisterRepository registerRepository { get; private set; }

        public ICoursesRepository coursesRepository { get; private set; }
        public IEmployeeRepository employeeRepository { get; private set;}

        public IClassStudyRepository classStudyRepository { get; private set; }

        public ICaseStudyRepository caseStudyRepository { get; private set; }

        public IReportRepository reportRepository { get; private set; }

        public IBranchRepository branchRepository { get; private set; }

        public UnitOfWork()
        {
            this.studentRepository = new StudentRepository();
            this.registerRepository = new RegisterRepository();
            this.coursesRepository = new CoursesRepository();
            this.employeeRepository = new EmployeeRepository();
            this.classStudyRepository = new ClassStudyRepository();
            this.caseStudyRepository = new CaseStudyRepository();
            this.reportRepository = new ReportRepository();
            this.branchRepository = new BranchRepository();
        }

    }
}

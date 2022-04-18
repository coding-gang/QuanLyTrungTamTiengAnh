﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.IConfiguration;
using Core.Repository.Employees;
using Core.Repository.Students;


namespace Core.UnitOfWork
{
  public class UnitOfWork : IUnitOfWork
    {
        public IStudentRepository studentRepository { get; private set; }

        public IEmployeeRepository employeeRepository { get; private set;}

        public UnitOfWork()
        {
            this.studentRepository = new StudentRepository();
            this.employeeRepository = new EmployeeRepository();
        }

    }
}

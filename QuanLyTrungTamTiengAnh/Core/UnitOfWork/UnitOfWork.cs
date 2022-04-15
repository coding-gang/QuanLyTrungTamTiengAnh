using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.IConfiguration;
using Core.Repository.Registers;
using Core.Repository.Students;

namespace Core.UnitOfWork
{
  public class UnitOfWork : IUnitOfWork
    {
        public IStudentRepository studentRepository { get; private set; }

        public IRegisterRepository registerRepository { get; private set; }

        public UnitOfWork()
        {
            this.studentRepository = new StudentRepository();
            this.registerRepository = new RegisterRepository();
        }

    }
}

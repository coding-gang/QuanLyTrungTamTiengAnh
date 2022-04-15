using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repository.Students;
using Core.Repository.Registers;
namespace Core.IConfiguration
{
   public interface IUnitOfWork 
    {
       IStudentRepository studentRepository { get;  }
       IRegisterRepository registerRepository { get; }
    }
}

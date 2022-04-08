using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repository.Students;
namespace Core.IConfiguration
{
   public interface IUnitOfWork 
    {
       IStudentRepository studentRepository { get;  }
    }
}

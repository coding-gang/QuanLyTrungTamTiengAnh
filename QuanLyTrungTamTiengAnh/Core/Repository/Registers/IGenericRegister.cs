using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos;
namespace Core.Repository.Registers
{
   public interface IGenericRegister
    {
        List<InfoToRegister> GetInfoToRegisters(int idCourse);
    }
}

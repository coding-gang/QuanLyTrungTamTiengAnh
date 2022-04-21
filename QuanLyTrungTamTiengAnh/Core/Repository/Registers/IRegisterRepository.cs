using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.GenericRepositorys;
using DAL.Entities;
namespace Core.Repository.Registers
{
  public  interface IRegisterRepository : IGenericRepository<Register> , IGenericRegister
    {
    }
}

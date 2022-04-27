using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository.ClassStudy
{
   public interface IGenericClassStudy
    {
        IEnumerable<ClassStudys> GetAllWithoutTeacher();
        bool UpdateEmployeesInClass(int id, string idTeacher);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.GenericRepositorys;
namespace Core.Repository.Courses
{
   public interface ICoursesRepository : IGenericRepository<DAL.Entities.Courses> 
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.GenericRepositorys;
using DAL;
using DAL.Extensions;
namespace Core.Repository.Courses
{
    public class CoursesRepository : GenericRepository , ICoursesRepository
    {
        public string query { get; set; }
        public object[] para { get; set; }

        public bool Add(DAL.Entities.Courses item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DAL.Entities.Courses> GetAll()
        {
            query = "Select * from Courses";
            var listCourses = new List<DAL.Entities.Courses>();
            var dataTable =  DataProvider.Instance.ExcuteDataReader(query);
            var dataRows =  dataTable.GetRows(listRow);
            foreach (var item in dataRows)
            {
                var courses = new DAL.Entities.Courses();
                courses.Id = int.Parse(item[0]);
                courses.Lesson = item[1];
                courses.Duration = int.Parse(item[2]);
                courses.Cost = decimal.Parse(item[3]);
                listCourses.Add(courses);
            }
            return listCourses;
        }

        public DAL.Entities.Courses GetById(object id)
        {
            query = $"Select * from Courses where id ={id}";
            var courses = new DAL.Entities.Courses();
            var dataTable = DataProvider.Instance.ExcuteDataReader(query);
            var dataRows = dataTable.GetRows(listRow);
            foreach (var item in dataRows)
            {
                courses.Id = int.Parse(item[0]);
                courses.Lesson = item[1];
                courses.Duration = int.Parse(item[2]);
                courses.Cost = decimal.Parse(item[3]);
            }
            return courses;
        }

        public bool Update(object id, DAL.Entities.Courses item)
        {
            throw new NotImplementedException();
        }


    }
}

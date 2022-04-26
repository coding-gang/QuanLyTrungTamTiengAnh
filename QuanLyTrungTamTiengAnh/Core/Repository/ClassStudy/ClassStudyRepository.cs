using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.GenericRepositorys;
using DAL;
using DAL.Entities;
using DAL.Extensions;
using Dtos;
namespace Core.Repository.ClassStudy
{
    public class ClassStudyRepository : GenericRepository, IClassStudyRepository
    {
        public string query { get; set ; }
        public object[] para { get; set; }

        public bool Add(ClassStudys item)
        {
            query = "dbo.Add_ClassStudy @course_id , @case_id , @teacher_id , @branch_id , @room , @start_date , @time_per_week , @active";
            para = new object[] { item.CourseId, item.CaseId, item.EmpId, item.BranchId, item.Room, item.StartDate, item.TimePerWeek, item.Active };
            return Command(query, para);
        }

        public bool Delete(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClassStudys> GetAll()
        {
            query = "select* from DetailClassStudy";
            var listClass = new List<DetailClassStudy>();
            var dataTable = DataProvider.Instance.ExcuteDataReader(query);
            var dataRows = dataTable.GetRows(listRow);
            foreach (var item in dataRows)
            {
                var classStudy = new DetailClassStudy
                {
                    Id = int.Parse(item[0]),
                    NameLessons = item[1],
                    NameCaseStudy = item[2],
                    NameTeacher = item[3],
                    BranchName = item[4],
                    Room = int.Parse(item[5]),
                    StartDate = DateTime.Parse(item[6]),
                    TimePerWeek = int.Parse(item[7]),
                    Active = bool.Parse(item[8])
                };
                listClass.Add(classStudy);
            }
            return listClass;
        }

        public ClassStudys GetById(object id)
        {
            throw new NotImplementedException();
        }

        public bool Update(object id, ClassStudys item)
        {
            throw new NotImplementedException();
        }
    }
}

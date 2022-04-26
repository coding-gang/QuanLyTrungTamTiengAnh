using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.GenericRepositorys;
using DAL.Entities;
using DAL;
using DAL.Extensions;

namespace Core.Repository.CaseStudy
{
    class CaseStudyRepository : GenericRepository, ICaseStudyRepository
    {
        public string query { get; set ; }
        public object[] para { get; set; }

        public bool Add(CaseStudys item)
        {
            query = "dbo.AddCaseStudy @Name , @start_time , @date_study";
            para = new object[] { item.Name, item.StartTime, item.DateStudy };
            return Command(query, para);
        }

        public bool Delete(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CaseStudys> GetAll()
        {
            query = "select* from Case_Study";
            var listCaseStudy = new List<CaseStudys>();
            var dataTable = DataProvider.Instance.ExcuteDataReader(query);
            var dataRows = dataTable.GetRows(listRow);
            foreach (var item in dataRows)
            {
                var caseStudy = new CaseStudys
                {
                  Id = int.Parse(item[0]),
                  Name = item[1],
                  StartTime = item[2],
                  DateStudy = item[3]
                };
                listCaseStudy.Add(caseStudy);
            }
            return listCaseStudy;
        }

        public CaseStudys GetById(object id)
        {
            throw new NotImplementedException();
        }

        public bool Update(object id, CaseStudys item)
        {
            throw new NotImplementedException();
        }
    }
}

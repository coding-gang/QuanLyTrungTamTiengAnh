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
            throw new NotImplementedException();
        }

        public bool Delete(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CaseStudys> GetAll()
        {
            throw new NotImplementedException();
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

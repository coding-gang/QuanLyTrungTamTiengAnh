using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.GenericRepositorys;
using DAL.Entities;
using DAL;
using DAL.Extensions;
using Core.Repository.Employees;

namespace Core.Repository.Branchs
{
    public class BranchRepository : GenericRepository, IBranchRepository
    {
        public string query { get; set; }
        public object[] para { get; set; }

        public bool Add(Branch item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Branch> GetAll()
        {
            query = "select * from Branches";
            var branches = new List<Branch>();
            var dataTable = DataProvider.Instance.ExcuteDataReader(query);
            var collectionRowData = dataTable.GetRows(listRow);
            foreach (var row in collectionRowData)
            {
                var branch = new Branch();
                branch.Id = int.Parse(row[0]);
                branch.Name = row[1];
                branch.Address = row[2];
                branches.Add(branch);
            }
            return branches;
        }

        public Branch GetById(object id)
        {
            throw new NotImplementedException();
        }

        public bool Update(object id, Branch item)
        {
            throw new NotImplementedException();
        }
    }
}

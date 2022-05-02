using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.GenericRepositorys;
using DAL;
using DAL.Extensions;
using Dtos;
namespace Core.Permission
{
   public class Role : GenericRepository
    {
        private  string query { get; set; }

        public Role()
        {

        }

        public  UserRole  GetRoleCurrentUser()
        {
            query = "Select * from InfoRoleUser";
            var dataTable = DataProvider.Instance.ExcuteDataReader(query);
            var dataRows = dataTable.GetRows(listRow);
            var userRole = new UserRole();
            foreach (var row in dataRows)
            {
                userRole.RoleName = row[0];
                userRole.UserName = row[1];
            }
            return userRole;
        }
    }
}

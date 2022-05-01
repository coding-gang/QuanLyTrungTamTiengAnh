using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace Core.Logins
{
   public class Login
    {
        private static Dictionary<string, string> serverName = new Dictionary<string, string>();
        private Login()
        {
            serverName.Add("Chi nhanh 1", @"DESKTOP-6HQ6JE6\MSSQLSERVER02");
            serverName.Add("Chi nhanh 2", @"DESKTOP-6HQ6JE6\MSSQLSERVER01");
        }
        public static bool LoginSystem(string id, string password,string branch)
        {
            DataProvider.Branch = serverName[branch];
            DataProvider.Id = id;
            DataProvider.Password = password;
            return DataProvider.Instance.ISConnected();
        }
    }
}

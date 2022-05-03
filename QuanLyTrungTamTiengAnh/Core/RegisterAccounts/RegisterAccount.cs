using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.GenericRepositorys;
using Dtos;
using DAL;
namespace Core.RegisterAccounts
{
   public class RegisterAccount : GenericRepository
    {
        private string query { get; set; }

        private object[] para { get; set; }

        private  Dictionary<string, string> serverName = null;

        public RegisterAccount()
        {
            serverName = new Dictionary<string, string>();
            serverName.Add("Chi nhánh 1", @"DESKTOP-6HQ6JE6\MSSQLSERVER02");
            serverName.Add("Chi nhánh 2", @"DESKTOP-6HQ6JE6\MSSQLSERVER01");
        }
        public bool CreateAccount(Account account,bool isLinkServer,string nameBranch =null)
        {
            query = "dbo.sp_TaoTaiKhoan @LGNAME , @PASS , @USERNAME , @ROLE";
            para = new object[] { account.LoginName, account.Password, account.Username, account.Role };
            if (isLinkServer)
            {
                var server = serverName[nameBranch];
                try
                {
                    bool result = DataProvider.Instance.CreateAccountForRoleGiamDoc(query, para, server);
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return Command(query, para);
            }
         
        }
    }
}

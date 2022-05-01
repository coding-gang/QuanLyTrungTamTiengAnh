using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class DataProvider
    {
        private static readonly DataProvider instance;
        private static string id;
        private static bool   isLogin;
        private static string password;
        private static string SERVERNAME;
        public static string Id
        {
            get {  return id; } 
            set { if (!isLogin){ id = value; } }
        }

        public static string Password
        {
            get { return password; }
            set { if (!isLogin) { password = value; } }
        }
        public static string Branch
        {
            get { return SERVERNAME; }
            set { if (!isLogin) { SERVERNAME = value; } }
        }

        public static DataProvider Instance
        {
            get { if (instance == null) return new DataProvider(); return DataProvider.instance; }
        }

        private DataProvider()
        {
        
        }

        private string strCon = $@"server={SERVERNAME};database=DatabaseEnglishCenter;User id={id};password={password}";

        private void hasParameter(SqlCommand cmd, string query, object[] para = null)
        {
            int i = 0;
            foreach (string parameter in query.Split(' ').ToArray().Where(p => p.Contains('@')))
            {
                cmd.Parameters.AddWithValue(parameter, para[i]);
                i++;
            }
        }

        public bool ISConnected()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(strCon);
                conn.Open();
                isLogin = true;
            }
            catch (SqlException err)
            {
                isLogin = false;
            }
            finally
            {
                if(conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return isLogin;
        }

        public bool LogOut()
        {
            isLogin = false;
            return isLogin;
        }

        public DataTable ExcuteDataReader(string query, object[] para = null)
        {
            try
            {
                DataTable data = new DataTable();
                using (SqlConnection conn = new SqlConnection(strCon))
                {

                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (para != null)
                    {

                        {
                            hasParameter(cmd, query, para);
                        }

                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(data);


                }
                return data;
            }
            catch (Exception err)
            {
                throw err;
            }

        }
        public bool ExcuteNonQuery(string query, object[] para = null)
        {
            try
            {
                int kq = 0;
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (para != null)
                    {
                        hasParameter(cmd, query, para);
                    }
                    kq = cmd.ExecuteNonQuery();

                }
                return kq > 0;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public int ExcuteScalar(string query, object[] para = null)
        {
            try
            {
                int count;
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (para != null)
                    {
                        hasParameter(cmd, query, para);

                    }
                    if (cmd.ExecuteScalar() == null)
                    {
                        count = 0;
                    }
                    else
                    {
                        count = (int)cmd.ExecuteScalar();
                    }
                }
                return count;
            }

            catch (Exception err)
            {
                throw err;
            }
        }
    }
}

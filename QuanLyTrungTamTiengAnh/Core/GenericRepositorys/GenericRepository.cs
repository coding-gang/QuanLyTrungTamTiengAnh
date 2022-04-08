using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace Core.GenericRepositorys
{
    public class GenericRepository
    {
        protected string query { get; set; }

        protected object[] para { get; set; }


        protected List<string> listRow { get; set; }

        protected DataProvider dataProvider { get; set; }
        public GenericRepository()
        {
            this.dataProvider = DataProvider.Instance;
        }
     
        public virtual bool Command(object item)
        {
            try
            {
                bool result = this.dataProvider.ExcuteNonQuery(query, para);
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}

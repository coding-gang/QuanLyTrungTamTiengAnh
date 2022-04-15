using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.GenericRepositorys;
using DAL;
using DAL.Extensions;
namespace Core.Repository.Registers
{
    class RegisterRepository : GenericRepository , IRegisterRepository
    {
        public string query { get; set; }
        public object[] para { get; set; }

        public IEnumerable<Register> GetAll()
        {
            var registers = new List<Register>();
            query = "Select * from Registers";
            var dataTable = DataProvider.Instance.ExcuteDataReader(query);
            var dataRow = dataTable.GetRows(listRow);
            foreach(var row in dataRow)
            {
                var register = new Register();
                register.Id = row[0];
                register.StudentId = int.Parse(row[1]);
                register.ClassId = int.Parse(row[2]);
                register.PaymentDate = DateTime.Parse(row[3]);
                register.Amount = Decimal.Parse(row[4]);
                register.Status = int.Parse(row[5]) == 1 ? true : false;
                registers.Add(register);
            }
            return registers;
        }

        public Register GetById(object id)
        {
            throw new NotImplementedException();
        }

        public bool Add(Register item)
        {
            return Command(query);
        }

        public bool Update(object id, Register item)
        {
            return Command(query);
        }

        public bool Delete(object id)
        {
            return Command(query);
        }
    }
}

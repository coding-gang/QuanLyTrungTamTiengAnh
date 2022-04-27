using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Branch()
        {

        }
        public Branch(Branch branch)
        {
            this.Id = branch.Id;
            this.Name = branch.Name;
            this.Address = branch.Address;
        }
    }
}

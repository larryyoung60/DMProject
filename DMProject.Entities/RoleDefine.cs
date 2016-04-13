using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMProject.Entities
{
    public class RoleDefine : IEntityBase
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public int ix { get; set; }
        public virtual ICollection<Privilege> privileges { get; set; }
        public RoleDefine() {
            privileges = new List<Privilege>();

        } 
    }

}

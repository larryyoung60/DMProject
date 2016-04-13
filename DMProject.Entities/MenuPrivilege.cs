using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMProject.Entities
{
     public class MenuPrivilege :IEntityBase
    {
        public int id { get; set; }
        public int menuid { get; set; }
        public virtual Menu menu { get; set; }
        public int Privilegeid { get; set; }
        public virtual Privilege privilege { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMProject.Entities
{
   public class RolePrivilege:IEntityBase
    {
        public int id { get; set; }

        public int RoleId { get; set; }
        public virtual RoleDefine Role {get;set;}

        public int operate { get; set; }
        public int scope { get; set; }
        public int PrivilegeId{ get; set; }
        public virtual Privilege Privilege { get; set; }
    


    }
}

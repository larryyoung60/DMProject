using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMProject.Entities
{
    public class UserRole:IEntityBase
    {
        public int id { get; set; }

        public int UserEntityId { get; set; }
        public virtual UserEntity Userentity { get; set; }
        public virtual RoleDefine RoleDefine{get;set;}
        public int RoleDefineId { get; set; }

    }
}

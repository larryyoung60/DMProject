using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMProject.Entities;

namespace DMProject.Services.Abstract.Base
{
    public interface IPrivilegeService
    {
         string AddPrivilege(Privilege privilege);
         string ModifyPrivilege(Privilege privilege);
         bool DelPrivilege(int privilegeid);
    }
}

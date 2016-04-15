using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMProject.Entities;
using DMProject.Data.Infrastructure;
using DMProject.Data.Repositories;
namespace DMProject.Services.Abstract.Base.Role
{
     public class RoleService
    {
        private IEntityBaseRepository<RoleDefine> _roledefineRepository;
        private IUnitOfWork _unitofWork;

        public RoleService(IEntityBaseRepository<RoleDefine> roledefineRepository, IUnitOfWork unitofWork)
        {
            this._roledefineRepository = roledefineRepository;
            this._unitofWork = unitofWork;
        }

        public string AddRole(RoleDefine roledef)
        {
            
            return "成功!";
        }
        public string ModifyRole(RoleDefine roledef)
        {
            return "成功!";
        }
        public string DelRole(int roleid)
        {
            return "成功!";
        }
    }
}

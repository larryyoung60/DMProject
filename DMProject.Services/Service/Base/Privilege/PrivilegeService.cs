using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMProject.Entities;
using DMProject.Data.Infrastructure;
using DMProject.Data.Repositories;
using DMProject.Services.Abstract.Base;

namespace DMProject.Services
{
    public class PrivilegeService :IPrivilegeService
    {
       private readonly IEntityBaseRepository<Privilege> _privilegeRepository;
        private readonly IUnitOfWork  _unitOfWork;
        public PrivilegeService(
                                 IEntityBaseRepository<Privilege> privilegeRepository,
                                 IUnitOfWork unitOfWork)
        {
            _privilegeRepository = privilegeRepository;
            _unitOfWork = unitOfWork;

        }
        public string AddPrivilege(Privilege privilege)
        {

            Result rs = new Result();
            if (privilege != null)
            {


                if (_privilegeRepository.GetAll().Count(p => p.parentid == privilege.parentid && (p.code == privilege.code || p.name == privilege.name)) > 0)
                    return "名称或权限代码重复！";

                if (privilege.parentid != 0)
                {
                    var parent = _privilegeRepository.FindBy(p => p.id == privilege.parentid);
                    if (parent == null)
                    {
                        return "无效的父节点!";

                    }
                    _privilegeRepository.Add(privilege);
                    _unitOfWork.Commit();

                    Privilege parprivilege = _privilegeRepository.GetSingle(privilege.parentid);
                    privilege.path = parprivilege.path + "," + privilege.id.ToString();
                    _privilegeRepository.Edit(privilege);
                    _unitOfWork.Commit();
                }
                return "成功!";
            }
            return "失败!";
        }
        public string ModifyPrivilege(Privilege privilege)
        {
            if (_privilegeRepository.GetAll().Count(p => p.parentid == privilege.parentid
             && (p.code == privilege.code || p.name == privilege.name)
             && p.id != privilege.id
             ) > 0)
            {
                return "已经存在相同名称(代码)的记录!";

            }

            if (privilege != null)
            {
                _privilegeRepository.Edit(privilege);
                _unitOfWork.Commit();
            }
            return "成功!";
        }
        public bool DelPrivilege(int privilegeid)
        {
            Privilege curpri = _privilegeRepository.GetSingle(privilegeid);
            _privilegeRepository.Delete(curpri);
            _unitOfWork.Commit();
            return true;
        }
    }
}

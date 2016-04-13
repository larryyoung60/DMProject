using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMProject.Entities;
using DMProject.Data.Repositories;


namespace DMProject.Data.Extensions
{
    public static class UserExtensions
    {
        public static UserEntity GetSingleByUsername(this IEntityBaseRepository<UserEntity> userRepository, string name)
        {
            return userRepository.GetAll().FirstOrDefault(x => x.name == name);
        }

        public static IQueryable<UserRole> GetUserRoleList(this IEntityBaseRepository<UserRole> userroleRepository, int userid)
        {
            return userroleRepository.GetAll().Where(x => x.UserEntityId == userid);
        }

        public static IQueryable<RolePrivilege> GetRolePrivilegeList(this IEntityBaseRepository<RolePrivilege> rolepriRepository, int roleid)
        {
            return rolepriRepository.GetAll().Where(x => x.RoleId == roleid);
        }
    }
}

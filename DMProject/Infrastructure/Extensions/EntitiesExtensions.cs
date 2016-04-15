using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DMProject.Entities;
using DMProject.Models;

namespace DMProject.Infrastructure.Extensions
{
    public static class EntitiesExtensions
    {

        public static void UpdateRoleDefine(this RoleDefine role, RoleViewModel roleviewvm)
        {
            role.id = roleviewvm.id;
            role.name = roleviewvm.name;
            role.code = roleviewvm.code;
            role.description = roleviewvm.description;
            role.status = roleviewvm.status;
            role.ix = roleviewvm.ix;

        }


        public static void UpdateUserEntity(this UserEntity userbean, RegistrationViewModel userbeanviewvm)
        {
            userbean.name = userbeanviewvm.name;
            userbean.password = userbeanviewvm.password;
            userbean.email = userbeanviewvm.email;
            userbean.mobile = userbeanviewvm.mobile;
            userbean.truename = userbeanviewvm.truename;
            userbean.sex = userbeanviewvm.sex;  
        }
        public static void UpdatePrivilegeEntity(this Privilege privilegebean, PrivilegeViewModel privilegebeanviewvm)
        {
            privilegebean.name = privilegebeanviewvm.name;
            privilegebean.code = privilegebeanviewvm.code;
            privilegebean.fullcode = privilegebeanviewvm.fullcode;
            privilegebean.type = privilegebeanviewvm.type;
            privilegebean.ix = privilegebeanviewvm.ix;
            privilegebean.parentid = privilegebeanviewvm.parentid;
            privilegebean.path = privilegebeanviewvm.path;
            privilegebean.hasscope = privilegebeanviewvm.hasscope;





    }

    }
}
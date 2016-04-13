using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMProject.Services.Utilities;
using DMProject.Entities;

namespace DMProject.Services.Abstract
{
    public interface IMembershipService
    {
        MembershipContext ValidateUser(string username, string password);
        UserEntity CreateUser(UserEntity userbean, int[] roles);
        UserEntity GetUser(int userId);
        List<Privilege> GetUserRoles(string username);
    }
}

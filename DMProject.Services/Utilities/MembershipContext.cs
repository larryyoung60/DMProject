using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using DMProject.Entities;

namespace DMProject.Services.Utilities
{
    public class MembershipContext
    {
        public IPrincipal Principal { get; set; }
        public UserEntity UserEntity { get; set; }
        public bool IsValid()
        {
            return Principal != null;
        }
    }
}

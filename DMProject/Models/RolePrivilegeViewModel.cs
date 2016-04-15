using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DMProject.Infrastructure.Validators;
namespace DMProject.Models
{
    public class RolePrivilegeViewModel 
    {

        public int roleid {get;set;}
        public List<int> privilegeid { get; set; }


    }
}
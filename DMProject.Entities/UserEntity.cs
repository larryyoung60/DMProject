using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMProject.Entities
{

    public class UserEntity : IEntityBase
    {
        //主键
        public int id { get; set; }
        //用户名
        public string name { get; set; }
        //密码
        public string password { get; set; }
        //真实姓名
        public string  truename { get; set; }
        //性别
        public string  sex { get; set; }
        //生日
        public DateTime ? birthday { get; set; }
        //位置
        public string positon { get; set; }
        //位置描述
        public string position_desc { get; set; }
        //办公电话
        public string office_phone { get; set; }
        //手机
        public string mobile { get; set; }
        //家庭电话
        public string home_phone { get; set; }
        //邮箱
        public string email { get; set; }
        //创建时间
        public DateTime createdate { get; set; }
        //个人照片
        public byte[] image { get; set; } 
        //地址
        public string address { get; set; }
       //是否锁定
        public bool islocked { get; set; }
        //密匙
        public string salt { get; set; }
        //个人所属机构id
        public int ? LocationId { get; set; }
        public virtual Location Location { get; set; }

        public UserEntity() {
            rolelist = new List<RoleDefine>();
        }
        public virtual ICollection<RoleDefine> rolelist { get; set; }




    }
}

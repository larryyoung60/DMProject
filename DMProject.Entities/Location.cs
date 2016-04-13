using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMProject.Entities
{
   public class Location :IEntityBase
    {
        public int id { get; set; }
        public string name { get; set; }

        public string fullname { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public int parentid { get; set; }
        public int ix { get; set; }
        public string path { get; set; }
        public DateTime createtime { get; set; }
        public string special { get; set; }

        public int createid { get; set; }

        public Location() {
            userlist = new List<UserEntity>();
        } 
        public virtual ICollection<UserEntity> userlist { get; set; }
    }
}

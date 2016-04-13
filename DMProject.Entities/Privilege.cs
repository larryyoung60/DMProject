using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMProject.Entities
{
   public class Privilege:IEntityBase
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string fullcode { get; set; }
        public string type { get; set; }
        public int ix { get; set; }
        public int parentid { get; set; }
        public string path { get; set; }
        public string hasscope { get; set; }

    }
}

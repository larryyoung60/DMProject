using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMProject.Entities
{
    public  class Menu:IEntityBase
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string menutype { get; set; }
        public string module { get; set; }
        public string moduleconfig { get; set; }
        public string method { get; set; }
        public int iswindow { get; set; }
        public string url { get; set; }
        public string iconcls { get; set; }
        public int parentid { get; set; }
        public string path { get; set; }
        public int ix { get; set; }
        public int privilege { get; set; }
        public int isseparator { get; set; }
        public string xtype { get; set; }
        public string disable { get; set; }
        public int noprivilege { get; set; }

        public Menu() {
            privilegelist = new List<Privilege>();
        }
        public virtual ICollection<Privilege> privilegelist { get; set; }


    }
}

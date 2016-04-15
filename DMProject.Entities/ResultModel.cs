using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;


namespace DMProject.Entities
{
    public class Result
    {
        public Result()
        {
            isok = false;
            code = "";
            message = "";
            date = DateTime.Now;
            data = new Hashtable();
        }

        public bool isok { get; set; }
        public string code { get; set; }
        public string message { get; set; } 
        public DateTime date { get; set; }
        public Hashtable data { get; set; }

        public void setData(string key, Object value)
        {
            if (data.Contains(key))
            {
                data[key] = value;
            }
            else {
                data.Add(key, value);
            }
        }

    }
}
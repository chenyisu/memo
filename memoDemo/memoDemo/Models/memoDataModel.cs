using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace memoDemo.Models
{
    public class memoDataModel
    {
        public int memo_id { get; set; }
        public string title { get; set; }
        public string memo_content { get; set; }
        public System.DateTime create_date { get; set; }
        public System.DateTime update_date { get; set; }
        public int enable { get; set; }
    }
}
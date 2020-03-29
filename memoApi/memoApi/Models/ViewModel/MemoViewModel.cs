using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace memoApi.Models.ViewModel
{
    public class MemoViewModel
    {
        public int memo_id { get; set; }
        public string title { get; set; }

        public string memo_content { get; set; }

        public string update_date { get; set; }
    }
}
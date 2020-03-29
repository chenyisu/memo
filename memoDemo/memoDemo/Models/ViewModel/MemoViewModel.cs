using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using memoDemo.Controllers;

namespace memoDemo.Models.ViewModel
{
    public partial class MemoViewModel
    {
        public int memo_id { get; set; }
        public string title { get; set; }

        public string memo_content { get; set; }

        public string update_date { get; set; }
    }
}
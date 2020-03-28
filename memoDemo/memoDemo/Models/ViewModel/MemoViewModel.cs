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
        public string title { get; set; }

        public string content { get; set; }

    }
}
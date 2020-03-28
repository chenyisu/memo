using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using memoDemo.Controllers;

namespace memoDemo.Models.ViewModel
{
    public partial class UserViewModel
    {

        public string account { get; set; }

        public string pwd { get; set; }

        public Resp result { get; set; }
    }
}
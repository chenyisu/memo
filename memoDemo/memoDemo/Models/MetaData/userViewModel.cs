using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace memoDemo.Models.ViewModel

{
    [MetadataType(typeof(UserViewModel_metadata))]
    public partial class UserViewModel
    {
        private partial class UserViewModel_metadata
        {
            [Required(ErrorMessage = "帳號請勿空白")]
            [Display(Name = "帳號")]
            public string account { get; set; }

            [Required(ErrorMessage = "密碼請勿空白")]
            [Display(Name = "密碼")]
            public string pwd { get; set; }
        }
    }
}
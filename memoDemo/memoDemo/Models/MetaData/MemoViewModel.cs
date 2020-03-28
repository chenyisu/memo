using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace memoDemo.Models.ViewModel

{
    [MetadataType(typeof(MemoViewModel_metadata))]
    public partial class MemoViewModel
    {
        private partial class MemoViewModel_metadata
        {
            [Display(Name = "標題")]
            public string title { get; set; }

            [Required(ErrorMessage = "內容請勿空白")]
            [Display(Name = "內容")]
            public string content { get; set; }
        }
    }
}
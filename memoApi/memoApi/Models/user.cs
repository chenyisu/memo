//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace memoApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class user
    {
        public int user_id { get; set; }
        public string account { get; set; }
        public string password { get; set; }
        public string user_name { get; set; }
        public System.DateTime create_date { get; set; }
        public System.DateTime update_date { get; set; }
        public int enable { get; set; }
    }
}

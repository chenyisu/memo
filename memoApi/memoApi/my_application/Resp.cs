using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace memoApi.my_application
{
    public class Resp
    {

        /// <summary>
        /// 狀態
        /// </summary>
        public bool isSuccessful { get; set; }
        /// <summary>
        /// 錯誤代碼
        /// </summary>
        public string errCode { get; set; }
        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public string resultMsg { get; set; }

        public Resp()
        {
            isSuccessful = false;
            errCode = string.Empty;
            resultMsg = string.Empty;
        }
    }
}
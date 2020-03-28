using memoDemo.Models;
using memoDemo.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace memoDemo.Controllers
{
    /// <summary>
    /// 提醒: Controller 資料導向 驗證 不做邏輯
    /// </summary>
    public class HomeController : Controller
    {
        memoEntities db = new memoEntities();

        //登入頁面
        public ActionResult Index()
        {
            UserViewModel login = new UserViewModel();
            return View(login);
        }

        //登入 (post)
        [HttpPost]
        public ActionResult login(UserViewModel logon)
        {
            //驗證資料格式
            if (!ModelState.IsValid)
            {return View("Index",logon);}

            //Resp resp = new Resp();
            user user = db.user.Where(x => x.account == logon.account).FirstOrDefault();
            if (user != null)
            {
                Session["auth"] = user.account;
                return RedirectToAction("memo");
            }
            logon.result = new Resp()
            {
                errCode = "9999",
                resultMsg = "登入失敗"
            };
            return View("Index",logon);
        }
    }
}
using memoDemo.Models.ViewModel;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;

namespace memoDemo.Controllers
{
    /// <summary>
    /// 提醒: Controller 資料導向 驗證 不做邏輯
    /// </summary>
    public class HomeController : Controller
    {
        public static readonly Uri _baseAddress = new Uri("http://localhost:9564/api/user");

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

            string userToString = JsonConvert.SerializeObject(logon);
            using(var httpClient = new HttpClient())
            {
                // post
                var postTask = httpClient.PostAsync(_baseAddress, new StringContent(userToString, Encoding.UTF8, "application/json"));
                postTask.Wait();
                if (postTask.Result.IsSuccessStatusCode)
                {
                    Session["auth"] = logon.account;
                    return RedirectToAction("Index", "Memo"); //導向memo頁面
                }
                else
                {
                    logon.result = new Resp()
                    {
                        errCode = "9999",
                        resultMsg = "登入失敗"
                    };
                    return View("Index", logon);
                }
            }
        }
    }
}
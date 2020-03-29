using System;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;
using memoDemo.Models.ViewModel;
using Newtonsoft.Json;

namespace memoDemo.Controllers
{

    public class NewMemoController : Controller
    {
        public static readonly Uri _baseAddress = new Uri("http://localhost:9564/api/memo");

        // NewMemo 頁面
        public ActionResult New()
        {
            if (Session["auth"] != null)
            {
                MemoViewModel memo = new MemoViewModel();
                return View(memo);
            }
            return RedirectToAction("Index", "Home");
        }
        //新增MEMO
        [HttpPost]
        public ActionResult addMemo(MemoViewModel memo)
        {
            //驗證
            if (!ModelState.IsValid)
            {
                return View("New", memo);
            }
            string memoToString = JsonConvert.SerializeObject(memo);
            using(var httpClient = new HttpClient())
            {
                // http post
                var postTask = httpClient.PostAsync(_baseAddress, new StringContent(memoToString, Encoding.UTF8, "application/json"));
                postTask.Wait();
                if (postTask.Result.IsSuccessStatusCode)
                {
                    TempData["edit"] = true;
                }
            }
            return RedirectToAction("Index", "Memo");
        }
    }
}
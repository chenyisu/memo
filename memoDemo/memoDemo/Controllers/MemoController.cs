using memoDemo.Models;
using memoDemo.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Text;

namespace memoDemo.Controllers
{
    public class MemoController : Controller
    {
        memoEntities db = new memoEntities();
        public static readonly Uri _baseAddress = new Uri("http://localhost:9564/api/memo");



        // Memo首頁
        public ActionResult Index()
        {
            // 是否登入
            if (Session["auth"] != null)
            {
                Uri address = _baseAddress;
                using (var httpClient = new HttpClient())
                {
                    var responseTask = httpClient.GetAsync(address);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsStringAsync();
                        List<memo> listMemo = JsonConvert.DeserializeObject<List<memo>>(readTask.Result);
                        readTask.Wait();
                        return View(listMemo);
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }
        #region test
        // 修改 做法1 (get該筆資訊)
        //public ActionResult editMemo(int id)
        //{
        //    // 是否登入
        //    if (Session["auth"] != null)
        //    {
        //        Uri address = new Uri(_baseAddress, "memo/"+id);
        //        using (var httpClient = new HttpClient())
        //        {
        //            var responseTask = httpClient.GetAsync(address);
        //            // 等待http回傳
        //            responseTask.Wait();
        //            var result = responseTask.Result;
        //            if (result.IsSuccessStatusCode)
        //            {
        //                var readTask = result.Content.ReadAsStringAsync();
        //                memo memo = JsonConvert.DeserializeObject<memo>(readTask.Result);
        //                readTask.Wait();
        //                // ViewModel
        //                MemoViewModel editmemo = new MemoViewModel()
        //                {
        //                    title = memo.title,
        //                    memo_id = id,
        //                    memo_content = memo.memo_content,
        //                    update_date = memo.update_date.ToString("yyyy/MM/dd")
        //                };
        //                return View(editmemo);
        //            }
        //        }
        //    }
        //    return RedirectToAction("Index", "Home");
        //}
        #endregion

        // 修改 做法2 (傳入該筆資訊)
        public ActionResult editMemo(memo thisMemo)
        {
            // 是否登入
            if (Session["auth"] != null)
            {
                // ViewModel
                MemoViewModel editmemo = new MemoViewModel()
                {
                    title = thisMemo.title,
                    memo_id = thisMemo.memo_id,
                    memo_content = thisMemo.memo_content,
                    update_date = thisMemo.update_date.ToString("yyyy/MM/dd")
                };
                return View(editmemo);
            }
            return RedirectToAction("Index", "Home");
        }


        //修改
        [HttpPost]
        public ActionResult editMemo(MemoViewModel editmemo)
        {
            string editToString = JsonConvert.SerializeObject(editmemo);

            using (var httpClient = new HttpClient())
            {
                // http post
                var putTask = httpClient.PutAsync(_baseAddress, new StringContent(editToString, Encoding.UTF8, "application/json"));
                putTask.Wait();
                if (putTask.Result.IsSuccessStatusCode)
                {
                   TempData["edit"] = true;
                }
            }
            return RedirectToAction("Index");
        }

        //刪除
        public ActionResult deleteMemo(int id)
        {
            //var delMemo = db.memo.Where(m => m.memo_id == id).FirstOrDefault();
            //db.memo.Remove(delMemo);
            //db.SaveChanges();
            //bool deletestate = true;

            Uri address = new Uri(_baseAddress, "/api/memo/"+id);
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.DeleteAsync(address);
                //if (!response.Result.IsSuccessStatusCode)
                //{
                //    deletestate = false;
                //}
            }
            return RedirectToAction("Index");
        }
    }
}
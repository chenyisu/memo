using memoDemo.Models;
using memoDemo.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace memoDemo.Controllers
{
    public class MemoController : Controller
    {
        memoEntities db = new memoEntities();



        // Memo首頁
        public ActionResult Index()
        {
            if (Session["auth"] != null)
            {
                var listMemo = db.memo.ToList();
                return View(listMemo);
            }
            return RedirectToAction("Index", "Home");
        }



        //修改
        public ActionResult editMemo(int id)
        {
            var memo = db.memo.Where(m => m.memo_id == id).FirstOrDefault();
            MemoViewModel editmemo = new MemoViewModel()
            {
                title = memo.title,
                memo_id = id,
                memo_content = memo.memo_content,
                update_date = memo.update_date.ToString("yyyy/MM/dd")
            };
            return View(editmemo);

        }
        //修改
        [HttpPost]
        public ActionResult editMemo(MemoViewModel editmemo)
        {
            var memo = db.memo.Where(m => m.memo_id == editmemo.memo_id).FirstOrDefault();
            memo.memo_content = editmemo.memo_content;
            memo.title = editmemo.title;
            memo.update_date = DateTime.Today;
            int i = db.SaveChanges();
            if (i > 0)
            {
                TempData["edit"] = true;
            }
            return RedirectToAction("Index");
        }

        //刪除
        public ActionResult deleteMemo(int id)
        {
            var delMemo = db.memo.Where(m => m.memo_id == id).FirstOrDefault();
            db.memo.Remove(delMemo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
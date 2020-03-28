using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using memoDemo.Models;
using memoDemo.Models.ViewModel;

namespace memoDemo.Controllers
{

    public class NewMemoController : Controller
    {
        memoEntities db = new memoEntities();
        DateTime today = DateTime.Today;


        // GET: NewMemo
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

            memo thisMemo = new memo()
            {
                title = memo.title,
                memo_content = memo.content,
                update_date = today,
                create_date = today,
                enable=1
            };
            db.memo.Add(thisMemo);
            int result = db.SaveChanges();
            if (result > 0)
            {
                TempData["msg"] = true;
            }
            return RedirectToAction("Index", "Memo");

        }
    }
}
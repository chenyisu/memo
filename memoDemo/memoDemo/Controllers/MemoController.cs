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



        // GET: Memo
        public ActionResult Index()
        {
            if (Session["auth"] != null)
            {
                var listMemo = db.memo.ToList();
                return View(listMemo);
            }
            return RedirectToAction("Index", "Home");
        }

        //public ActionResult editMemo(int id)
        //{
        //    return View();
        //}
        public ActionResult editMemo(memo memo)
        {
            return View();
        }

        public ActionResult deleteMemo(int id)
        {
            var delMemo = db.memo.Where(m => m.memo_id == id).FirstOrDefault();
            db.memo.Remove(delMemo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
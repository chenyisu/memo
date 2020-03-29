using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using memoApi.Models;
using memoApi.my_application;
using Newtonsoft.Json;

namespace memoApi.Controllers
{
    public class memoController : ApiController
    {
        memoEntities db = new memoEntities();

        // GET: api/memo 列表
        public IHttpActionResult Get()
        {
            var memoList = db.memo.OrderBy(m => m.memo_id).ToList();
            return Ok(memoList);

        }
        //public string Get()
        //{
        //    Resp resp = new Resp();
        //    var memoList = db.memo.OrderBy(m=>m.memo_id).ToList();
        //    resp.isSuccessful = memoList != null ? true : false;
        //    resp.resultMsg = JsonConvert.SerializeObject(memoList);
        //    //return memoList;
        //    return JsonConvert.SerializeObject(resp);
        //}

        // GET: api/memo/5  該memo
        public memo Get(int id)
        {
            var theMemo = db.memo.Where(m => m.memo_id == id).FirstOrDefault();
            return theMemo;
        }

        // POST: api/memo
        public void Post([FromBody]string value)
        {
        }


        // PUT: api/memo/5
        public void Put(int id, [FromBody]string value)
        {
            
        }

        // DELETE: api/memo/5  刪除該memo
        public void Delete(int id)
        {
            var theMemo = db.memo.Where(m => m.memo_id == id).FirstOrDefault();
            
            db.memo.Remove(theMemo);
            db.SaveChanges();
        }
    }
}

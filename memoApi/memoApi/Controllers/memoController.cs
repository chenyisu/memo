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
            //取得整張memo表
            var memoList = db.memo.OrderBy(m => m.memo_id).ToList();
            return Ok(memoList);

        }

        // GET: api/memo/5  該memo
        public IHttpActionResult Get(int id)
        {
            // 尋找該memo
            var theMemo = db.memo.Where(m => m.memo_id == id).FirstOrDefault();
            return Ok(theMemo);
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

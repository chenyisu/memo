using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using memoApi.Models;
using memoApi.Models.ViewModel;


namespace memoApi.Controllers
{

    public class UserController : ApiController
    {
        memoEntities db = new memoEntities();

        // POST: api/User
        public IHttpActionResult Post(UserViewModel fUser)
        {
            var user = db.user.Where(m => m.account == fUser.account && m.password == fUser.pwd).FirstOrDefault();
            if (user != null)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}

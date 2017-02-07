using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapis2.Models;
namespace webapis2.Controllers
{
    public class loginController : ApiController
    {
        dbmanageDataContext db = new dbmanageDataContext();
        public class response
        {
            public string status { get; set; }
            public string message { get; set; }
        }
        public string Get() { return "a"; }
        public response Get(string uname, string password)
        {
            var data = from l in db.tbllogins
                       where l.username == uname && l.password == password
                       select l;
            response
                res = new response();
            if (data.ToList().Count == 1)
            {
                res.status = "1";
                res.message = data.ToList()[0].loginid.ToString();

            }
            else
            {
                res.status = "-1";
                res.message = "username or password wrong!";

            }
            return res;

        }

    }
}

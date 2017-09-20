using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using WebAPI_2013.Models;

namespace WebAPI_2013.Controllers
{
    [RoutePrefix("cookie")]
    public class CookieController : ApiController
    {
        [Route("")]
        public HttpResponseMessage Get()
        {
            var resp = new HttpResponseMessage();
            var cookie = new CookieHeaderValue("session-id", "123456");
            cookie.Expires = DateTimeOffset.Now.AddDays(1);
            cookie.Domain = Request.RequestUri.Host;
            cookie.Path = "/";

            resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            return resp;
        }

        //-A CookieHeaderValue contains a collection of CookieState instances. 
        //Each CookieState represents one cookie. Use the indexer method to get a CookieState by name, as shown.
        [Route("Details")]
        public HttpResponseMessage GetDetails()
        {
            var resp = new HttpResponseMessage();
            var nv = new NameValueCollection();
            nv["sid"] = "12345";
            nv["token"] = "abcdef";
            nv["theme"] = "dark blue";
            var cookie = new CookieHeaderValue("session", nv);

            resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            return resp;
        }

        [Route("valueCookie")]
        public IHttpActionResult GetValueCookie()
        {
            var resp = new HttpResponseMessage();
            myCookie cook = new myCookie();

            CookieHeaderValue cookie = Request.Headers.GetCookies("session").FirstOrDefault();
            if (cookie != null)
            {
                CookieState cookieState = cookie["session"];
                cook.SessionId = cookieState["sid"];
                cook.SessionToken = cookieState["token"];
                cook.Theme = cookieState["theme"];
            }
            return Ok(cook);
        }

    }
}

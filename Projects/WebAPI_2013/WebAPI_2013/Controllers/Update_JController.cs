using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI_2013.Models;

namespace WebAPI_2013.Controllers
{
     
    [RoutePrefix("Update")] 
    public class Update_JController : ApiController
    {
        static readonly Dictionary<Guid, Update_J> dicoUpdate = new Dictionary<Guid, Update_J>();

        [HttpPost]
        [Route("")]
        //[ActionName("Complex")]
        public HttpResponseMessage PostComplex(Update_J up)
        {
            if (ModelState.IsValid && up != null)
            {

                //converts any HTML Markup in the status text
                up.Status = HttpUtility.HtmlEncode(up.Status);

                //assing new id
                var id = Guid.NewGuid();
                dicoUpdate[id] = up;

                //create response 201
                var reponse = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content=new StringContent(up.Status)
                };
                reponse.Headers.Location = new Uri(Url.Link("GetStatus", new { id = id }));
                return reponse;
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest);
        }


        [Route("{id}" ,Name="GetStatus")]
        //[Route("{id}")] //http://localhost:51653/Update/00000000-0000-0000-0000-000000000000
        public Update_J GetStatus(Guid id)
        {
            Update_J upj;
            if(dicoUpdate.TryGetValue(id,out upj))
            {
                return upj;
            }
            else
                throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        #region generated Auto
        // GET: api/Update_J
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Update_J/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Update_J
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Update_J/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Update_J/5
        public void Delete(int id)
        {
        }
#endregion

        [HttpPost]
        [Route("simple")]
        public HttpResponseMessage PostSimple([FromBody] string value)//By default, Web API tries to get simple types from the request URI. The FromBody attribute tells Web API to read the value from the request body.
        {
            if(value!=null)
            {
                Update_J up = new Update_J
                {
                    Status=HttpUtility.HtmlEncode(value),
                    Date=DateTime.UtcNow

                };

                var id = Guid.NewGuid();
                dicoUpdate[id] = up;

                var response = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content=new StringContent(up.Status)
                };
                response.Headers.Location=new Uri(Url.Link("GetStatus",new {id=id}));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [Route("simpleArray")]
        public HttpResponseMessage PostSimple([FromBody] string []tabvalue)//By default, Web API tries to get simple types from the request URI. The FromBody attribute tells Web API to read the value from the request body.
        {
            if (tabvalue != null && tabvalue.Length>1)
            {
                Update_J up = new Update_J
                {
                    Status = HttpUtility.HtmlEncode(tabvalue[0]),
                    Date = DateTime.UtcNow

                };

                var id = Guid.NewGuid();
                dicoUpdate[id] = up;

                var response = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(up.Status)
                };
                response.Headers.Location = new Uri(Url.Link("GetStatus", new { id = id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}

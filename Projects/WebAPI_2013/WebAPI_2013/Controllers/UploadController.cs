using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebAPI_2013.Controllers
{
    
    [RoutePrefix("file")]
    public class UploadController : ApiController
    {

        #region Generated
            // GET: api/Upload
            public IEnumerable<string> Get()
            {
                return new string[] { "value1", "value2" };
            }

            // GET: api/Upload/5
            public string Get(int id)
            {
                return "value";
            }

            // POST: api/Upload
            public void Post([FromBody]string value)
            {
            }

            // PUT: api/Upload/5
            public void Put(int id, [FromBody]string value)
            {
            }

            // DELETE: api/Upload/5
            public void Delete(int id)
            {
            }

        #endregion

        [Route("upload")]
        public async Task<HttpResponseMessage> PostFormData()
            {

            //check if requests contains multipart/form-data
                if(!Request.Content.IsMimeMultipartContent())
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);//code error :415
                }

                string root = HttpContext.Current.Server.MapPath("~/App_Data");
                var provider = new MultipartFormDataStreamProvider(root);


                try
                {
                    //read the form data
                    await Request.Content.ReadAsMultipartAsync(provider);

                    //apres lecture du fichier nous obtenons un objet MultipartFileData
                    foreach (MultipartFileData file in provider.FileData)
                    {
                        //•The Content-Disposition header includes the name of the control. For files, it also contains the file name.
                        System.Diagnostics.Trace.WriteLine(file.Headers.ContentDisposition.FileName);
                        System.Diagnostics.Trace.WriteLine("Server file path: " + file.LocalFileName);
                    }

                    foreach (var key in provider.FormData.AllKeys)
                    {
                        foreach (var val in provider.FormData.GetValues(key))
                        {
                            System.Diagnostics.Trace.WriteLine(String.Format("{0}:{1}",key,val));
                        }
                    }
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception e)
                {

                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
                }
            }


        [Route("forms")]
        public async Task<HttpResponseMessage> PostFormDatanoFile()
        {

            //check if requests contains multipart/form-data
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);//code error :415
            }

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);


            try
            {
                //read the form data
                await Request.Content.ReadAsMultipartAsync(provider);     

                foreach (var key in provider.FormData.AllKeys)
                {
                    foreach (var val in provider.FormData.GetValues(key))
                    {
                        System.Diagnostics.Trace.WriteLine(String.Format("{0}:{1}", key, val));
                    }
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}

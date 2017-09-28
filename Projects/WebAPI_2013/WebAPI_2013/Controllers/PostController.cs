using Discover_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_2013.Controllers
{
    [RoutePrefix("testController")]
    public class PostController : ApiController
    {
        private readonly IPostRepository _repository;

        public PostController(IPostRepository repository)
        {
            _repository = repository;
        }

        public PostController()
        {
            _repository = new PostRepository();
        }

         
        [Route("")]
        public IQueryable<Post> Get()
        {
            return _repository.GetAll();
        }

        [Route("{id}")]
        public Post Get(int id)
        {
            /* \if matriculeconnecte
             * \a b  vrai
             * endif  
          * */
            Post _p = null;
            _p = _repository.Get(id);
            if (_p != null)
                return _p;
            else
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        [Route("Post",Name ="GetPostbyID")]
        public HttpResponseMessage Post(Post post)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(post);
                var response = Request.CreateResponse(HttpStatusCode.Created);
                response.StatusCode = HttpStatusCode.Created;
                //return CreatedAtRoute("GetById", new { id = product.Id }, product);
                string uri = Url.Link("GetbyID", new { id = post.Id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));
        }
    }
}

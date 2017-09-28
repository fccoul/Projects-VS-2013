using Discover_WebAPI.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebAPI_2013.Controllers;
using Xunit;

namespace WebAPI_2013.Test
{
    public class TestPostController
    {
        [Fact]
       public void Get_with_in_Memory_Hosting_failed()
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            HttpServer server = new HttpServer(config);

            HttpClient client = new HttpClient(server);
            var response = client.GetAsync("http://loclahost:51653/testController").Result;

            Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);

        }

        [Fact]
        public void Get_with_in_Memory_Hosting_Succes()
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            HttpServer server = new HttpServer(config);

            HttpClient client = new HttpClient(server);
            var response = client.GetAsync("http://loclahost:51653/testController").Result;

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Fact]
        public void GetById_shouldReturn_thepost()
        {
            List<Post> _posts = new List<Post>();
            _posts.Add(new Post { Id = 1, Date = new DateTime(2010, 04, 09), Title = "An introduction to the web api", Body = "..." });
            _posts.Add(new Post { Id = 2, Date = new DateTime(2010, 04, 11), Title = "REST is BEST", Body = "..." });

            // Mock<IPostRepository> repo = new Mock<IPostRepository>();
            //PostController controller = new PostController(repo.Object);
            ////IPostRepository repo = Mock.Of<PostRepository>();
            PostController controller = Mock.Of<PostController>();
            
            Mock.Get(controller).Setup(m => m.Get(2)).Returns(_posts[1]);
           // controller.Get(2);
           // repo.Verify(r => r.Get(2));
        }
    }
}
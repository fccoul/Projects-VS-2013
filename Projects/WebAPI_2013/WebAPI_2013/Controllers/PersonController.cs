using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_2013.Models;

namespace WebAPI_2013.Controllers
{
    [RoutePrefix("Person")]
    public class PersonController : ApiController
    {
        [HttpPut]
        [Route("maj")]
        public string Put(Person p)
        {
            return p.name + " " + p.surname;
        }

        [HttpPut]
        [Route("majcomplex")]
        public string PutComplex([FromUri]Int32 ID,[FromBody] string name)
        {
            return "ID is :" + ID + " Name : " + name;
        }

        [HttpPost]
        [Route("insert")]
        public string Postcomplex(Person p)
        {
             return p.name + " " + p.surname;
        }

        [HttpGet]
        [Route("JSON")]
        //public List<string> Post()
        public List<Person> Post()
        {
            /*
            List<string> lst = new List<string>();
            lst.Add("Tom sawyer");
            lst.Add("Pierre lapin");
            lst.Add("Polo debruille");
            
            return lst;
             * */

            /***avec un type complex*/
            List<Person> lst = new List<Person>();
            Person p1 = new Person();
            p1.name = "yuri";
            p1.surname = "boyka";

            Person p2 = new Person();
            p2.name = "tommy";
            p2.surname = "san";

            lst.Add(p1);
            lst.Add(p2);

            return lst;
        }
    }
}

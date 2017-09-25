using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI_2013.Models;

namespace WebAPI_2013.Controllers
{

    /*
     * pa defaut :
     * •If the parameter is a simple type like int, bool, double etc., WebAPI tries to get values from the URI (Either from route data or from QueryString).
       •If a parameter is a complex type like customer, product, employee etc., WebAPI tries to get values from request body.
     * ex: void Action(int id,Post P):id sera lu depuis l'URL et Post sera lu depuis le Body....
     * 
     * Si nous avions deux types complex àpasser en paramètre ,il n'ya qu'unseul qui pourra etre lu depuis le body et l'autre depuis une autre source:formURI par ex;
     * ou bien dans ce cas crrer un objet(un autyre type complex) qui regroupe ces deux types.
     * web api ne lit le coprs de la response(frombody) qu'une seule fois, si ns avions plusieurs types complex dans le frombody il faudrait en creer
     * un seul personnalisé qui regroup ces types ou bien passer les autres types , depuis l'URI(fromURI)

     * */
    //[ApiExplorerSettings(IgnoreApi = true)]
    [RoutePrefix("params")]
    public class FromBodyUriController : ApiController
    {

        private static ConcurrentDictionary<string, Product> _products = new ConcurrentDictionary<string, Product>();
        List<Product> _lst = new System.Collections.Generic.List<Product>();
        List<Update_J> _lstUpdate = new List<Update_J>();
        public FromBodyUriController()
        {
            _products.TryAdd("1", new Product { Id = "1", Name = "clavier", Price = 5, Category = "Ordinateur", Quantite = 40 });
            _products.TryAdd("2", new Product { Id = "2", Name = "table", Price = 13, Category = "Restaurant", Quantite = 18 });
            _products.TryAdd("3", new Product { Id = "3", Name = "pneu", Price = 45, Category = "Voiture", Quantite = 4 });


            _lst = _products.Values.ToList();
        }


        [Route("")]
        public IQueryable<Product> Get()
        {
            List<Product> _lst = new System.Collections.Generic.List<Product>();
            _lst = _products.Values.ToList();
            return _lst.AsQueryable();
        }

        
        [Route("Update/{Id}")]
        public HttpResponseMessage Put(string Id, [FromBody] Product prod)
        {
            if (prod == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            if (!_products.Keys.Contains(Id))
            {
                //return new HttpResponseMessage(HttpStatusCode.NotFound);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Produit non trouve");
            }

            _products[Id] = prod;
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

       
        [Route("UpdateUri")]
        public HttpResponseMessage PutUri(string _Id,[FromUri] Product prod)
        {
            if (prod == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            if (!_products.Keys.Contains(prod.Id))
            {
                //return new HttpResponseMessage(HttpStatusCode.NotFound);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Produit non trouve");
            }

            _products[prod.Id] = prod;
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }//PutUri :bleme ala genration de la doc , comm quoi cle de l'element deja ajouté,renommer les _params 

       // [ApiExplorerSettings(IgnoreApi = true)]
        [Route("UpdateMixed")]
        public HttpResponseMessage PutMixed([FromBody]string Id, [FromUri] Product prod)
        {
            if (prod == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            if (!_products.Keys.Contains(Id))
            {
                //return new HttpResponseMessage(HttpStatusCode.NotFound);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Produit non trouve");
            }

            _products[Id] = prod;
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

       
        [HttpPut]
        [Route("UpdateComplex1")]
        public IHttpActionResult PutComplex([FromBody] Product prod, [FromUri] Update_J up)
        {
            if (prod == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (!_products.Keys.Contains(prod.Id))
            {
                //return new HttpResponseMessage(HttpStatusCode.NotFound);
                return BadRequest("Produit non trouve");
            }

            _products[prod.Id] = prod;
            _lstUpdate.Add(up);

            return Ok(up);
        }

        
        [Route("UpdateComplex2")]//---idem au Updatecomplex1 
        public IHttpActionResult PutComplex2( Product prod, [FromUri] Update_J up)
        {
            if (prod == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (!_products.Keys.Contains(prod.Id))
            {
                //return new HttpResponseMessage(HttpStatusCode.NotFound);
                return BadRequest("Produit non trouve");
            }

            _products[prod.Id] = prod;
            _lstUpdate.Add(up);

            return Ok(up);
        }
    }
}

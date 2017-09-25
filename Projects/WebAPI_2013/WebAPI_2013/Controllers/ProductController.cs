using System.Collections.Generic;
using System.Web.Http;
using WebAPI_2013.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Concurrent;
using System.Web.Http.Results;
using System.Web.Http.Description;
 

namespace WebAPI_2013.Controllers
{
    
    //[RoutePrefix("api/products")]
    //[Route("Products")]//possibilite de call directement la methlod eGet via http://localhost:51653/products
    [RoutePrefix("Products")]//utile si on definit des routes au sein des methodes du controller et que l'on veut conserver le emee prefix
    public class ProductController : ApiController
    {

        #region discover WEB API 2
        //public static List<Product> _products=new List<Product>();
        private static ConcurrentDictionary<string,Product> _products=new ConcurrentDictionary<string,Product>();
        List<Product> _lst = new System.Collections.Generic.List<Product>();
        public ProductController ()
	        {
               _products.TryAdd("1",new Product{Id="1",Name="clavier",Price=5,Category="Ordinateur",Quantite=40});
               _products.TryAdd("2", new Product { Id = "2", Name = "table", Price = 13, Category = "Restaurant" ,Quantite=18});
               _products.TryAdd("3", new Product { Id = "3", Name = "pneu", Price = 45, Category = "Voiture" ,Quantite=4});

             
               _lst = _products.Values.ToList();
	        }

        [Route("")]//http://localhost:51653/products
        public IQueryable<Product> GetAll()// 
        {
            List<Product> _lst = new System.Collections.Generic.List<Product>();
            _lst = _products.Values.ToList();
            return _lst.AsQueryable();
        }

        [Route("AllProducts")]
        public IQueryable<Product> Get()//http://localhost:51653/products/AllProducts : ici on conserve le prefixe "products"
        {
            List<Product> _lst = new System.Collections.Generic.List<Product>();
            _lst = _products.Values.ToList();
            return _lst.AsQueryable();
        }

        
        [Route("~/FindQuantite/{Quantite:int?}")]//value par defaut parameter...
        public Product GetProduct_byQuantite(Int32 Quantite=4)
        {
             //get quantite de table http://localhost:51653/findquantite/18
            //get valeur par defaut ici 4 dou les pneu http://localhost:51653/findquantite
            Product product = _lst.Find(l => l.Quantite == Quantite);
            if (product != null)
            {
                return product;
            }
            else
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

        }


        [Route("~/FindDefault/{Quantite:int=4}")]//http://localhost:51653/FindDefault : ici on override la route avec le prefixe, et on fixe la valeur par defaut à 4
        public Product GetProd_byQuantite(Int32 Quantite)//--dou plus ne cessaire de donner value par defaut ici
        {
            //get quantite de table http://localhost:51653/FindDefault/18
            //get valeur par defaut ici 4 dou les pneu http://localhost:51653/FindDefault
            Product product = _lst.Find(l => l.Quantite == Quantite);
            if (product != null)
            {
                return product;
            }
            else
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

        }

        
        [Route("~/FindProduct")]//http://localhost:51653/FindProduct : ici on override la route avec le prefixe, pr acceder direcetement sans utiliser le prefix definit au niveau classe
        public Product GetProduct_byId()
        {
            string Id = "2";
            Product product = null;
            if (_products.TryGetValue(Id, out product))
            {
                return product;
            }
            else
                NotFound();
            return null;

        }

        [Route("ProductById/{Id}")]//passage de parameter à la route
        public Product GetProduct_byId(string Id)//http://localhost:51653/products/ProductById/2
        {
             
            Product product = null;
            if (_products.TryGetValue(Id, out product))
            {
                return product;
            }
            else
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

        }

        [Route("ProductById/{Id}/Test")]//possibilitéde surcharger la methode tout en modifiant le template route au client
        public Product GetProd_byId(string Id)//http://localhost:51653/products/ProductById/2
        {

            Product product = null;
            if (_products.TryGetValue(Id, out product))
            {
                return product;
            }
            else
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

        }


        [Route("ProductByName/{Libelle:minlength(3)}")] //-contrainte parameter
        public Product GetProd_byName(string Libelle) 
        {
            //OK :http://localhost:51653/products/ProductByName/table ,vu que le mot table >=3
            //KO:http://localhost:51653/products/ProductByName/ta
            Product product = _lst.Find(l => l.Name == Libelle);               
            if(product!=null) 
            {
                return product;
            }
            else
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

        }


        [Route("AllProducts/name")]
        public string GetPr()
        {
            string _mId = _lst.Max(m => m.Id);
            int idPrec=int.Parse(_mId) - 1;
            string uri = Url.Link("GetFCOProduct", new { id = idPrec.ToString() });//construction de l'url servant a appelr une route bien particulière au travers du name "GetFCOProduct"
            return uri;
        }

        [Route("AllProducts/name/{id}", Name = "GetFCOProduct")]
        public Product GetPr(string id)
        {
            Product product = null;
            if (_products.TryGetValue(id, out product))
            {
                return product;
            }
            else
                NotFound();
            return null;            
        }

#endregion


        [Route("{id}",Name="GetById")]
        public IHttpActionResult Get(string id)//http://localhost:51653/products/2
        {
            Product product=null;
            if (_products.TryGetValue(id, out product))
            {
                return Ok(product); //si elt trouvé Returns an OkNegotiatedContentResult
                /*
                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.OK) //return resultat au foramt xml
                    {
                        Content=new ObjectContent<Product>(product,new System.Net.Http.Formatting.XmlMediaTypeFormatter{
                            UseXmlSerializer=true
                        })
                        
                    });
                */
            }
            else
            {
                return NotFound();// Returns a NotFoundResult
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(Product product)
        {
            if(product == null)
            {
                return BadRequest("Product cannot be null");
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            product.Id = Guid.NewGuid().ToString();
            _products[product.Id] = product;
            //GetById :  namde de la route Get
            return CreatedAtRoute("GetById", new { id=product.Id},product);

        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(string id,Product product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_products.Keys.Contains(id))
            {
                return NotFound();
            }

            _products[id] = product;
            return new StatusCodeResult(HttpStatusCode.NoContent,this);

        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            Product product = null;
            _products.TryRemove(id, out product);
            return new StatusCodeResult(HttpStatusCode.NoContent, this);
        }

        // POST: api/Product
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}

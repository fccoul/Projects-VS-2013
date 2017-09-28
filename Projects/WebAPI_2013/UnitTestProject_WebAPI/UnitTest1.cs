using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebAPI_2013.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using WebAPI_2013;
using System.Collections.Generic;
using Discover_WebAPI.Models;
using WebAPI_2013.Controllers;
using System.Web.Http.Routing;
using System.Web.Http.Hosting;

namespace UnitTestProject_WebAPI
{
    [TestClass]
    public class UnitTest1
    {
        string valConverted = string.Empty;
        [TestInitialize]// C'est l'endroit idéal pour factoriser des initialisations dont dependent les tests
        public void InitialisationTest()
        {
            //valConverted = "150";
            valConverted = "bg";
        }

        [TestMethod]
        public void TestMethod1()
        {
            Mock<checkEmploye> chk = new Mock<checkEmploye>();
            //We need to use a lambda expression to point to a specific function. 
            chk.Setup(x => x.checkEmp()).Returns(true);

            processEmployee obje = new processEmployee();
            Assert.AreEqual(obje.insertEmployee(chk.Object), true);
            Debug.WriteLine("executé le : "+DateTime.Now.TimeOfDay.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]//succès si l'operation leve une exception(formtexcption)
        public void toInt32_AvecChaineNonNumerique_leveExcption()
        {
            //Convert.ToInt32("45");
            //Convert.ToInt32("abc");
            Convert.ToInt32(valConverted);
            //Convert.ToInt32("45");
        }
            
        
         [TestMethod]
        public void ObtenirMeteoDuJour_valueMock_returnSoleil()
        {
            IDal1 dal = new Dal();
            //Meteo meteoDuJour = dal.ObtenirMeteoDuJour();
            //utilsiation de mock pour bouchonner le code...
            Meteo fausseMeteo = new Meteo { Temperature = 25, temps = Temps.Soleil };
            IDal1 fausseDal = Mock.Of<IDal1>();//Mock.Of :sert à créér une fausse implementation
            /**
             *  Ensuite, on récupère le bouchon via la méthode Mock.Get pour ensuite paramétrer le comportement de la méthode et
             *   lui faire renvoyer ce que l'on veut. Pour cela, on utilise la méthode Setup à travers une expression lambda 
             *   pour indiquer que la méthode ObtenirLaMeteoDuJour retournera en fait un faux objet météo.
             * */
            Mock.Get(fausseDal).Setup(d => d.ObtenirMeteoDuJour()).Returns(fausseMeteo);
            //---fin du bouchon
            Meteo meteoDuJour = fausseDal.ObtenirMeteoDuJour();
            int valResult = 25;
            Assert.AreEqual(valResult, meteoDuJour.Temperature,"la valeur doit être egale à "+valResult );
            Assert.AreEqual(Temps.Soleil, meteoDuJour.temps);
        }


        [TestMethod]
        public void Generateur_valueMock()
        {
            IGenerateur fausseGenerateur = new Generateur();
            int fausseValue = 15;
            fausseGenerateur = Mock.Of<IGenerateur>();//creation faux geneateur
            //parametrage de la methode quon veut bouchonner et affactetion de notrevaluer de test
            Mock.Get(fausseGenerateur).SetupGet(s => s.Valeur).Returns(fausseValue);
            int result= fausseGenerateur.Valeur;//appel de la fausse ethode
            Assert.AreEqual(15, result,"la valeur doit etre egale a la valuer simulacre ici :"+fausseValue);
        }

        [TestMethod]
        public void Get_with_in_Memory_Hosting_failed()////--Test d'Integration vu qu'on depend de ressources externe (repository par ex)
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            HttpServer server = new HttpServer(config);

            HttpClient client = new HttpClient(server);
            var response = client.GetAsync("http://loclahost:51653/testController").Result;

            Assert.AreNotEqual(HttpStatusCode.OK, response.StatusCode);
            //Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }

        [TestMethod]
        public void Post_with_in_Memory_Hosting_Succes()//--Test d'Integration vu qu'on depend de ressources externe (repository par ex)
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);

            HttpServer server = new HttpServer(config);
            HttpClient client = new HttpClient(server);
            HashSet<KeyValuePair<string, string>> values = new HashSet<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Title","never come back !"),
                new KeyValuePair<string, string>("Date","2017-09-28"),
                new KeyValuePair<string, string>("Body","toujours viser plus haut..."),
                new KeyValuePair<string, string>("Email","fhcoulibaly@gs2e.ci")

            };

            HttpResponseMessage response = client.PostAsync("http://loclahost:51653/testController/Post", new FormUrlEncodedContent(values)).Result;

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(response.Headers.Location);
            Assert.AreEqual("http://loclahost:51653/testController/4", response.Headers.Location);

        }

       // [TestMethod]
        public void GetById_shouldReturn_thepost()//--Test unitaire :-pas trop correct à cause du mock
        {
            List<Post> _posts = new List<Post>();
            _posts.Add(new Post { Id = 1, Date = new DateTime(2010, 04, 09), Title = "An introduction to the web api", Body = "..." });
            _posts.Add(new Post { Id = 2, Date = new DateTime(2010, 04, 11), Title = "REST is BEST", Body = "..." });

            Mock<IPostRepository> repo = new Mock<IPostRepository>();
            repo.Setup(s => s.initTest());
            PostController controller = new PostController(repo.Object);            
            controller.Get(2); //leve l' exception prevu à cet effet dans le code dela methode "Get" vu que le repository called ne contient aucun elemnt
            repo.Verify(r => r.Get(2));
            ////IPostRepository repo = Mock.Of<PostRepository>();
            //PostController controller = Mock.Of<PostController>();
            //Mock.Get(controller).Setup(m => m.Get(2)).Returns(_posts[1]);

        }

        [TestMethod]
        public void Post_Status_isCreatedAndHeader_containsLocation()
        {
            Mock<IPostRepository> repository = new Mock<IPostRepository>();
            var controller = new PostController(repository.Object);

            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post,
                                                  "http://loclahost:51653/Post");
            //IHttpRoute route = config.Routes.MapHttpRoute("");
            //IHttpRoute route = config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}");
            //HttpRouteData routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "posts" } });
            //controller.ControllerContext = new System.Web.Http.Controllers.HttpControllerContext(config, routeData, request);
            config.MapHttpAttributeRoutes();

            //controller.ControllerContext = new System.Web.Http.Controllers.HttpControllerContext(config,null,request);
            controller.ControllerContext = new System.Web.Http.Controllers.HttpControllerContext();
            request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            //request.Properties[HttpPropertyKeys.HttpRouteDataKey] = config;
            controller.Request = request;

            HttpResponseMessage response = controller.Post(new Post()
            {
                Id = 1,
                Date = new DateTime(2017, 04, 09),
                Title = "An introduction to the web apiet Test Unitaire...",
                Body = "..."
            });
            //failed a cause de la contsruction du location :Url.Link;
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestCleanup]//C'est l'endroit idéal pour factoriser les nettoyages dont dépendent tous les tests.
        public void NettoyageTest()
        {

        }
    }
}

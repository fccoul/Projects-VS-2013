using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsApp_Customer
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static void ShowProduct(Product product)
        {
            
            Console.WriteLine("Name: {0}\tPrice: {1}\tCategory: {2}\tQuantite: {3}", product.Name, product.Price, product.Category,product.Quantite);
        }

#region CRUD
        static async Task<Uri> CreateProductAsync(Product product)
        {
            //The PostAsJsonAsync method serializes an object to JSON and then sends the JSON payload in a POST request           
            HttpResponseMessage response = await client.PostAsJsonAsync("products", product);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

         static async Task<Product> GetProductAsync(string path)
        {
            Product product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                //ReadAsAsync to deserialize the JSON
                //La méthode ReadAsync est asynchrone car le corps de réponse peut être arbitrairement grand.
                product = await response.Content.ReadAsAsync<Product>();
            }
            return product;
        }

        static async Task<Product> UpdateProductAsync(Product product)
        {
          
            HttpResponseMessage response = await client.PutAsJsonAsync(string.Format("products/{0}",product.Id), product);
            response.EnsureSuccessStatusCode();//Throws an exception if the IsSuccessStatusCode property for the HTTP response is false.

            // Deserialize the updated product from the response body.
            product = await response.Content.ReadAsAsync<Product>();
            return product;
        }

        static async Task<HttpStatusCode> DeleteProductAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(string.Format("products/{0}",id));
            return response.StatusCode;
        }


#endregion

        static void Main(string[] args)
        {
            RunAsync().Wait();

        }

         static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://localhost:51653/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                Product product = new Product();

                // Create a new product
                
                 product = new Product { Name = "Gizmo", Price = 100, Category = "Widgets",Quantite=75 };

                var url = await CreateProductAsync(product);
                Console.WriteLine("Created at {0}",url);
                
                // Get the product
                product = await GetProductAsync(url.PathAndQuery);
               // product = await GetProductAsync("http://localhost:51653/api/products/2");
                ShowProduct(product);
                
                // Update the product
                Console.WriteLine("Updating price...");
                product.Price = 80;
                await UpdateProductAsync(product);

                // Get the updated product
                product = await GetProductAsync(url.PathAndQuery);
                ShowProduct(product);

                // Delete the product
                var statusCode = await DeleteProductAsync(product.Id);
                Console.WriteLine("Deleted (HTTP Status = {0})",statusCode);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
 

    }
}

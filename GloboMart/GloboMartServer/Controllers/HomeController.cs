using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace GloboMartServer.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }

        public ActionResult CreateProduct(Product product)
        {
            using (var client = new HttpClient())
            {
                CreateApiClient(client);

                HttpResponseMessage responseMessage = client.PostAsJsonAsync<Product>("api/productcatalogue/postproduct", product).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                    var products = JsonConvert.DeserializeObject<Product>(responseData);

                    return RedirectToAction("GetProducts");
                }
            }
            return View("Error");
        }

        [HttpGet]
        public ActionResult RemoveProduct(long id)
        {
            using (var client = new HttpClient())
            {
                CreateApiClient(client);

                HttpResponseMessage responseMessage = client.GetAsync("api/productcatalogue/getproduct/" + id.ToString()).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                    var product = JsonConvert.DeserializeObject<Product>(responseData);

                    return View("DeleteProduct", product);
                }
            }
            return View("Error");
        }

        public ActionResult DeleteProduct(long id)
        {
            using (var client = new HttpClient())
            {
                CreateApiClient(client);

                HttpResponseMessage responseMessage = client.DeleteAsync("api/productcatalogue/deleteproduct/" + id.ToString()).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                    var products = JsonConvert.DeserializeObject<Product>(responseData);

                    return View();
                }
            }
            return View("Error");
        }

        public ActionResult GetProducts()
        {
            using (var client = new HttpClient())
            {
                CreateApiClient(client);

                HttpResponseMessage responseMessage = client.GetAsync("api/productcatalogue/getproducts").Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                    var products = JsonConvert.DeserializeObject<List<Product>>(responseData);

                    return View(products);
                }
            }
            return View("Error");
        }

        [HttpGet]
        public ActionResult FindProductByType(string type)
        {

            using (var client = new HttpClient())
            {
                CreateApiClient(client);

                HttpResponseMessage responseMessage = client.GetAsync("api/productcatalogue/getproductsbytype/?type=" + type).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                    var products = JsonConvert.DeserializeObject<List<Product>>(responseData);

                    return View("GetProducts", products);
                }
            }
            return View("Error");
        }

        [HttpGet]
        public ActionResult GetProductPrice(long id)
        {
            using (var client = new HttpClient())
            {
                CreateApiClient(client);

                HttpResponseMessage responseMessage = client.GetAsync("api/productprice/getproduct/" + id).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                    var product = JsonConvert.DeserializeObject<Product>(responseData);

                    return PartialView("_GetProductPrice", product);
                }
            }
            return View("Error");
        }

        private static void CreateApiClient(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:56724");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}

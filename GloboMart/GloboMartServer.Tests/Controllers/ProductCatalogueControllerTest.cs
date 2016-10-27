using System.Linq;
using GloboMartDataAccessService.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace GloboMartDataAccessService.Controllers.Tests
{
    [TestClass()]
    public class ProductCatalogueControllerTest
    {
        public GloboMartContext Context { get; private set; }

        [TestInitialize]
        public void Initliaze()
        {
            Context = new GloboMartContext();
        }

        [TestMethod]
        public void GetProducts()
        {
            var result = Context.Products.ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual("Four", result[3].Type);
        }

        [TestMethod]
        public void GetProduct()
        {
            var result = Context.Products.Find(5);
            Assert.IsNotNull(result);
            Assert.AreEqual("Maruti Suzuki Swift", result.Name);
        }


        [TestMethod]
        public void PostProduct()
        {
            Context.Products.Add(new Product { Name = "Volkswogan Polo", Price = 1452, Type = "Sedan" });
            Context.SaveChanges();
            Assert.AreEqual(5, Context.Products.Count());
        }

        [TestMethod]
        public void DeleteProduct()
        {
            var result = Context.Products.Remove(Context.Products.Find(6));
            Context.SaveChanges();
            Assert.AreEqual(4, Context.Products.Count());
        }

        [TestMethod]
        public void GetProductPrice()
        {
            var result = Context.Products.Find(4);
            Assert.AreEqual(500000.00M, result.Price);
        }

        [TestCleanup]
        public void CloseContext()
        {
            Context.Dispose();
            Context = null;
        }
    }
}
using System;

namespace StockControl.Products
{
    public class ProductsController : IProductsController
    {
        public ProductsController()
        {
           
        }
    
        public string SetPageTitle()
        {
            return "Product Management";
        }
    }

}

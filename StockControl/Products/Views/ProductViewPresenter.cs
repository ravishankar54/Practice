using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;
using System.Web;

namespace StockControl.Products.Views
{
    public class ProductViewPresenter : Presenter<IProductViewView>
    {
        private IProductsController _controller;
        public ProductViewPresenter([CreateNew] IProductsController controller)
        {
            //// Method on controller class invoked here
            _controller = controller;
        }

        public override void OnViewLoaded()
        {
            string productName = (string)HttpContext.Current.Session["ProductName"];
            string productCost = (string)HttpContext.Current.Session["Cost"];

            //// You can access asp.net controls on the page with View
            View.LblProductName.Text = productName;
            View.LblProductCost.Text = productCost;
        }

        public override void OnViewInitialized()
        {
            View.LblTitle.Text = _controller.SetPageTitle();
        }

        
    }
}





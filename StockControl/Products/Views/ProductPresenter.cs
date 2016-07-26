using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;
using System.Web;

namespace StockControl.Products.Views
{
    public class ProductPresenter : Presenter<IProductView>
    {

        private IProductsController _controller;

        public ProductPresenter([CreateNew] IProductsController controller)
        {
            //// Method on controller class invoked here
            _controller = controller;
        }

        public override void OnViewLoaded()
        {
            //// Bind event
            View.BtnSave_Click += new EventHandler(View_BtnSave_Click);
        }

        public override void OnViewInitialized()
        {
            View.LblTitle.Text = _controller.SetPageTitle();
        }

        private void View_BtnSave_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["ProductName"] = View.TxtProductName.Text;
            HttpContext.Current.Session["Cost"] = View.TxtCost.Text;
            HttpContext.Current.Response.Redirect("ProductView.aspx", false);
        }


    }
}





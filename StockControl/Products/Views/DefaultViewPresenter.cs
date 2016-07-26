using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;

namespace StockControl.Products.Views
{
    public class DefaultViewPresenter : Presenter<IDefaultView>
    {
        private IProductsController _controller;

        public DefaultViewPresenter([CreateNew] IProductsController controller)
        {
            this._controller = controller;
        }
    }
}

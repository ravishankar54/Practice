using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace StockControl.Products.Views
{
    public interface IProductViewView
    {       
        Label LblProductName { get; set; }       
        Label LblProductCost { get; set; }
        Label LblTitle { get; set; }      
    }
}





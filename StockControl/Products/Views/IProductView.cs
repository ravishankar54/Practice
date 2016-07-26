using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace StockControl.Products.Views
{
    public interface IProductView
    {
        event EventHandler BtnSave_Click;
        TextBox TxtProductName { get; set; }
        TextBox TxtCost { get; set; }
        Label LblTitle { get; set; }
    }
}





using System;
using System.Web.UI;

namespace UserControlDemo
{
    public partial class _Default : Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Response.Write("WebForm Page Pre Init event called <br/> ");
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Write("WebForm Page Init event called <br/> ");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("WebForm Page Load event called <br/> ");
        }
    }
}
using System;

namespace UserControlDemo.UserControls
{
    public partial class UserInformation : System.Web.UI.UserControl
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Response.Write("User Control Pre Init event called <br/> ");
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Write("User Control Init event called <br/> ");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("User Control Load event called <br/> ");
        }
    }
}
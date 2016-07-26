using System;
using System.Web.UI;

namespace UserControlDemo
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Response.Write("Master Page Pre Init event called <br/> ");
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Write("Master Page Init event called <br/> ");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Master Page Load event called <br/> ");
        }
    }
}
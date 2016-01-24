using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using HttpModulesAndHttpHandlerDemo.App_Code;

namespace HttpModulesAndHttpHandlerDemo
{
     public partial class Default : System.Web.UI.Page
    {

        protected void Page_init(object sender, EventArgs e)
        {
            MyHttpModule.objArrayList.Add("Page:Init");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            MyHttpModule.objArrayList.Add("Page:Load");
        }
        public override void Validate()
        {
            MyHttpModule.objArrayList.Add("Page:Validate");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            MyHttpModule.objArrayList.Add("Page:Event");
        }
        protected override void Render(HtmlTextWriter output)
        {
            MyHttpModule.objArrayList.Add("Page:Render");
            base.Render(output);
        }
        protected void Page_Unload(object sender, EventArgs e)
        {
            MyHttpModule.objArrayList.Add("Page:UnLoad");
        }
    }
}
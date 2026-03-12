using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class PageCycle : System.Web.UI.Page
    {
        public void Page_PreInit(object sender, EventArgs e)
        {  Response.Write("Page Pre_Initialized"); }

        public void Page_Init(object sender, EventArgs e)
        { Response.Write("Page Initialized"); }

        public void Page_InitComplete(object sender, EventArgs e)
        { Response.Write("Page Initialized Complete"); }

        public void Page_PreLoad(object sender, EventArgs e)
        { Response.Write("Page Pre_Load"); }

        protected void Page_Load(object sender, EventArgs e)
        { Response.Write("Page Load"); }

        protected void Page_LoadComplete(object sender, EventArgs e)
        { Response.Write("Page_LoadComplete"); }
        protected void Page_Render(object sender, EventArgs e)
        { Response.Write("Page Render"); }
        protected void Page_PreRender(object sender, EventArgs e)
        { Response.Write("Page Pre Render "); }
        protected void Page_PreRenderComplete(object sender, EventArgs e)
        { Response.Write("Page Pre Render Complete."); }

        protected void Page_Unload(object sender, EventArgs e)
        { 
            
            //Response.Write("Page Pre Render Complete."); 
        }


    }
}
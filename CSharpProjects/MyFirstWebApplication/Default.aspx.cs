using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyFirstWebApplication
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                message.Text = "Page Loaded";
            }
        }

        protected void Btn_Submit()
        {
            message.Text = "Hello" + textName.Text;
        }

      
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Createbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CreateAccount.aspx");
        }

        protected void SignInbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/LoginAccount.aspx");
        }
    }
}
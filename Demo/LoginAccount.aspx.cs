using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo
{
    public partial class LoginAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private async void authentication()
        {
            HttpClient APIclient = new HttpClient();
            APIclient.BaseAddress = new Uri("https://dataclassifier.azurewebsites.net/api/Login" + "?email=" + txtEmail.Text + "&password=" + txtPass.Text);
            var task = APIclient.GetAsync(APIclient.BaseAddress);
            var items = await task;
            if (items.IsSuccessStatusCode)
            {
                Response.Redirect("~/Dashboard.aspx");
            }
            else
                lblEmail.Text = "Login Failed. Please try again.";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            authentication();
        }
    }
}
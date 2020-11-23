using DataClassifierAPI.Models;
using Microsoft.AspNetCore.Http;
using RestSharp;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.UI;

namespace Demo
{
    public partial class Contact : Page
    {
        private int tracker = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            tracker = Tracking();
        }
        public void CreateAccount()
        {
            if(tracker != 0)
            {
                tracker += 1;
                UserModel user = new UserModel { Id = tracker, email = txtEmail.Text, Password = txtPass.Text };
                var client = new RestClient("https://dataclassifier.azurewebsites.net/api/Login/CreateAccount");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", "    {\r\n        \"id\":" + user.Id + ",\r\n        \"email\": \"" + user.email + "\",\r\n        \"Password\": \"" + user.Password + "\"\r\n    }", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.IsSuccessful)
                    Response.Redirect("~/LoginAccount.aspx");
                else
                    lblEmail.Text = "Error, pleasetry again.";
            }
            lblEmail.Text = "An error occured please try again.";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            CreateAccount();
        }
        private int Tracking()
        {
            var client = new RestClient("https://dataclassifier.azurewebsites.net/api/UploadTo");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            int temp = 0;
            if(Int32.TryParse(response.Content, out temp))
                return temp;
            return temp;
        }
    }
}
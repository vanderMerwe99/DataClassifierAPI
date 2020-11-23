using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataClassifierAPI
{
    public class HelperAPI
    {
        public HttpClient APIclient { get; set; }
        
        private IConfiguration _config;
        public HelperAPI(IConfiguration config)
        {
            InitializeClient();
            _config = config;
        }

        private void InitializeClient()
        {
            string API = _config.GetSection("Data").GetSection("API").Value;

            APIclient = new HttpClient();
            APIclient.BaseAddress = new Uri(API);
        }

        public async Task authenticate(string username, string password)
        {
            var dat = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });

            using HttpResponseMessage response = await APIclient.PostAsync("/api/Login", dat);
            ;
        }
    }
}

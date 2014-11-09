using System;
using System.Collections.Generic;
using Windows.Web.Http;
using Spicer.ViewModel;
using Utils;

namespace Spicer.Model
{
    public class Login
    {
        public string Username {get; set; }
        public string Password {get; set; }
    }

    public class ServiceLogin : WebServiceEndDetector
    {
        private readonly WebService _ws = new WebService();
        private readonly LoginViewModel _vm;

        public ServiceLogin(LoginViewModel vm)
        {
            _vm = vm;
        }

        public void LoginGo(string username, string password)
        {
            _ws.SendRequest(HttpMethod.Put, RequestType.Connect, RequestContentType.Text, new Dictionary<string, string>
            {
                {"username", username},
                {"password", password}
            });
            StartTimer();
        }

        protected override void waitEnd_Tick(object sender, EventArgs e)
        {
            if (_ws.IsRequestOver)
            {
                StopTimer();
                Logs.Output.ShowOutput("REPONSE!: " + _ws.Result);
            }
            else
            {
                Logs.Output.ShowOutput("PAS REPONSE!");
            }
        }
    }
}

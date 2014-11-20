using System;
using System.Collections.Generic;
using Windows.Web.Http;
using Spicer.ViewModel;
using Utils;

namespace Spicer.Model
{
    public sealed class User
    {
        public string Username {get; set; }
        public string Password {get; set; }
    }

    public class ServiceUser : WebServiceEndDetector
    {
        private readonly WebService _ws = new WebService();
        private readonly LoginViewModel _vm;

        public ServiceUser(LoginViewModel vm)
        {
            _vm = vm;
        }

        public void LoginGo(string username, string password)
        {
            _ws.SendRequest(HttpMethod.Put, RequestType.User, RequestContentType.Text, new Dictionary<string, string>
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

                //_vm.Username = "titi";
                //_vm.Password = "dsqdqsfsqf";
            }
            else
            {
                Logs.Output.ShowOutput("PAS REPONSE!");
            }
        }
    }
}

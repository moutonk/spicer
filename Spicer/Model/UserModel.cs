using System;
using System.Collections.Generic;
using Windows.Web.Http;
using Newtonsoft.Json;
using Spicer.ViewModel;
using Utils;

namespace Spicer.Model
{
    public sealed class UserModel : BaseModel
    {
        public string Username {get; set; }
        public string Password {get; set; }

        public void Print()
        {
            Print(this);
        }
    }

    public sealed class LoginResponseModel : BaseModel
    {
        public string Token { get; set; }

        public void Print()
        {
            Print(this);
        }
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
            _ws.SendRequest(HttpMethod.Post, RequestType.User, RequestContentType.Text, new Dictionary<string, string>
            {
                {"username", username},
                {"password", password},
                {"plateform", "wp"}
            });
            StartTimer();
        }

        protected override void waitEnd_Tick(object sender, EventArgs e)
        {
            if (!_ws.IsRequestOver)
                return;

            StopTimer();

            if (_ws.Error.ErrorCode != null)
            {
                Logs.Output.ShowOutput(((int)_ws.Error.ErrorCode.Value).ToString());
                Logs.Output.ShowOutput(_ws.Error.CodeDescription);
            }
            else if (!string.IsNullOrEmpty(_ws.Result))
            {
                var res = JsonConvert.DeserializeObject<LoginResponseModel>(_ws.Result);

                Data.Token = res.Token;
            }
        }
    }
}

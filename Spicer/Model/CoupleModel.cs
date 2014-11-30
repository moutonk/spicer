using System;
using System.Collections.Generic;
using Windows.Web.Http;
using Newtonsoft.Json;
using Spicer.ViewModel;
using Utils;

namespace Spicer.Model
{
    public class CoupleModel : BaseModel
    {
        public string User1 { get; set; }
        public string User2 { get; set; }
        public string Password { get; set; }

        public void Print()
        {
            Print(this);
        }
    }

    public class ServiceCouple : WebServiceEndDetector
    {
        private readonly WebService _ws = new WebService();
        private readonly SignUpViewModel _vm;

        public ServiceCouple(SignUpViewModel vm)
        {
            _vm = vm;
        }

        public void SignUpGo(string username1, string username2, string password)
        {
            _ws.SendRequest(HttpMethod.Post, RequestType.Couple, RequestContentType.Text, new Dictionary<string, string>
            {
                {"user1", username1},
                {"user2", username2},
                {"password", password}
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
                var obj = JsonConvert.DeserializeObject<BasicResponse>(_ws.Result);
            }
        }
    }
}

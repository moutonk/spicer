using System;
using System.Collections.Generic;
using Windows.Web.Http;
using Newtonsoft.Json;
using Spicer.ViewModel;
using Utils;

namespace Spicer.Model
{
    public sealed class FantasySeenModel
    {
        public string Id { get; set; }
        public bool Status { get; set; }
    }

    public class FantasySeenService : WebServiceEndDetector
    {
        private readonly WebService _ws = new WebService();
        private readonly FantasyViewModel _vm;

        public FantasySeenService(FantasyViewModel vm)
        {
            _vm = vm;
        }

        //set a fantasy to liked/disliked and return a new fantasy
        public void SetFantasySeen(string id, bool status)
        {
            _ws.SendRequest(HttpMethod.Post, RequestType.FantasySeen, RequestContentType.Text, new Dictionary<string, string>
            {
                {"id", id},
                {"status", status.ToString()}
            });
            StartTimer();
        }

        //retreive an new fantasy
        public void GetFantasySeen()
        {
            _ws.SendRequest(HttpMethod.Get, RequestType.FantasySeen, RequestContentType.Text, new Dictionary<string, string>
            {
            });
            StartTimer();
        }

        protected override void waitEnd_Tick(object sender, EventArgs e)
        {
            if (!_ws.IsRequestOver)
                return;

            StopTimer();
            Logs.Output.ShowOutput("REPONSE!: " + _ws.Result);

            if (_ws.Error.ErrorCode != null)
            {
                //error
            }
            else if (!string.IsNullOrEmpty(_ws.Result))
            {
                var obj = JsonConvert.DeserializeObject<FantasyModel>(_ws.Result);
            }
        }
    }
}

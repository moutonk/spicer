using System;
using System.Collections.Generic;
using Windows.Web.Http;
using Newtonsoft.Json;
using Spicer.ViewModel;
using Utils;

namespace Spicer.Model
{
    public sealed class FantasyModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ImgUrl { get; set; }
    }

    public class FantasyService : WebServiceEndDetector
    {
        private readonly WebService _ws = new WebService();
        private readonly FantasyViewModel _vm;

        public FantasyService(FantasyViewModel vm)
        {
            _vm = vm;
        }

        public void FantasyList()
        {
            _ws.SendRequest(HttpMethod.Get, RequestType.Fantasy, RequestContentType.Text, new Dictionary<string, string>
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
                var obj = JsonConvert.DeserializeObject<List<FantasyModel>>(_ws.Result);
            }
        }
    }
}

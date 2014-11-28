﻿using System;
using System.Collections.Generic;
using Windows.Web.Http;
using Newtonsoft.Json;
using Spicer.ViewModel;
using Utils;

namespace Spicer.Model
{
    public sealed class FantasyModel : BaseModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ImgUrl { get; set; }

        public void Print()
        {
            Print(this);
        }
    }

    public class FantasyService : WebServiceEndDetector
    {
        private readonly WebService _ws = new WebService();
        private readonly FantasyViewModel _vm;
        private RequestType _requestType;

        public FantasyService(FantasyViewModel vm)
        {
            _vm = vm;
        }

        public void FantasyList()
        {
            _requestType = RequestType.Fantasy;
            _ws.SendRequest(HttpMethod.Get, RequestType.Fantasy, RequestContentType.Text, new Dictionary<string, string>
            {
            });
            StartTimer();
        }

        public void FantasyId(string fantasyId)
        {
            _requestType = RequestType.FantasyId;
            _ws.SendRequest(HttpMethod.Get, RequestType.FantasyId, RequestContentType.Text, new Dictionary<string, string>(), new List<string>
            {
                fantasyId
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
                switch (_requestType)
                {
                    case RequestType.Fantasy:
                        var fantasyList = JsonConvert.DeserializeObject<List<FantasyModel>>(_ws.Result);
                        foreach (var fantasyModel in fantasyList)
                            fantasyModel.Print();
                        break;
                    case RequestType.FantasyId:
                        var fantasy = JsonConvert.DeserializeObject<FantasyModel>(_ws.Result);
                        fantasy.Print();
                        break;
                }
            }
        }
    }
}

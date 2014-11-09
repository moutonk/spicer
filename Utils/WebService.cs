﻿using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Media.Imaging;
using Windows.Web.Http;

namespace Utils
{
    public enum RequestType
    {
        Connect,
        Couple
    }

    public enum RequestContentType
    {
        Text,
        Image
    }

    public class WebService
    {
        private  CookieCollection _cookieColl = new CookieCollection();
        private  readonly CookieContainer _cookieContainer = new CookieContainer();

        public void SendRequest(HttpMethod httpReqType, RequestType reqType, RequestContentType reqContentType, Dictionary<string, string> args)
        {
            Logs.Output.ShowOutput(Environment.NewLine + "SendRequest: " + httpReqType + " " + reqType + " " + args.Aggregate("",(current, keyValuePair) =>current + ("[" + keyValuePair.Key + " " + keyValuePair.Value + "]")));
            
            var dicoToString = FormateDictionnaryToString(args);
            var url = Paths.ServerAddress + RequestTypeToUrlString(reqType);


            if (httpReqType == HttpMethod.Post)
                PostRequest(ref url, ref dicoToString, reqType, reqContentType);
            else if (httpReqType == HttpMethod.Put)
                PutRequest(ref url, ref dicoToString, reqType, reqContentType);
            else if (httpReqType == HttpMethod.Get)
                GetRequest(ref url, ref dicoToString, reqType, reqContentType);
        }
     
        private static string RequestTypeToUrlString(RequestType reqType)
        {
            switch (reqType)
            {
                case RequestType.Connect:
                    return "user/";
                case RequestType.Couple:
                    return "couple/";
                default:
                    return reqType.ToString();
            }
        }

        private void PostRequest(ref string url, ref string parameters, RequestType reqType, RequestContentType reqContentType)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            Logs.Output.ShowOutput(url + " " + parameters);

            _cookieContainer.Add(new Uri(Paths.ServerAddress), _cookieColl);

            request.CookieContainer = _cookieContainer;
            request.Method = HttpMethod.Post.ToString();

            byte[] requestParams;

            switch (reqContentType)
            {
                case RequestContentType.Text:
                    requestParams = Encoding.UTF8.GetBytes(parameters);
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = requestParams.Length;
                    request.BeginGetRequestStream(new AsyncCallback(WriteParamsInStreamCallBack), Tuple.Create(request, requestParams, reqType));

                    break;

                case RequestContentType.Image:
                    const string boundary = "---MultiPartHeader---";
                    var head = Encoding.UTF8.GetBytes(String.Format("--{0}\r\n" + "Content-Disposition: form-data; name=\"file\"; filename=\"profilpic.jpg\"\r\n" + "\r\n", boundary));
                    var content = Convert.FromBase64String(parameters);
                    var tail = Encoding.UTF8.GetBytes(String.Format("\r\n" + "--{0}--\r\n", boundary));

                    requestParams = new byte[head.Length + tail.Length + content.Length];
                    Array.Copy(head, 0, requestParams, 0, head.Length);
                    Array.Copy(content, 0, requestParams, head.Length, content.Length);
                    Array.Copy(tail, 0, requestParams, head.Length + content.Length, tail.Length);
                    request.ContentType = "multipart/form-data; boundary=" + boundary;
                    //request.ContentLength = content.Length;
                    request.BeginGetRequestStream(new AsyncCallback(WriteParamsInStreamCallBack), Tuple.Create(request, requestParams, reqType));
                    break;
            }
        }

        private void PutRequest(ref string url, ref string parameters, RequestType reqType, RequestContentType reqContentType)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            Logs.Output.ShowOutput(url + " " + parameters);

            _cookieContainer.Add(new Uri(Paths.ServerAddress), _cookieColl);

            request.CookieContainer = _cookieContainer;
            request.Method = HttpMethod.Put.ToString();

            byte[] requestParams;

            switch (reqContentType)
            {
                case RequestContentType.Text:
                    requestParams = Encoding.UTF8.GetBytes(parameters);
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = requestParams.Length;
                    request.BeginGetRequestStream(new AsyncCallback(WriteParamsInStreamCallBack), Tuple.Create(request, requestParams, reqType));

                    break;

                case RequestContentType.Image:
                    const string boundary = "---MultiPartHeader---";
                    var head = Encoding.UTF8.GetBytes(String.Format("--{0}\r\n" + "Content-Disposition: form-data; name=\"file\"; filename=\"profilpic.jpg\"\r\n" + "\r\n", boundary));
                    var content = Convert.FromBase64String(parameters);
                    var tail = Encoding.UTF8.GetBytes(String.Format("\r\n" + "--{0}--\r\n", boundary));

                    requestParams = new byte[head.Length + tail.Length + content.Length];
                    Array.Copy(head, 0, requestParams, 0, head.Length);
                    Array.Copy(content, 0, requestParams, head.Length, content.Length);
                    Array.Copy(tail, 0, requestParams, head.Length + content.Length, tail.Length);
                    request.ContentType = "multipart/form-data; boundary=" + boundary;
                    //request.ContentLength = content.Length;
                    request.BeginGetRequestStream(new AsyncCallback(WriteParamsInStreamCallBack), Tuple.Create(request, requestParams, reqType));
                    break;
            }
        }


        private void GetRequest(ref string url, ref string parameters, RequestType reqType, RequestContentType reqContentType)
        {
            var request = (HttpWebRequest)WebRequest.Create(url + "?" + parameters);

            _cookieContainer.Add(new Uri(Paths.ServerAddress), _cookieColl);

            request.CookieContainer = _cookieContainer;
            Logs.Output.ShowOutput(url + "?" + parameters);
            request.Method = HttpMethod.Get.ToString();

            request.BeginGetResponse(new AsyncCallback(ManageResponse), Tuple.Create(request, new byte[1], reqType));
        }

        private void WriteParamsInStreamCallBack(IAsyncResult ar)
        {
            Logs.Output.ShowOutput("Writing request BEGIN...");
            var tuple = (Tuple<HttpWebRequest, byte[], RequestType>)ar.AsyncState;

            using (var postStream = tuple.Item1.EndGetRequestStream(ar))
            {
                postStream.Write(tuple.Item2, 0, tuple.Item2.Length);
                postStream.Flush();
            }

            Logs.Output.ShowOutput("Writing request END...");
            tuple.Item1.BeginGetResponse(new AsyncCallback(ManageResponse), ar.AsyncState);
        }

        private string FormateDictionnaryToString(IReadOnlyCollection<KeyValuePair<string, string>> dict)
        {
            var builder = new StringBuilder();

            Logs.Output.ShowOutput("-------------------------------------------");
            for (var dicoLine = 0; dicoLine < dict.Count; dicoLine++)
            {
                builder.Append(dict.ElementAt(dicoLine).Key.Equals("") == false ? dict.ElementAt(dicoLine).Key + "=" + dict.ElementAt(dicoLine).Value : dict.ElementAt(dicoLine).Value);
                if (dicoLine + 1 < dict.Count)
                    builder.Append("&");    
            }
            Logs.Output.ShowOutput("-------------------------------------------");
      
            return builder.ToString();
        }

        private void ShowCookiesInfos(HttpWebResponse response)
        {
            foreach (Cookie cook in response.Cookies)
            {
                Logs.Output.ShowOutput("Cookie:");
                Logs.Output.ShowOutput(cook.Name + "=" + cook.Value);
                Logs.Output.ShowOutput("Domain: " + cook.Domain);
                Logs.Output.ShowOutput("Path: " + cook.Path);
                Logs.Output.ShowOutput("Port: " + cook.Port);
                Logs.Output.ShowOutput("Secure: " + cook.Secure);

                Logs.Output.ShowOutput("When issued:" + cook.TimeStamp);
                Logs.Output.ShowOutput("Expires: (expired?)" + cook.Expires + " " + cook.Expired);
                Logs.Output.ShowOutput("Don't save:" + cook.Discard);
                Logs.Output.ShowOutput("Comment: " + cook.Comment);
                Logs.Output.ShowOutput("Uri for comments: " + cook.CommentUri);
                Logs.Output.ShowOutput("Version: RFC " + (cook.Version == 1 ? "2109" : "2965"));

                // Show the string representation of the cookie.
                Logs.Output.ShowOutput("String: " + cook.ToString());
            }
        }

        private void ManageResponse(IAsyncResult ar)
        {
            Logs.Output.ShowOutput("Waiting answer BEGIN...");
            var tuple = (Tuple<HttpWebRequest, byte[], RequestType>)ar.AsyncState;

            try
            {
                using (var response = (HttpWebResponse)tuple.Item1.EndGetResponse(ar))
                using (var streamResponse = response.GetResponseStream())
                using (var streamRead = new StreamReader(streamResponse))
                {
                    var responseString = streamRead.ReadToEnd();
                    _cookieColl = response.Cookies;

                    if (response.Cookies != null)
                        ShowCookiesInfos(response);

                    Logs.Output.ShowOutput("Answer: " + responseString);
                    //DataConverter.ParseJson(responseString, (RequestType) tuple.Item3);
                }
            }
            catch (WebException e)
            {
                ManageResponseExplicitError(e);
            }
            Logs.Output.ShowOutput("Waiting answer END...");
        }

        private void ManageResponseExplicitError(WebException e)
        {
            Logs.Output.ShowOutput("GetResponseCallback: " + e.Message + ": " + e.InnerException.Message);
            var aResp = e.Response as HttpWebResponse;

            if (aResp != null)
            {
                Logs.Output.ShowOutput("statusCode: " + (int)aResp.StatusCode);
                using (var reader = new StreamReader(aResp.GetResponseStream()))
                {
                    Logs.Output.ShowOutput(reader.ReadToEnd());
                }
            }
        }

        public BitmapImage DownloadImageUrl(string url)
        {
            var uri = new Uri(url, UriKind.Absolute);
            return new BitmapImage(uri);
        }
    }
}
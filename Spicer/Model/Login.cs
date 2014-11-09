using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using Utils;

namespace Spicer.Model
{
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public static class ServiceLogin
    {
        public static WebService Ws = new WebService();

        public static void LoginGo(string username, string password)
        {
            Ws.SendRequest(HttpMethod.Put, RequestType.Connect, RequestContentType.Text, new Dictionary<string, string>
            {
                {"username", username},
                {"password", password}
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Windows.Web.Http;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Spicer.Resources;
using Utils;

namespace Spicer
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var ws = new WebService();

            ws.SendRequest(HttpMethod.Post, RequestType.Connect, RequestContentType.Text, new Dictionary<string, string>
            {
                {"email", "k.k@k.kk"},
                {"password", "kkkkkk"},
                {"deviceType", "3"},
                {"notificationId", "07798707078965569798"}
            });
        }
    }
}
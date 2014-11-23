using System;
using System.Windows;
using System.Windows.Media;
using Microsoft.Phone.Controls;
using Spicer.ViewModel;
using Utils;

namespace Spicer.View
{
    public partial class StartPage : PhoneApplicationPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void ConnectButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Paths.ConnectionView);
        }

        private void SignUpButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Paths.SignUpView);
        }
    }
}
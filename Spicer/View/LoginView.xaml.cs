using System;
using System.Windows;
using Microsoft.Phone.Controls;
using Spicer.ViewModel;

namespace Spicer.View
{
    public partial class LoginView : PhoneApplicationPage
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }

        private void Login_OnClick(object sender, RoutedEventArgs e)
        {
            (DataContext as LoginViewModel).LoginGo();
        }
    }
}
using System.Windows;
using Microsoft.Phone.Controls;
using Spicer.ViewModel;

namespace Spicer.View
{
    public partial class StartPage : PhoneApplicationPage
    {
        public StartPage()
        {
            InitializeComponent();
            DataContext = new SignUpViewModel();
        }

        private void Login_OnClick(object sender, RoutedEventArgs e)
        {
            (DataContext as LoginViewModel).LoginGo();
        }

        private void SignUp_OnClick(object sender, RoutedEventArgs e)
        {
            (DataContext as SignUpViewModel).SignUpGo();
        }
    }
}
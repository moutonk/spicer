using System.Windows;
using Microsoft.Phone.Controls;
using Spicer.ViewModel;

namespace Spicer.View
{
    public partial class SignUp : PhoneApplicationPage
    {
        public SignUp()
        {
            InitializeComponent();
            DataContext = new SignUpViewModel();
        }

        private void SignUp_OnClick(object sender, RoutedEventArgs e)
        {
            (DataContext as SignUpViewModel).SignUpGo();
        }
    }
}
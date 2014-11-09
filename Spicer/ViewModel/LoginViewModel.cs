using System.ComponentModel;
using Spicer.Model;

namespace Spicer.ViewModel
{
    public class LoginViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly Login _loginModel = new Login();

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                NotifyPropertyChanged(ref _username, value);
                _loginModel.Username = _username;
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                NotifyPropertyChanged(ref _password, value);
                _loginModel.Password = _password;
            }
        }

        public void LoginGo()
        {
            var wsLogin = new ServiceLogin(this);
            wsLogin.LoginGo(_username, _password);
        }
    }
}

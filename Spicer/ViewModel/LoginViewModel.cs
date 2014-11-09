using System.ComponentModel;
using Spicer.Model;

namespace Spicer.ViewModel
{
    class LoginViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set { NotifyPropertyChanged(ref _username, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { NotifyPropertyChanged(ref _password, value); }
        }

        public void LoginGo()
        {
            ServiceLogin.LoginGo(_username, _password);
        }
    }
}

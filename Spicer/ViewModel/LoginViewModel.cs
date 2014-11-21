using System.ComponentModel;
using Spicer.Model;

namespace Spicer.ViewModel
{
    public sealed class LoginViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly UserModel _userModel = new UserModel();

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                NotifyPropertyChanged(ref _username, value);
                _userModel.Username = _username;
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                NotifyPropertyChanged(ref _password, value);
                _userModel.Password = _password;
            }
        }

        public void LoginGo()
        {
            var wsLogin = new ServiceUser(this);
            wsLogin.LoginGo(_username, _password);
        }
    }
}

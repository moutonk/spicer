using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Spicer.Model;
using Utils;

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

        private bool UpdateFields(Argument[] args)
        {
            base.UpdateFields(this, args);
            return true;
        }

        public void LoginGo()
        {
            var wsLogin = new ServiceLogin(UpdateFields);
            wsLogin.LoginGo(_username, _password);
        }
    }
}

using System;
using System.ComponentModel;
using Spicer.Model;
using Utils;

namespace Spicer.ViewModel
{
    class LoginViewModel : ViewModelBase, INotifyPropertyChanged
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
            ServiceLogin.LoginGo(_username, _password);
            StartTimer();
        }

        protected override void waitEnd_Tick(object sender, EventArgs e)
        {
            if (ServiceLogin.Ws.IsRequestOver == true)
            {
                StopTimer();
                Logs.Output.ShowOutput("REPONSE!");
            }
            else
            {
                Logs.Output.ShowOutput("PAS REPONSE!");
            }
        }
    }
}

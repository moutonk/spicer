using System.ComponentModel;
using Spicer.Model;

namespace Spicer.ViewModel
{
    public class SignUpViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly Couple _coupleModel = new Couple();

        private string _username1;
        public string Username1
        {
            get { return _username1; }
            set
            {
                NotifyPropertyChanged(ref _username1, value);
                _coupleModel.User1 = _username1;
            }
        }

        private string _username2;
        public string Username2
        {
            get { return _username2; }
            set
            {
                NotifyPropertyChanged(ref _username2, value);
                _coupleModel.User2 = _username2;
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                NotifyPropertyChanged(ref _password, value);
                _coupleModel.Password = _password;
            }
        }

        public void SignUpGo()
        {
            var wsLogin = new ServiceCouple(this);
            wsLogin.SignUpGo(_username1, _username2, _password);
        }
    }
}

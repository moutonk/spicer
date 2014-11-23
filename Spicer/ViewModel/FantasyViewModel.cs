using System.ComponentModel;
using Spicer.Model;

namespace Spicer.ViewModel
{
    public class FantasyViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly FantasyModel _fantasyModel = new FantasyModel();

        //private string _username;
        //public string Username
        //{
        //    get { return _username; }
        //    set
        //    {
        //        NotifyPropertyChanged(ref _username, value);
        //        _fantasyModel.Username = _username;
        //    }
        //}

        //private string _password;
        //public string Password
        //{
        //    get { return _password; }
        //    set
        //    {
        //        NotifyPropertyChanged(ref _password, value);
        //        _fantasyModel.Password = _password;
        //    }
        //}

        public void FantasyList()
        {
            var wsF = new FantasyService(this);
            wsF.FantasyList();
        }
    }
}

using System.ComponentModel;
using Spicer.Model;

namespace Spicer.ViewModel
{
    public class FantasyViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly FantasyModel _fantasyModel = new FantasyModel();

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                NotifyPropertyChanged(ref _title, value);
                _fantasyModel.Title = _title;
            }
        }

        private string _imgUrl;
        public string ImgUrl
        {
            get { return _imgUrl; }
            set
            {
                NotifyPropertyChanged(ref _imgUrl, value);
                _fantasyModel.ImgUrl = _imgUrl;
            }
        }

        public void GetFantasyList()
        {
            var wsF = new FantasyService(this);
            wsF.GetFantasyList();
        }

        public void GetFantasyId(string id)
        {
            var wsF = new FantasyService(this);
            wsF.GetFantasyId(id);
        }
    }
}

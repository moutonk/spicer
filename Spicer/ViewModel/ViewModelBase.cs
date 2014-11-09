using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Utils;

namespace Spicer.ViewModel
{
    class ViewModelBase : WebServiceEndDetector
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string nomPropriete)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
        }

        public bool NotifyPropertyChanged<T>(ref T variable, T valeur, [CallerMemberName] string nomPropriete = null)
        {
            if (object.Equals(variable, valeur)) return false;

            variable = valeur;
            NotifyPropertyChanged(nomPropriete);
            return true;
        }

        protected override void waitEnd_Tick(object sender, EventArgs e)
        {
        }
    }
}

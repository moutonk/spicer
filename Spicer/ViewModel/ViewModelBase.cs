using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Utils;

namespace Spicer.ViewModel
{
    public class Argument
    {
        public string PropertyName { get; set; }
        public object PropertyValue { get; set; }
    }

    public class ViewModelBase
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

        protected bool UpdateFields(object childClass, Argument[] args)
        {
            try
            {
                foreach (var arg in args)
                    childClass.GetType().GetProperty(arg.PropertyName).SetValue(this, arg.PropertyValue);
            }
            catch (Exception exp)
            {
                Logs.Error.ShowError("GetProperty: unknown property");
            }
            return true;
        }
    }
}

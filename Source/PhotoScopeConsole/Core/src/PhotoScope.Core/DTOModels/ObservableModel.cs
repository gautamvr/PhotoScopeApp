using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PhotoFeed.Core.Annotations;

namespace PhotoScope.Core.DTOModels
{
    public class ObservableModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetField<T>(ref T propertyField, T value,
            [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(propertyField, value))
            {
                return false;
            }
            propertyField = value;
            NotifyPropertyChanged(propertyName);
            return true;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

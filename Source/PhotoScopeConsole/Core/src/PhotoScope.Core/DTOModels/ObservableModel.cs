using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PhotoFeed.Core.Annotations;

namespace PhotoScope.Core.DTOModels
{
    /// <summary>
    /// Observable model that implements INotify property changed (To be used by any models that is to be shown on UI)
    /// </summary>
    public class ObservableModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Protected Fields

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

        #endregion
    }
}

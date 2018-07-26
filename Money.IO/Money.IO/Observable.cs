using System.ComponentModel;
using System.Runtime.CompilerServices;
using Money.IO.Annotations;

namespace Money.IO
{
    public abstract class Observable : INotifyPropertyChanged
    {
        public virtual event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
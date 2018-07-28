using System.Threading.Tasks;
using Xamarin.Forms;

namespace Money.IO
{
    public abstract class ValueViewModel : Observable
    {
        private double value;

        public ValueViewModel(INavigation navigation, Repository repository)
        {
            Navigation = navigation;
            Repository = repository;
            Value = 0.0;
        }

        private INavigation Navigation { get; }

        public Repository Repository { get; }

        public double Value
        {
            get => value;
            set
            {
                if (value.Equals(this.value)) return;
                this.value = value;
                OnPropertyChanged();
            }
        }

        public async Task Save()
        {
            var records = Repository.Load();
            var record = CreateRecord();
            records.Add(record);
            Repository.Save(records);
            await Navigation.PopToRootAsync();
        }

        protected abstract Record CreateRecord();
    }
}
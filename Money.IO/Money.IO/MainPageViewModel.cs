using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Money.IO
{
    public class MainPageViewModel : Observable
    {
        private INavigation Navigation { get; }
        private Repository Repository { get; }

        private double money;

        public MainPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Repository = new Repository();
            //var data = Repository.Load();
        }

        public double Money
        {
            get => money;
            set
            {
                if (value.Equals(money)) return;
                money = value;
                OnPropertyChanged();
            }
        }

        public ICommand IncomeCommand => 
            new Command(async () => 
                await Navigation.PushAsync(new IncomePage()));

        public ICommand OutcomeCommand =>
            new Command(async () =>
                await Navigation.PushAsync(new OutcomePage()));
    }
}
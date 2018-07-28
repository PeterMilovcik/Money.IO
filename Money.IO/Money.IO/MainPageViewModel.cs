using System;
using System.Linq;
using System.Timers;
using System.Windows.Input;
using Xamarin.Forms;

namespace Money.IO
{
    public class MainPageViewModel : Observable
    {
        private INavigation Navigation { get; }
        private Repository Repository { get; }
        private Calculator Calculator { get; }
        private double sum;
        private double rate;

        public MainPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Calculator = new Calculator();
            Repository = new Repository();
            Repository.Saved += OnRepositorySaved;
            Update();
            var timer = new Timer();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Elapsed += OnTimerElapsed;
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e) => Sum += Rate;

        private void OnRepositorySaved(object sender, EventArgs e) => Update();

        private void Update()
        {
            var records = Repository.Load();
            Sum = Calculator.Sum(records);
            Rate = Calculator.Rate(records);
        }

        public double Sum
        {
            get => sum;
            set
            {
                if (value.Equals(sum)) return;
                sum = value;
                OnPropertyChanged();
            }
        }

        public double Rate
        {
            get => rate;
            set
            {
                if (value.Equals(rate)) return;
                rate = value;
                OnPropertyChanged();
            }
        }

        public ICommand IncomeCommand => 
            new Command(async () => 
                await Navigation.PushAsync(new IncomePage(Repository)));

        public ICommand OutcomeCommand =>
            new Command(async () =>
                await Navigation.PushAsync(new OutcomePage(Repository)));
    }
}
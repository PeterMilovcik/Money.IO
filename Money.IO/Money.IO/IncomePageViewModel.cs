using System.Threading.Tasks;
using Xamarin.Forms;

namespace Money.IO
{
    public class IncomePageViewModel
    {
        private INavigation Navigation { get; }

        public IncomePageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }

        public async Task Save() => 
            await Navigation.PopToRootAsync();
    }
}
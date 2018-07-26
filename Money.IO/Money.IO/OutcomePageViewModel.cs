using System.Threading.Tasks;
using Xamarin.Forms;

namespace Money.IO
{
    public class OutcomePageViewModel
    {
        private INavigation Navigation { get; }

        public OutcomePageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }

        public async Task Save() => 
            await Navigation.PopToRootAsync();
    }
}
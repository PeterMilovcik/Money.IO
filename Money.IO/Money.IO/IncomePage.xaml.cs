using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Money.IO
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IncomePage : ContentPage
	{
	    private IncomeViewModel ViewModel { get; }

	    public IncomePage(Repository repository)
		{
			InitializeComponent ();
		    ViewModel = new IncomeViewModel(Navigation, repository);
		    BindingContext = ViewModel;
		}

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
	        Entry.Focus();
	    }

	    private async void OnCompleted(object sender, EventArgs e) => 
	        await ViewModel.Save();
	}
}
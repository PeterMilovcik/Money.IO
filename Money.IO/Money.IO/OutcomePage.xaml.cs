using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Money.IO
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OutcomePage : ContentPage
	{
	    private OutcomeViewModel ViewModel { get; }

	    public OutcomePage(Repository repository)
		{
			InitializeComponent ();
		    ViewModel = new OutcomeViewModel(Navigation, repository);
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
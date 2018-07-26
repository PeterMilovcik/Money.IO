using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Money.IO
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OutcomePage : ContentPage
	{
	    private OutcomePageViewModel ViewModel { get; }

	    public OutcomePage ()
		{
			InitializeComponent ();
		    ViewModel = new OutcomePageViewModel(Navigation);
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
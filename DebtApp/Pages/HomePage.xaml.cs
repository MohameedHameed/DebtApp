using DebtApp.ViewModel;

namespace DebtApp.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
         await Navigation.PushAsync(new DisplayDeptprocess(new AddDebtProcessViewModel()));
    }

    private async void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new DisplayUnDeptprocess());

    }
}
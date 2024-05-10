using DebtApp.ViewModel;
using UraniumUI;
namespace DebtApp.Pages;


public partial class UserPage : ContentPage
{
	public UserPage()
	{
		InitializeComponent();
	}

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		await Navigation.PushAsync(new AddUser(new AddUserViewModel()));
		
    }

    private async void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new Display_Users());
    }

    private async void TapGestureRecognizer_Tapped_2(object sender, TappedEventArgs e)
    {
        await Navigation.PushModalAsync(new AddDeptprocess(new AddDebtProcessViewModel()));
    }

    private async void TapGestureRecognizer_Tapped_3(object sender, TappedEventArgs e)
    {
        await Navigation.PushModalAsync(new AddUnDebtProcess(new AddUnDebtProcessViewModel()));
    }
}
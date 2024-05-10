using DebtApp.ViewModel;

namespace DebtApp.Pages;

public partial class AddUser : ContentPage
{
    AddUserViewModel addUserViewModel;

    public AddUser(AddUserViewModel addUserViewModel)
	{
		InitializeComponent();
        BindingContext = addUserViewModel;
        this.addUserViewModel=addUserViewModel;
    }

    private async void BtnSave_Clicked(object sender, EventArgs e)
    {
       string result=await addUserViewModel.AddCustomer();
        await DisplayAlert("Message", result, "OK");
        await Navigation.PushAsync(new UserPage());
    }

    private async void BtnCancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
using DebtApp.Model;
using DebtApp.Model.DB;
using DebtApp.ViewModel;

namespace DebtApp.Pages;

public partial class Display_Users : ContentPage
{
    public CustomerEntity customerEntity { get; set; }
    public Display_Users()
	{
		InitializeComponent();
        customerEntity = new CustomerEntity();

        getall();
    }
    public async void getall()
    {
        var result= await customerEntity.GetAllAsync();
        mylist.ItemsSource = result;
    }

    private async void mylist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        await Navigation.PushAsync(new UpdateUser((Customer)mylist.SelectedItem, new AddUserViewModel()));
    }
}
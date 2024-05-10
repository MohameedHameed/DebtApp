using DebtApp.Model;
using DebtApp.ViewModel;

namespace DebtApp.Pages;

public partial class UpdateUser : ContentPage
{
    Customer customer;

    AddUserViewModel addUserViewModel;
	int CustomerId;
    public UpdateUser( Customer customer,AddUserViewModel addUserViewModel)
	{
		InitializeComponent();
	
		this.addUserViewModel=addUserViewModel;
		BindingContext = addUserViewModel;
        CustomerId = customer.CustomerId;
        CustomerName.Text = customer.CustomerName;
        CustomerAddress.Text = customer.CustomerAddress;
        CustomerPhone.Text = customer.CustomerPhone;
        this.customer = customer;

    }

    private async void BtUpdate_Clicked(object sender, EventArgs e)
    {
		Customer customer = new Customer { CustomerId = CustomerId, CustomerName = CustomerName.Text, CustomerAddress = CustomerAddress.Text, CustomerPhone = CustomerPhone.Text,TotalDebtInYER=this.customer.TotalDebtInYER,TotalDebtInSAR=this.customer.TotalDebtInSAR,TotalDebtInUSD=this.customer.TotalDebtInUSD, };
		string result = await this.addUserViewModel.UpdateCustomer(customer);
        await DisplayAlert("Message", result, "OK");
        await Navigation.PushAsync(new UserPage());

    }

    private async void BtUDelete_Clicked(object sender, EventArgs e)
    {
        bool result1 = await DisplayAlert(" Õ–Ì— ", "”Ì „ Õ–› Â–« «·⁄„Ì· ÊÕ–› Ã„Ì⁄ œÌÊ‰Â Â· «‰  „ «ﬂœ?", "‰⁄„", "·«");
        if (result1) {
            Customer customer = new Customer { CustomerId = CustomerId, CustomerName = CustomerName.Text, CustomerAddress = CustomerAddress.Text, CustomerPhone = CustomerPhone.Text, TotalDebtInYER = this.customer.TotalDebtInYER, TotalDebtInSAR = this.customer.TotalDebtInSAR, TotalDebtInUSD = this.customer.TotalDebtInUSD, };
            string result = await this.addUserViewModel.DeleteCustomer(customer);
            await DisplayAlert("Message", result, "OK");
            await Navigation.PushAsync(new UserPage());
        }
      
    }
}
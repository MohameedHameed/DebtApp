using DebtApp.Model;
using DebtApp.ViewModel;

namespace DebtApp.Pages;

public partial class AddUnDebtProcess : ContentPage
{
	AddUnDebtProcessViewModel AddUnDebtProcessViewModel;
	public AddUnDebtProcess(AddUnDebtProcessViewModel AddUnDebtProcessViewModel)
	{
		InitializeComponent();
		this.AddUnDebtProcessViewModel= AddUnDebtProcessViewModel;


    }

    private async void BtnSave_Clicked(object sender, EventArgs e)
    {
        string result = await AddUnDebtProcessViewModel.AddDebtData(((Customer)PikerCuctomer.SelectedItem).CustomerId, ((Currency)PickerCurrency.SelectedItem).CurrencyId, int.Parse(the_amounnt.Text), PickerCurrency.SelectedIndex);
      await  DisplayAlert("message", result, "OK");
        PikerCuctomer.SelectedIndex = -1;
        PickerCurrency.SelectedIndex = -1;
        the_amounnt.Text = string.Empty;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}
using DebtApp.Model;
using DebtApp.Model.DB;

namespace DebtApp.Pages;

public partial class DisplayUnDeptprocess : ContentPage
{
    DebtProcessEntity DebtProcessEntity;
    CustomerEntity CustomerEntity;
    CurrencyEntity CurrencyEntity;
    public DisplayUnDeptprocess()
	{
		InitializeComponent();
        DebtProcessEntity = new DebtProcessEntity();
        CustomerEntity = new CustomerEntity();
        CurrencyEntity = new CurrencyEntity();
        loaddata();
	}
    public async void loaddata()
    {
        var query = from debtProcess in DebtProcessEntity.db.DebtProcesses
                    join customer in DebtProcessEntity.db.Customers on debtProcess.CustomerId equals customer.CustomerId
                    join currency in DebtProcessEntity.db.Currencys on debtProcess.CurrencyId equals currency.CurrencyId
                    where debtProcess.DeptType == "UnDept"
                    select new
                    {
                        DeptId=debtProcess.DebtProcessId,
                        CustomerId = customer.CustomerId,
                        CustomerName = customer.CustomerName,
                        CurrencyName = currency.CurrencyName,
                        Amount = debtProcess.Amount,
                        DateofDebt = debtProcess.DateofDebt
                    };
        mylist.ItemsSource = query;

    }

    private async void mylist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        bool result1 = await DisplayAlert(" ‰»Ì…", "Â·  —Ìœ  ⁄œÌ· «·„»·€ ?", "‰⁄„", "·«");
        if (result1)
        {
            var selectedDebt = mylist.SelectedItem;
            var DeptId = selectedDebt.GetType().GetProperty("DeptId").GetValue(selectedDebt, null);
            DebtProcess debtProcess = await DebtProcessEntity.FindAsync((int)DeptId);


            var customerId = selectedDebt.GetType().GetProperty("CustomerId").GetValue(selectedDebt, null);
            Customer customer = await CustomerEntity.FindAsync((int)customerId);
            string result = await DisplayPromptAsync("«·„»·€", "«œŒ· «·„»·€ «·ÃœÌœ");
            if (string.IsNullOrEmpty(result))
            {
                return;
            }
            double newamount = int.Parse(result);
            var currencyName = selectedDebt.GetType().GetProperty("CurrencyName").GetValue(selectedDebt, null);
            string currencyName1 = currencyName.ToString();
            var amount = selectedDebt.GetType().GetProperty("Amount").GetValue(selectedDebt, null);
            double amount2 = Convert.ToDouble(amount);
            double Amount = newamount - amount2;
            debtProcess.Amount = Convert.ToInt32(newamount);
            if (currencyName1 == "YER")
                customer.TotalDebtInYER -= Amount;
            else if (currencyName1 == "USD")
                customer.TotalDebtInUSD -= Amount;
            else
                customer.TotalDebtInSAR -= Amount;
            bool result2 = await CustomerEntity.UpdateDataAsync(customer);
            bool result3 = await DebtProcessEntity.UpdateDataAsync(debtProcess);
            if (result2 && result3)
            {
                await DisplayAlert("message", "sucess update", "Ok");
                loaddata();
            }
            else
            {
                await DisplayAlert("message", "filed update", "Ok");

            }

        }
    }
}
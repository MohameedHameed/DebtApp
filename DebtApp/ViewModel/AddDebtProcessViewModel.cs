using CommunityToolkit.Mvvm.ComponentModel;
using DebtApp.Model;
using DebtApp.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtApp.ViewModel
{
    public partial class AddDebtProcessViewModel:ObservableObject
    {
        //Fileds
        [ObservableProperty]
        string customerName;

        [ObservableProperty]
        string currencyName;

        [ObservableProperty]
        string amount;

       public CustomerEntity customerEntity;

      public  CurrencyEntity currencyEntity;
       public DebtProcessEntity DebtProcessEntity;
        [ObservableProperty]

        List<Customer> customers;
        [ObservableProperty]

        List<Currency> currencyes;

        [ObservableProperty]
        Customer customer;

        [ObservableProperty]
        Currency currency;

        public AddDebtProcessViewModel()
        {
            DebtProcessEntity = new DebtProcessEntity();
            customers = new List<Customer>();
            currencyes = new List<Currency>();
            currencyEntity = new CurrencyEntity();
            customerEntity = new CustomerEntity();
            loaddata();
        }

     
        public async void loaddata()
        {
            Customers = await customerEntity.GetAllAsync();
            Currencyes=await currencyEntity.GetAllAsync();
        }
        
        public async virtual Task<string> AddDebtData(int Customer_Id,int CurrencyId,int Amount,int CurrencyType)
        {
            DebtProcess debtProcess = new DebtProcess() { CustomerId = Customer_Id, CurrencyId = CurrencyId, Amount = Amount, DateofDebt = DateTime.Now ,DeptType="Dept"};

            bool result = await DebtProcessEntity.AddDataAsync(debtProcess);
            if (result)
            {
                Customer customer = await customerEntity.FindAsync(Customer_Id);

                if (CurrencyType == 0)

                    customer.TotalDebtInYER += Amount;
                else if (CurrencyType == 1)
                    customer.TotalDebtInUSD += Amount;
                else
                    customer.TotalDebtInSAR += Amount;



                bool result2 = await customerEntity.UpdateDataAsync(customer);
                if(result2)
                return "sucess saved";
                else
                    return "filed save";


            }
            else
                return "filed save";
        }
    }
}

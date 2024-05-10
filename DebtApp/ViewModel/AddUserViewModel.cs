using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using DebtApp.Model.DB;
using System.Windows.Input;
using DebtApp.Model;

namespace DebtApp.ViewModel
{
    public partial class AddUserViewModel : ObservableObject
    {
        //Fileds
        [ObservableProperty]
        string customerName;

        [ObservableProperty]
        string customerPhone;

        [ObservableProperty]
        string customerAddress;

       
        CustomerEntity  CustomerEntity;
        public AddUserViewModel()
        {
            CustomerEntity = new CustomerEntity();
        }

    
       public  async Task<string>  AddCustomer()
        {
            if (!(string.IsNullOrEmpty(CustomerName) || string.IsNullOrEmpty(CustomerPhone) || string.IsNullOrEmpty(CustomerAddress))) {
                
                Customer customer = new Customer { CustomerName = CustomerName, CustomerPhone = CustomerPhone, CustomerAddress = CustomerAddress, TotalDebtInYER = 0,TotalDebtInUSD=0,TotalDebtInSAR=0};
                 bool b=  await CustomerEntity.AddDataAsync(customer);
                if(b)
                    return "Sucess saved";
                else
                    return "filed save";

            }
            return "complete the data please";
        }
        public async Task<string> UpdateCustomer(Customer customer)
        {
            if (!(string.IsNullOrEmpty(CustomerName) || string.IsNullOrEmpty(CustomerPhone) || string.IsNullOrEmpty(CustomerAddress)))
            {

                bool b = await CustomerEntity.UpdateDataAsync(customer);
                if (b)
                    return "Updated Sucess";
                else
                    return "filed Update";

            }
            return "complete the data please";
        }
        public async Task<string> DeleteCustomer(Customer customer)
        {
            if (!(string.IsNullOrEmpty(CustomerName) || string.IsNullOrEmpty(CustomerPhone) || string.IsNullOrEmpty(CustomerAddress)))
            {

                bool b = await CustomerEntity.DeleteDataAsync(customer);
                if (b)
                    return "Deleted Sucess";
                else
                    return "filed Delete";

            }
            return "complete the data please";
        }
    }


}
    


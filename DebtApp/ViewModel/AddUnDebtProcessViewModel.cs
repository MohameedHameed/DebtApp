using DebtApp.Model;
using DebtApp.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtApp.ViewModel
{
    public partial class AddUnDebtProcessViewModel :AddDebtProcessViewModel
    {
        public async override Task<string> AddDebtData(int Customer_Id, int CurrencyId, int Amount, int CurrencyType)
        {
            DebtProcess debtProcess = new DebtProcess() { CustomerId = Customer_Id, CurrencyId = CurrencyId, Amount = Amount, DateofDebt = DateTime.Now,DeptType="UnDept" };

          
                Customer customer = await customerEntity.FindAsync(Customer_Id);

                if (CurrencyType == 0)
                {
                double customerdebt = customer.TotalDebtInYER;
                customerdebt -= Amount;
                if (customerdebt < 0)
                    return "المبلغ الذي تم سداده اكبر من مبلغ الدين";
                else
                    customer.TotalDebtInYER -= Amount;
                }
                else if (CurrencyType == 1)
                {
                double customerdebt = customer.TotalDebtInUSD;

                customerdebt -= Amount;
                if (customerdebt < 0)
                    return "المبلغ الذي تم سداده اكبر من مبلغ الدين";
                else
                    customer.TotalDebtInUSD -= Amount;
                }
                else
                {
                double customerdebt = customer.TotalDebtInSAR;

                customerdebt -= Amount;
                if (customerdebt < 0)
                    return "المبلغ الذي تم سداده اكبر من مبلغ الدين";
                else
                    customer.TotalDebtInSAR -= Amount;
                }

                bool result = await DebtProcessEntity.AddDataAsync(debtProcess);

                bool result2 = await customerEntity.UpdateDataAsync(customer);
                if (result && result2)
                    return "sucess saved";
                else
                    return "filed save";


            }
         
        }
    }


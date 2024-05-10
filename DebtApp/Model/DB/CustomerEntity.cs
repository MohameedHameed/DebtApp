using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtApp.Model.DB
{
    public class CustomerEntity : IDataHelper<Customer>
    {
        DBContext db;
       public CustomerEntity()
        {
            db=new DBContext();
        }
        public async Task<bool> AddDataAsync(Customer table)
        {
            try
            {
                await db.Customers.AddAsync(table);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async  Task<bool> DeleteDataAsync(Customer table)
        {
            try
            {
                 db.Customers.Remove(table);
                await db.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Customer> FindAsync(int Id)
        {
           
            return await db.Customers.FindAsync(Id);
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await db.Customers.ToListAsync();
       }

        public async  Task<bool> UpdateDataAsync(Customer table)
        {
            try
            {
                db.Customers.Update(table);
                await db.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

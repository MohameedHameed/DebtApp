using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtApp.Model.DB
{
    public class CurrencyEntity : IDataHelper<Currency>
    {
        DBContext db;
        public CurrencyEntity()
        {
            db = new DBContext();
        }
        public Task<bool> AddDataAsync(Currency table)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDataAsync(Currency table)
        {
            throw new NotImplementedException();
        }

        public Task<Currency> FindAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Currency>> GetAllAsync()
        {
            return await db.Currencys.ToListAsync();
        }

        public Task<bool> UpdateDataAsync(Currency table)
        {
            throw new NotImplementedException();
        }
    }
}

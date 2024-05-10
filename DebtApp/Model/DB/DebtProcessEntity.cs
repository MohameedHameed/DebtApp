using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DebtApp.Model;
using Microsoft.EntityFrameworkCore;
namespace DebtApp.Model.DB
{
    public class DebtProcessEntity : IDataHelper<DebtProcess>
    {
      public  DBContext db;
        public DebtProcessEntity()
        {
            db = new DBContext();
        }
        public async Task<bool> AddDataAsync(DebtProcess table)
        {
            try
            {
                await db.DebtProcesses.AddAsync(table);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteDataAsync(DebtProcess table)
        {
            try
            {
                db.DebtProcesses.Remove(table);
                await db.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<DebtProcess> FindAsync(int Id)
        {

            return await db.DebtProcesses.FindAsync(Id);
        }

        public async Task<List<DebtProcess>> GetAllAsync()
        {
            return await db.DebtProcesses.ToListAsync();
        }

        public async Task<bool> UpdateDataAsync(DebtProcess table)
        {
            try
            {
                db.DebtProcesses.Update(table);
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

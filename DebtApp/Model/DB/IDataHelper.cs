using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtApp.Model.DB
{
    public interface IDataHelper<Table>
    {
        Task<List<Table>> GetAllAsync();

        Task<Table> FindAsync(int Id);

        Task<bool> AddDataAsync(Table table);

       Task< bool> DeleteDataAsync(Table table);

       Task< bool> UpdateDataAsync(Table table);
    }
}

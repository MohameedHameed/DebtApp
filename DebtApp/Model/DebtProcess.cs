using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtApp.Model
{
    public class DebtProcess
    {
        [Key]
        public int DebtProcessId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }
        public int Amount { get; set; }
        public string DeptType { get; set; }
        public DateTime DateofDebt { get; set; }
        public Customer Customer { get; set; } // Navigation property
        public Currency Currency { get; set; } // Navigation property



    }
}

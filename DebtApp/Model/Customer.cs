using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtApp.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public double TotalDebtInYER { get; set; }
        public double TotalDebtInUSD { get; set; }
        public double TotalDebtInSAR{ get; set; }

        public ICollection<DebtProcess> DebtProcesses { get; set; }

    }
}

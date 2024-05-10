using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtApp.Model
{
    public  class Currency
    {
        [Key]
        public int CurrencyId { get; set; }
        [Required]
        public string CurrencyName { get; set; }
    }
}

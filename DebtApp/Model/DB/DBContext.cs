using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtApp.Model.DB
{
    public class DBContext:DbContext
    {
        //Add Tables
        public DbSet <Currency> Currencys { get; set; }
        public DbSet <Customer> Customers { get; set; }
        public DbSet <DebtProcess> DebtProcesses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var filename = Path.Combine(path,"DebtApp.db");
            optionsBuilder.UseSqlite("FileName="+filename);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure one-to-many relationship between Customer and DebtProcess
            modelBuilder.Entity<DebtProcess>()
                .HasOne(d => d.Customer)
                .WithMany(c => c.DebtProcesses)
                .HasForeignKey(d => d.CustomerId);

            // Configure one-to-many relationship between Currency and DebtProcess
            modelBuilder.Entity<DebtProcess>()
                .HasOne(d => d.Currency)
                .WithMany()
                .HasForeignKey(d => d.CurrencyId);

            // Set required constraint for CurrencyName
            modelBuilder.Entity<Currency>()
                .Property(c => c.CurrencyName)
                .IsRequired();
            modelBuilder.Entity<Customer>()
            .Property(c => c.CustomerPhone)
            .IsRequired();

            modelBuilder.Entity<Currency>().HasData(
        new Currency { CurrencyId = 1, CurrencyName = "YER" },
        new Currency { CurrencyId = 2, CurrencyName = "USD" },
        new Currency { CurrencyId = 3, CurrencyName = "SAR" });
        }

    }
}

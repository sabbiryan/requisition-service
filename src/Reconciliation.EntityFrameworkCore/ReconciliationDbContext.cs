using System;
using Microsoft.EntityFrameworkCore;
using ReconciliationApp.EntityFrameworkCore.IncomeOrExpenses;
using ReconciliationApp.EntityFrameworkCore.IncomeOrExpenseTypes;
using ReconciliationApp.EntityFrameworkCore.Reconciliations;

namespace ReconciliationApp.EntityFrameworkCore
{
    public class ReconciliationDbContext: DbContext
    {

        public ReconciliationDbContext(DbContextOptions options) : base(options)
        {

        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    IConfigurationRoot configuration = new ConfigurationBuilder()
        //        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        //        .AddJsonFile("appsettings.json")
        //        .Build();
        //    optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        //}


        public DbSet<IncomeOrExpenseType> IncomeOrExpenseTypes { get; set; }
        public DbSet<IncomeOrExpense> IncomeOrExpenses { get; set; }
        public DbSet<Reconciliation> Reconciliations { get; set; }

    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic.CompilerServices;
using ReconciliationApp.EntityFrameworkCore.IncomeOrExpenseTypes;

namespace ReconciliationApp.EntityFrameworkCore.Reconciliations
{
    [Table("Reconciliations")]
    public class Reconciliation: EntityBase<string>
    {

        public Reconciliation()
        {
            
        }


        public Reconciliation(string incomeOrExpenseTypeId, Month month, decimal amount, int year = 2019)
        {
            Id = Guid.NewGuid().ToString();
            IncomeOrExpenseTypeId = incomeOrExpenseTypeId;
            Month = month;
            Amount = amount;
            Year = year;
        }

        public string IncomeOrExpenseTypeId { get; set; }
        [ForeignKey("IncomeOrExpenseTypeId")]
        public IncomeOrExpenseType IncomeOrExpenseType { get; set; }

        public int Year { get; set; }
        public Month Month { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ReconciliationApp.EntityFrameworkCore.IncomeOrExpenseTypes;

namespace ReconciliationApp.EntityFrameworkCore.IncomeOrExpenses
{
    [Table("IncomeOrExpenses")]
    public class IncomeOrExpense: EntityBase<string>
    {
        public IncomeOrExpense()
        {
            
        }


        public IncomeOrExpense(string incomeOrExpenseTypeId, DateTime date, decimal amount)
        {
            Id = Guid.NewGuid().ToString();
            IncomeOrExpenseTypeId = incomeOrExpenseTypeId;
            Date = date;
            Amount = amount;
            CreationTime = date;
        }

        public string IncomeOrExpenseTypeId { get; set; }
        [ForeignKey("IncomeOrExpenseTypeId")]
        public virtual IncomeOrExpenseType IncomeOrExpenseType { get; set; }


        public DateTime Date { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
    }
}

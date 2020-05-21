using System.ComponentModel;

namespace ReconciliationApp.EntityFrameworkCore.IncomeOrExpenseTypes
{
    public enum IncomeOrExpenseFlag
    {
        [Description("Income")]
        Income = 1,

        [Description("Expense")]
        Expense = 2
    }
}
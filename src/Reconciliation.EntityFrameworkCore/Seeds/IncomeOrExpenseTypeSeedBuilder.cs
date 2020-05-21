using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ReconciliationApp.EntityFrameworkCore.IncomeOrExpenseTypes;

namespace ReconciliationApp.EntityFrameworkCore.Seeds
{
    public static class IncomeOrExpenseTypeSeedBuilder
    {
        public const string ExpenseType1 = "Expense Type 1";
        public const string ExpenseType2 = "Expense Type 2";
        public const string ExpenseType3 = "Expense Type 3";
        public const string IncomeType1 = "Income Type 1";
        public const string IncomeType2 = "Income Type 2";
        public const string IncomeType3 = "Income Type 3";

        public static void Build(ReconciliationDbContext context)
        {
            var incomeOrExpenseTypes = new List<IncomeOrExpenseType>()
            {
                new IncomeOrExpenseType(ExpenseType1, IncomeOrExpenseFlag.Expense),
                new IncomeOrExpenseType(ExpenseType2, IncomeOrExpenseFlag.Expense),
                new IncomeOrExpenseType(ExpenseType3, IncomeOrExpenseFlag.Expense),

                new IncomeOrExpenseType(IncomeType1, IncomeOrExpenseFlag.Income),
                new IncomeOrExpenseType(IncomeType2, IncomeOrExpenseFlag.Income),
                new IncomeOrExpenseType(IncomeType3, IncomeOrExpenseFlag.Income),
            };

            if (!context.IncomeOrExpenseTypes.AsNoTracking().Any())
            {
                context.IncomeOrExpenseTypes.AddRange(incomeOrExpenseTypes);
            }
            else
            {
                var types = context.IncomeOrExpenseTypes.AsNoTracking().ToList();

                foreach (var incomeOrExpenseType in incomeOrExpenseTypes)
                {
                    if (!types.Any(x => x.Flag == incomeOrExpenseType.Flag && x.SystemName == incomeOrExpenseType.SystemName))
                    {
                        context.IncomeOrExpenseTypes.Add(incomeOrExpenseType);
                    }
                }
            }

            context.SaveChanges();
        }
    }
}
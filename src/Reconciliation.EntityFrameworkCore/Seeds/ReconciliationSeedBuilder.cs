using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ReconciliationApp.EntityFrameworkCore.Reconciliations;

namespace ReconciliationApp.EntityFrameworkCore.Seeds
{
    public static class ReconciliationSeedBuilder
    {
        public static void Build(ReconciliationDbContext context)
        {
            //Ensure reconciliation has only seed data
            context.Reconciliations.RemoveRange(context.Reconciliations);
            context.SaveChanges();

            var types = context.IncomeOrExpenseTypes.AsNoTracking().ToList();

            var incomeType1Id = types.First(x => x.SystemName == IncomeOrExpenseTypeSeedBuilder.IncomeType1).Id;
            var incomeType2Id = types.First(x => x.SystemName == IncomeOrExpenseTypeSeedBuilder.IncomeType2).Id;
            var incomeType3Id = types.First(x => x.SystemName == IncomeOrExpenseTypeSeedBuilder.IncomeType3).Id;

            var expenseType1Id = types.First(x => x.SystemName == IncomeOrExpenseTypeSeedBuilder.ExpenseType1).Id;
            var expenseType2Id = types.First(x => x.SystemName == IncomeOrExpenseTypeSeedBuilder.ExpenseType2).Id;
            var expenseType3Id = types.First(x => x.SystemName == IncomeOrExpenseTypeSeedBuilder.ExpenseType3).Id;

            var reconciliations = new List<Reconciliation>()
            {
                new Reconciliation(incomeType1Id, Month.January, 1200),
                new Reconciliation(incomeType2Id, Month.January, 251),
                new Reconciliation(expenseType2Id, Month.January, 200),

                new Reconciliation(incomeType2Id, Month.March, 152),
                new Reconciliation(expenseType3Id, Month.March, 250),

                new Reconciliation(incomeType1Id, Month.April, 52),
                new Reconciliation(incomeType3Id, Month.April, 225),
                new Reconciliation(expenseType1Id, Month.April, 300),

                new Reconciliation(incomeType2Id, Month.May, 522),

                new Reconciliation(expenseType2Id, Month.June, 500),

                new Reconciliation(expenseType1Id, Month.August, 100),
            };

            if (!context.Reconciliations.Any())
            {
                context.Reconciliations.AddRange(reconciliations);
            }

            context.SaveChanges();
        }
    }
}
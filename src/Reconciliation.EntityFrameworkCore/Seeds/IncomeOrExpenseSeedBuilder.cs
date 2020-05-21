using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ReconciliationApp.EntityFrameworkCore.IncomeOrExpenses;
using ReconciliationApp.EntityFrameworkCore.IncomeOrExpenseTypes;

namespace ReconciliationApp.EntityFrameworkCore.Seeds
{
    public static class IncomeOrExpenseSeedBuilder
    {
        public static void Build(ReconciliationDbContext context)
        {
            //Ensure income or expense has only seed data
            context.IncomeOrExpenses.RemoveRange(context.IncomeOrExpenses);
            context.SaveChanges();

            var types = context.IncomeOrExpenseTypes.AsNoTracking().ToList();

            var incomeType1Id = types.First(x=> x.SystemName == IncomeOrExpenseTypeSeedBuilder.IncomeType1).Id;
            var incomeType2Id = types.First(x=> x.SystemName == IncomeOrExpenseTypeSeedBuilder.IncomeType2).Id;
            var incomeType3Id = types.First(x=> x.SystemName == IncomeOrExpenseTypeSeedBuilder.IncomeType3).Id;

            var expenseType1Id = types.First(x => x.SystemName == IncomeOrExpenseTypeSeedBuilder.ExpenseType1).Id;
            var expenseType2Id = types.First(x => x.SystemName == IncomeOrExpenseTypeSeedBuilder.ExpenseType2).Id;
            var expenseType3Id = types.First(x => x.SystemName == IncomeOrExpenseTypeSeedBuilder.ExpenseType3).Id;

            var incomeOrExpenseTypes = new List<IncomeOrExpense>()
            {
                new IncomeOrExpense(incomeType1Id, new DateTime(2019, 01, 01), 100),
                new IncomeOrExpense(incomeType1Id, new DateTime(2019, 02, 01), 50),
                new IncomeOrExpense(incomeType1Id, new DateTime(2019, 03, 01), 150),
                new IncomeOrExpense(incomeType1Id, new DateTime(2019, 04, 01), 0),
                new IncomeOrExpense(incomeType1Id, new DateTime(2019, 05, 01), 800),
                new IncomeOrExpense(incomeType1Id, new DateTime(2019, 06, 01), 50),
                new IncomeOrExpense(incomeType1Id, new DateTime(2019, 07, 01), 100),
                new IncomeOrExpense(incomeType1Id, new DateTime(2019, 08, 01), 0),
                new IncomeOrExpense(incomeType1Id, new DateTime(2019, 09, 01), 0),
                new IncomeOrExpense(incomeType1Id, new DateTime(2019, 10, 01), 0),
                new IncomeOrExpense(incomeType1Id, new DateTime(2019, 11, 01), 0),
                new IncomeOrExpense(incomeType1Id, new DateTime(2019, 12, 01), 0),


                new IncomeOrExpense(expenseType1Id, new DateTime(2019, 01, 01), 200),
                new IncomeOrExpense(expenseType1Id, new DateTime(2019, 02, 01), 70),
                new IncomeOrExpense(expenseType1Id, new DateTime(2019, 03, 01), 120),
                new IncomeOrExpense(expenseType1Id, new DateTime(2019, 04, 01), 200),
                new IncomeOrExpense(expenseType1Id, new DateTime(2019, 05, 01), 300),
                new IncomeOrExpense(expenseType1Id, new DateTime(2019, 06, 01), 50),
                new IncomeOrExpense(expenseType1Id, new DateTime(2019, 07, 01), 50),
                new IncomeOrExpense(expenseType1Id, new DateTime(2019, 08, 01), 0),
                new IncomeOrExpense(expenseType1Id, new DateTime(2019, 09, 01), 0),
                new IncomeOrExpense(expenseType1Id, new DateTime(2019, 10, 01), 0),
                new IncomeOrExpense(expenseType1Id, new DateTime(2019, 11, 01), 0),
                new IncomeOrExpense(expenseType1Id, new DateTime(2019, 12, 01), 0),
            };

            if (!context.IncomeOrExpenses.Any())
            {
                context.IncomeOrExpenses.AddRange(incomeOrExpenseTypes);
            }

            context.SaveChanges();
        }
    }
}
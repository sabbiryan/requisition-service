using System.Collections.Generic;
using System.Linq;
using ReconciliationApp.EntityFrameworkCore.IncomeOrExpenses;
using ReconciliationApp.EntityFrameworkCore.IncomeOrExpenseTypes;
using ReconciliationApp.EntityFrameworkCore.Reconciliations;
using ReconciliationApp.Service.Reconciliations.Dtos;

namespace ReconciliationApp.Service.Reconciliations
{
    public class StatementBuilder
    {
        /// <summary>
        /// Generate monthly income statement
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="incomeOrExpenses"></param>
        public static void BuildIncomeStatement(YearlyReconciliationGridDto grid, ref List<IncomeOrExpense> incomeOrExpenses)
        {
            var row = new YearlyReconciliationGridResultDto(StatementConst.Income, 0);
            foreach (var title in grid.Titles)
            {
                var column = new YearlyReconciliationGridResultValueDto(title.Month);

                column.Amount = incomeOrExpenses
                    .Where(x => x.IncomeOrExpenseType.Flag == IncomeOrExpenseFlag.Income &&
                                x.Date.Month == (int)title.Month)
                    .Sum(x => x.Amount);

                row.Values.Add(column);
            }

            grid.Statements.Add(row);
        }


        /// <summary>
        /// Calculate cumulative monthly income
        /// </summary>
        /// <param name="grid"></param>
        public static void BuildCumulativeIncomeStatement(YearlyReconciliationGridDto grid)
        {
            var incomeRow = grid.Statements.FirstOrDefault(x => x.Title == StatementConst.Income);
            if (incomeRow == null) return;

            var row = new YearlyReconciliationGridResultDto(StatementConst.CumulativeIncome, 1);
            for (var index = 0; index < grid.Titles.Count; index++)
            {
                var title = grid.Titles[index];
                var column = new YearlyReconciliationGridResultValueDto(title.Month);

                var currentMonth = incomeRow.Values.FirstOrDefault(x => x.Month == title.Month);
                if (index == 0)
                {
                    if (currentMonth != null) column.Amount = currentMonth.Amount;
                }
                else
                {
                    var previousMonthCumulative = row.Values.FirstOrDefault(x => x.Month == (Month)((int)title.Month - 1));

                    if (previousMonthCumulative != null && currentMonth != null)
                        column.Amount = previousMonthCumulative.Amount + currentMonth.Amount;
                }

                row.Values.Add(column);
            }

            grid.Statements.Add(row);
        }


        /// <summary>
        /// Generate monthly cost statement
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="incomeOrExpenses"></param>
        public static void BuildCostStatement(YearlyReconciliationGridDto grid, ref List<IncomeOrExpense> incomeOrExpenses)
        {
            var row = new YearlyReconciliationGridResultDto(StatementConst.Cost, 2);
            foreach (var title in grid.Titles)
            {
                var column = new YearlyReconciliationGridResultValueDto(title.Month);

                column.Amount = incomeOrExpenses
                    .Where(x => x.IncomeOrExpenseType.Flag == IncomeOrExpenseFlag.Expense &&
                                x.Date.Month == (int)title.Month)
                    .Sum(x => x.Amount);

                row.Values.Add(column);
            }

            grid.Statements.Add(row);
        }


        /// <summary>
        /// Calculate cumulative monthly expense
        /// </summary>
        /// <param name="grid"></param>
        public static void BuildCumulativeCostStatement(YearlyReconciliationGridDto grid)
        {
            var costRow = grid.Statements.FirstOrDefault(x => x.Title == StatementConst.Cost);
            if (costRow == null) return;

            var row = new YearlyReconciliationGridResultDto(StatementConst.CumulativeCost, 3);
            for (var index = 0; index < grid.Titles.Count; index++)
            {
                var title = grid.Titles[index];
                var column = new YearlyReconciliationGridResultValueDto(title.Month);

                var currentMonth = costRow.Values.FirstOrDefault(x => x.Month == title.Month);
                if (index == 0)
                {
                    if (currentMonth != null) column.Amount = currentMonth.Amount;
                }
                else
                {
                    var previousMonthCumulative = row.Values.FirstOrDefault(x => x.Month == (Month)((int)title.Month - 1));

                    if (previousMonthCumulative != null && currentMonth != null)
                        column.Amount = previousMonthCumulative.Amount + currentMonth.Amount;
                }

                row.Values.Add(column);
            }

            grid.Statements.Add(row);
        }


        /// <summary>
        /// Calculate monthly statement result
        /// </summary>
        /// <param name="grid"></param>
        public static void BuildStatementResult(YearlyReconciliationGridDto grid)
        {
            var incomeRow = grid.Statements.FirstOrDefault(x => x.Title == StatementConst.Income);
            var costRow = grid.Statements.FirstOrDefault(x => x.Title == StatementConst.Cost);

            if (incomeRow == null || costRow == null) return;

            var row = new YearlyReconciliationGridResultDto(StatementConst.Result, 4);
            foreach (var title in grid.Titles)
            {
                var column = new YearlyReconciliationGridResultValueDto(title.Month);

                var income = incomeRow.Values.FirstOrDefault(x => x.Month == title.Month);
                var cost = costRow.Values.FirstOrDefault(x => x.Month == title.Month);

                column.Amount = income?.Amount - cost?.Amount;

                row.Values.Add(column);
            }

            grid.Statements.Add(row);
        }
    }
}
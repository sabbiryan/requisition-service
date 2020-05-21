using System;
using System.Linq;
using System.Text;
using ReconciliationApp.EntityFrameworkCore.IncomeOrExpenseTypes;
using ReconciliationApp.EntityFrameworkCore.Reconciliations;
using ReconciliationApp.Service.Reconciliations.Dtos;

namespace ReconciliationApp.Service.Reconciliations
{
    public class ReconciliationBuilder
    {

        /// <summary>
        /// Calculate reconciliation summation result
        /// </summary>
        /// <param name="grid"></param>
        public static void BuildReconciliationResult(YearlyReconciliationGridDto grid)
        {
            var row = new YearlyReconciliationGridResultDto(ReconciliationConst.Result, 0);
            foreach (var title in grid.Titles)
            {
                var column = new YearlyReconciliationGridResultValueDto(title.Month);

                var columnValues = grid.Rows
                    .SelectMany(x => x.Columns)
                    .Where(x => x.Month == title.Month).ToList();

                column.Amount = columnValues.Where(x => x.Flag == IncomeOrExpenseFlag.Income).Sum(x => x.Amount) -
                              columnValues.Where(x => x.Flag == IncomeOrExpenseFlag.Expense).Sum(x => x.Amount);

                row.Values.Add(column);
            }

            grid.Results.Add(row);
        }


        /// <summary>
        /// Calculate reconciliation final result based on statement summation result and reconciliation summation result
        /// </summary>
        /// <param name="grid"></param>
        public static void BuildReconciliationFinalResult(YearlyReconciliationGridDto grid)
        {
            var statementResultRow = grid.Statements.FirstOrDefault(x => x.Title == StatementConst.Result);
            var reconciliationResultRow = grid.Results.FirstOrDefault(x => x.Title == ReconciliationConst.Result);
            if(statementResultRow == null || reconciliationResultRow == null) return;

            var row = new YearlyReconciliationGridResultDto(ReconciliationConst.FinalResult, 1);
            foreach (var title in grid.Titles)
            {
                var column = new YearlyReconciliationGridResultValueDto(title.Month);

                var income = statementResultRow.Values.FirstOrDefault(x => x.Month == title.Month);
                var cost = reconciliationResultRow.Values.FirstOrDefault(x => x.Month == title.Month);

                column.Amount = income?.Amount + cost?.Amount;

                row.Values.Add(column);
            }

            grid.Results.Add(row);
        }


        /// <summary>
        /// Calculate cumulative final result
        /// </summary>
        /// <param name="grid"></param>
        public static void BuildCumulativeFinalResult(YearlyReconciliationGridDto grid)
        {
            var finalResultRow = grid.Results.FirstOrDefault(x => x.Title == ReconciliationConst.FinalResult);
            if (finalResultRow == null) return;

            var row = new YearlyReconciliationGridResultDto(ReconciliationConst.CumulativeFinalResult, 2);
            for (var index = 0; index < grid.Titles.Count; index++)
            {
                var title = grid.Titles[index];
                var column = new YearlyReconciliationGridResultValueDto(title.Month);

                var currentMonth = finalResultRow.Values.FirstOrDefault(x => x.Month == title.Month);
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

            grid.Results.Add(row);
        }

    }
}

using System;
using ReconciliationApp.EntityFrameworkCore.Reconciliations;
using ReconciliationApp.Service.IncomeOrExpenseTypes.Dtos;
using ReconciliationApp.Shared.Dtos;
using ReconciliationApp.Shared.Extensions;

namespace ReconciliationApp.Service.Reconciliations.Dtos
{
    public class ReconciliationDto : DtoBase<string>
    {
        public string IncomeOrExpenseTypeId { get; set; }
        public IncomeOrExpenseTypeDto IncomeOrExpenseType { get; set; }

        public int Year { get; set; }
        public Month Month { get; set; }
        public string MonthDisplayText => Month.GetDescription();

        public decimal Amount { get; set; }
    }
}
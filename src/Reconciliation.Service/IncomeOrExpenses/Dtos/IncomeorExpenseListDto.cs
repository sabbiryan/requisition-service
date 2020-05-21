using System;
using System.Collections.Generic;
using System.Text;
using ReconciliationApp.Service.IncomeOrExpenseTypes.Dtos;
using ReconciliationApp.Shared.Dtos;

namespace ReconciliationApp.Service.IncomeOrExpenses.Dtos
{
    public class IncomeOrExpenseListDto: DtoBase<string>
    {
        public string IncomeOrExpenseTypeId { get; set; }
        public IncomeOrExpenseTypeDto IncomeOrExpenseType { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }
    }
}

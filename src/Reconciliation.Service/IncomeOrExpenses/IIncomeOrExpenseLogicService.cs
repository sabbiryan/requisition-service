using System.Collections.Generic;
using System.Threading.Tasks;
using ReconciliationApp.Service.IncomeOrExpenses.Dtos;
using ReconciliationApp.Service.IncomeOrExpenseTypes.Dtos;

namespace ReconciliationApp.Service.IncomeOrExpenses
{
    public interface IIncomeOrExpenseLogicService
    {
        Task<List<IncomeOrExpenseListDto>> GetIncomeOrExpensesAsync();
    }
}
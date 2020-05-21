using System.Collections.Generic;
using System.Threading.Tasks;
using ReconciliationApp.Service.IncomeOrExpenseTypes.Dtos;

namespace ReconciliationApp.Service.IncomeOrExpenseTypes
{
    public interface IIncomeOrExpenseTypeLogicService
    {
        Task<List<IncomeOrExpenseTypeListDto>> GetIncomeOrExpenseTypesAsync();
    }
}
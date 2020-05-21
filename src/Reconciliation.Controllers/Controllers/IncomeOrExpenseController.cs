using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReconciliationApp.Service.IncomeOrExpenses;
using ReconciliationApp.Service.IncomeOrExpenses.Dtos;

namespace ReconciliationApp.Controllers.Controllers
{
    public class IncomeOrExpenseController : ApiControllerBase
    {
        private readonly IIncomeOrExpenseLogicService _incomeOrExpenseLogicService;

        public IncomeOrExpenseController(IIncomeOrExpenseLogicService incomeOrExpenseLogicService)
        {
            _incomeOrExpenseLogicService = incomeOrExpenseLogicService;
        }

        [HttpGet]
        public async Task<List<IncomeOrExpenseListDto>> Get()
        {
            var incomeOrExpenseTypes = await _incomeOrExpenseLogicService.GetIncomeOrExpensesAsync();

            return incomeOrExpenseTypes;
        }
    }
}
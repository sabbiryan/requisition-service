using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReconciliationApp.Service.IncomeOrExpenseTypes;
using ReconciliationApp.Service.IncomeOrExpenseTypes.Dtos;

namespace ReconciliationApp.Controllers.Controllers
{
    public class IncomeOrExpenseTypeController : ApiControllerBase
    {
        private readonly IIncomeOrExpenseTypeLogicService _incomeOrExpenseTypeLogicService;

        public IncomeOrExpenseTypeController(IIncomeOrExpenseTypeLogicService incomeOrExpenseTypeLogicService)
        {
            _incomeOrExpenseTypeLogicService = incomeOrExpenseTypeLogicService;
        }

        [HttpGet]
        public async Task<List<IncomeOrExpenseTypeListDto>> Get()
        {
            var incomeOrExpenseTypes = await _incomeOrExpenseTypeLogicService.GetIncomeOrExpenseTypesAsync();

            return incomeOrExpenseTypes;
        }
    }
}
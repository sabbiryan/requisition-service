using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReconciliationApp.EntityFrameworkCore;
using ReconciliationApp.Service.IncomeOrExpenses.Dtos;

namespace ReconciliationApp.Service.IncomeOrExpenses
{
    public class IncomeOrExpenseLogicService: LogicServiceBase, IIncomeOrExpenseLogicService
    {
        public IncomeOrExpenseLogicService(ReconciliationDbContext context) : base(context)
        {
        }


        public async Task<List<IncomeOrExpenseListDto>> GetIncomeOrExpensesAsync()
        {
            var incomeOrExpenses = await Context.IncomeOrExpenses.AsNoTracking().Include(x=> x.IncomeOrExpenseType).ToListAsync();

            var map = Mapper.Map<List<IncomeOrExpenseListDto>>(incomeOrExpenses);

            return map;
        }
    }
}

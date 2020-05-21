using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReconciliationApp.EntityFrameworkCore;
using ReconciliationApp.Service.IncomeOrExpenseTypes.Dtos;

namespace ReconciliationApp.Service.IncomeOrExpenseTypes
{
    public class IncomeOrExpenseTypeLogicService: LogicServiceBase, IIncomeOrExpenseTypeLogicService
    {
        public IncomeOrExpenseTypeLogicService(ReconciliationDbContext context) : base(context)
        {
        }


        public async Task<List<IncomeOrExpenseTypeListDto>> GetIncomeOrExpenseTypesAsync()
        {
            var incomeOrExpenseTypes = await Context.IncomeOrExpenseTypes.AsNoTracking().ToListAsync();
            var result = Mapper.Map<List<IncomeOrExpenseTypeListDto>>(incomeOrExpenseTypes);

            return result;
        }
    }
}

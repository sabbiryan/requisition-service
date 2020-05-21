using ReconciliationApp.EntityFrameworkCore.IncomeOrExpenseTypes;
using ReconciliationApp.Shared.Dtos;
using ReconciliationApp.Shared.Extensions;

namespace ReconciliationApp.Service.IncomeOrExpenseTypes.Dtos
{
    public class IncomeOrExpenseTypeDto : DtoBase<string>
    {
        public string DisplayName { get; set; }

        public IncomeOrExpenseFlag Flag { get; set; }
        public string FlagDisplayText => Flag.GetDescription();
    }
}
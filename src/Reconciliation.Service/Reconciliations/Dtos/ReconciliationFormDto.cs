using System;
using System.ComponentModel.DataAnnotations;
using ReconciliationApp.EntityFrameworkCore.Reconciliations;
using ReconciliationApp.Shared.Dtos;

namespace ReconciliationApp.Service.Reconciliations.Dtos
{
    public class ReconciliationFormDto : DtoBase<string>
    {
        public ReconciliationFormDto()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Required(ErrorMessage = "Please enter a year")]
        public int Year { get; set; } = DateTime.Now.Year;

        [Required(ErrorMessage = "Please select a month of reconciliation")]
        [Range(1, 12, ErrorMessage = "Please select a month of reconciliation")]
        public int Month { get; set; }


        [Required(ErrorMessage = "Please select an income or expense type")]
        public string IncomeOrExpenseTypeId { get; set; }


        [Required(ErrorMessage = "Please select an amount more than 0")]
        public decimal Amount { get; set; }
    }
}
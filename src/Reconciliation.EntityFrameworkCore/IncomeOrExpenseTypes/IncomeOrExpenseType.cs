using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ReconciliationApp.EntityFrameworkCore.Reconciliations;

namespace ReconciliationApp.EntityFrameworkCore.IncomeOrExpenseTypes
{
    [Table("IncomeOrExpenseTypes")]
    public class IncomeOrExpenseType : EntityBase<string>
    {
        public IncomeOrExpenseType()
        {
            
        }

        public IncomeOrExpenseType(string displayName, IncomeOrExpenseFlag flag)
        {
            Id = Guid.NewGuid().ToString();
            DisplayName = displayName;
            SystemName = displayName;
            Flag = flag;
        }

        /// <summary>
        /// Name to display on client end.
        /// </summary>
        [StringLength(128)]
        public string DisplayName { get; set; }


        /// <summary>
        /// Annotated as a system type
        /// </summary>
        public bool IsSystem { get; set; }


        /// <summary>
        /// By default system name is same as display name. But when the entry is annotated as system type, the system name could not be change on change of display name.
        /// We can generate the system names using seed on startup
        /// </summary>
        [StringLength(128)]
        public string SystemName { get; set; }


        /// <summary>
        /// Define flag, the type is using for expense or income
        /// </summary>
        public IncomeOrExpenseFlag Flag { get; set; }



        public virtual ICollection<IncomeOrExpenseType> IncomeOrExpenseTypes { get; set; }
        public virtual ICollection<Reconciliation> Reconciliations { get; set; }
    }
}

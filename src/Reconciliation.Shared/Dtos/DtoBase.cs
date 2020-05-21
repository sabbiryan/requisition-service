using System;
using System.Collections.Generic;
using System.Text;

namespace ReconciliationApp.Shared.Dtos
{
    public class DtoBase<T>
    {
        public T Id { get; set; }

        public DateTime CreationTime { get; set; } = DateTime.Now;
    }
}

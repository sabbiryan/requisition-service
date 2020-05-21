using System;
using System.ComponentModel.DataAnnotations;

namespace ReconciliationApp.EntityFrameworkCore
{
    public class EntityBase<T>
    {
        [Key]
        public T Id { get; set; }


        public DateTime CreationTime { get; set; } = DateTime.Now;
        public DateTime? ModificationTime { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }


        public string DeviceInfo { get; set; }
        public string IpAddress { get; set; }
    }
}
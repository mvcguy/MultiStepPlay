using System;
using System.ComponentModel.DataAnnotations;

namespace MyPersonalDiary.com.Domain.Repository
{
    public abstract class AuditFields
    {
        [Key]
        public Guid? Id { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public Guid? CreatedBy { get; set; }

        public Guid? ModifiedBy { get; set; }

        [Timestamp]
        public byte[] TStamp { get; set; }
    }
}

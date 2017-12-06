using System;

namespace OfficePlanApi.Domain.Entities
{
    public abstract class BaseEntityAuditDate : BaseEntity
    {
        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}

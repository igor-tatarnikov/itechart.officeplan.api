using System;

namespace OfficePlanApi.Domain.Entities
{
    public abstract class BaseEntitySoftDelete : BaseEntityAuditDate
    {
        public bool Deleted { get; set; }

        public int? DeletedBy { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}

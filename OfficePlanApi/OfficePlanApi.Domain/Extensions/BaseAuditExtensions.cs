using OfficePlanApi.Domain.Entities;
using OfficePlanApi.Domain.Interfaces.Services;
using OfficePlanApi.Domain.Interfaces.WorkContexts;

namespace OfficePlanApi.Domain.Extensions
{
    public static class BaseAuditExtensions
    {
        public static void AuditModify(this BaseEntityAuditDate entity, IDateTimeService dateTimeService, IBaseWorkContext workContext)
        {
            if (entity != null)
            {
                entity.ModifiedBy = workContext.EmployeeId;
                entity.ModifiedOn = dateTimeService.GetNowDateTime();
            }
        }

        public static void AuditCreate(this BaseEntityAuditDate entity, IDateTimeService dateTimeService, IBaseWorkContext workContext)
        {
            if (entity != null)
            {
                entity.CreatedBy = workContext.EmployeeId;
                entity.CreatedOn = dateTimeService.GetNowDateTime();
                entity.AuditModify(dateTimeService, workContext);
            }
        }

        public static void AuditDelete(this BaseEntitySoftDelete entity, IDateTimeService dateTimeService, IBaseWorkContext workContext)
        {
            if (entity != null)
            {
                entity.Deleted = true;
                entity.DeletedBy = workContext.EmployeeId;
                entity.DeletedOn = dateTimeService.GetNowDateTime();
            }
        }
    }
}

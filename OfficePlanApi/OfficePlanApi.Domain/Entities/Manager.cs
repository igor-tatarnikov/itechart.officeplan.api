namespace OfficePlanApi.Domain.Entities
{
    public class Manager : BaseEntitySoftDelete
    {
        public int EmployeeId { get; set; }

        public int ControlledDepartmentId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Department ControlledDepartment { get; set; }
    }
}

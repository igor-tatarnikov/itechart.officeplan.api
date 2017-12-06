namespace OfficePlanApi.Domain.Entities
{
    public class Employee : BaseEntitySoftDelete
    {
        public int SmgUserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhotoUrl { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}

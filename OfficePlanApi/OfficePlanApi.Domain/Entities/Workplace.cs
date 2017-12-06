namespace OfficePlanApi.Domain.Entities
{
    public class Workplace : BaseEntitySoftDelete
    {
        public int? AssignedEmployeeId { get; set; }

        public int RoomObjectId { get; set; }

        public virtual Employee AssignedEmployee { get; set; }

        public virtual RoomObject RoomObject { get; set; }
    }
}

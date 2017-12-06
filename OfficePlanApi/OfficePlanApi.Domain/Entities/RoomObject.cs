namespace OfficePlanApi.Domain.Entities
{
    public class RoomObject : BaseEntitySoftDelete
    {
        public int RoomId { get; set; }

        public double CoordinateX { get; set; }

        public double CoordinateY { get; set; }

        public virtual Room Room { get; set; }
    }
}

namespace OfficePlanApi.Domain.Entities
{
    public class RoomObject : BaseEntitySoftDelete
    {
        public int RoomId { get; set; }

        public int CoordinateX { get; set; }

        public int CoordinateY { get; set; }

        public virtual Room Room { get; set; }
    }
}

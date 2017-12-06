namespace OfficePlanApi.Domain.Entities
{
    public class Furniture : BaseEntitySoftDelete
    {
        public int RoomObjectId { get; set; }

        public FurnitureTypes Type { get; set; }

        public double Rotation { get; set; }

        public virtual RoomObject RoomObject { get; set; }
    }
}

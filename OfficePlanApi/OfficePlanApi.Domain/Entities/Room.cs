namespace OfficePlanApi.Domain.Entities
{
    public class Room : BaseEntitySoftDelete
    {
        public int OfficeId { get; set; }

        public int ResponsibleManagerId { get; set; }

        public string Name { get; set; }

        public virtual Office Office { get; set; }

        public virtual Manager ResponsibleManager { get; set; }
    }
}

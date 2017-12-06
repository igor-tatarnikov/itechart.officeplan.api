namespace OfficePlanApi.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public static bool operator ==(BaseEntity x, BaseEntity y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(BaseEntity x, BaseEntity y)
        {
            return !(x == y);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public virtual bool Equals(BaseEntity compareTo)
        {
            if (compareTo == null)
            {
                return false;
            }

            if (ReferenceEquals(this, compareTo))
            {
                return true;
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as BaseEntity);
        }
    }
}

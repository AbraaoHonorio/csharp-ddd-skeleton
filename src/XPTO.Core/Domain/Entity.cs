using System;

namespace XPTO.Core.Domain
{
    public abstract class Entity : AssertionConcern
    {
        public Guid Id { get; set; }

        protected Entity()
        {
        }

        public abstract bool IsValidate();

        public override int GetHashCode()
        {
            return GetType().GetHashCode() + Id.GetHashCode();
        }

        public override bool Equals(object @object)
        {
            if (@object is null) return false;

            var compareTO = @object as Entity;

            if (ReferenceEquals(this, compareTO)) return true;

            return Id.Equals(compareTO.Id);
        }

        public static bool operator ==(Entity entityOne, Entity entityTow)
        {
            if (entityOne is null && entityTow is null)
                return true;

            if (entityOne is null || entityTow is null)
                return false;

            return entityOne.Equals(entityTow);
        }

        public static bool operator !=(Entity entityOne, Entity entityTow) => !(entityOne == entityTow);
    }
}
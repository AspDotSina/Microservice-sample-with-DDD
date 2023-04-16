using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Framework
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; protected set; }

        public override bool Equals(object? obj)
        {
            if(ReferenceEquals(null,obj))return false;
            if(ReferenceEquals(this,obj))return true;
            if(obj.GetType() != typeof(Entity)) return false;

            return EqualityComparer<Guid>.Default.Equals(Id, ((Entity)obj).Id);
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (ReferenceEquals(left,null))
            {
                return ReferenceEquals(right, null);
            }
            return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)=>!(left == right);

        public override int GetHashCode()
        {
            if (Id.Equals(default(Guid)))
            {
                return base.GetHashCode();
            }
            return GetType().GetHashCode()^Id.GetHashCode();
        }

    }
}

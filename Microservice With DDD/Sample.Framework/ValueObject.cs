using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Framework
{
    public abstract class ValueObject
    {
        private const int HighPrime = 557927;

        protected abstract IEnumerable<object> GetAtomicValues();



        public override int GetHashCode()
        {
            return GetAtomicValues().Select((x, i) => (x != null ? x.GetHashCode() : 0) + (HighPrime * i)).Aggregate((x, y) => x ^ y);
        }
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(ValueObject)) return false;

            return Equals((ValueObject)obj);
        }

        public static bool operator ==(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }
            return left.Equals(right);
        }

        public static bool operator !=(ValueObject left, ValueObject right) => !(left == right);

       public ValueObject GetCopy()
        {
            return this.MemberwiseClone() as ValueObject;
        }
    }
}

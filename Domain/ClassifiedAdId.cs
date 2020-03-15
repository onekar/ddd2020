using Marketplace.Framework;
using System;

namespace Marketplace.Domain
{
    public class ClassifiedAdId : IEquatable<ClassifiedAdId>
    {
        private readonly Guid value;

        public ClassifiedAdId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Classified Ad id cannot be empty");

            this.value = value;
        }

        public bool Equals(ClassifiedAdId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return value.Equals(other.value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ClassifiedAdId)obj);
        }
    }
}

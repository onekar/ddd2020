using Marketplace.Framework;
using System;

namespace Marketplace.Domain
{
    public class UserId : Value<UserId>
    {
        private readonly Guid value;

        public UserId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "User id cannot be empty");

            this.value = value;
        }
    }
}

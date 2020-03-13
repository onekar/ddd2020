﻿using Marketplace.Framework;
using System;

namespace Marketplace.Domain
{
    public class ClassifiedAdId : Value<ClassifiedAdId>
    {
        private readonly Guid value;

        public ClassifiedAdId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Classified Ad id cannot be empty");

            this.value = value;
        }
    }
}

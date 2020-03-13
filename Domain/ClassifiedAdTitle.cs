using Marketplace.Framework;
using System;

namespace Marketplace.Domain
{
    public class ClassifiedAdTitle : Value<ClassifiedAdTitle>
    {
        private readonly string value;

        private ClassifiedAdTitle(string value)
        {
            if (value.Length > 100)
                throw new ArgumentException("Title cannot be longer than 100 characters", nameof(value));

            this.value = value;
        }

        public static ClassifiedAdTitle FromString(string title) => new ClassifiedAdTitle(title);
    }
}

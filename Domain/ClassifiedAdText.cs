using Marketplace.Framework;
using System;

namespace Marketplace.Domain
{
    public class ClassifiedAdText : Value<ClassifiedAdText>
    {
        private readonly string value;

        private ClassifiedAdText(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Text cannot be empty", nameof(value));

            this.value = value;
        }

        public static ClassifiedAdText Create(string text) => new ClassifiedAdText(text);
    }
}

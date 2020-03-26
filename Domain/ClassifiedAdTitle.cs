using Marketplace.Framework;
using System;

namespace Marketplace.Domain
{
    public class ClassifiedAdTitle : Value<ClassifiedAdTitle>
    {
        public string Value { get; }

        internal ClassifiedAdTitle(string title) => Value = title;
        
        public static ClassifiedAdTitle Create(string title)
        {
            CheckValidity(title);
            return new ClassifiedAdTitle(title);
        }

        public static implicit operator string(ClassifiedAdTitle classifiedAdTitle) => classifiedAdTitle.Value;

        private static void CheckValidity(string value)
        {
            if (value.Length > 100)
                throw new ArgumentException("Title cannot be longer than 100 characters", nameof(value));
        }
    }
}

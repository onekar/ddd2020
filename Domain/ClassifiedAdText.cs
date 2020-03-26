using Marketplace.Framework;

namespace Marketplace.Domain
{
    public class ClassifiedAdText : Value<ClassifiedAdText>
    {
        public string Value { get; }

        internal ClassifiedAdText(string text) => Value = text;
        
        public static ClassifiedAdText Create(string text) => new ClassifiedAdText(text);

        public static implicit operator string(ClassifiedAdText classifiedAdText) => classifiedAdText.Value;
    }
}

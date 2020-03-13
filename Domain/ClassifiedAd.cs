
using System;

namespace Marketplace.Domain
{
    public class ClassifiedAd
    {
        private UserId ownerId;
        private string title;
        private string text;
        private decimal price;

        public ClassifiedAdId Id { get; }

        public ClassifiedAd(ClassifiedAdId id, UserId ownerId)
        {
            Id = id;
            this.ownerId = ownerId;
        }

        public void SetTitle(string title) => this.title = title;

        public void UpdateText(string text) => this.text = text;

        public void UpdatePrice(decimal price) => this.price = price;
    }
}

using Marketplace.Domain;
using Marketplace.Framework;
using System;
using Xunit;

namespace Marketplace.Tests
{
    public class ClassifiedAd_Publish_specs
    {
        private readonly ClassifiedAd classifiedAd;

        public ClassifiedAd_Publish_specs()
        {
            classifiedAd = new ClassifiedAd(
                new ClassifiedAdId(Guid.NewGuid()),
                new UserId(Guid.NewGuid()));
        }

        [Fact]
        public void Can_publish_a_valid_ad()
        {
            classifiedAd.SetTitle(ClassifiedAdTitle.Create("Test ad"));
            classifiedAd.UpdateText(ClassifiedAdText.Create("Please buy my stuff"));
            classifiedAd.UpdatePrice(Price.Create(100.100m, "EUR", new FakeCurrencyLookup()));

            classifiedAd.RequestToPublish();

            Assert.Equal(ClassiefiedAdState.PendingReview, classifiedAd.State);
        }

        [Fact]
        public void Cannot_publish_without_title()
        {
            classifiedAd.UpdateText(ClassifiedAdText.Create("Please buy my stuff"));
            classifiedAd.UpdatePrice(Price.Create(100.100m, "EUR", new FakeCurrencyLookup()));

            Assert.Throws<InvalidEntityStateException>(() => classifiedAd.RequestToPublish()); 
        }

        [Fact]
        public void Cannot_publish_without_text()
        {
            classifiedAd.SetTitle(ClassifiedAdTitle.Create("Test ad"));
            classifiedAd.UpdatePrice(Price.Create(100.100m, "EUR", new FakeCurrencyLookup()));

            Assert.Throws<InvalidEntityStateException>(() => classifiedAd.RequestToPublish());
        }

        [Fact]
        public void Cannot_publish_without_price()
        {
            classifiedAd.SetTitle(ClassifiedAdTitle.Create("Test ad"));
            classifiedAd.UpdateText(ClassifiedAdText.Create("Please buy my stuff"));

            Assert.Throws<InvalidEntityStateException>(() => classifiedAd.RequestToPublish());
        }

        [Fact]
        public void Cannot_publish_with_zero_price()
        {
            classifiedAd.SetTitle(ClassifiedAdTitle.Create("Test ad"));
            classifiedAd.UpdateText(ClassifiedAdText.Create("Please buy my stuff"));
            classifiedAd.UpdatePrice(Price.Create(0.0m, "EUR", new FakeCurrencyLookup()));

            Assert.Throws<InvalidEntityStateException>(() => classifiedAd.RequestToPublish());
        }
    }
}

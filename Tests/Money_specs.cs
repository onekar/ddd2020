using Marketplace.Domain;
using Marketplace.Framework;
using System;
using Xunit;

namespace Marketplace.Tests
{
    public class Money_specs
    {
        private static readonly ICurrencyLookup currencyLookup = new FakeCurrencyLookup();

        [Fact]
        public void Two_of_same_amount_should_be_equal()
        {
            var firstAmount = Money.Create(5, "EUR", currencyLookup);
            var secondAmount = Money.Create(5, "EUR", currencyLookup);

            Assert.Equal(firstAmount, secondAmount);
        }

        [Fact]
        public void Two_of_same_amount_but_different_currencies_should_not_be_equal()
        {
            var firstAmount = Money.Create(5, "EUR", currencyLookup);
            var secondAmount = Money.Create(5, "USD", currencyLookup);

            Assert.NotEqual(firstAmount, secondAmount);
        }

        [Fact]
        public void Creating_money_amount_from_string_and_from_decimal_should_be_equal()
        {
            var firstAmount = Money.Create(5, "EUR", currencyLookup);
            var secondAmount = Money.Create("5,0", "EUR", currencyLookup);

            Assert.Equal(firstAmount, secondAmount);
        }

        [Fact]
        public void Sum_of_money_gives_full_amount()
        {
            var coin1 = Money.Create(1, "EUR", currencyLookup);
            var coin2 = Money.Create(2, "EUR", currencyLookup);
            var coin3 = Money.Create(2, "EUR", currencyLookup);

            var banknote = Money.Create(5, "EUR", currencyLookup);

            Assert.Equal(coin1 + coin2 + coin3, banknote);
        }

        [Fact]
        public void Subtracting_money_gives_proper_amount()
        {
            var coin1 = Money.Create(1, "EUR", currencyLookup);
            var coin2 = Money.Create(2, "EUR", currencyLookup);
            var coin3 = Money.Create(2, "EUR", currencyLookup);

            var banknote = Money.Create(5, "EUR", currencyLookup);

            Assert.Equal(banknote - coin2 - coin3, coin1);
        }

        [Fact]
        public void Unused_currency_should_not_be_allowed()
        {
            Assert.Throws<ArgumentException>(() => Money.Create(100, "DEM", currencyLookup));
        }

        [Fact]
        public void Unknown_currency_should_not_be_allowed()
        {
            Assert.Throws<ArgumentException>(() => Money.Create(100, "WHAT?", currencyLookup));
        }

        [Fact]
        public void Throw_when_too_many_decimal_places()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Money.Create(100.123m, "EUR", currencyLookup));
        }

        [Fact]
        public void Throws_on_summing_different_currencies()
        {
            var firstAmount = Money.Create(5, "EUR", currencyLookup);
            var secondAmount = Money.Create(5, "USD", currencyLookup);

            Assert.Throws<CurrencyMismatchException>(() => firstAmount + secondAmount);
        }

        [Fact]
        public void Throws_on_subtracting_different_currencies()
        {
            var firstAmount = Money.Create(5, "EUR", currencyLookup);
            var secondAmount = Money.Create(5, "USD", currencyLookup);

            Assert.Throws<CurrencyMismatchException>(() => firstAmount - secondAmount);
        }
    }
}

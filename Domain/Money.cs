using Marketplace.Framework;
using System;

namespace Marketplace.Domain
{
    public class Money : Value<Money>
    {
        private string DEFAULTCURRENCY = "EUR"; 
        public decimal Amount { get; }
        public CurrencyDetails Currency { get; }

        protected Money(decimal amount, string currencyCode, ICurrencyLookup currencyLookup)
        {
            var currency = currencyLookup.FindCurrency(currencyCode);
            if (!currency.InUse)
                throw new ArgumentException(
                    $"Currency {currencyCode} is not valid");

            if (decimal.Round(amount, currency.DecimalPlaces) != amount)
                throw new ArgumentOutOfRangeException(
                    nameof(amount), $"Amount in {currencyCode} cannot have more than {currency.DecimalPlaces} decimals");

            Amount = amount;
            Currency = currency;
        }

        private Money(decimal amount, CurrencyDetails currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Money Create(
            decimal amount, 
            string currency, 
            ICurrencyLookup currencyLookup)
            => new Money(amount, currency, currencyLookup);

        public static Money Create(
            string amount, 
            string currency, 
            ICurrencyLookup currencyLookup)
            => new Money(decimal.Parse(amount), currency, currencyLookup);

        public Money Add(Money summand)
        {
            if (Currency != summand.Currency)
                throw new CurrencyMismatchException("Cannot sum amounts with different currencies");

            return new Money(Amount + summand.Amount, Currency);
        }

        public Money Subtract(Money subtrahend)
        {
            if (Currency != subtrahend.Currency)
                throw new CurrencyMismatchException("Cannot subtract amounts with different currencies");

            return new Money(Amount - subtrahend.Amount, Currency);
        }

        public static Money operator +(Money summand1, Money summand2) => summand1.Add(summand2);

        public static Money operator -(Money minued, Money subtrahend) => minued.Subtract(subtrahend);
    }
}

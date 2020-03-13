using Marketplace.Framework;

namespace Marketplace.Domain
{
    public class CurrencyDetails : Value<CurrencyDetails>
    {
        public string CurrencyCode { get; set; }
        public bool InUse { get; set; }
        public int DecimalPlaces { get; set; }

        public static CurrencyDetails None = 
            new CurrencyDetails
            {
                InUse = false
            };
    }
}

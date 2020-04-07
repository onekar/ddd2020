using System;

namespace Marketplace.Contracts
{
    public static class ClassiefiedAds
    {
        public static class V1
        {
            public class Create
            {
                public Guid Id { get; set; }
                public Guid OwnerId { get; set; }
            }
        }
    }
}

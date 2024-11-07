using System;
using Volo.Abp.Caching;

namespace ecommerce
{
    [CacheName("Costumers")]
    public class CostumerCacheItem
    {
        public Guid id {get; set;}
        public string Name { get; set; }

        public DateTime BirthDate{ get; set; }

        public string Document { get; set; }
    }
}

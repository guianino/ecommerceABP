using Volo.Abp.Caching;

namespace ecommerce
{
    [CacheName("Costumers")]
    public class CostumerCacheItem
    {
        public string Name { get; set; }

        public float Document { get; set; }
    }
}

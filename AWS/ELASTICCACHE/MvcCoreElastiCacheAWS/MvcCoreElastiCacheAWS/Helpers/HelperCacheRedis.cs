using StackExchange.Redis;

namespace MvcCoreElastiCacheAWS.Helpers
{
    public class HelperCacheRedis
    {
        private static readonly Lazy<ConnectionMultiplexer> CreateConnection = new(() =>
        {
            return ConnectionMultiplexer.Connect("cache-coches.kxsby6.ng.0001.use1.cache.amazonaws.com:6379");
        });
        public static ConnectionMultiplexer Connection { get { return CreateConnection.Value; } }
    }
}

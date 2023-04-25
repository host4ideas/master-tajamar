using StackExchange.Redis;

namespace ConsolaCacheRedis
{
    public static class HelperCacheMultiplexer
    {
        private static readonly Lazy<ConnectionMultiplexer> CreateConnection = new(() =>
        {
            string cnn = "bbddproductosredisfmb.redis.cache.windows.net:6380,password=4ZBuWGvP7HVCnNMO0nDki15a9fUasqQ10AzCaBdj70w=,ssl=True,abortConnect=False";
            return ConnectionMultiplexer.Connect(cnn);
        });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return CreateConnection.Value;
            }
        }
    }
}

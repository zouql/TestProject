namespace ConsoleApp_Redis
{
    using System;
    using CSRedis;

    /// <summary>
    /// CSRedisCore
    /// </summary>
    public class CSRedisCoreRedisHelper
    {
        static CSRedisCoreRedisHelper()
        {
            var client = new CSRedisClient("127.0.0.1:6379,password=,defaultDatabase=0,poolsize=50,ssl=false,writeBuffer=10240,prefix=");

            // Init RedisHelper
            RedisHelper.Initialization(client);
        }

        public static void Test1(bool flush = true)
        {
            var client = new CSRedisClient("127.0.0.1:6379,password=,defaultDatabase=0,poolsize=50,ssl=false,writeBuffer=10240,prefix=");

            if (flush)
            {
                client.Del("Test1");
            }

            client.SAdd("Test11", Guid.NewGuid());

            client.SAdd("Test12", Guid.NewGuid());

            client.SAdd("Test13", Guid.NewGuid());

            client.SAdd("Test14", Guid.Empty);

            client.SRem("Test15", Guid.Empty);

            client.SAdd("test16", new[] { Guid.NewGuid() });

            var value = client.SMembers<Guid>("test16");

            client.Dispose();
        }

        public static void Test2(bool flush = true)
        {
            if (flush)
            {
                RedisHelper.Del("Test2");
            }

            RedisHelper.SAdd("Test2", Guid.NewGuid());

            RedisHelper.SAdd("Test2", Guid.NewGuid());

            RedisHelper.SAdd("Test2", Guid.NewGuid());

            RedisHelper.SAdd("Test2", Guid.Empty);

            RedisHelper.SAdd("Test2", Guid.Empty);

            RedisHelper.SRem("Test2", Guid.Empty);
        }
    }
}

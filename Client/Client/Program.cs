using System;
using StackExchange.Redis;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("docker");
            IDatabase db = redis.GetDatabase();

            string value = "hello";
            db.StringSet("world", value, TimeSpan.FromHours(2));

            string valueFromRedis = db.StringGet("world");
            Console.WriteLine(valueFromRedis);

            db.KeyDelete("world");
            string valueFromRedis2 = db.StringGet("world");
            Console.WriteLine(valueFromRedis2);
            Console.ReadKey();
        }
    }
}

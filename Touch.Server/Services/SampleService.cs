using MagicOnion;
using MagicOnion.Server;
using Touch.Shared.Services;
using System;

namespace Touch.Server.Services
{
    public class SampleService : ServiceBase<ISampleService>, ISampleService
    {

        public async UnaryResult<int> SumAsync(int x, int y)
        {
            Console.WriteLine($"Received:{x}, {y}");
            return x + y;
        }

        public async UnaryResult<int> ProductAsync(int x, int y)
        {
            return x * y;
        }
    }
}

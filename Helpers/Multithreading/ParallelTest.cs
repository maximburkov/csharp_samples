using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Helpers.Multithreading
{
    public static class ParallelTest
    {
        public static void Test()
        {
            var count = 10000000;
            int[] nums = Enumerable.Range(0, count).ToArray();
            long total = 0;
            var sw = new Stopwatch();
            sw.Start();

            Parallel.For<long>(0, nums.Length, () => 0, (j, loop, subtotal) =>
                {
                    subtotal += nums[j];
                    return subtotal;
                },
                (x) => Interlocked.Add(ref total, x)
            );

            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine(total);
            total = 0;
            sw.Start();

            for (int i = 0; i < count; i++)
            {
                total += nums[i];
            }

            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine(total);
        }
    }
}

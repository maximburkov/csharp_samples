using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Helpers.AsyncAwait
{
    class AwaiterTest
    {
        public static void Test()
        {
            var t = Task.Run(() =>
            {
                Console.WriteLine("task started");
                Thread.Sleep(1000);
                Console.WriteLine("task ended");
            });

            var awaiter = t.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                Console.WriteLine("Awaiter on completed");
            });
            Console.WriteLine(awaiter.IsCompleted);

            //awaiter.UnsafeOnCompleted(() =>
            //{
            //    Console.WriteLine("Awaiter unsafe on completed");
            //});

            Console.WriteLine("method end");

            Thread.Sleep(2000);
            Console.WriteLine(awaiter.IsCompleted);
        }
    }
}

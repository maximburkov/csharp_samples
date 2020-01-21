using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Helpers.Multithreading
{
    public static class WaitHandleTest
    {
        public static void Test()
        {
            var auto = new AutoResetEvent(false);
            var manual  = new ManualResetEvent(false);

            var t1 = new Thread(() =>
            {
                Console.WriteLine("1 thread started");
                Thread.Sleep(1000);
                auto.Set();
                Console.WriteLine("1 thread ended");
            });

            var t2 = new Thread(() =>
            {
                Console.WriteLine("2 thread started");
                Thread.Sleep(3000);
                manual.Set();
                Console.WriteLine("2 thread ended");
            });

            t1.Start();
            t2.Start();

            WaitHandle.WaitAll(new WaitHandle[] { auto, manual });
            Console.WriteLine("all ended");
            //WaitHandle.WaitAny(new WaitHandle[] { auto, manual });
            //Console.WriteLine("one ended");

            t1.Join();
            t2.Join();
        }
    }
}

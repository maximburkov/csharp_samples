using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Helpers
{
    public static class ResetEventTest
    {
        private static ManualResetEvent reset = new ManualResetEvent(true);

        private static AutoResetEvent autoReset = new AutoResetEvent(false);

        public static void TestManualResetEvent()
        {
            var t1 = new Thread(() =>
            {
                Console.WriteLine("1 thread started");
                reset.Reset();// or new ManualResetEvent(false)
                Thread.Sleep(5000);
                reset.Set();
                Console.WriteLine("1 thread ended");
            });

            var t2 = new Thread(() =>
            {
                Console.WriteLine("2 thread started");
                Thread.Sleep(1000);
                reset.WaitOne();
                Console.WriteLine("2 thread ended");
            });

            var t3 = new Thread(() =>
            {
                Console.WriteLine("3 thread started");
                Thread.Sleep(1000);
                reset.WaitOne(2000); //won't wait till the end
                Console.WriteLine("3 thread ended");
            });

            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();
        }

        public static void TestAutoResetEvent()
        {
            var t1 = new Thread(() =>
            {
                Console.WriteLine("1 thread started");
                Thread.Sleep(5000);
                autoReset.Set();
                Console.WriteLine("1 thread ended");
                Thread.Sleep(2000);
                autoReset.Set();
            });


            var t2 = new Thread(() =>
            {
                Console.WriteLine("2 thread started");
                Thread.Sleep(1000);
                autoReset.WaitOne();
                Console.WriteLine("2 thread ended");

            });

            var t3 = new Thread(() =>
            {
                Console.WriteLine("3 thread started");
                Thread.Sleep(1000);
                autoReset.WaitOne(); 
                Console.WriteLine("3 thread ended");
            });

            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();
        }
    }
}

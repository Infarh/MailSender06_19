using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.ConsoleTest
{
    internal static class ThreadPoolTest
    {
        public static void Start()
        {
            //ThreadPool.SetMinThreads(2, 2);
            //ThreadPool.SetMaxThreads(16, 16);
            var cpu_count = Environment.ProcessorCount;
            ThreadPool.SetMaxThreads(cpu_count, cpu_count);
            for (var i = 0; i < 50; i++)
                //ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadPoolMethod));
                ThreadPool.QueueUserWorkItem(ThreadPoolMethod, "Hello World!");
        }

        private static void ThreadPoolMethod(object parameter)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"Задание {parameter} в пуле потоков Thread id {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}

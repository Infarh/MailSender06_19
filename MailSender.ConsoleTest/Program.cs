using System;
using System.Diagnostics;
using System.Threading;

namespace MailSender.ConsoleTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //ThreadTest.Start();

            //ThreadSynchronizationTest.Start();

            //ThreadPoolTest.Start();

            #region Загадка!
            var threads = new Thread[10];

            for (var i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() => Console.WriteLine($"Сообщение №{i}"));

                //var i0 = i;
                //threads[i] = new Thread(() => Console.WriteLine($"Сообщение №{i0}"));
            }

            for (var i = 0; i < threads.Length; i++)
                threads[i].Start(); 
            #endregion

            Console.ReadLine();
        }
    }
}

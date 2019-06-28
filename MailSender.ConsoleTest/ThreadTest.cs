using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.ConsoleTest
{
    internal static class ThreadTest
    {
        public static void Start()
        {
            Thread.CurrentThread.Name = "Main thread";
            //Thread.CurrentThread.ManagedThreadId

            //var thread1 = new Thread(new ThreadStart(FirstThreadMethod));
            var thread1 = new Thread(FirstThreadMethod);
            //var thread2 = new Thread(new ParameterizedThreadStart(FirstParametricThreadMethod));
            var thread2 = new Thread(FirstParametricThreadMethod);

            thread1.Start();
            thread2.Start("Hello World!");

            var clock_thread = new Thread(UpdateClockMethod);
            clock_thread.Name = "Поток обновления часов";
            clock_thread.Priority = ThreadPriority.Lowest;
            //System.Diagnostics.Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            clock_thread.IsBackground = true;

            clock_thread.Start();

            var msg = "Hello World!";
            var count = 100;
            var timeout = 100;
            var printer_thread1 = new Thread(() => PrintMethod(msg, count, timeout));
            //printer_thread1.Start();

            var printer_task = new ThreadPrinterTask
            {
                Message = "qwe",
                Count = 100,
                TimeOut = 10
            };

            var priter_thread2 = new Thread(printer_task.PrintMethod);
            priter_thread2.Start();

            Console.WriteLine($"Главный поток программы id {Thread.CurrentThread.ManagedThreadId}");
            Console.ReadLine();

            Console.WriteLine("Остановка потока часов");
            __IsClockUpdating = false;

            if (!clock_thread.Join(1))
            {
                clock_thread.Interrupt();
                //clock_thread.Abort();
            }
        }

        private static void FirstThreadMethod()
        {
            Console.WriteLine($"Выполнение в потоке id {Thread.CurrentThread.ManagedThreadId}");
        }

        private static void FirstParametricThreadMethod(object parameter)
        {
            Console.WriteLine($"Выполнение в потоке id {Thread.CurrentThread.ManagedThreadId} с параметром {parameter}");
        }

        private static bool __IsClockUpdating = true;
        private static void UpdateClockMethod()
        {
            try
            {
                while (__IsClockUpdating)
                {
                    Thread.Sleep(1000);
                    Console.Title = DateTime.Now.ToString("HH:mm:ss:ff");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.Write("Часы завершили свою работу");
        }

        private static void PrintMethod(string Message, int Count, int Timeout)
        {
            for (var i = 0; i < Count; i++)
            {
                Console.WriteLine($"Сообщение из потока id {Thread.CurrentThread.ManagedThreadId} - {Message} :: {i}");
                Thread.Sleep(Timeout);
            }
        }
    }
}

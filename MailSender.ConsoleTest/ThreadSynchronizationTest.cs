using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.ConsoleTest
{
    internal static class ThreadSynchronizationTest
    {
        public static void Start()
        {
            for (var i = 0; i < 5; i++)
                new Thread(PrintNumbers).Start();

            //Semaphore semaphore = new Semaphore(0, 5);
            //semaphore.WaitOne();
            //semaphore.Release();

            //Mutex mutex = new Mutex(true, "MutexName");
            //mutex.WaitOne();
            //mutex.ReleaseMutex();

            //ManualResetEvent manual_reset_event = new ManualResetEvent(false);
            //AutoResetEvent auto_reset_event = new AutoResetEvent(false);
            //auto_reset_event.Set();
            //auto_reset_event.WaitOne();
        }

        private static readonly object __SyncRoot = new object();
        private static void PrintNumbers()
        {
            lock (__SyncRoot)
            {
                Console.Write($"Thread id:{Thread.CurrentThread.ManagedThreadId} - ");
                for (var i = 0; i < 10; i++)
                {
                    Console.Write($"{i}, ");
                    Thread.Sleep(10);
                }
                Console.WriteLine("10");
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void SequentalMethod()
        {
            // Некоторое содержимое
        }

        private static void PrintNumbers2()
        {
            Monitor.Enter(__SyncRoot);
            try
            {
                Console.Write($"Thread id:{Thread.CurrentThread.ManagedThreadId} - ");
                for (var i = 0; i < 10; i++)
                {
                    Console.Write($"{i}, ");
                    Thread.Sleep(10);
                }
                Console.WriteLine("10");
            }
            finally
            {
                Monitor.Exit(__SyncRoot);
            }
        }
    }

    [Synchronization]
    internal class FileLogger : ContextBoundObject
    {
        private readonly string _FileName;

        public FileLogger(string FileName) => _FileName = FileName;

        //[MethodImpl(MethodImplOptions.Synchronized)]
        public void Log(string msg)
        {
            //lock (this)
                System.IO.File.AppendAllText(_FileName, msg);
        }
    }
}

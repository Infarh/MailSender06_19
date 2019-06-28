using System;
using System.Threading;

namespace MailSender.ConsoleTest
{
    internal class ThreadPrinterTask
    {
        public string Message { get; set; }
        public int TimeOut { get; set; }
        public int Count { get; set; }

        public void PrintMethod()
        {
            var count = Count;
            var msg = Message;
            var timeout = TimeOut;

            for (var i = 0; i < count; i++)
            {
                Console.WriteLine($"Сообщение из потока id {Thread.CurrentThread.ManagedThreadId} - {msg} :: {i}");
                Thread.Sleep(timeout);
            }
        }
    }
}
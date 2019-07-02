using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.ConsoleTest
{
    static class TPLTest
    {
        public static void Start()
        {
            //ParallelTest();
            PLINQTest();
        }

        private static void ParallelTest()
        {
            //Parallel.Invoke(
            //    TestMethod1,
            //    TestMethod2,
            //    TestMethod3,
            //    () => Console.WriteLine("Дополнительное параллельное действие"));

            //Console.WriteLine();

            //Parallel.Invoke(
            //    TestMethod1,
            //    TestMethod2,
            //    TestMethod3,
            //    () => Console.WriteLine("Дополнительное параллельное действие"));

            //Parallel.For(1, 51/*, new ParallelOptions { MaxDegreeOfParallelism = 3 }*/, i =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine($"Message {i}");
            //});


            //for (var i = 1; i < 51; i++)
            //{
            //    if (i > 10) break;

            //}

            //Parallel.For(1, 51, new ParallelOptions { MaxDegreeOfParallelism = 8 }, (i, state) =>
            //{
            //    if(i > 10) state.Break();
            //    Thread.Sleep(1000);
            //    Console.WriteLine($"Message {i}");
            //});

            var messages = Enumerable.Range(1, 50).Select(i => $"Message {i}");

            //Parallel.ForEach(messages, msg =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine($"Сообщение: {msg}");
            //});

            // var loop_result = Parallel.ForEach(messages, new ParallelOptions { MaxDegreeOfParallelism = 5 }, (msg, state) =>
            //{
            //    if(msg.EndsWith("15")) state.Break();
            //    Thread.Sleep(1000);
            //    Console.WriteLine($"Сообщение: {msg}");
            //});

            // Console.WriteLine($"Было выполнено {loop_result.LowestBreakIteration} итераций");  
        }

        private static void TestMethod1() =>
            Console.WriteLine($"Метод 1 поток {Thread.CurrentThread.ManagedThreadId} задача {Task.CurrentId}");

        private static void TestMethod2() =>
            Console.WriteLine($"Метод 2 поток {Thread.CurrentThread.ManagedThreadId} задача {Task.CurrentId}");

        private static void TestMethod3() =>
            Console.WriteLine($"Метод 3 поток {Thread.CurrentThread.ManagedThreadId} задача {Task.CurrentId}");

        private static void PLINQTest()
        {
            //System.Linq.ParallelEnumerable

            IEnumerable<string> messages = Enumerable.Range(1, 50).Select(i => $"Message {i}");

            //ParallelQuery<string> parallel_messages = messages.AsParallel();

            var start = DateTime.Now;
            var messages_length = messages
               .AsParallel()
               .Select(msg =>
                {
                    Thread.Sleep(100);
                    Console.WriteLine($"Долгий расчёт длины сообщения {msg} завершён = {msg.Length}");
                    return msg.Length;
                })
               .AsSequential()
               .Sum();
            Console.WriteLine("Полная длина всех сообщений = {0} за {1}", messages_length, DateTime.Now -start);
        }
    }
}

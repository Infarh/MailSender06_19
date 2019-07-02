using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.ConsoleTest
{
    static class AsyncAwaitTest
    {
        public static async void Start()
        {
            //var data = "Hello World!";

            //var compute_task = Task.Run(() => LongDataFunction(data));

            //Console.WriteLine("Во время вычисления задачи я могу не терять времени, а сделать ещё что-ниудь");

            //var result = compute_task.Result; // Это неправильно!
            //var result = await compute_task;

            //Console.WriteLine($"Расчитанное значение {result}");
            //Console.WriteLine($"Расчитанное значение {await compute_task}");

            IEnumerable<string> messages = Enumerable.Range(1, 50).Select(i => $"Message {i}");

            var tasks_enum = messages.Select(msg => Task.Run(() => LongDataFunction(msg)));
            //Task.Factory.StartNew(() => {}, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Current);

            var task_array = tasks_enum.ToArray();

            //Task.WaitAll(task_array);
            //Task.WaitAny(task_array);

            var wait_all_task = Task.WhenAll(task_array);

            var result = await wait_all_task;

            //Task.WhenAny(task_array);

            Console.WriteLine("Все задачи завершены! total length = {0}", result.Sum());
        }

        private static int LongDataFunction(string Data)
        {
            Console.WriteLine("Вычисляю длина строки: {0}", Data);
            Thread.Sleep(100);
            Console.WriteLine("Lлина строки {0} = {1}", Data, Data.Length);
            return Data.Length;
        }
    }
}

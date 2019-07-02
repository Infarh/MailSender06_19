using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.ConsoleTest
{
    static class TaskTest
    {
        public static void Start()
        {
            //Task

            //var task = new Task(new Action(TaskTestMethod));
            var task = new Task(() => TaskTestMethod());

            task.Start();

            var task2 = Task.Run(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("Параллельная задача 2 завершилась.");
            });

            var task3 = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("Параллельная задача 3 завершилась.");
            });


            var data = (string)null;

            //var string_length_task = Task.Run(() => GetStringLength(data));
            //var string_length_task = Task.Run(() => GetStringLength("Hello World!"));
            //var string_length_task2 = ((Task) string_length_task).ContinueWith(t =>
            //{
            //    Console.WriteLine($"Задача расчёта длины строки завершилась... \"{data}\"");
            //    Thread.Sleep(100);
            //    Console.WriteLine($"Длина строки \"{data}\" - {t.Result}");
            //}, TaskContinuationOptions.OnlyOnRanToCompletion);
            //string_length_task2.ContinueWith(t => Console.WriteLine("Вывод на консоль завершился"));

            //((Task) string_length_task).ContinueWith(
            //    t => Console.WriteLine("Задача завершилась с ошибкой {0}", t.Exception.InnerExceptions.FirstOrDefault()),
            //    TaskContinuationOptions.OnlyOnFaulted);

            for (var i = 0; i < 10; i++)
            {
                Thread.Sleep(10);
                Console.WriteLine("Какие-то бессмысленные действия в основном потоке...");
            }

            var faulted_task = Task.Run(() => GetStringLength(null));

            try
            {
                faulted_task.Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //var string_length = string_length_task.Result;

            //Console.WriteLine($"Длина строки \"{data}\" - {string_length}");

            task2.Wait();
        }

        private static void TaskTestMethod()
        {
            Console.WriteLine("Запуск параллельной задачи");

            Thread.Sleep(1500);
            Console.WriteLine("Параллельная задача завершилась.");
        }

        private static int GetStringLength(string str)
        {
            if (str is null) throw new ArgumentNullException(nameof(str));

            Thread.Sleep(3000);
            return str.Length;
        }
    }
}

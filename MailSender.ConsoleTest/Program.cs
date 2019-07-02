using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.ConsoleTest
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            //TaskTest.Start();
            //TPLTest.Start();
            //AsyncAwaitTest.Start();

            //await Task.Run(() => Console.WriteLine("Параллельное действие в Main"));

            Func<string, int> function = LongDataFunction;

            var data = "Hello World";

            //var result = function(data);
            //result = function.Invoke(data);

            //var async_result = function.BeginInvoke(data, r =>
            //{
            //    var func_result = function.EndInvoke(r);
            //    Console.WriteLine("Результат выполнения {0}", func_result);
            //}, null);

            var delegate_task = Task.Factory.FromAsync(
                function.BeginInvoke,
                function.EndInvoke,
                data, null);

            var f_result = await delegate_task;

            Console.WriteLine("Основной поток завершился");
            Console.ReadLine();
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

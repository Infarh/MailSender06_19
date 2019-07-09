using System;
using System.Collections.Generic; // Основные коллекции
using System.Collections.Concurrent; // Коллекции с контролем многопоточности
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.ConsoleTest
{
    static class Questions
    {
        public static void Test()
        {
            GC.Collect();

            var binary = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            var xml = new System.Xml.Serialization.XmlSerializer(typeof(List<string>));
            var json = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(List<string>));

            Func<string, double> f = delegate(string str) { return str.Length; };

            int x = 42;
            int y = x;
            x = 32;
            object X = x;   // Упаковка
            int? X1 = x;
            Nullable<int> X2 = x;
            var Y = X;
            X = 65;
            x = (int)X; // Распаковка

            //System.Collections.Concurrent.BlockingCollection<>
            //System.Collections.Concurrent.ConcurrentBag<> // Аналог списка
            //System.Collections.Concurrent.ConcurrentDictionary<>

            //System.Collections.Immutable.ImmutableDictionary<string, int>.
        }
    }
}

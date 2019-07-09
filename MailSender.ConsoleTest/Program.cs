using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
//using System.Reflection.Emit;

namespace MailSender.ConsoleTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //System.Reflection.Emit.AssemblyBuilder

            //Assembly
            //Type
            //ConstructorInfo
            //MethodInfo //ParameterInfo
            //PropertyInfo
            //FieldInfo
            //EventInfo

            const string test_lib_file_name = "TestLib.dll";
            var test_lib_assembly = Assembly.LoadFrom(test_lib_file_name);
            //Assembly.Load()

            foreach (Type defined_type in test_lib_assembly.DefinedTypes)
            {
                var attributes = defined_type.GetCustomAttributes();
                foreach (var description in attributes.OfType<DescriptionAttribute>())
                {
                    Console.WriteLine("[{0}]", description.Description);
                }

                Console.WriteLine(defined_type.FullName);
            }

            Console.WriteLine();

            var printer_type = test_lib_assembly.GetType("TestLib.Printer");

            Console.WriteLine("Тип данных {0}", printer_type.FullName);

            foreach (var method_info in printer_type.GetMethods())
            {
                Console.WriteLine("{0} {1}({2})", 
                    method_info.ReturnType.FullName,
                    method_info.Name,
                    string.Join(", ", method_info.GetParameters()
                       .Select(parameter => $"{parameter.ParameterType.FullName} {parameter.Name}")));
            }

            var constructor_info = printer_type.GetConstructor(new Type[0]);

            object printer = constructor_info.Invoke(new object[0]);

            var print_method_info = printer_type.GetMethod("Print");

            print_method_info.Invoke(printer, new object[] {"Hello Wold!"});

            var constructor2_info = printer_type.GetConstructor(new Type[] { typeof(string) });

            object printer2 = constructor2_info.Invoke(new object[] { "123---" });

            var field_info = printer_type.GetField("_Prefix", BindingFlags.NonPublic | BindingFlags.Instance);

            var field_value = (string)field_info.GetValue(printer2);

            field_info.SetValue(printer2, "=======");

            print_method_info.Invoke(printer2, new object[] { "Hello Wold!" });

            Console.WriteLine();
            dynamic dynamic_printer = printer2;
            dynamic_printer.Print("123");

            var int_result = Sum(5, 7);
            var str_result = Sum("Hello ", "World!");
            //var bool_result = Sum(true, false);

            ProcessData(new object[] { "HEllo World!", 42, 3.14159265358979, true, false });

            Console.ReadLine();
        }

        public static dynamic Sum(dynamic x, dynamic y) => x + y;

        public static void ProcessData(object[] DataObjects)
        {
            //foreach (var value in DataObjects)
            //    switch (value)
            //    {
            //        case string v: Process(v); break;
            //        case int v: Process(v); break;
            //        case double v: Process(v); break;
            //        case bool v: Process(v); break;
            //    }

            foreach (var value in DataObjects)
            {
                dynamic v = value;
                Process(v);
            }
        }

        private static void Process(string value) => Console.WriteLine("str:{0}", value);
        private static void Process(int value) => Console.WriteLine("int:{0}", value);
        private static void Process(double value) => Console.WriteLine("double:{0:f3}", value);
        private static void Process(bool value) => Console.WriteLine("bool:{0}", value);
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLib
{
    [Description("Публичый класс")]
    public class Printer
    {
        protected string _Prefix = "Data:";

        public Printer() { }

        public Printer(string Prefix) => _Prefix = Prefix;

        public virtual void Print(string str) => Console.WriteLine("{0} {1}{2}",
            DateTime.Now, _Prefix, str);
    }

    [Description("Скрытый класс")]
    internal class InternalPrinter : Printer
    {
        private InternalPrinter() : base("Internal:") { }

        public InternalPrinter(string Str) : base(Str) { }

        public override void Print(string str) => Console.WriteLine("{0}{1}", _Prefix, str);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MailSender.lib.MVVM;

namespace MailSender.Commands
{
    class ApplicationCloseCommand : LamdaCommand
    {
        public ApplicationCloseCommand() : base(p => Application.Current.Shutdown()) { }
    }
}

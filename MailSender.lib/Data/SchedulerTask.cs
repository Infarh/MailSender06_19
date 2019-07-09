using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Data.BaseEntityes;

namespace MailSender.lib.Data
{
    public class SchedulerTask : Entity
    {
        public DateTime Time { get; set; }

        public virtual MailMessage Message { get; set; }

        public virtual Sender Sender { get; set; }

        public virtual RecipientsList Recipients { get; set; }

        public virtual Server Server { get; set; }
    }
}

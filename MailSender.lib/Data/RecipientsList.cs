using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Data.BaseEntityes;

namespace MailSender.lib.Data
{
    public  class RecipientsList : NamedEntity
    {
        public virtual ICollection<Recipient> Recipients { get; set; }
    }
}

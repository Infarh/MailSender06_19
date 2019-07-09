using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MailSender.lib.Data.BaseEntityes;

namespace MailSender.lib.Data
{
    /// <summary>Получатель почты</summary>
    public class Recipient : Human
    {
        //public int? RecipientsListId { get; set; } // int? - это значит, что получатель почты может не входить ни в один список

        //[ForeignKey(nameof(RecipientsListId))]
        //public virtual RecipientsList List { get; set; }

        public virtual ICollection<RecipientsList> Lists { get; set; }
    }
}
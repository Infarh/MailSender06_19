namespace MailSender.lib.Data.BaseEntityes
{
    /// <summary>Персоналия</summary>
    public abstract class Human : NamedEntity
    {
        /// <summary>Адрес электронной почты</summary>
        public string Address { get; set; }

        public string Description { get; set; }
    }
}
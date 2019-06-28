namespace MailSender.lib.Data.BaseEntityes
{
    /// <summary>Именованная сущность</summary>
    public abstract class NamedEntity : Entity
    {
        /// <summary>Имя</summary>
        public string Name { get; set; }
    }
}
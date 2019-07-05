namespace MailSender.ConsoleTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateArtist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artists", "Surname", c => c.String());
            AddColumn("dbo.Artists", "Patronimyc", c => c.String());
            AddColumn("dbo.Artists", "BirthDay", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artists", "BirthDay");
            DropColumn("dbo.Artists", "Patronimyc");
            DropColumn("dbo.Artists", "Surname");
        }
    }
}

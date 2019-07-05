namespace MailSender.ConsoleTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateArtist2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Artists", "Surname", "SecondName");
            AlterColumn("dbo.Artists", "SecondName", c => c.String(maxLength: 80));
            AlterColumn("dbo.Artists", "Patronimyc", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Artists", "SecondName", "Surname");
            AlterColumn("dbo.Artists", "Surname", c => c.String());
            AlterColumn("dbo.Artists", "Patronimyc", c => c.String());
        }
    }
}

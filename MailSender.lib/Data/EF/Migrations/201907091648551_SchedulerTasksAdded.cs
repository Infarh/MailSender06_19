namespace MailSender.lib.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchedulerTasksAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecipientsLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SchedulerTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        Message_Id = c.Int(),
                        Recipients_Id = c.Int(),
                        Sender_Id = c.Int(),
                        Server_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MailMessages", t => t.Message_Id)
                .ForeignKey("dbo.RecipientsLists", t => t.Recipients_Id)
                .ForeignKey("dbo.Senders", t => t.Sender_Id)
                .ForeignKey("dbo.Servers", t => t.Server_Id)
                .Index(t => t.Message_Id)
                .Index(t => t.Recipients_Id)
                .Index(t => t.Sender_Id)
                .Index(t => t.Server_Id);
            
            CreateTable(
                "dbo.RecipientsListRecipients",
                c => new
                    {
                        RecipientsList_Id = c.Int(nullable: false),
                        Recipient_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RecipientsList_Id, t.Recipient_Id })
                .ForeignKey("dbo.RecipientsLists", t => t.RecipientsList_Id, cascadeDelete: true)
                .ForeignKey("dbo.Recipients", t => t.Recipient_Id, cascadeDelete: true)
                .Index(t => t.RecipientsList_Id)
                .Index(t => t.Recipient_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SchedulerTasks", "Server_Id", "dbo.Servers");
            DropForeignKey("dbo.SchedulerTasks", "Sender_Id", "dbo.Senders");
            DropForeignKey("dbo.SchedulerTasks", "Recipients_Id", "dbo.RecipientsLists");
            DropForeignKey("dbo.SchedulerTasks", "Message_Id", "dbo.MailMessages");
            DropForeignKey("dbo.RecipientsListRecipients", "Recipient_Id", "dbo.Recipients");
            DropForeignKey("dbo.RecipientsListRecipients", "RecipientsList_Id", "dbo.RecipientsLists");
            DropIndex("dbo.RecipientsListRecipients", new[] { "Recipient_Id" });
            DropIndex("dbo.RecipientsListRecipients", new[] { "RecipientsList_Id" });
            DropIndex("dbo.SchedulerTasks", new[] { "Server_Id" });
            DropIndex("dbo.SchedulerTasks", new[] { "Sender_Id" });
            DropIndex("dbo.SchedulerTasks", new[] { "Recipients_Id" });
            DropIndex("dbo.SchedulerTasks", new[] { "Message_Id" });
            DropTable("dbo.RecipientsListRecipients");
            DropTable("dbo.SchedulerTasks");
            DropTable("dbo.RecipientsLists");
        }
    }
}

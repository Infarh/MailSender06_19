using System.Data.Entity.Migrations;

namespace MailSender.lib.Data.EF.Migrations //-MigrationsDirectory Data\EF\Migrations
{
    //Enable-Migrations -StartUpProjectName MailSender -EnableAutomaticMigrations -MigrationsDirectory Data\EF\Migrations
    //Add-Migration Initial -StartUpProjectName MailSender -Verbose
    //Update-Database -StartUpProjectName MailSender -Verbose
    internal sealed class Configuration : DbMigrationsConfiguration<MailSenderDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;           // -EnableAutomaticMigrations
            MigrationsDirectory = @"Data\EF\Migrations";
        }

        protected override void Seed(MailSender.lib.Data.EF.MailSenderDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}

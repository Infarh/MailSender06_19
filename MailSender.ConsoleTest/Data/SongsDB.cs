using System;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.ConsoleTest.Migrations;

namespace MailSender.ConsoleTest.Data
{
    public class SongsDB : DbContext          
    {
        #region Установка инициализацтора БД

        static SongsDB()
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<SongsDB>()); // Отладочный инициализатор
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SongsDB>());
            //Database.SetInitializer(new CreateDatabaseIfNotExists<SongsDB>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SongsDB, Configuration>());
        }

        #endregion

        public SongsDB() : this("Name=SongsDB") { }

        public SongsDB(string ConnectionString) : base(ConnectionString) // Либо имя строки подключения из app.config, либо саму строку подключения
        {

        }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Artist> Artists { get; set; }
    }

    //[Table("Artist")]
}

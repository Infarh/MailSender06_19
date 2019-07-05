using System.Linq;
using MailSender.ConsoleTest.Data;

namespace MailSender.ConsoleTest.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SongsDB>
    {
        public Configuration() => AutomaticMigrationsEnabled = true;

        protected override void Seed(SongsDB db)
        {
            if (!db.Songs.Any())
            {
                var songs = new Song[100];
                for (var i = 0; i < songs.Length; i++)
                    songs[i] = new Song
                    {
                        Name = $"Песня {i + 1}",
                        Artist = new Artist { Name = $"Исполнитель {i}" }
                    };
                db.Songs.AddRange(songs);

                db.SaveChanges();
            }
        }
    }
}

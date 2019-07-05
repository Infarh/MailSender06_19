using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MailSender.ConsoleTest.Data;

namespace MailSender.ConsoleTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var db = new Data.SongsDB())
            {
                Console.WriteLine("Songs count - {0}", db.Songs.Count());
            }

            using (var db = new SongsDB())
            {
               
            }

            //using (var db = new Data.SongsDB())
            //{
            //    foreach (var song in db.Songs.ToArray())
            //    {
            //        Console.WriteLine("Song {0} - artist {1}", song.Name, song.Artist.Name);
            //    }
            //}

            using (var db = new SongsDB())
            {
                db.Database.Log = str => Console.WriteLine(str); // Указыаем контексту БД куда писать лог

                var song = db.Songs.FirstOrDefault(s => s.Artist.Name == "Исполнитель 9");
                if (song != null)
                    db.Songs.Remove(song);

                db.SaveChanges();
            }

            Console.ReadLine();
        }
    }
}

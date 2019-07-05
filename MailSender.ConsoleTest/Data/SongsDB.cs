using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.ConsoleTest.Data
{
    public class SongsDB : DbContext
    {
        public SongsDB() : this("Name=SongsDB") { }

        public SongsDB(string ConnectionString) : base(ConnectionString) // Либо имя строки подключения из app.config, либо саму строку подключения
        {

        }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Artist> Artists { get; set; }
    }

    [Table("Songs")]
    public class Song
    {
        public int Id { get; set; }

        [Required, MaxLength(120)]
        public string Name { get; set; }

        public double Length { get; set; }

        public string Description { get; set; }

        public virtual Artist Artist { get; set; } //  virtual - используется не по прямому назначению!  virtual говорит EF, что свойство является "навигационным".
    }

    //[Table("Artist")]
    public class Artist
    {
        //[Key]
        public int Id { get; set; }

        [Required, MaxLength(120)]
        public string Name { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}

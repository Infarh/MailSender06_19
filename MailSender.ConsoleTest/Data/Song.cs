using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailSender.ConsoleTest.Data
{
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
}
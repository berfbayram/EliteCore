using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EliteCore.Models
{
    public class GelenMail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GelenMailKod { get; set; }

        [Column(TypeName = "VARCHAR(1000)")]
        public string? GelenMesaj { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string? KullaniciMail { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string? Ad { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string? Soyad { get; set; }

        public string? Telefon { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TpFinal.Models
{
    [Keyless]
    [Table("ArchivesComics", Schema = "Heros")]
    public partial class ArchivesComic
    {
        [Column("ArchivesComicsID")]
        public int ArchivesComicsId { get; set; }
        public int? ComicsId { get; set; }
        [StringLength(25)]
        public string? Nom { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateDelete { get; set; }
    }
}

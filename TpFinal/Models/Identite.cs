using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TpFinal.Models
{
    [Table("Identite", Schema = "Heros")]
    public partial class Identite
    {
        public Identite()
        {
            Heroes = new HashSet<Hero>();
        }

        [Key]
        public int IdentiteId { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateNaissance { get; set; }
        public int Age { get; set; }
        public byte[]? DateNaissanceChiffree { get; set; }

        [InverseProperty("Identite")]
        public virtual ICollection<Hero> Heroes { get; set; }
    }
}

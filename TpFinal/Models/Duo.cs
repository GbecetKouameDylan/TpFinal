using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TpFinal.Models
{
    [Table("Duo", Schema = "Divers")]
    public partial class Duo
    {
        [Key]
        public int EquipeId { get; set; }
        [StringLength(25)]
        public string Nom { get; set; } = null!;
        public int Hero1Id { get; set; }
        public int Hero2Id { get; set; }

        [ForeignKey("Hero1Id")]
        [InverseProperty("DuoHero1s")]
        public virtual Hero Hero1 { get; set; } = null!;
        [ForeignKey("Hero2Id")]
        [InverseProperty("DuoHero2s")]
        public virtual Hero Hero2 { get; set; } = null!;
    }
}

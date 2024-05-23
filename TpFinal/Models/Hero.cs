using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TpFinal.Models
{
    [Table("Hero", Schema = "Heros")]
    public partial class Hero
    {
        public Hero()
        {
            DuoHero1s = new HashSet<Duo>();
            DuoHero2s = new HashSet<Duo>();
        }

        [Key]
        public int HeroId { get; set; }
        [StringLength(25)]
        public string Nom { get; set; } = null!;
        public int PouvoirId { get; set; }
        public int IdentiteId { get; set; }

        [ForeignKey("IdentiteId")]
        [InverseProperty("Heroes")]
        public virtual Identite Identite { get; set; } = null!;
        [ForeignKey("PouvoirId")]
        [InverseProperty("Heroes")]
        public virtual Pouvoir Pouvoir { get; set; } = null!;
        [InverseProperty("Hero1")]
        public virtual ICollection<Duo> DuoHero1s { get; set; }
        [InverseProperty("Hero2")]
        public virtual ICollection<Duo> DuoHero2s { get; set; }
    }
}

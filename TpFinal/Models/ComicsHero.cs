using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TpFinal.Models
{
    [Keyless]
    [Table("ComicsHero", Schema = "Heros")]
    public partial class ComicsHero
    {
        public int ComicsId { get; set; }
        public int HeroId { get; set; }

        [ForeignKey("ComicsId")]
        public virtual Comic Comics { get; set; } = null!;
        [ForeignKey("HeroId")]
        public virtual Hero Hero { get; set; } = null!;
    }
}

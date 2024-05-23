using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TpFinal.Models
{
    [Keyless]
    public partial class VHeroDetail
    {
        public int HeroId { get; set; }
        [StringLength(25)]
        public string HeroName { get; set; } = null!;
        [StringLength(25)]
        public string PouvoirType { get; set; } = null!;
        [StringLength(100)]
        public string PouvoirDescription { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime DateNaissance { get; set; }
        public int Age { get; set; }
        [StringLength(25)]
        public string? DuoName { get; set; }
        [StringLength(25)]
        public string? ComicsName { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ComicsDate { get; set; }
    }
}

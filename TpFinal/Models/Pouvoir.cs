using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TpFinal.Models
{
    [Table("Pouvoir", Schema = "Heros")]
    public partial class Pouvoir
    {
        public Pouvoir()
        {
            Heroes = new HashSet<Hero>();
        }

        [Key]
        public int PouvoirId { get; set; }
        [StringLength(25)]
        public string Type { get; set; } = null!;
        [StringLength(100)]
        public string Description { get; set; } = null!;

        [InverseProperty("Pouvoir")]
        public virtual ICollection<Hero> Heroes { get; set; }
    }
}

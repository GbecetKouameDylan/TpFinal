using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TpFinal.Models
{
    [Table("Comics", Schema = "Divers")]
    public partial class Comic
    {
        [Key]
        public int ComicsId { get; set; }
        [StringLength(25)]
        public string Nom { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
    }
}

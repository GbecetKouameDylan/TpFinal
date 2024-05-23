using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TpFinal.Models
{
    [Table("Image", Schema = "Heros")]
    [Index("Identifiant", Name = "UC_Image_identifiant", IsUnique = true)]
    public partial class Image
    {
        [Key]
        [Column("ImageID")]
        public int ImageId { get; set; }
        [StringLength(100)]
        public string Nom { get; set; } = null!;
        public Guid Identifiant { get; set; }
        public byte[]? FichierImage { get; set; }
    }
}

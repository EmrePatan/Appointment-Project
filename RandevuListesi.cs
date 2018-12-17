using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RandevuSistemiGüncel.Models
{
    [Table("RandevuListesi")]
    public class RandevuListesi
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int DoktorID { get; set; }
        [Required]
        public int AyID { get; set; }
        [Required]
        public int GünID { get; set; }
        [Required]
        public int SaatID { get; set; }
        [Required]
        public int HastaID { get; set; }
    }
}
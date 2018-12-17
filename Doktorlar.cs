using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RandevuSistemiGüncel.Models
{
    [Table("Doktorlar")]
    public class Doktorlar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(20), Required]
        public string Ad { get; set; }
        [StringLength(20), Required]
        public string Soyad { get; set; }
        [StringLength(20), Required]
        public string Unvan { get; set; }
        [StringLength(20), Required]
        public string Branş { get; set; }
        public virtual List<Hastalar> Hastalar { get; set; }
    }
}
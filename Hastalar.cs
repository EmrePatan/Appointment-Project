using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RandevuSistemiGüncel.Models
{
    [Table("Hastalar")]
    public class Hastalar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(11), Required]
        public string TC { get; set; }
        [StringLength(20), Required]
        public string Ad { get; set; }
        [StringLength(20), Required]
        public string Soyad { get; set; }
        [StringLength(300)]
        public string Şikayeti { get; set; }
        [StringLength(300)]
        public string Tanısı { get; set; }
        [StringLength(300)]
        public string Tedavisi { get; set; }
        public virtual Doktorlar Doktorlar { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RandevuSistemiGüncel.Models
{
    [Table("Kullanıcılar")]
    public class Kullanıcılar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string KullanıcıAdı { get; set; }
        [Required]
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
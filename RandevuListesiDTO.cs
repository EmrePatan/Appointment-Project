using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RandevuSistemiGüncel.Models.DTOs
{
    public class RandevuListesiDTO
    {
        public int DoktorCBox { get; set; }
        public int AyCBox { get; set; }
        public int GünCBox { get; set; }
        public int SaatCBox { get; set; }
        public int HastaIDGöster { get; set; }
    }
}
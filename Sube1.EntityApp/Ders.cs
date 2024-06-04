using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sube1.EntityApp
{
    [Table("tblDersler")]
    internal class Ders
    {
        public int Dersid { get; set; }
        
        [Column(TypeName ="varchar")]
        [MaxLength(30)]
        [Required]
        public string Dersad { get; set; }
        
        [Column(TypeName = "varchar")]
        [MaxLength(30)]
        [Required]
        //[Key] primarykey yapmamızı sağlar
        public string Derskod { get; set; }
    }
}

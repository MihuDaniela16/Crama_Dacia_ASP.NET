using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crama_Dacia_ASP.NET.Models
{
    public class Vin
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]

        [Display(Name = "Nume Vin")]
        public string Nume { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$"),  Required,StringLength(50, MinimumLength = 3)]

        public string Sortiment { get; set; }
        [Range(1, 300)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }

        [DataType(DataType.Date)]
        public DateTime ProductieDate { get; set; }

        public int SoiID { get; set; }
        public Soi Soi { get; set; }

        public ICollection<VinTip> VinTipuri { get; set; }
    }
}

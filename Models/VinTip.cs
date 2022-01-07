using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crama_Dacia_ASP.NET.Models
{
    public class VinTip
    {
        public int ID { get; set; }
        public int VinID { get; set; }
        public Vin Vin { get; set; }
        public int TipID { get; set; }
        public Tip Tip { get; set; }
    }
}

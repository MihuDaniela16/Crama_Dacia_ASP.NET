using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crama_Dacia_ASP.NET.Models
{
    public class VinData
    {
        public IEnumerable<Vin> Vinuri { get; set; }
        public IEnumerable<Tip> Tipuri { get; set; }
        public IEnumerable<VinTip> VinTipuri { get; set; }
    }
}

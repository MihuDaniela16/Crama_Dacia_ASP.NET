using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crama_Dacia_ASP.NET.Models
{
    public class Tip
    {
        public int ID { get; set; }
        public string NumeTip { get; set; }
        public ICollection<VinTip> VinTipuri { get; set; }
    }
}

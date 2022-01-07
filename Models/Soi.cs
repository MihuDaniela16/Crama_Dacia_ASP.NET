using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crama_Dacia_ASP.NET.Models
{
    public class Soi
    {
        public int ID { get; set; }
        public string NumeSoi { get; set; }
        public ICollection<Vin> Vinuri { get; set; }
    }
}

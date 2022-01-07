using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Crama_Dacia_ASP.NET.Models;

namespace Crama_Dacia_ASP.NET.Data
{
    public class Crama_Dacia_ASPNETContext : DbContext
    {
        public Crama_Dacia_ASPNETContext (DbContextOptions<Crama_Dacia_ASPNETContext> options)
            : base(options)
        {
        }

        public DbSet<Crama_Dacia_ASP.NET.Models.Vin> Vin { get; set; }

        public DbSet<Crama_Dacia_ASP.NET.Models.Soi> Soi { get; set; }

        public DbSet<Crama_Dacia_ASP.NET.Models.Tip> Tip { get; set; }
    }
}

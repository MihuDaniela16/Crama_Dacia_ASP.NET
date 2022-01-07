using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Crama_Dacia_ASP.NET.Data;
using Crama_Dacia_ASP.NET.Models;

namespace Crama_Dacia_ASP.NET.Pages.Vinuri
{
    public class IndexModel : PageModel
    {
        private readonly Crama_Dacia_ASP.NET.Data.Crama_Dacia_ASPNETContext _context;

        public IndexModel(Crama_Dacia_ASP.NET.Data.Crama_Dacia_ASPNETContext context)
        {
            _context = context;
        }

        public IList<Vin> Vin { get;set; }
        public VinData VinD { get; set; }
        public int VinID { get; set; }
        public int TipID { get; set; }

        public async Task OnGetAsync(int? id, int? tipID)
        {
            VinD = new VinData();

            VinD.Vinuri = await _context.Vin
                .Include(v => v.Soi)
                .Include(v => v.VinTipuri)
                .ThenInclude(v => v.Tip)
                .AsNoTracking()
                .OrderBy(v => v.Nume)
                .ToListAsync();
            if (id != null)
            {
                VinID = id.Value;
                Vin vin = VinD.Vinuri
                .Where(i => i.ID == id.Value).Single();
                VinD.Tipuri = vin.VinTipuri.Select(s => s.Tip);
            }
        }
    }
}

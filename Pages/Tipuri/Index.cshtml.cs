using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Crama_Dacia_ASP.NET.Data;
using Crama_Dacia_ASP.NET.Models;

namespace Crama_Dacia_ASP.NET.Pages.Tipuri
{
    public class IndexModel : PageModel
    {
        private readonly Crama_Dacia_ASP.NET.Data.Crama_Dacia_ASPNETContext _context;

        public IndexModel(Crama_Dacia_ASP.NET.Data.Crama_Dacia_ASPNETContext context)
        {
            _context = context;
        }

        public IList<Tip> Tip { get;set; }

        public async Task OnGetAsync()
        {
            Tip = await _context.Tip.ToListAsync();
        }
    }
}

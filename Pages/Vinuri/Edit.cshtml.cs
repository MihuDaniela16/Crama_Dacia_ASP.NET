using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Crama_Dacia_ASP.NET.Data;
using Crama_Dacia_ASP.NET.Models;

namespace Crama_Dacia_ASP.NET.Pages.Vinuri
{
    public class EditModel : VinTipuriPageModel
    {
        private readonly Crama_Dacia_ASP.NET.Data.Crama_Dacia_ASPNETContext _context;

        public EditModel(Crama_Dacia_ASP.NET.Data.Crama_Dacia_ASPNETContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vin Vin { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Vin = await _context.Vin
                .Include(v => v.Soi)
                .Include(v => v.VinTipuri).ThenInclude(v => v.Tip)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            Vin = await _context.Vin.FirstOrDefaultAsync(m => m.ID == id);

            if (Vin == null)
            {
                return NotFound();
            }
            PopulateAlegeTipData(_context, Vin);
            ViewData["SoiID"] = new SelectList(_context.Set<Soi>(), "ID", "NumeSoi");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedTipuri)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vinToUpdate = await _context.Vin
                .Include(i => i.Soi)
                .Include(i => i.VinTipuri)
                .ThenInclude(i => i.Tip)
                .FirstOrDefaultAsync(s => s.ID == id);
            if (vinToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Vin>(
            vinToUpdate,
            "Vin",
            i => i.Nume, i => i.Sortiment,
            i => i.Pret, i => i.ProductieDate, i => i.Soi))
            {
                UpdateVinTipuri(_context, selectedTipuri, vinToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            
            UpdateVinTipuri(_context, selectedTipuri, vinToUpdate);
            PopulateAlegeTipData(_context, vinToUpdate);
            return Page();
        
    }

        private bool VinExists(int id)
        {
            return _context.Vin.Any(e => e.ID == id);
        }
    }
}

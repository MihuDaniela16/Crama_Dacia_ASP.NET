using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Crama_Dacia_ASP.NET.Data;
using Crama_Dacia_ASP.NET.Models;

namespace Crama_Dacia_ASP.NET.Pages.Vinuri
{
    public class CreateModel : VinTipuriPageModel
    {
        private readonly Crama_Dacia_ASP.NET.Data.Crama_Dacia_ASPNETContext _context;

        public CreateModel(Crama_Dacia_ASP.NET.Data.Crama_Dacia_ASPNETContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["SoiID"] = new SelectList(_context.Set<Soi>(), "ID", "NumeSoi");
            var vin = new Vin();
            vin.VinTipuri = new List<VinTip>();
            PopulateAlegeTipData(_context, vin);
            return Page();
        }

        [BindProperty]
        public Vin Vin { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedTipuri)
        {
            var newVin = new Vin();
            if (selectedTipuri != null)
            {
                newVin.VinTipuri = new List<VinTip>();
                foreach (var cat in selectedTipuri)
                {
                    var catToAdd = new VinTip
                    {
                        TipID = int.Parse(cat)
                    };
                    newVin.VinTipuri.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Vin>(newVin,"Vin",i => i.Nume, i => i.Sortiment,i => i.Pret, i => i.ProductieDate, i => i.SoiID))
            {
                _context.Vin.Add(newVin);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAlegeTipData(_context, newVin);
            return Page();
        }
    }
}

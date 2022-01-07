using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Crama_Dacia_ASP.NET.Data;
using Crama_Dacia_ASP.NET.Models;

namespace Crama_Dacia_ASP.NET.Pages.Soiuri
{
    public class CreateModel : PageModel
    {
        private readonly Crama_Dacia_ASP.NET.Data.Crama_Dacia_ASPNETContext _context;

        public CreateModel(Crama_Dacia_ASP.NET.Data.Crama_Dacia_ASPNETContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Soi Soi { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Soi.Add(Soi);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

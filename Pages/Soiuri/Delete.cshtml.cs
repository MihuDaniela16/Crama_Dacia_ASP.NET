﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Crama_Dacia_ASP.NET.Data;
using Crama_Dacia_ASP.NET.Models;

namespace Crama_Dacia_ASP.NET.Pages.Soiuri
{
    public class DeleteModel : PageModel
    {
        private readonly Crama_Dacia_ASP.NET.Data.Crama_Dacia_ASPNETContext _context;

        public DeleteModel(Crama_Dacia_ASP.NET.Data.Crama_Dacia_ASPNETContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Soi Soi { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Soi = await _context.Soi.FirstOrDefaultAsync(m => m.ID == id);

            if (Soi == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Soi = await _context.Soi.FindAsync(id);

            if (Soi != null)
            {
                _context.Soi.Remove(Soi);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

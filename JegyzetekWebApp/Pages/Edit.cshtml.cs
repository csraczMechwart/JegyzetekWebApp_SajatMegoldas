using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JegyzetekWebApp.Data;
using JegyzetekWebApp.Models;

namespace JegyzetekWebApp.Pages
{
    public class EditModel : PageModel
    {
        private readonly JegyzetekWebApp.Data.TodolistDbContext _context;

        public EditModel(JegyzetekWebApp.Data.TodolistDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Teendo Teendo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teendo =  await _context.Teendok.FirstOrDefaultAsync(m => m.Id == id);
            if (teendo == null)
            {
                return NotFound();
            }
            Teendo = teendo;
           ViewData["KartyaId"] = new SelectList(_context.Kartyak, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Teendo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeendoExists(Teendo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TeendoExists(int id)
        {
            return _context.Teendok.Any(e => e.Id == id);
        }
    }
}

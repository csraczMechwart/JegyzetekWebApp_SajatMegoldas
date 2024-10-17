using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JegyzetekWebApp.Data;
using JegyzetekWebApp.Models;

namespace JegyzetekWebApp.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly JegyzetekWebApp.Data.TodolistDbContext _context;

        public DeleteModel(JegyzetekWebApp.Data.TodolistDbContext context)
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

            var teendo = await _context.Teendok.FirstOrDefaultAsync(m => m.Id == id);

            if (teendo == null)
            {
                return NotFound();
            }
            else
            {
                Teendo = teendo;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teendo = await _context.Teendok.FindAsync(id);
            if (teendo != null)
            {
                Teendo = teendo;
                _context.Teendok.Remove(Teendo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

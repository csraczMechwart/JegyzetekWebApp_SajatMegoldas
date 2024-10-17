using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JegyzetekWebApp.Data;
using JegyzetekWebApp.Models;

namespace JegyzetekWebApp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly JegyzetekWebApp.Data.TodolistDbContext _context;

        public CreateModel(JegyzetekWebApp.Data.TodolistDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["KartyaId"] = new SelectList(_context.Kartyak, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Teendo Teendo { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Teendok.Add(Teendo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

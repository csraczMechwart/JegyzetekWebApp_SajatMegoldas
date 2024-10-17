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
    public class IndexModel : PageModel
    {
        private readonly JegyzetekWebApp.Data.TodolistDbContext _context;

        public IndexModel(JegyzetekWebApp.Data.TodolistDbContext context)
        {
            _context = context;
        }

        public IList<Teendo> Teendo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Teendo = await _context.Teendok
                .Include(t => t.Kartya).ToListAsync();
        }
    }
}

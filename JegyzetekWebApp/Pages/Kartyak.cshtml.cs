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
    public class KartyakModel : PageModel
    {
        private readonly JegyzetekWebApp.Data.TodolistDbContext _context;

        public KartyakModel(JegyzetekWebApp.Data.TodolistDbContext context)
        {
            _context = context;
        }

        public IList<Kartya> Kartya { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Kartya = await _context.Kartyak.ToListAsync();
        }
    }
}

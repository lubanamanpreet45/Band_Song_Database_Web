﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Band_Song_Database_Web.Business;
using Band_Song_Database_Web.Models;

namespace Band_Song_Database_Web.Pages.Producers
{
    public class DeleteModel : PageModel
    {
        private readonly Band_Song_Database_Web.Models.Band_Song_Database_DataContext _context;

        public DeleteModel(Band_Song_Database_Web.Models.Band_Song_Database_DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Producer Producer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Producer = await _context.Producer.FirstOrDefaultAsync(m => m.Id == id);

            if (Producer == null)
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

            Producer = await _context.Producer.FindAsync(id);

            if (Producer != null)
            {
                _context.Producer.Remove(Producer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

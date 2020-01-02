using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TextStory.Data;
using TextStory.Models;

namespace TextStory.Pages.Collection
{
    public class EditModel : PageModel
    {
        private readonly TextStory.Data.ApplicationDbContext _context;

        public EditModel(TextStory.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Collection Collection { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Collection = await _context.Collections.FirstOrDefaultAsync(m => m.ID == id);

            if (Collection == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Collection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollectionExists(Collection.ID))
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

        private bool CollectionExists(int id)
        {
            return _context.Collections.Any(e => e.ID == id);
        }
    }
}

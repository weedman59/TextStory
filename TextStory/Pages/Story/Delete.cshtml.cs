using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TextStory.Data;
using TextStory.Models;

namespace TextStory.Pages.Story
{
    public class DeleteModel : PageModel
    {
        private readonly TextStory.Data.ApplicationDbContext _context;

        public DeleteModel(TextStory.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Story Story { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Story = await _context.Stories
                .Include(s => s.Collection).FirstOrDefaultAsync(m => m.ID == id);

            if (Story == null)
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

            Story = await _context.Stories.FindAsync(id);

            if (Story != null)
            {
                _context.Stories.Remove(Story);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TextStory.Data;
using TextStory.Models;
using System.Security.Claims;

namespace TextStory.Pages.Story
{
    public class CreateModel : PageModel
    {
        private readonly TextStory.Data.ApplicationDbContext _context;

        public CreateModel(TextStory.Data.ApplicationDbContext context)
        {
            _context = context;
        }

    
        public IActionResult OnGet()
        {
            ViewData["CollectionID"] = new SelectList(_context.Collections, "ID", "Title");
            
            return Page();
        }

        [BindProperty]
        public Models.Story Story { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Story.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _context.Stories.Add(Story);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TextStory.Data;
using TextStory.Models;

namespace TextStory.Pages.Collection
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
            return Page();
        }

        [BindProperty]
        public Models.Collection Collection { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Collections.Add(Collection);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

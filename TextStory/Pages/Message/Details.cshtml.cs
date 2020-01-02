using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TextStory.Data;
using TextStory.Models;

namespace TextStory.Pages.Message
{
    public class DetailsModel : PageModel
    {
        private readonly TextStory.Data.ApplicationDbContext _context;

        public DetailsModel(TextStory.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Models.Message Message { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Message = await _context.Messages.FirstOrDefaultAsync(m => m.ID == id);

            if (Message == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

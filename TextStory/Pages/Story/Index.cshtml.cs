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
    public class IndexModel : PageModel
    {
        private readonly TextStory.Data.ApplicationDbContext _context;

        public IndexModel(TextStory.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Story> Story { get;set; }

        public async Task OnGetAsync()
        {
            Story = await _context.Stories
                .Include(s => s.Collection)
                .Include(i => i.Messages)
                .ToListAsync();
        }
    }
}

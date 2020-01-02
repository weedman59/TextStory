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
    public class IndexModel : PageModel
    {
        private readonly TextStory.Data.ApplicationDbContext _context;

        public IndexModel(TextStory.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Message> Message { get; set; }

        public async Task OnGetAsync()
        {
            Message = await _context.Messages.ToListAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TextStory.Data;
using TextStory.Models;

namespace TextStory.Pages.Story
{
    public class EditModel : PageModel
    {
        private readonly TextStory.Data.ApplicationDbContext _context;

        public EditModel(TextStory.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Story Story { get; set; }
        public object Context { get; private set; }

        //public ActionResult OnGetRow(int seqNum, int storyID)
            public async Task<IActionResult> OnGetRow(int seqNum, int storyID)
        {
            TextStory.Models.Message newMessage = new TextStory.Models.Message
            {
                StoryId = storyID,
                Sequence = seqNum,
                PauseMins = 0,
                PauseSeconds = 0
            };
            _context.Messages.Add(newMessage);
            
            //Story.Messages.Add(newMessage);

            await _context.SaveChangesAsync();
            return Partial("_EmptyMessageRow", newMessage);
            
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            

            Story = await _context.Stories
                .Include(s => s.Collection)
                .Include(i => i.Messages)
                .FirstOrDefaultAsync(m => m.ID == id)
                ;
            
            if (Story == null) { return NotFound(); }

           Story.Messages = Story.Messages.OrderBy(m => m.Sequence).ToList();

           ViewData["CollectionID"] = new SelectList(_context.Collections, "ID", "Title");
            //TempData["returnPath"] = Request.PathBase + Request.Path + Request.QueryString;
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["CollectionID"] = new SelectList(_context.Collections, "ID", "Title");
                return Page();
            }

            _context.Attach(Story).State = EntityState.Modified;

            foreach(Models.Message msg in _context.Messages)
            {
                var m = msg.ID;
                _context.Attach(msg).State = EntityState.Modified;

            }
            

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoryExists(Story.ID))
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

        private bool StoryExists(int id)
        {
            return _context.Stories.Any(e => e.ID == id);
        }
    }
}

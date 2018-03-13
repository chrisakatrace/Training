using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Training.Models;

namespace Training.Pages.UserAccounts
{
    public class EditModel : PageModel
    {
        private readonly Training.Models.MyDbContext _context;

        public EditModel(Training.Models.MyDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pollsters Pollsters { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pollsters = await _context.Pollsters.SingleOrDefaultAsync(m => m.Id == id);

            if (Pollsters == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Pollsters).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PollstersExists(Pollsters.Id))
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

        private bool PollstersExists(int id)
        {
            return _context.Pollsters.Any(e => e.Id == id);
        }
    }
}

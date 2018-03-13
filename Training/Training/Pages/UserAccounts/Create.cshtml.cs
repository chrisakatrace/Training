using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Training.Models;

namespace Training.Pages.UserAccounts
{
    public class CreateModel : PageModel
    {
        private readonly Training.Models.MyDbContext _context;

        public CreateModel(Training.Models.MyDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Pollsters Pollsters { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Pollsters.Add(Pollsters);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
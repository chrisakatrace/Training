using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Training.Models;

namespace Training.Pages.UserAccounts
{
    public class DetailsModel : PageModel
    {
        private readonly Training.Models.MyDbContext _context;

        public DetailsModel(Training.Models.MyDbContext context)
        {
            _context = context;
        }

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
    }
}

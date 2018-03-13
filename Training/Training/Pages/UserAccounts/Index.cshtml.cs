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
    public class IndexModel : PageModel
    {
        private readonly Training.Models.MyDbContext _context;

        public IndexModel(Training.Models.MyDbContext context)
        {
            _context = context;
        }

        public IList<Pollsters> Pollsters { get;set; }

        public async Task OnGetAsync()
        {
            Pollsters = await _context.Pollsters.ToListAsync();
        }
    }
}

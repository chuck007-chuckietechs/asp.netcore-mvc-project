using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NBDPrototype.Data;
using NBDPrototype.Models;

namespace NBDPrototype.Pages.ClientList
{
    public class IndexModel : PageModel
    {
        private readonly NBDContext _context;

        public IndexModel(NBDContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get;set; }

        public async Task OnGetAsync()
        {
            Client = await _context.Clients.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}

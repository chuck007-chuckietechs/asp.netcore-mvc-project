using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBDPrototype.Data;
using NBDPrototype.Models;
using NBDPrototype.Utilities;

namespace NBDPrototype.Controllers
{
   
    public class NBDClientsController : BaseController
    {
        private readonly NBDContext _context;

        public NBDClientsController(NBDContext context)
        {
            _context = context;
        }

        // GET: NBDClients
        public async Task<IActionResult> Index(string SearchString, int? ID,
            int? page, string actionButton, string sortDirection = "asc", string sortField = "Client Name")
        {

            PopulateDropDownLists(); //Data for Project Filter DDL
            ViewData["Filtering"] = "";  //Assume not filtering

            var nBDContext = from c in _context.Clients
                .Include(c => c.Projects)
                             select c;

            //Add as many filters as needed
            if (ID.HasValue)
            {
                nBDContext = nBDContext.Where(c => c.ID == ID);
                ViewData["Filtering"] = " show";
            }

            if (!String.IsNullOrEmpty(SearchString))
            {
                nBDContext = nBDContext.Where(c => c.ClientName.ToUpper().Contains(SearchString.ToUpper()));
                ViewData["Filtering"] = " show";
            }

            if (!String.IsNullOrEmpty(actionButton)) //Form Submitted so lets sort!
            {
                page = 1;//Reset page to start

                if (actionButton != "Filter")//Change of sort is requested
                {
                    if (actionButton == sortField) //Reverse order on same field
                    {
                        sortDirection = sortDirection == "asc" ? "desc" : "asc";
                    }
                    sortField = actionButton;//Sort by the button clicked
                }
            }

            //Now we know which field and direction to sort by
            if (sortField == "Client Name")
            {
                if (sortDirection == "asc")
                {
                    nBDContext = nBDContext
                        .OrderByDescending(c => c.ClientName);
                }
                else
                {
                    nBDContext = nBDContext
                        .OrderBy(c => c.ClientName);
                }
            }
            else if (sortField == "Client Address")
            {
                if (sortDirection == "asc")
                {
                    nBDContext = nBDContext
                        .OrderBy(c => c.ClientAddress);

                }
                else
                {
                    nBDContext = nBDContext
                        .OrderByDescending(c => c.ClientAddress);
                }
            }

            else if (sortField == "Contact Name")
            {
                if (sortDirection == "asc")
                {
                    nBDContext = nBDContext
                        .OrderBy(c => c.ClientName);

                }
                else
                {
                    nBDContext = nBDContext
                        .OrderByDescending(c => c.ContactName);
                }
            }

            else if (sortField == "Contact Phone")
            {
                if (sortDirection == "asc")
                {
                    nBDContext = nBDContext
                        .OrderBy(c => c.ContactPhone);

                }
                else
                {
                    nBDContext = nBDContext
                        .OrderByDescending(c => c.ContactPhone);
                }
            }

            else //Sorting by Project Name
            {
                if (sortDirection == "asc")
                {
                    nBDContext = nBDContext
                        .OrderBy(c => c.ClientName);
                }
                else
                {
                    nBDContext = nBDContext
                        .OrderByDescending(c => c.ClientName);
                }
            }
            //Set sort for next time
            ViewData["sortField"] = sortField;
            ViewData["sortDirection"] = sortDirection;

            int pageSize = 3;//Change as required
            var pagedData = await PaginatedList<Client>.CreateAsync(nBDContext.AsNoTracking(), page ?? 1, pageSize);

            //return View(await nBDContext.ToListAsync());
            return View(pagedData);
            //return View(await _context.Clients.ToListAsync());
        }

        // GET: NBDClients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c=>c.Projects)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: NBDClients/Create
        public IActionResult Create()
        {

            PopulateDropDownLists();
            return View();
        }

        // POST: NBDClients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ClientName,ClientAddress,ContactName,ContactPhone")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                //try to create and save data into database
                NotifyCreate("Data created successfully");
                return RedirectToAction(nameof(Index));
            }
            PopulateDropDownLists(client);
            return View(client);
        }

        // GET: NBDClients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            PopulateDropDownLists(client);
            return View(client);
        }

        // POST: NBDClients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ClientName,ClientAddress,ContactName,ContactPhone")] Client client)
        {
            if (id != client.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                    //try to save data into database
                    NotifyUpdate("Data saved successfully");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateDropDownLists(client);
            return View(client);
        }

        // GET: NBDClients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.Projects)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: NBDClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            try
            {
                NotifyDelete("Data deleted successfully!", notificationType: NotificationType.success);
                //throw new UnauthorizedAccessException();
            }
            catch (UnauthorizedAccessException)
            {
                NotifyDelete("Could not delete data!", notificationType: NotificationType.error);

            }
            return RedirectToAction(nameof(Index));
            //return RedirectToAction(nameof(Index));
        }

        private void PopulateDropDownLists(Client client = null)
        {
            ViewData["ID"] = new SelectList(_context.Projects, "ID", "Name", client?.ID);
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.ID == id);
        }
    }
}

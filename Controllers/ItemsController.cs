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
    public class ItemsController : Controller
    {
        private readonly NBDContext _context;

        public ItemsController(NBDContext context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index(string SearchString, int? ID,
            int? page, string actionButton, string sortDirection = "asc", string sortField = "Code")
        {
            var nBDContext = from i in _context.Items.Include(i => i.ItemType) select i;
            //Add as many filters as needed
            if (ID.HasValue)
            {
                nBDContext = nBDContext.Where(i => i.ID == ID);
                ViewData["Filtering"] = " show";
            }

            if (!String.IsNullOrEmpty(SearchString))
            {
                nBDContext = nBDContext.Where(i => i.Description.ToUpper().Contains(SearchString.ToUpper()));
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
            if (sortField == "Code")
            {
                if (sortDirection == "asc")
                {
                    nBDContext = nBDContext
                        .OrderByDescending(i => i.Code);
                }
                else
                {
                    nBDContext = nBDContext
                        .OrderBy(i => i.Code);
                }
            }
            else if (sortField == "Item Type")
            {
                if (sortDirection == "asc")
                {
                    nBDContext = nBDContext
                        .OrderBy(i => i.ItemType);

                }
                else
                {
                    nBDContext = nBDContext
                        .OrderByDescending(i => i.ItemType);
                }
            }

            else if (sortField == "Description")
            {
                if (sortDirection == "asc")
                {
                    nBDContext = nBDContext
                        .OrderBy(i => i.Description);

                }
                else
                {
                    nBDContext = nBDContext
                        .OrderByDescending(i => i.Description);
                }
            }
            else if (sortField == "Price")
            {
                if (sortDirection == "asc")
                {
                    nBDContext = nBDContext
                        .OrderBy(i => i.Price);

                }
                else
                {
                    nBDContext = nBDContext
                        .OrderByDescending(i => i.Price);
                }
            }
            else if (sortField == "Size")
            {
                if (sortDirection == "asc")
                {
                    nBDContext = nBDContext
                        .OrderBy(i => i.Size);

                }
                else
                {
                    nBDContext = nBDContext
                        .OrderByDescending(i => i.Size);
                }
            }

            //Set sort for next time
            ViewData["sortField"] = sortField;
            ViewData["sortDirection"] = sortDirection;

            int pageSize = 3;//Change as required
            var pagedData = await PaginatedList<Item>.CreateAsync(nBDContext.AsNoTracking(), page ?? 1, pageSize);

            //return View(await nBDContext.ToListAsync());
            return View(pagedData);

        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.ItemType)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            ViewData["ItemTypeId"] = new SelectList(_context.ItemTypes, "ID", "Type");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Code,ItemTypeId,Description,Size,Price")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemTypeId"] = new SelectList(_context.ItemTypes, "ID", "Type", item.ItemTypeId);
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["ItemTypeId"] = new SelectList(_context.ItemTypes, "ID", "Type", item.ItemTypeId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Code,ItemTypeId,Description,Size,Price")] Item item)
        {
            if (id != item.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ID))
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
            ViewData["ItemTypeId"] = new SelectList(_context.ItemTypes, "ID", "Type", item.ItemTypeId);
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.ItemType)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ID == id);
        }

        
    }
}

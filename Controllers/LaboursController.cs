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
    public class LaboursController : Controller
    {
        private readonly NBDContext _context;

        public LaboursController(NBDContext context)
        {
            _context = context;
        }

        // GET: Labours
        public async Task<IActionResult> Index(string SearchString, int? ID,
            int? page, string actionButton, string sortDirection = "asc", string sortField = "Labour")
        {
            ViewData["Filtering"] = "";  //Assume not filtering

            var nBDContext = from l in _context.Labours.Include(l => l.Staffs) select l;

            //Add as many filters as needed
            if (ID.HasValue)
            {
                nBDContext = nBDContext.Where(l => l.ID == ID);
                ViewData["Filtering"] = " show";
            }

            if (!String.IsNullOrEmpty(SearchString))
            {
                nBDContext = nBDContext.Where(l => l.Description.ToUpper().Contains(SearchString.ToUpper()));
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
            if (sortField == "Description")
            {
                if (sortDirection == "asc")
                {
                    nBDContext = nBDContext
                        .OrderByDescending(l => l.Description);
                }
                else
                {
                    nBDContext = nBDContext
                        .OrderBy(l => l.Description);
                }
            }
            else if (sortField == "Price")
            {
                if (sortDirection == "asc")
                {
                    nBDContext = nBDContext
                        .OrderBy(l => l.PriceHour);
                }
                else
                {
                    nBDContext = nBDContext
                        .OrderByDescending(l => l.PriceHour);
                }
            }

            //Set sort for next time
            ViewData["sortField"] = sortField;
            ViewData["sortDirection"] = sortDirection;

            int pageSize = 3;//Change as required
            var pagedData = await PaginatedList<Labour>.CreateAsync(nBDContext.AsNoTracking(), page ?? 1, pageSize);

            //return View(await nBDContext.ToListAsync());
            return View(pagedData);
        }

        // GET: Labours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labour = await _context.Labours.FirstOrDefaultAsync(m => m.ID == id);
            if (labour == null)
            {
                return NotFound();
            }

            return View(labour);
        }

        [HttpGet]
        [Route("/Labours/Create", Name = "labourcreate")]
        // GET: Labours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Labours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,PriceHour")]Labour labour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(labour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(labour);
        }

        // GET: Labours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labour = await _context.Labours.FindAsync(id);
            if (labour == null)
            {
                return NotFound();
            }
            return View(labour);
        }

        // POST: Labours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description,PriceHour")] Labour labour)
        {
            if (id != labour.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(labour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabourExists(labour.ID))
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
            return View(labour);
        }

        // GET: Labours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labour = await _context.Labours
                .FirstOrDefaultAsync(m => m.ID == id);
            if (labour == null)
            {
                return NotFound();
            }

            return View(labour);
        }

        // POST: Labours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var labour = await _context.Labours.FindAsync(id);
            _context.Labours.Remove(labour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabourExists(int id)
        {
            return _context.Labours.Any(e => e.ID == id);
        }
    }
}

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
using NBDPrototype.ViewModels;

namespace NBDPrototype.Controllers
{
    public class StaffsController : Controller
    {
        private readonly NBDContext _context;

        public StaffsController(NBDContext context)
        {
            _context = context;
        }

        // GET: Staffs
        public async Task<IActionResult> Index(string SearchString, int? ID,
            int? page, string actionButton, string sortDirection = "asc", string sortField = "First Name")
        {
            PopulateDropDownLists(); //Data for Staffs Filter DDL
            ViewData["Filtering"] = "";  //Assume not filtering

            var nBDContext = from s in _context.Staffs.Include(s => s.Labour) select s;

            //Add as many filters as needed
            if (ID.HasValue)
            {
                nBDContext = nBDContext.Where(s => s.ID == ID);
                ViewData["Filtering"] = " show";
            }

            if (!String.IsNullOrEmpty(SearchString))
            {
                nBDContext = nBDContext.Where(s => s.StaffFirstName.ToUpper().Contains(SearchString.ToUpper()));
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
            if (sortField == "Labour")
            {
                if (sortDirection == "asc")
                {
                    nBDContext = nBDContext
                        .OrderByDescending(s => s.Labour);
                }
                else
                {
                    nBDContext = nBDContext
                        .OrderBy(s => s.Labour);
                }
            }
            else if (sortField == "First Name")
            {
                if (sortDirection == "asc")
                {
                    nBDContext = nBDContext
                        .OrderBy(s => s.StaffFirstName);

                }
                else
                {
                    nBDContext = nBDContext
                        .OrderByDescending(s => s.StaffLastName);
                }
            }

            else if (sortField == "Phone")
            {
                if (sortDirection == "asc")
                {
                    nBDContext = nBDContext
                        .OrderBy(s => s.StaffPhone);

                }
                else
                {
                    nBDContext = nBDContext
                        .OrderByDescending(s => s.StaffPhone);
                }
            }

            //Set sort for next time
            ViewData["sortField"] = sortField;
            ViewData["sortDirection"] = sortDirection;

            int pageSize = 3;//Change as required
            var pagedData = await PaginatedList<Staff>.CreateAsync(nBDContext.AsNoTracking(), page ?? 1, pageSize);

            //return View(await nBDContext.ToListAsync());
            return View(pagedData);

        }

        // GET: Staffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staffs
                .Include(s => s.Labour)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // GET: Staffs/Create
        public IActionResult Create()
        {
            ViewData["LabourId"] = new SelectList(_context.Labours, "ID", "Description");
            PopulateDropDownLists();
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LabourId,StaffFirstName,StaffLastName,StaffPhone")] StaffVM staffVM)
        {
            Staff staff = staffVM.Convert();

            if (ModelState.IsValid)
            {
                _context.Add(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LabourId"] = new SelectList(_context.Labours, "ID", "Description", staff.LabourId);
            return View(staff);
        }

        // GET: Staffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            ViewData["LabourId"] = new SelectList(_context.Labours, "ID", "Description", staff.LabourId);
            return View(staff);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StaffVM staffVm)
        {
            if (id != staffVm.ID)
            {
                return NotFound();
            }

            Staff staff = staffVm.Convert();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(staff.ID))
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
            ViewData["LabourId"] = new SelectList(_context.Labours, "ID", "Description", staff.LabourId);
            return View(staff);
        }

        // GET: Staffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staffs
                .Include(s => s.Labour)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staff = await _context.Staffs.FindAsync(id);
            _context.Staffs.Remove(staff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private void PopulateDropDownLists(Staff staff = null)
        {
            ViewData["ID"] = new SelectList(_context.Staffs, "ID", "StaffName", staff?.ID);
        }

        private bool StaffExists(int id)
        {
            return _context.Staffs.Any(e => e.ID == id);
        }
    }
}

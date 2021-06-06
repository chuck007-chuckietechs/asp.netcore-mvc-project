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
    public class BidStaffsController : Controller
    {
        private readonly NBDContext _context;

        public BidStaffsController(NBDContext context)
        {
            _context = context;
        }

        // GET: BidItems
        public async Task<IActionResult> Index(int? BidId, int? page, int? pageSizeID, int? StaffId, string actionButton, string sortDirection = "desc", string sortField = "Collections")
        {
            if (!BidId.HasValue)
            {
                return RedirectToAction("Index", "Bids");
            }

            PopulateDropDownLists();
            ViewData["Filtering"] = "btn-outline-dark";

            //Get the URL with the last filter, sort and page parameters from the Patients Index View
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "Bids");

            //Clear the sort/filter/paging URL Cookie for Patient Appointments Master/Details
            CookieHelper.CookieSet(HttpContext, "BidStaffURL", "", -1);

            var bites = from a in _context.BidStaffs.Include(a => a.Staff).ThenInclude(a => a.Labour).Include(a => a.Bid)
                        where a.BidId == BidId.GetValueOrDefault()
                        select a;

            if (StaffId.HasValue)
            {
                bites = bites.Where(p => p.StaffId == StaffId);
                ViewData["Filtering"] = "btn-danger";
            }

            //Before we sort, see if we have called for a change of filtering or sorting
            if (!String.IsNullOrEmpty(actionButton)) //Form Submitted so lets sort!
            {
                page = 1;//Reset back to first page when sorting or filtering

                if (actionButton != "Filter")//Change of sort is requested
                {
                    if (actionButton == sortField) //Reverse order on same field
                    {
                        sortDirection = sortDirection == "asc" ? "desc" : "asc";
                    }
                    sortField = actionButton;//Sort by the button clicked
                }
            }
            //Now we know which field and direction to sort by, but a Switch is hard to use for 2 criteria
            //so we will use an if() structure instead.
            if (sortField.Contains("Item Type"))
            {
                if (sortDirection == "asc")
                {
                    bites = bites
                        .OrderBy(p => p.Staff.Labour.Description);
                }
                else
                {
                    bites = bites
                        .OrderByDescending(p => p.Staff.Labour.Description);
                }
            }

            //Set sort for next time
            ViewData["sortField"] = sortField;
            ViewData["sortDirection"] = sortDirection;

            //Now get the MASTER record, the patient, so it can be displayed at the top of the screen
            Bid bid = _context.Bids
                .Include(p => p.Projects)
                .Where(p => p.ID == BidId.GetValueOrDefault()).FirstOrDefault();
            ViewBag.Bid = bid;

            //Handle Paging
            int pageSize;//This is the value we will pass to PaginatedList
            if (pageSizeID.HasValue)
            {
                //Value selected from DDL so use and save it to Cookie
                pageSize = pageSizeID.GetValueOrDefault();
                CookieHelper.CookieSet(HttpContext, "pageSizeValue", pageSize.ToString(), 30);
            }
            else
            {
                //Not selected so see if it is in Cookie
                pageSize = Convert.ToInt32(HttpContext.Request.Cookies["pageSizeValue"]);
            }
            pageSize = (pageSize == 0) ? 3 : pageSize;//Neither Selected or in Cookie so go with default
            ViewData["pageSizeID"] =
                new SelectList(new[] { "3", "5", "10", "20", "30", "40", "50", "100", "500" }, pageSize.ToString());
            var pagedData = await PaginatedList<BidStaff>.CreateAsync(bites.AsNoTracking(), page ?? 1, pageSize);
            return View(pagedData);
        }

        // GET: BidItems/Add
        public IActionResult Add(int? BidId)
        {
            if (!BidId.HasValue)
            {
                return RedirectToAction("Index", "Bids");
            }

            //Get the URL with the last filter, sort and page parameters
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "BidStaffs");


            BidStaff a = new BidStaff()
            {
                BidId = BidId.GetValueOrDefault()
            };
            PopulateDropDownLists();
            return View(a);
        }

        // POST: BidItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("ID,BidId,StaffId,BidStaffTotalHours,BidStaffMarkup")] BidStaff bidstaff)
        {
            //Get the URL with the last filter, sort and page parameters
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "BidStaffs");

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(bidstaff);
                    await _context.SaveChangesAsync();
                    return Redirect(ViewData["returnURL"].ToString());
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            PopulateDropDownLists(bidstaff);
            return View(bidstaff);
        }

        // GET: BidItems/Edit/5
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Get the URL with the last filter, sort and page parameters
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "BidStaffs");

            var bidstaff = await _context.BidStaffs
               .Include(a => a.Bid)
               .Include(a => a.Staff)
                    .ThenInclude(a => a.Labour)
               .FirstOrDefaultAsync(m => m.ID == id);
            if (bidstaff == null)
            {
                return NotFound();
            }
            PopulateDropDownLists(bidstaff);
            return View(bidstaff);
        }

        // POST: BidItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id)
        {
            var bidstaffToUpdate = await _context.BidStaffs
                .Include(a => a.Staff)
                    .ThenInclude(a => a.Labour)
                .Include(a => a.Bid)
                .FirstOrDefaultAsync(m => m.ID == id);
            //Check that you got it or exit with a not found error
            if (bidstaffToUpdate == null)
            {
                return NotFound();
            }

            //Get the URL with the last filter, sort and page parameters
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "BidStaffs");

            //Try updating it with the values posted
            if (await TryUpdateModelAsync<BidStaff>(bidstaffToUpdate, "",
                p => p.BidId, p => p.StaffId, p => p.BidStaffTotalHours, p => p.BidStaffMarkup))
            {
                try
                {
                    _context.Update(bidstaffToUpdate);
                    await _context.SaveChangesAsync();
                    return Redirect(ViewData["returnURL"].ToString());
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!BidStaffExists(bidstaffToUpdate.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            PopulateDropDownLists(bidstaffToUpdate);
            return View(bidstaffToUpdate);
        }

        // POST: BidItems/Delete/5
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Get the URL with the last filter, sort and page parameters
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "BidStaffs");

            var bidstaff = await _context.BidStaffs
                .Include(a => a.Staff)
                    .ThenInclude(a => a.Labour)
                .Include(a => a.Bid)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bidstaff == null)
            {
                return NotFound();
            }
            return View(bidstaff);
        }

        // POST: BidItem/Remove/5
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveConfirmed(int id)
        {
            var bidstaff = await _context.BidStaffs
                .Include(a => a.Staff)
                    .ThenInclude(a => a.Labour)
                .Include(a => a.Bid)
                .FirstOrDefaultAsync(m => m.ID == id);

            //Get the URL with the last filter, sort and page parameters
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "BidStaffs");

            try
            {
                _context.BidStaffs.Remove(bidstaff);
                await _context.SaveChangesAsync();
                //return RedirectToAction("Index", new { appointment.PatientID });
                return Redirect(ViewData["returnURL"].ToString());
            }
            catch (Exception dex)
            {
                if (dex.GetBaseException().Message.Contains("Cannot delete seeded data"))
                {
                    ModelState.AddModelError("", "Unable to delete.  You cannot delete originally seeded data.");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }

            return View(bidstaff);
        }

        private SelectList BidStaffSelectList(int? id)
        {
            var dQuery = from d in _context.Items
                         orderby d.Description
                         select d;
            return new SelectList(dQuery, "ID", "Description", id);
        }

        private void PopulateDropDownLists(BidStaff item = null)
        {
            ViewData["BidId"] = BidStaffSelectList(item?.BidId);
            ViewData["StaffId"] = new SelectList(_context.Staffs, "ID", "StaffFullName");
        }
        private bool BidStaffExists(int id)
        {
            return _context.BidStaffs.Any(e => e.ID == id);
        }
    }
}

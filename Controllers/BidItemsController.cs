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
    public class BidItemsController : Controller
    {
        private readonly NBDContext _context;

        public BidItemsController(NBDContext context)
        {
            _context = context;
        }

        // GET: BidItems
        public async Task<IActionResult> Index(int? BidId, int? page, int? pageSizeID, int? ItemId, string actionButton, string sortDirection = "desc", string sortField = "Appointment")
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
            CookieHelper.CookieSet(HttpContext, "BidItemURL", "", -1);

            var bitem = from a in _context.BidItems.Include(a => a.Item).ThenInclude(a => a.ItemType).Include(a => a.Bid)
                        where a.BidId == BidId.GetValueOrDefault()
                        select a;

            if (ItemId.HasValue)
            {
                bitem = bitem.Where(p => p.ItemId == ItemId);
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
                    bitem = bitem
                        .OrderBy(p => p.Item.ItemType.Type);
                }
                else
                {
                    bitem = bitem
                        .OrderByDescending(p => p.Item.ItemType.Type);
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
            var pagedData = await PaginatedList<BidItem>.CreateAsync(bitem.AsNoTracking(), page ?? 1, pageSize);
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
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "BidItems");


            BidItem a = new BidItem()
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
        public async Task<IActionResult> Add([Bind("ID,BidId,ItemId,BidItemQuantity")] BidItem biditem)
        {
            //Get the URL with the last filter, sort and page parameters
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "BidItems");

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(biditem);
                    await _context.SaveChangesAsync();
                    UpdateAmount(biditem.BidId, biditem.ItemId, biditem.BidItemQuantity);

                    return Redirect(ViewData["returnURL"].ToString());
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            PopulateDropDownLists(biditem);
            return View(biditem);
        }

        // GET: BidItems/Edit/5
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Get the URL with the last filter, sort and page parameters
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "BidItems");

            var biditem = await _context.BidItems
               .Include(a => a.Bid)
               .Include(a => a.Item)
                    .ThenInclude(a => a.ItemType)
               .FirstOrDefaultAsync(m => m.ID == id);
            if (biditem == null)
            {
                return NotFound();
            }
            PopulateDropDownLists(biditem);
            return View(biditem);
        }

        // POST: BidItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id)
        {
            var biditemToUpdate = await _context.BidItems
                .Include(a => a.Item)
                    .ThenInclude(a => a.ItemType)
                .Include(a => a.Bid)
                .FirstOrDefaultAsync(m => m.ID == id);
            //Check that you got it or exit with a not found error
            if (biditemToUpdate == null)
            {
                return NotFound();
            }

            //Get the URL with the last filter, sort and page parameters
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "BidItems");

            //Try updating it with the values posted
            if (await TryUpdateModelAsync<BidItem>(biditemToUpdate, "",
                p => p.BidId, p => p.ItemId, p => p.BidItemQuantity))
            {
                try
                {
                    _context.Update(biditemToUpdate);
                    await _context.SaveChangesAsync();
                    return Redirect(ViewData["returnURL"].ToString());
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!BidItemExists(biditemToUpdate.ID))
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
            PopulateDropDownLists(biditemToUpdate);
            return View(biditemToUpdate);
        }

        // POST: BidItems/Delete/5
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Get the URL with the last filter, sort and page parameters
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "BidItems");

            var biditem = await _context.BidItems
                .Include(a => a.Item)
                    .ThenInclude(a => a.ItemType)
                .Include(a => a.Bid)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (biditem == null)
            {
                return NotFound();
            }
            return View(biditem);
        }

        // POST: BidItem/Remove/5
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveConfirmed(int id)
        {
            var biditem = await _context.BidItems
                .Include(a => a.Item)
                    .ThenInclude(a => a.ItemType)
                .Include(a => a.Bid)
                .FirstOrDefaultAsync(m => m.ID == id);

            //Get the URL with the last filter, sort and page parameters
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "BidItems");

            try
            {
                _context.BidItems.Remove(biditem);
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

            return View(biditem);
        }

        private SelectList BidItemSelectList(int? id)
        {
            var dQuery = from d in _context.Items
                         orderby d.Description
                         select d;
            return new SelectList(dQuery, "ID", "Description", id);
        }

        private void PopulateDropDownLists(BidItem item = null)
        {
            ViewData["BidId"] = BidItemSelectList(item?.BidId);
            ViewData["ItemId"] = new SelectList(_context.Items, "ID", "Description");
        }
        private bool BidItemExists(int id)
        {
            return _context.BidItems.Any(e => e.ID == id);
        }

        private async void UpdateAmount(int bidID, int itemID, int qnty)
        {
            try
            {
                var bidToUpdate = await _context.Bids.SingleOrDefaultAsync(p => p.ID == bidID);
                var itemToAdd = await _context.Items.SingleOrDefaultAsync(p => p.ID == itemID);

                bidToUpdate.Amount = itemToAdd.Price * qnty;

                _context.Update(bidToUpdate);
                await _context.SaveChangesAsync();
                
            }
            catch
            {
                ModelState.AddModelError("", "Something went Worng");
            }
        }

       
    }
}

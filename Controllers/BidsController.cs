using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBDPrototype.Data;
using NBDPrototype.Models;
using NBDPrototype.ViewModels;

namespace NBDPrototype.Controllers
{
    public class BidsController : BaseController
    {

        private readonly NBDContext _context;

        public BidsController(NBDContext context)
        {
            _context = context;
        }

        // GET: Bids
        public async Task<IActionResult> Index(int? id, int? biditemID)
        {
            var viewModel = new BidVM();
            viewModel.Bids = await _context.Bids
                .Include(i => i.Projects)
                .Include(i => i.BidItems)
                    .ThenInclude(i => i.Item)
                    .ThenInclude(i => i.ItemType)
                .Include(i => i.Statuses)
                .Include(i => i.BidStaffs)
                    .ThenInclude(i => i.Staff)
                    .ThenInclude(i => i.Labour)
                .AsNoTracking()
                .ToListAsync();

            if (id != null)
            {
                ViewData["BidId"] = id.Value;
                Bid bid = viewModel.Bids.Where(
                    i => i.ID == id.Value).Single();
                viewModel.Items = bid.BidItems.Select(s => s.Item);
                viewModel.Staffs = bid.BidStaffs.Select(s => s.Staff);
            }

            //dynamic nbdmodel = new ExpandoObject();
            //var nBDContext = _context.Bids.Include(b => b.Projects).Include(b => b.Statuses);
            //nbdmodel.BidItems = Get
            //return View(await nBDContext.ToListAsync());
            return View(viewModel);
        }

        // GET: Bids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bid = await _context.Bids
                .Include(b => b.Projects)
                .Include(b => b.Statuses)
                .Include(b => b.BidItems)
                    .ThenInclude(b => b.Item)
                    .ThenInclude(b => b.ItemType)
                .Include(b => b.BidStaffs)
                    .ThenInclude(b => b.Staff)
                    .ThenInclude(b => b.Labour)
                .FirstOrDefaultAsync(m => m.ID == id); 
            if (bid == null)
            {
                return NotFound();
            }

            return View(bid);
        }

        // GET: Bids/Create


        //[Route("/Bids/Create", Name = "bidscreate")]
        public IActionResult Create()
        {
            PopulateDropDownLists();
            //Bid bid = new Bid();
            //PopulateBidItemList(bid);
            //ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "ID");
            //ViewData["StatusId"] = new SelectList(_context.Statuses, "ID", "ID");
            return View();
        }

        // POST: Bids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProjectID,Date,StartDate,ClosingDate,StatusId,IsApproved")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bid);
                await _context.SaveChangesAsync();
                //try to create and save data into database
                NotifyCreate("Data created successfully");
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "ID", bid.ProjectID);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "ID", "ID", bid.StatusId);
            return View(bid);
        }


        // GET: Bids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bid = await _context.Bids.FindAsync(id);
            if (bid == null)
            {
                return NotFound();
            }
            //ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "ID", bid.ProjectID);
            //ViewData["StatusId"] = new SelectList(_context.Statuses, "ID", "ID", bid.StatusId);
            PopulateDropDownLists();
            return View(bid);
        }

        // POST: Bids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProjectID,Date,StartDate,ClosingDate,Amount,StatusId,IsApproved")] Bid bid)
        {
            if (id != bid.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bid);
                    await _context.SaveChangesAsync();
                    //try to save data into database
                    NotifyUpdate("Data saved successfully");

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BidExists(bid.ID))
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
            //PopulateBidItemList(bid);
            //ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "ID", bid.ProjectID);
            //ViewData["StatusId"] = new SelectList(_context.Statuses, "ID", "ID", bid.StatusId);
            PopulateDropDownLists();
            return View(bid);
        }

        // GET: Bids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bid = await _context.Bids
                .Include(b => b.Projects)
                .Include(b => b.Statuses)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bid == null)
            {
                return NotFound();
            }

            return View(bid);
        }

        // POST: Bids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bid = await _context.Bids.FindAsync(id);
            _context.Bids.Remove(bid);
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
        }

        private void PopulateDropDownLists(Bid bid = null)
        {
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name", bid?.ProjectID);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "ID", "BidStatus", bid?.StatusId);
        }

        private bool BidExists(int id)
        {
            return _context.Bids.Any(e => e.ID == id);
        }

        


        //private void PopulateBidItemList(Bid bid)
        //{
        //    var allOptions = _context.Items;
        //    var currentOptionsHS = new HashSet<int>(bid.BidItems.Select(b => b.ItemId));
        //    var selected = new List<BidItemVM>();
        //    var available = new List<BidItemVM>();
        //    foreach (var s in allOptions)
        //    {
        //        if (currentOptionsHS.Contains(s.ID))
        //        {
        //            selected.Add(new BidItemVM
        //            {
        //                ID = s.ID,
        //                BIName = s.Description
                        

        //            });
        //        }
        //        else
        //        {
        //            available.Add(new BidItemVM
        //            {
        //                ID = s.ID,
        //                BIName = s.Description
        //            });
        //        }
        //    }

        //    ViewData["selOpts"] = new MultiSelectList(selected.OrderBy(s => s.BIName), "ID", "BIName");
        //    ViewData["availOpts"] = new MultiSelectList(available.OrderBy(s => s.BIName), "ID", "BIName");
        //}
    }
}

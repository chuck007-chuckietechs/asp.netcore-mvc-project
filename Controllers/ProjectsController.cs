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
    public class ProjectsController : BaseController
    {
        private readonly NBDContext _context;

        public ProjectsController(NBDContext context)
        {
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index(string SearchString, int? ClientID,
            int? page, string actionButton, string sortDirection = "asc", string sortField = "Project Name")
        {
            PopulateDropDownLists(); //Data for Client Filter DDL
            ViewData["Filtering"] = "";  //Assume not filtering

            var nBDContext = from p in _context.Projects
                .Include(p => p.Client)
                select p;

            //Add as many filters as needed
            if (ClientID.HasValue)
            {
                nBDContext = nBDContext.Where(p => p.ClientID == ClientID);
                ViewData["Filtering"] = " show";
            }

            if (!String.IsNullOrEmpty(SearchString))
            {
                nBDContext = nBDContext.Where(p => p.Name.ToUpper().Contains(SearchString.ToUpper()));
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
            if (sortField == "Project Name")
            {
                if (sortDirection == "asc")
                {
                    nBDContext = nBDContext
                        .OrderByDescending(p => p.Name);
                }
                else
                {
                    nBDContext = nBDContext
                        .OrderBy(p => p.Name);
                }
            }
            else if (sortField == "Project Site")
            {
                if (sortDirection == "asc")
                {
                    nBDContext = nBDContext
                        .OrderBy(p => p.Location);
                        
                }
                else
                {
                    nBDContext = nBDContext
                        .OrderByDescending(p => p.Location);
                }
            }

            else if (sortField == "Client Name")
            {
                if (sortDirection == "asc")
                {
                    nBDContext = nBDContext
                        .OrderBy(p => p.Client.ClientName);

                }
                else
                {
                    nBDContext = nBDContext
                        .OrderByDescending(p => p.Client.ClientName);
                }
            }

            else if (sortField == "Starting Date")
            {
                if (sortDirection == "asc")
                {
                    nBDContext = nBDContext
                        .OrderBy(p => p.DateStart);

                }
                else
                {
                    nBDContext = nBDContext
                        .OrderByDescending(p => p.DateStart);
                }
            }

            else if (sortField == "Completion Date")
            {
                if (sortDirection == "asc")
                {
                    nBDContext = nBDContext
                        .OrderBy(p => p.DateComplete);

                }
                else
                {
                    nBDContext = nBDContext
                        .OrderByDescending(p => p.DateComplete);
                }
            }
            else //Sorting by Project Name
            {
                if (sortDirection == "asc")
                {
                    nBDContext = nBDContext
                        .OrderBy(p => p.Name);
                }
                else
                {
                    nBDContext = nBDContext
                        .OrderByDescending(p => p.Name);                 
                }
            }
            //Set sort for next time
            ViewData["sortField"] = sortField;
            ViewData["sortDirection"] = sortDirection;

            int pageSize = 3;//Change as required
            var pagedData = await PaginatedList<Project>.CreateAsync(nBDContext.AsNoTracking(), page ?? 1, pageSize);

            //return View(await nBDContext.ToListAsync());
            return View(pagedData);
        }
       
        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.Client)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            PopulateDropDownLists();
            return View();
        }

        

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Location,ClientID,DateStart,DateComplete")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                //try to create and save data into database
                NotifyCreate("Data created successfully");
                return RedirectToAction(nameof(Index));
            }
            PopulateDropDownLists(project);
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            PopulateDropDownLists(project);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Location,ClientID,DateStart,DateComplete")] Project project)
        {
            if (id != project.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                    //try to save data into database
                    NotifyUpdate("Data saved successfully");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ID))
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
            PopulateDropDownLists(project);
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.Client)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(project);
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

        private void PopulateDropDownLists(Project project = null)
        {
            ViewData["ClientID"] = new SelectList(_context.Clients, "ID", "ClientName", project?.ClientID);
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ID == id);
        }
    }
}

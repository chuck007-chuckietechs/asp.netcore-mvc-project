using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NBDPrototype.Data;
using NBDPrototype.Models;
using NBDPrototype.Utilities;
using NBDPrototype.ViewModels;

namespace NBDPrototype.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NBDContext _context;

        public HomeController(ILogger<HomeController> logger, NBDContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(int? ItemCountpage, int? TopBidPerProjectpage, int? DesignersPerProjectpage)
        {
            StatisticVM statistics = new StatisticVM();

            statistics.TotalAmountOfProjects = _context.Projects.Count();
            statistics.TotalAmountOfBids = _context.Bids.Count();

            statistics.TotalNotApprovedProjects = _context.Projects.Count();
            statistics.TotalClients = _context.Clients.Count();
            statistics.TotalStaffs = _context.Staffs.Count();

            var itemCountQuery = _context.Items
                .Include(x => x.ItemType)
                .GroupBy(x => x.ItemType.Type)
                .Select(x => new Tuple<string, int>(x.Key, x.Count())).ToList();

            statistics.ItemCount = PaginatedList<Tuple<string, int>>.Create(itemCountQuery, ItemCountpage ?? 1, 3);

            var projectWithBids = _context.Projects
                .Include(x => x.Bids)
                .Where(x => x.Bids.Count > 0).ToList();

            List<Tuple<string, decimal>> projectWithTopBid = new List<Tuple<string, decimal>>();

            foreach (var project in projectWithBids)
            {
                projectWithTopBid.Add(new Tuple<string, decimal>(project.Name, project.Bids.Max(x => x.Amount)));
            }

            List<Tuple<string, decimal>> tuples = new List<Tuple<string, decimal>>();
            statistics.TopBidPerProject = PaginatedList<Tuple<string, decimal>>.Create(projectWithTopBid, TopBidPerProjectpage ?? 1, 3);

            return View(statistics);
        }

        public IActionResult Create()
        {
            try
            {   //try to create and save data into database
                NotifyCreate("Data created successfully");
            }
            catch (Exception)
            {


            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Save()
        {
            try
            {   //try to save data into database
                NotifyUpdate("Data saved successfully");
            }
            catch (Exception)
            {


            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete()
        {
            try
            {
                throw new UnauthorizedAccessException();
            }
            catch (Exception)
            {
                NotifyDelete("Could not delete data!", notificationType: NotificationType.error);

            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

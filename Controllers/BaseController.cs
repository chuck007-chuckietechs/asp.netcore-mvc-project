using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NBDPrototype.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NBDPrototype.Controllers
{
    public class BaseController : Controller
    {
        public void NotifyDelete(string message, string title = "Deleted Successfully",
                                    NotificationType notificationType = NotificationType.success)
        {
            var msg = new
            {
                message = message,
                title = title,
                icon = notificationType.ToString(),
                type = notificationType.ToString(),
                buttons = true,
                dangerMode = true,
                provider = GetProvider()

            };

            TempData["Message"] = JsonConvert.SerializeObject(msg);
        }

        public void NotifyUpdate(string message, string title = "Updated Successfully",
                                    NotificationType notificationType = NotificationType.success,
                                    bool showDenyButton = true, bool showCancelButton = true,
                                    string confirmButtonText = "Save", string denyButtonText = "Don't save")
        {
            var msg = new
            {
                message = message,
                title = title,
                icon = notificationType.ToString(),
                type = notificationType.ToString(),
                showDenyButton = true,
                showCancelButton = true,
                confirmButtonText = confirmButtonText,
                denyButtonText = denyButtonText,
                provider = GetProvider()

            };

            TempData["Message"] = JsonConvert.SerializeObject(msg);
        }


        public void NotifyCreate(string message, string title = "Created Successfully",
                                   NotificationType notificationType = NotificationType.success)
        {
            var msg = new
            {
                message = message,
                title = title,
                icon = notificationType.ToString(),
                type = notificationType.ToString(),
                buttons = true,
                dangerMode = true,
                provider = GetProvider()

            };

            TempData["Message"] = JsonConvert.SerializeObject(msg);
        }

        private string GetProvider()
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                              .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();
            var value = configuration["NotificationProvider"];
            return value;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}

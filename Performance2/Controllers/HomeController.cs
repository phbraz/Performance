using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Performance2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Performance2.Services;
using Performance2.Models.ViewModels;
using Performance2.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace Performance2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        public IActionResult Index()
        {
            var updateWorker = new UpdateWorker();

            var updatedWorkers = updateWorker.UpdateUserName();

            var vm = new WorkerViewModel()
            {
                Workers = updatedWorkers,
            };
           
            return View(vm);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SaveWorkerChanges()
        {
            var updateWorker = new UpdateWorker();

            var workersToUpdate = updateWorker.UpdateUserName();
           

            var test = workersToUpdate.Select(x => new Employee
            {
                LoginId = x.LoginID,
                BusinessEntityId = x.Id,
                BusinessEntity = new Person() { BusinessEntityId = x.Id }
                
            });

            updateWorker.SaveChanges(test);

            return RedirectToAction("Index", "HomeController");

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

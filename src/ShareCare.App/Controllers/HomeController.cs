using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShareCare.App.Extensions;
using ShareCare.App.Models;
using ShareCare.Model.Enums;
using ShareCare.Model.Interfaces;
using ShareCare.Model.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShareCare.App.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService homeService;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService)
        {
            _logger = logger;
            this.homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            var doctor = PersonType.Doctor.ToString();
            bool isDoctor = HttpContext.GetRole().Equals(doctor);
            var identify = Guid.Parse(HttpContext.GetIdentifier());

            if (isDoctor)
            {
                var schedulers = await homeService.GetDetailSolicitationAsync(identify);
                return View(schedulers);
            }
            else
            {
                var schedulers = await homeService.GetDetailSchedulerAsync(identify);
                var dairies = await homeService.GetDiaryAsync(identify);
                var tupleData = new Tuple<IEnumerable<DetailSchedulerModel>, IEnumerable<DiaryModel>>(schedulers, dairies);
                return View("PatientIndex", tupleData);
            }
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

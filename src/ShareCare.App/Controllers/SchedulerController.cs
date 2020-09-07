using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareCare.App.Extensions;
using ShareCare.Model.Enums;
using ShareCare.Model.Interfaces;
using ShareCare.Model.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ShareCare.App.Controllers
{
    [Authorize]
    public class SchedulerController : Controller
    {
        private readonly ISchedulerService schedulerService;

        public SchedulerController(ISchedulerService schedulerService)
        {
            this.schedulerService = schedulerService;
        }


        public IActionResult Index(Guid id, PersonType shedulertype, string specialties)
        {
            var scheduler = new SchedulerModel();
            scheduler.DoctorPatient = new DoctorPatientModel();
            scheduler.DateStart = DateTime.Now.AddHours(1);
            scheduler.DateEnd = DateTime.Now.AddHours(2);

            if (shedulertype == PersonType.Doctor)
            {
                scheduler.DoctorPatient.DoctorId = id;
                scheduler.Specialties = specialties.Split(",").ToList();
                scheduler.DoctorPatient.PatientId = Guid.Parse(HttpContext.GetIdentifier());
                scheduler.Type = SchedulerType.Scheduler;
            }
            else
            {
                scheduler.DoctorPatient.PatientId = id;
                scheduler.DoctorPatient.DoctorId = Guid.Parse(HttpContext.GetIdentifier());
                scheduler.Type = SchedulerType.Solicitation;
                scheduler.Specialties = specialties.Split(",").ToList();
            }

            return View(scheduler);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(SchedulerModel scheduler)
        {
            if (ModelState.IsValid)
            {
                var schedulervalidator = await schedulerService.CreateAsync(scheduler);
                if (!schedulervalidator.Item1.Any())
                {
                    if (scheduler.Type == SchedulerType.Scheduler)
                    {
                        return RedirectToAction(nameof(DetailScheduler), new { schedulerId = schedulervalidator.Item2 });
                    }
                    else
                    {
                        return RedirectToAction(nameof(DetailSolicitation), new { schedulerId = schedulervalidator.Item2 });
                    }
                }
            }

            return View(scheduler);
        }

        public async Task<IActionResult> DetailScheduler(Guid schedulerId)
        {
            var scheduler = await schedulerService.GetConfirmSchedulerAsync(schedulerId);
            return View(scheduler);
        }

        public async Task<IActionResult> DetailSolicitation(Guid schedulerId)
        {
            var solicitation = await schedulerService.GetConfirmSolicitationAsync(schedulerId);
            return View(solicitation);
        }
    }
}

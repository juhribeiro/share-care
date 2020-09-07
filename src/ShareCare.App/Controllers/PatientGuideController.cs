using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareCare.App.Extensions;
using ShareCare.Model.Interfaces;
using System;
using System.Threading.Tasks;

namespace ShareCare.App.Controllers
{
    [Authorize]
    public class PatientGuideController : Controller
    {
        private readonly IPatientGuideService patientGuideService;

        public PatientGuideController(IPatientGuideService patientGuideService)
        {
            this.patientGuideService = patientGuideService;
        }

        public async Task<IActionResult> Index()
        {
            var identifier = HttpContext.GetIdentifier();
            var patients = await patientGuideService.GetListAsync(identifier);
            return View(patients);
        }

        public IActionResult Details(Guid id)
        {
            //todo analise metrica paciente
            return View();
        }

        public async Task<IActionResult> Historic(Guid id)
        {
            var historic = await patientGuideService.GetHistoricAsync(id);
            return View(historic);
        }
    }
}

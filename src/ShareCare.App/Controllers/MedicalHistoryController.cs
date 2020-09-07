using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareCare.App.Extensions;
using ShareCare.Model.Interfaces;
using System;
using System.Threading.Tasks;

namespace ShareCare.App.Controllers
{
    [Authorize]
    public class MedicalHistoryController : Controller
    {
        private readonly IMedicalHistoryService medicalHistoryService;

        public MedicalHistoryController(IMedicalHistoryService medicalHistoryService)
        {
            this.medicalHistoryService = medicalHistoryService;
        }

        public async Task<IActionResult> Index()
        {
            var id = Guid.Parse(HttpContext.GetIdentifier());
            var medical = await medicalHistoryService.GetMedicallHistoriesAsync(id);
            return View(medical);
        }

        public IActionResult History()
        {
            return View();
        }
    }
}
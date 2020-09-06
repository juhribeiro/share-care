using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareCare.Model.Enums;
using ShareCare.Model.Interfaces;
using System.Threading.Tasks;

namespace ShareCare.App.Controllers
{
    [Authorize]
    public class MedicalGuideController : Controller
    {
        private readonly IMedicalGuideService guideService;

        public MedicalGuideController(IMedicalGuideService guideService)
        {
            this.guideService = guideService;
        }

        public async Task<IActionResult> Index()
        {
            var doctors = await guideService.GetListAsync();
            return View(doctors);
        }
    }
}
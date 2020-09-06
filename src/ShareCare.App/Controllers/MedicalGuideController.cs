using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShareCare.App.Controllers
{
    [Authorize]
    public class MedicalGuideController : Controller
    {
        public MedicalGuideController()
        {

        }

        [ValidateAntiForgeryToken]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SaveSchedule()
        {
            return View();
        }
    }
}
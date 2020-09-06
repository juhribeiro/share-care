using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShareCare.App.Controllers
{
    [Authorize]
    public class MedicalHistoryController : Controller
    {
        public MedicalHistoryController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }
    }
}
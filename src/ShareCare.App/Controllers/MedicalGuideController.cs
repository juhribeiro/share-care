using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ShareCare.App.Controllers
{
    public class MedicalGuideController : Controller
    {
        public MedicalGuideController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }

        public IActionResult SaveSchedule()
        {
            return View();
        }
    }
}
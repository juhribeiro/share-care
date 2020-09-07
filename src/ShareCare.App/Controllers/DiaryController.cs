using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareCare.App.Extensions;
using ShareCare.Model.Interfaces;
using ShareCare.Model.Models;

namespace ShareCare.App.Controllers
{
    [Authorize]
    public class DiaryController : Controller
    {
        private readonly IDiaryService diaryService;

        public DiaryController(IDiaryService diaryService)
        {
            this.diaryService = diaryService;
        }

        public IActionResult Create(string dateTime)
        {

            dateTime = dateTime.Substring(0, dateTime.IndexOf('(') - 1);
            DateTime dt = DateTime.ParseExact(dateTime, "ddd MMM dd yyyy HH:mm:ss 'GMT'K", CultureInfo.InvariantCulture);
            dt.AddHours(3);
            var diary = new DiaryModel();
            diary.DataAnnotation = dt;
            diary.PatientId = Guid.Parse(HttpContext.GetIdentifier());
            return View(diary);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DiaryModel model)
        {
            if (ModelState.IsValid)
            {
                await diaryService.CreateAsync(model);
                return Redirect("~/Home/Index");
            }

            return View(model);
        }
    }
}

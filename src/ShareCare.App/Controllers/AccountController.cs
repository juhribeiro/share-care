using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using ShareCare.App.Extensions;
using ShareCare.App.Models;
using ShareCare.Model.Enums;
using ShareCare.Model.Interfaces;
using ShareCare.Model.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ShareCare.App.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        private readonly ISpecialtyService specialtyService;

        public AccountController(IAccountService accountService, ISpecialtyService specialtyService)
        {
            this.accountService = accountService;
            this.specialtyService = specialtyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var loginvalidation = await accountService.LoginAsync(login);

                if (!loginvalidation.Any())
                {
                    return Redirect("~/Home/Index");
                }

                ModelState.SetModelErrors(loginvalidation);
                return View();
            }

            return View(login);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SelectPersonType selectPersonType)
        {
            if (ModelState.IsValid)
            {
                var availability = await accountService.AvailabilityEmailAsync(selectPersonType.Email, selectPersonType.Type);
                if (!availability.Any())
                {
                    // ou get do google
                    ContactModel contact = new ContactModel
                    {
                        Type = ContactType.Email,
                        Value = selectPersonType.Email,
                    };
                    var phone = new ContactModel { Type = ContactType.Phone };
                    if (selectPersonType.Type == PersonType.Doctor)
                    {
                        var specialities = await specialtyService.GetSpecialtyAsync();
                        var doctormodel = new SimpleDoctorModel
                        {
                            Specialties = specialities,
                            Name = selectPersonType.Name,
                            Password = selectPersonType.Password
                        };

                        doctormodel.Contacts.Add(contact);
                        doctormodel.Contacts.Add(phone);

                        return View(nameof(CreateDoctor), doctormodel);
                    }
                    else
                    {
                        var patientModel = new SimplePatientModel
                        {
                            Name = selectPersonType.Name,
                            Password = selectPersonType.Password
                        };

                        patientModel.Contacts.Add(contact);
                        patientModel.Contacts.Add(phone);
                        return View(nameof(CreatePatient), patientModel);
                    }
                }

                ModelState.SetModelErrors(availability);
            }

            return View(selectPersonType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDoctor(SimpleDoctorModel simpleDoctor)
        {
            if (ModelState.IsValid)
            {
                await accountService.CreateAsync(simpleDoctor);
                return Redirect("~/Home/Index");
            }

            simpleDoctor.Specialties = await specialtyService.GetSpecialtyAsync();
            return View(simpleDoctor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePatient(SimplePatientModel simplePatient)
        {
            if (ModelState.IsValid)
            {
                await accountService.CreateAsync(simplePatient);
                return Redirect("~/Home/Index");
            }

            return View(simplePatient);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return View(nameof(Login));
        }
    }
}
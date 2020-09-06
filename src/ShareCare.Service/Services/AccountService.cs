using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ShareCare.Model.DbModels;
using ShareCare.Model.Hash;
using ShareCare.Model.Interfaces;
using ShareCare.Model.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShareCare.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IBaseRepository<Doctor, SimpleDoctorModel> doctorRepository;
        private readonly IBaseRepository<Patient, SimplePatientModel> patientRepository;
        private readonly IMapper mapper;
        private readonly IBaseRepository<Person, SimplePersonModel> personRepository;

        public AccountService(
            IHttpContextAccessor httpContextAccessor,
            IBaseRepository<Doctor, SimpleDoctorModel> doctorRepository,
            IBaseRepository<Patient, SimplePatientModel> patientRepository,
            IMapper mapper,
             IBaseRepository<Person, SimplePersonModel> personRepository)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.doctorRepository = doctorRepository;
            this.patientRepository = patientRepository;
            this.mapper = mapper;
            this.personRepository = personRepository;
        }

        public async Task<ModelStateDictionary> AvailabilityEmailAsync(string email)
        {
            ModelStateDictionary keyValuePairs = new ModelStateDictionary();
            var personentity = await personRepository.GetByConditionAsync(x => x.Contacts.Any(x => x.Value.Equals(email)));
            if (personentity != null)
            {
                keyValuePairs.AddModelError("Email", "Este email já está cadastrado");
            }

            return keyValuePairs;
        }

        public async Task CreateAsync(SimplePersonModel person)
        {
            var email = person.Contacts.FirstOrDefault(x => x.Type == Model.Enums.ContactType.Email).Value;

            if (person is SimpleDoctorModel doctorModel)
            {
                var doctor = mapper.Map<Doctor>(person);
                await doctorRepository.AddAsync(doctor);
            }
            else
            {
                var patientmodel = person as SimpleDoctorModel;
                var patient = mapper.Map<Patient>(patientmodel);
                await patientRepository.AddAsync(patient);
            }

            var login = new LoginModel
            {
                Email = email,
                Password = person.Password
            };

            await LoginAsync(login);
        }

        public async Task<ModelStateDictionary> LoginAsync(LoginModel login)
        {
            ModelStateDictionary keyValuePairs = new ModelStateDictionary();

            var person = await personRepository.GetByConditionAsync(x => x.Contacts.Any(x => x.Value.Equals(login.Email)));
            if (person is null)
            {
                keyValuePairs.AddModelError("Email", "Email não cadastrado, crie uma conta para poder acessar o site");
                return keyValuePairs;
            }

            string pwd = Cryptography.GetHashString(login.Password);
            if (person.Password.Equals(pwd))
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.Email, login.Email));
                identity.AddClaim(new Claim(ClaimTypes.Name, person.Name));
                identity.AddClaim(new Claim(ClaimTypes.Role, person.Type.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, person.Id.ToString()));
                var principal = new ClaimsPrincipal(identity);
                await httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = true });
            }
            else
            {

                keyValuePairs.AddModelError("Email", "Login ou Senha incorretos");
                keyValuePairs.AddModelError("Password", "Login ou Senha incorretos");
            }

            return keyValuePairs;
        }
    }
}

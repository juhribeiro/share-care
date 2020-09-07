using Microsoft.AspNetCore.Mvc.ModelBinding;
using ShareCare.Model.Enums;
using ShareCare.Model.Models;
using System.Threading.Tasks;

namespace ShareCare.Model.Interfaces
{
    public interface IAccountService
    {
        Task<ModelStateDictionary> LoginAsync(LoginModel login);

        Task CreateAsync(SimplePersonModel person);

        Task<ModelStateDictionary> AvailabilityEmailAsync(string email, PersonType personType);
    }
}

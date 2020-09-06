using Microsoft.AspNetCore.Mvc.ModelBinding;
using ShareCare.Model.Models;
using System.Threading.Tasks;

namespace ShareCare.Model.Interfaces
{
    public interface IAccountService
    {
        Task<ModelStateDictionary> LoginAsync(LoginModel login);

        Task CreateAsync(SimplePersonModel person);

        Task<ModelStateDictionary> AvailabilityEmailAsync(string email);
    }
}

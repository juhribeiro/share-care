using Microsoft.AspNetCore.Mvc.ModelBinding;
using ShareCare.Model.Models;
using System;
using System.Threading.Tasks;

namespace ShareCare.Model.Interfaces
{
    public interface ISchedulerService
    {
        Task<Tuple<ModelStateDictionary, Guid>> CreateAsync(SchedulerModel model);

        Task<ConfirmSchedulerModel> GetConfirmSchedulerAsync(Guid guid);

        Task<ConfirmSolicitationModel> GetConfirmSolicitationAsync(Guid guid);
    }
}

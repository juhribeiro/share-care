using ShareCare.Model.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShareCare.Model.Interfaces
{
    public interface IHomeService
    {
        Task<List<DetailSchedulerModel>> GetDetailSchedulerAsync(Guid doctorId);

        Task<List<DetailSolicitationModel>> GetDetailSolicitationAsync(Guid doctorId);
    }
}

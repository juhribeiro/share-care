using ShareCare.Model.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShareCare.Model.Interfaces
{
    public interface IHomeService
    {
        Task<List<DetailSchedulerModel>> GetDetailSchedulerAsync(Guid patientId);

        Task<List<DetailSolicitationModel>> GetDetailSolicitationAsync(Guid doctorId);

        Task<List<DiaryModel>> GetDiaryAsync(Guid patientId);
    }
}

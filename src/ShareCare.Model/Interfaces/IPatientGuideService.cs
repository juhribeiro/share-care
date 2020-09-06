using ShareCare.Model.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShareCare.Model.Interfaces
{
    public interface IPatientGuideService
    {
        Task<List<SimplePatientModel>> GetListAsync(string doctorId);


        Task<List<EnchiridionModel>> GetHistoricAsync(Guid patientId);
    }
}

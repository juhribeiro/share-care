using ShareCare.Model.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShareCare.Model.Interfaces
{
    public interface IMedicalHistoryService
    {
        Task<IEnumerable<EnchiridionDoctorModel>> GetMedicallHistoriesAsync(Guid id);
    }
}

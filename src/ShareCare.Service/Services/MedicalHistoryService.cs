using ShareCare.Model.DbModels;
using ShareCare.Model.Interfaces;
using ShareCare.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareCare.Service.Services
{
    public class MedicalHistoryService : IMedicalHistoryService
    {
        private readonly IBaseRepository<Scheduler, EnchiridionDoctorModel> enchiridionRepository;

        public MedicalHistoryService(IBaseRepository<Scheduler, EnchiridionDoctorModel> enchiridionRepository)
        {
            this.enchiridionRepository = enchiridionRepository;
        }

        public async Task<IEnumerable<EnchiridionDoctorModel>> GetMedicallHistoriesAsync(Guid id)
        {
            return await enchiridionRepository.ListByConditionAsync(x => x.DoctorPatient.Patient.Id.Equals(id) && x.Enchiridions.Any());
        }
    }
}

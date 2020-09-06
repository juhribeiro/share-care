using ShareCare.Model.DbModels;
using ShareCare.Model.Interfaces;
using ShareCare.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareCare.Service.Services
{
    public class PatientGuideService : IPatientGuideService
    {
        private readonly IBaseRepository<Patient, SimplePatientModel> patientRepository;
        private readonly IBaseRepository<Enchiridion, EnchiridionModel> enchiridionRepository;

        public PatientGuideService(IBaseRepository<Patient, SimplePatientModel> patientRepository,
            IBaseRepository<Enchiridion, EnchiridionModel> enchiridionRepository)
        {
            this.patientRepository = patientRepository;
            this.enchiridionRepository = enchiridionRepository;
        }

        public async Task<List<EnchiridionModel>> GetHistoricAsync(Guid patientId)
        {
            return await enchiridionRepository.ListByConditionAsync(x => x.Scheduler.DoctorPatient.Patient.Id.Equals(patientId));
        }

        public async Task<List<SimplePatientModel>> GetListAsync(string doctorId)
        {
            var id = Guid.Parse(doctorId);
            var patients = await patientRepository.ListByConditionAsync(x => x.DoctorPatients.Any(x => x.Doctor.Id.Equals(id)));
            patients.ForEach(x => x.Password = string.Empty);
            
            return patients;
        }
    }
}
